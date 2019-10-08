Remove-Item ".\bin\" -Force -Recurse
New-Item ".\bin\scratch\x64\" -ItemType Directory -Force
New-Item ".\bin\scratch\x86\" -ItemType Directory -Force
Expand-Archive -Path "..\USMT\x64.zip" -DestinationPath ".\bin\scratch\x64\usmt\" -Force
Expand-Archive -Path "..\USMT\x86.zip" -DestinationPath ".\bin\scratch\x86\usmt\" -Force