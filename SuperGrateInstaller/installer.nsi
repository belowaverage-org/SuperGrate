!define NAME "Super Grate"
!define VERSION "1.2.0.0"
!include "MUI2.nsh"
Name "${NAME}"
OutFile ".\bin\SuperGrateInstaller.exe"

!define MUI_ICON "..\SuperGrate\Images\supergrate.ico"
!define MUI_HEADERIMAGE
!define MUI_HEADERIMAGE_BITMAP ".\header.bmp"
!define MUI_WELCOMEFINISHPAGE_BITMAP ".\welcome.bmp"

!define MUI_WELCOMEPAGE_TITLE_3LINES
!define MUI_WELCOMEPAGE_TEXT "${NAME} setup will guide you through the installation process.$\r$\n$\r$\n$\r$\nPress Next to continue."

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_COMPONENTS 
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_PAGE_INSTFILES 
!insertmacro MUI_PAGE_FINISH 

!insertmacro MUI_LANGUAGE "English"

Section "Install ${NAME}"

File "..\SuperGrate\bin\Release\SuperGrate.exe"

SectionEnd

Section "Uninstall"

SectionEnd