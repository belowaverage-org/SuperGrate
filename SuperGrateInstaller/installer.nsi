!define NAME "Super Grate"
!define VERSION "1.2.0.0"
!include x64.nsh
!include "MUI2.nsh"
Name "${NAME}"
OutFile ".\bin\SuperGrateInstaller.exe"

VIAddVersionKey "ProductName" "${NAME}"
VIAddVersionKey "LegalTrademarks" "Super Suite"
VIAddVersionKey "LegalCopyright" "(C) Dylan Bickerstaff"
VIAddVersionKey "FileDescription" "${NAME} - Installer"
VIAddVersionKey "FileVersion" "${VERSION}"
VIProductVersion "${VERSION}"

!define MUI_ICON "..\SuperGrate\Images\supergrate.ico"
!define MUI_HEADERIMAGE
!define MUI_HEADERIMAGE_BITMAP ".\header.bmp"
!define MUI_WELCOMEFINISHPAGE_BITMAP ".\welcome.bmp"
!define MUI_UNWELCOMEFINISHPAGE_BITMAP ".\welcome.bmp"
!define MUI_WELCOMEPAGE_TITLE_3LINES
!define MUI_WELCOMEPAGE_TEXT "${NAME} setup will guide you through the installation process.$\r$\n$\r$\n$\r$\nPress Next to continue."
!define MUI_FINISHPAGE_NOAUTOCLOSE
!define MUI_UNFINISHPAGE_NOAUTOCLOSE

InstallDir "$PROGRAMFILES64\Super Suite\Super Grate"

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_PAGE_INSTFILES 
!insertmacro MUI_UNPAGE_INSTFILES 
!insertmacro MUI_PAGE_FINISH
!insertmacro MUI_UNPAGE_FINISH

!insertmacro MUI_LANGUAGE "English"

Section "!${NAME}"

SetShellVarContext all

WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" "DisplayName" "${NAME}"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" "UninstallString" "$INSTDIR\Uninstall.exe"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" "Publisher" "Dylan Bickerstaff"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" "DisplayVersion" "${VERSION}"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" "DisplayIcon" "$INSTDIR\SuperGrate.exe"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" "Comments" "Super Grate"

SetOutPath "$INSTDIR"

${If} ${RunningX64}
	File "..\SuperGrate\bin\Release_64\SuperGrate.exe"
${Else}
    File "..\SuperGrate\bin\Release\SuperGrate.exe"
${EndIf}  

WriteUninstaller "$INSTDIR\Uninstall.exe"

CreateDirectory "$SMPROGRAMS\Super Suite"
CreateShortcut "$SMPROGRAMS\Super Suite\Super Grate.lnk" "$INSTDIR\SuperGrate.exe"

SectionEnd



Section "USMT 64-Bit"

SetOutPath "$INSTDIR\USMT\X64"
File /r ".\bin\scratch\x64\usmt\*.*"

SectionEnd



Section "USMT 32-Bit"

SetOutPath "$INSTDIR\USMT\X86"
File /r ".\bin\scratch\x86\usmt\*.*"

SectionEnd



Section "Uninstall"

SetShellVarContext all

RMDir /r "$INSTDIR\USMT"
RMDir /r "$INSTDIR\STORE"
Delete "$INSTDIR\SuperGrate.xml"
Delete "$INSTDIR\SuperGrate.exe"
Delete "$INSTDIR\Uninstall.exe"
Delete "$SMPROGRAMS\Super Suite\Super Grate.lnk"
RMDir "$SMPROGRAMS\Super Suite" 
RMDir "$INSTDIR"
DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}"

SectionEnd