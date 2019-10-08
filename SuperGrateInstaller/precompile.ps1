Remove-Item ".\bin\" -Force -Recurse
New-Item ".\bin\scratch\x64\" -ItemType Directory -Force
New-Item ".\bin\scratch\x86\" -ItemType Directory -Force
Invoke-WebRequest -Uri "https://github.com/belowaverage-org/SuperGrate/raw/master/USMT/x64.zip" -OutFile ".\bin\scratch\x64\usmt.zip"
Invoke-WebRequest -Uri "https://github.com/belowaverage-org/SuperGrate/raw/master/USMT/x86.zip" -OutFile ".\bin\scratch\x86\usmt.zip"
Expand-Archive -Path ".\bin\scratch\x64\usmt.zip" -DestinationPath ".\bin\scratch\x64\usmt\" -Force
Expand-Archive -Path ".\bin\scratch\x86\usmt.zip" -DestinationPath ".\bin\scratch\x86\usmt\" -Force