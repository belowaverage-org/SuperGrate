New-Item ".\bin\scratch\" -ItemType Directory
Copy-Item "..\SuperGrate\bin\Release\SuperGrate.exe" ".\bin\scratch\SuperGrateX86.exe"
Copy-Item "..\SuperGrate\bin\Release_64\SuperGrate.exe" ".\bin\scratch\SuperGrateX64.exe"