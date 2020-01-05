!define NAME "Super Grate"
!define NAME2 "SuperGrate"
!define VERSION "1.3.0.0"
!include x64.nsh
!include "MUI2.nsh"
Name "${NAME}"
OutFile ".\bin\${NAME2}Installer.exe"
BrandingText "Dylan Bickerstaff (C) 2020 - Super Suite - ${NAME} - v${VERSION}"

VIAddVersionKey "ProductName" "${NAME}"
VIAddVersionKey "LegalTrademarks" "Super Suite"
VIAddVersionKey "LegalCopyright" "(C) Dylan Bickerstaff"
VIAddVersionKey "FileDescription" "${NAME} - Installer"
VIAddVersionKey "FileVersion" "${VERSION}"
VIProductVersion "${VERSION}"

!define MUI_ICON "..\${NAME2}\Images\supergrate.ico"
!define MUI_UNICON "..\${NAME2}\Images\supergrate.ico"
!define MUI_HEADERIMAGE
!define MUI_HEADERIMAGE_BITMAP ".\header.bmp"
!define MUI_WELCOMEFINISHPAGE_BITMAP ".\welcome.bmp"
!define MUI_UNWELCOMEFINISHPAGE_BITMAP ".\welcome.bmp"
!define MUI_COMPONENTSPAGE_CHECKBITMAP ".\checks.bmp"
!define MUI_WELCOMEPAGE_TITLE_3LINES
!define MUI_WELCOMEPAGE_TEXT "${NAME} setup will guide you through the installation process.$\r$\n$\r$\n$\r$\nPress Next to continue."
!define MUI_FINISHPAGE_NOAUTOCLOSE
!define MUI_UNFINISHPAGE_NOAUTOCLOSE
!define MUI_FINISHPAGE_LINK "${NAME} - GitHub"
!define MUI_FINISHPAGE_LINK_LOCATION "https://github.com/belowaverage-org/${NAME2}"

InstallDir "$PROGRAMFILES64\Super Suite\${NAME}"

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_LICENSE "..\license"
!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_PAGE_INSTFILES 
!insertmacro MUI_UNPAGE_INSTFILES 
!insertmacro MUI_PAGE_FINISH
!insertmacro MUI_UNPAGE_FINISH

!insertmacro MUI_LANGUAGE "English"

Section "!${NAME}" SuperGrate

SectionIn RO

SetShellVarContext all

SetOutPath "$INSTDIR"

${If} ${RunningX64}
	File "..\${NAME2}\bin\Release_64\${NAME2}.exe"
${Else}
    File "..\${NAME2}\bin\Release\${NAME2}.exe"
${EndIf}  



SectionEnd



Section "USMT 64-Bit" USMT64

SetOutPath "$INSTDIR\USMT\X64"
File /r ".\bin\scratch\x64\usmt\*.*"

SectionEnd



Section "USMT 32-Bit" USMT32

SetOutPath "$INSTDIR\USMT\X86"
File /r ".\bin\scratch\x86\usmt\*.*"

SectionEnd



Section "Shortcut - Start Menu" SMSC

SetOutPath "$INSTDIR"
CreateDirectory "$SMPROGRAMS\Super Suite"
CreateShortcut "$SMPROGRAMS\Super Suite\${NAME}.lnk" "$INSTDIR\${NAME2}.exe"

SectionEnd



Section /o "Shortcut - Desktop" DTSC

SetOutPath "$INSTDIR"
CreateShortcut "$DESKTOP\${NAME}.lnk" "$INSTDIR\${NAME2}.exe"

SectionEnd



Section "Uninstaller" Uninst

SetShellVarContext all

SetOutPath "$INSTDIR"

WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" "DisplayName" "${NAME}"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" "UninstallString" "$INSTDIR\uninstall.exe"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" "Publisher" "Dylan Bickerstaff"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" "DisplayVersion" "${VERSION}"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" "DisplayIcon" "$INSTDIR\${NAME2}.exe"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" "Comments" "${NAME}"

WriteUninstaller "$INSTDIR\uninstall.exe"

SectionEnd



Section "Uninstall"

SetShellVarContext all

RMDir /r "$INSTDIR"
Delete "$SMPROGRAMS\Super Suite\${NAME}.lnk"
Delete "$DESKTOP\${NAME}.lnk"
RMDir "$SMPROGRAMS\Super Suite"
RMDir "$INSTDIR"
RMDir "$INSTDIR\..\"
DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}"

SectionEnd



!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
  !insertmacro MUI_DESCRIPTION_TEXT ${Application} "This item installs the ${NAME} program."
  !insertmacro MUI_DESCRIPTION_TEXT ${USMT64} "This item installs the 64-Bit version of USMT."
  !insertmacro MUI_DESCRIPTION_TEXT ${USMT32} "This item installs the 32-Bit version of USMT."
  !insertmacro MUI_DESCRIPTION_TEXT ${SMSC} "This item places a shortcut in the start menu."
  !insertmacro MUI_DESCRIPTION_TEXT ${DTSC} "This item places a shortcut on the desktop."
  !insertmacro MUI_DESCRIPTION_TEXT ${Uninst} "This item installs an Uninstaller so that ${NAME} can be removed in the future."
!insertmacro MUI_FUNCTION_DESCRIPTION_END