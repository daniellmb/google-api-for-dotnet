cls

Import-Module '..\tool\psake\psake.psm1'
Invoke-psake '.\build.ps1' Test -framework 3.5
Remove-Module psake