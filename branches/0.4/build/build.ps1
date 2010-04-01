properties { 
  $zipFilePostfix = "_0.4_alpha.zip"
  $signAssemblies = $true
  $buildDocumentation = $true
  
  $baseDir  = resolve-path ..
  $buildDir = "$baseDir\build"
  $sourceDir = "$baseDir\src"
  $toolDir = "$baseDir\tool"
  $docDir = "$baseDir\doc"
  $releaseDir = "$baseDir\release"
  $workingDir = "$baseDir\working"
  $signKeyPath = "$sourceDir\GoogleAPI.snk"
  $names = @{Solution = "GoogleAPI"; Core = "Core"; Search = "GoogleSearchAPI"; Translate = "GoogleTranslateAPI"; TestsPostfix = ".Tests"}
  $builds = @(
    @{Postfix = ".Silverlight"; Constants="SILVERLIGHT"; FinalDir="Silverlight"},
    @{Postfix = ".Compact"; Constants="PocketPC"; FinalDir="Compact"},
    @{Postfix = ".Net20"; Constants="NET20"; FinalDir="DotNet20"},
    @{Postfix = ""; Constants=""; FinalDir="DotNet"}
  )
} 

task default -depends Test

# Ensure a clean working directory
task Clean {
  Set-Location $baseDir
  
  if (Test-Path -path $workingDir)
  {
    Write-Output "Deleting Working Directory"
    
    del $workingDir -Recurse -Force
  }
  
  New-Item -Path $workingDir -ItemType Directory
}

# Build each solution, optionally signed
task Build -depends Clean { 
  
  foreach ($build in $builds)
  {
    $name = $names.Solution + $build.Postfix
    $finalDir = $build.FinalDir

    Write-Host -ForegroundColor Green "Building " $name
    Write-Host
    exec { msbuild "/t:Clean;Rebuild" /p:Configuration=Release /p:OutputPath=bin\Release\$finalDir\ /p:AssemblyOriginatorKeyFile=$signKeyPath /p:SignAssembly=$signAssemblies (GetConstants $build.Constants $signAssemblies) .\src\$name.sln } "Error building $name"
  }
}

# Merge
task Merge -depends Build {
  foreach ($name in ($names.Translate, $names.Search))
  {
    foreach ($build in $builds)
    {
      $binaryDir = "$sourceDir\" + $name + "\bin\release\" + $build.FinalDir
  	  MergeAndDelete $binaryDir ($name + $build.Postfix) ($names.Core + $build.Postfix)
    }
  }
}

# Optional build documentation, add files to final zip
task Package -depends Merge {
  foreach ($name in ($names.Translate, $names.Search))
  {
    foreach ($build in $builds)
    {
      $finalDir = $build.FinalDir
    
      Copy-Item -Path $sourceDir\$name\bin\release\$finalDir -Destination $workingDir\package\$name\bin\$finalDir -recurse
    }
	
	if ($buildDocumentation)
    {
      exec { msbuild "/t:Clean;Rebuild" /p:Configuration=Release "/p:DocumentationSourcePath=$workingDir\package\$name\bin\DotNet" "/p:OutputPath=$workingDir\Documentation\$name\" $docDir\$name.shfbproj } "Error building documentation. Check that you have Sandcastle, Sandcastle Help File Builder and HTML Help Workshop installed."
    
      move -Path $workingDir\Documentation\$name\Documentation.chm -Destination $workingDir\Package\$name\Documentation.chm
      move -Path $workingDir\Documentation\$name\LastBuild.log -Destination $workingDir\$name.Documentation.log
    }
	
	Copy-Item -Path $docDir\$name.readme.txt -Destination $workingDir\package\$name
	Rename-Item -Path $workingDir\package\$name\$name.readme.txt -NewName readme.txt
	
	$zipFileName = $name + $zipFilePostfix
	
	exec { .\tool\7-zip\7za.exe a -tzip $workingDir\$zipFileName $workingDir\package\$name\* } "Error zipping"
  }
}

# Unzip package to a location
task Deploy -depends Package {
  foreach ($name in ($names.Translate, $names.Search))
  {
	$zipFileName = $name + $zipFilePostfix

	exec { .\tool\7-zip\7za.exe x -y "-o$workingDir\deployed\$name\" $workingDir\$zipFileName } "Error unzipping"
  }
}

# Run tests on deployed files
task Test -depends Deploy {
  foreach ($name in ($names.Translate, $names.Search))
  {
    foreach ($build in $builds)
    {
#	  Trap {Write-Host -ForegroundColor Red "$($_.Exception.Message)"; Write-Host; Continue}
	
	  $testsDir = $name + $names.TestsPostfix
      $testsname = $name + $names.TestsPostfix + $build.Postfix
      $finalDir = $build.FinalDir
    
      Write-Host -ForegroundColor Green "Copying test assembly $name to deployed directory"
      Write-Host
	  
	  Copy-Item -Path $sourceDir\$testsDir\bin\release\$finalDir -Destination $workingDir\deployed\$name\test\$finalDir -Recurse

      Write-Host -ForegroundColor Green "Running tests " $testsname
      Write-Host

      exec { .\tool\NUnit\nunit-console.exe $workingDir\deployed\$name\test\$finalDir\$testsname.dll /xml:$workingDir\$testsname.xml /out:$workingDir\$testsname.NUnitLog.txt /labels } "Error running $testsname"
    }
  }
}

function MergeAssembly($dllPrimaryAssembly, $signKey, [string[]]$mergedAssemlies)
{
  $primary = Get-Item $dllPrimaryAssembly
  $mergedAssemblyName = $primary.Name
  $temporaryDir = $primary.DirectoryName + "\" + [Guid]::NewGuid().ToString()
  New-Item $temporaryDir -ItemType Directory
  
  try
  {
    if ($dllPrimaryAssembly.Contains("Silverlight"))
	{
	  $programFilesDir = "C:\Program Files (x86)"
	  if (!(Test-Path $programFilesDir))
	  {
	    $programFilesDir = "C:\Program Files"
	  }
	  $libDir = "$programFilesDir\Reference Assemblies\Microsoft\Framework\Silverlight\v3.0"
	  exec { .\tool\ILMerge\ilmerge.exe "/targetplatform:v2,$libDir" "/lib:$libDir" "/internalize" "/closed" "/log:$workingDir\$mergedAssemblyName.MergeLog.txt" $ilMergeKeyFile "/out:$temporaryDir\$mergedAssemblyName" $dllPrimaryAssembly $mergedAssemlies } "Error executing ILMerge"
	}
	else
	{
      exec { .\tool\ILMerge\ilmerge.exe "/internalize" "/closed" "/log:$workingDir\$mergedAssemblyName.MergeLog.txt" $ilMergeKeyFile "/out:$temporaryDir\$mergedAssemblyName" $dllPrimaryAssembly $mergedAssemlies } "Error executing ILMerge"
    }
    Copy-Item -Path $temporaryDir\$mergedAssemblyName -Destination $dllPrimaryAssembly -Force
  }
  finally
  {
    Remove-Item $temporaryDir -Recurse -Force
  }
}

function GetConstants($constants, $includeSigned)
{
  $signed = switch($includeSigned) { $true { ";SIGNED" } default { "" } }

  return "/p:DefineConstants=`"TRACE;$constants$signed`""
}

function SelectFormat([string[]]$assemblies, [string]$format)
{
  $assemblydlls = @()
  foreach($assembly in $assemblies)
  {
    $assemblydlls += ($format -f $assembly)
  }
  
  return $assemblydlls
}

function MergeAndDelete([string]$dir, [string]$primary, [string[]]$merged)
{
  if (Test-Path ("$dir\" + "LinqBridge.dll"))
  {
    $merged += "LinqBridge"
  }
  
  MergeAssembly "$dir\$primary.dll" $signKeyPath (SelectFormat $merged "$dir\{0}.dll")
  
  del (SelectFormat $merged "$dir\{0}.*")
}