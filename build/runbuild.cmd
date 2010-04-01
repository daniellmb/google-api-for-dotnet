powershell -Command "& {Import-Module ..\tool\psake\psake.psm1; Invoke-psake .\build.ps1 %*}"
pause