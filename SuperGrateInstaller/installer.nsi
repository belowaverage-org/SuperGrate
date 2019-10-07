!define VERSION "1.2.0.0"
!include "MUI2.nsh"
Name "Super Grate - v${VERSION}"
OutFile "SuperGrate - v${VERSION}.exe"

!define MUI_WELCOMEFINISHPAGE_BITMAP  ".\welcome.bmp"

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_LICENSE ".\lisc.txt"
!insertmacro MUI_PAGE_COMPONENTS 
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_PAGE_INSTFILES 
!insertmacro MUI_PAGE_FINISH 

!insertmacro MUI_LANGUAGE "English"

Section "Install SuperGrate"

SectionEnd

Section "Uninstall"

SectionEnd