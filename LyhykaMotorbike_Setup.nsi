; NSIS Installer Script for Lyhyka Motorbike AN68
; Compile: makensis /DAPP_VERSION="04.22.26.01" LyhykaMotorbike_Setup.nsi

!define APPNAME "Lyhyka Motorbike AN68"
!define COMPANYNAME "Lyhyka"
!define APPEXE "AN68.exe"
!define SOURCEDIR "Lyhyka\bin\Debug"

; Version được truyền từ donggoi.bat qua /DAPP_VERSION="..."
!ifndef APP_VERSION
    !define APP_VERSION "0.0.0"
!endif

Name "${APPNAME} v${APP_VERSION}"
OutFile "Output\LyhykaMotorbike_AN68_Setup_v${APP_VERSION}.exe"
; Cài vào LocalAppData thay vì Program Files - không cần admin để chạy app
InstallDir "$LOCALAPPDATA\${APPNAME}"
; Installer vẫn cần admin để viết registry Add/Remove Programs
RequestExecutionLevel admin

; UI
!include "MUI2.nsh"
!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_LANGUAGE "English"

Section "Install"
    SetOutPath "$INSTDIR"
    
    ; Main executable and config
    File "${SOURCEDIR}\AN68.exe"
    File "${SOURCEDIR}\AN68.exe.config"
    
    ; Database files (only if not exist - preserve existing data)
    SetOverwrite off
    File "${SOURCEDIR}\Motobike.db"
    IfFileExists "${SOURCEDIR}\Motobike-oto.db" 0 +2
        File "${SOURCEDIR}\Motobike-oto.db"
    SetOverwrite on
    
    ; Core DLLs
    File "${SOURCEDIR}\Lyhyka.DBCore.dll"
    File /nonfatal "${SOURCEDIR}\Lyhyka.DBCore.dll.config"
    
    ; DevExpress DLLs
    File /nonfatal "${SOURCEDIR}\DevExpress.*.dll"
    
    ; Entity Framework
    File "${SOURCEDIR}\EntityFramework.dll"
    File "${SOURCEDIR}\EntityFramework.SqlServer.dll"
    
    ; SQLite
    File "${SOURCEDIR}\System.Data.SQLite.dll"
    File "${SOURCEDIR}\System.Data.SQLite.EF6.dll"
    File "${SOURCEDIR}\System.Data.SQLite.Linq.dll"
    
    ; Microsoft ReportViewer
    File /nonfatal "${SOURCEDIR}\Microsoft.ReportViewer.*.dll"
    
    ; Microsoft SqlServer Types
    File /nonfatal "${SOURCEDIR}\Microsoft.SqlServer.Types.dll"
    
    ; PDF Viewer
    File /nonfatal "${SOURCEDIR}\PdfiumViewer.dll"
    
    ; Newtonsoft JSON
    File /nonfatal "${SOURCEDIR}\Newtonsoft.Json.dll"
    
    ; Microsoft Extensions
    File /nonfatal "${SOURCEDIR}\Microsoft.Extensions.*.dll"
    File /nonfatal "${SOURCEDIR}\Microsoft.Bcl.*.dll"
    
    ; System libraries
    File /nonfatal "${SOURCEDIR}\System.Buffers.dll"
    File /nonfatal "${SOURCEDIR}\System.Configuration.ConfigurationManager.dll"
    File /nonfatal "${SOURCEDIR}\System.Diagnostics.DiagnosticSource.dll"
    File /nonfatal "${SOURCEDIR}\System.Drawing.Common.dll"
    File /nonfatal "${SOURCEDIR}\System.Formats.Asn1.dll"
    File /nonfatal "${SOURCEDIR}\System.IO.Pipelines.dll"
    File /nonfatal "${SOURCEDIR}\System.Memory.dll"
    File /nonfatal "${SOURCEDIR}\System.Net.Http.WinHttpHandler.dll"
    File /nonfatal "${SOURCEDIR}\System.Numerics.Vectors.dll"
    File /nonfatal "${SOURCEDIR}\System.Runtime.CompilerServices.Unsafe.dll"
    File /nonfatal "${SOURCEDIR}\System.Security.*.dll"
    File /nonfatal "${SOURCEDIR}\System.Text.*.dll"
    File /nonfatal "${SOURCEDIR}\System.Threading.Tasks.Extensions.dll"
    File /nonfatal "${SOURCEDIR}\System.ValueTuple.dll"
    File /nonfatal "${SOURCEDIR}\stdole.dll"
    File /nonfatal "${SOURCEDIR}\EnvDTE.dll"
    
    ; Native DLLs (x86/x64)
    SetOutPath "$INSTDIR\x86"
    File /nonfatal /r "${SOURCEDIR}\x86\*.*"
    SetOutPath "$INSTDIR\x64"
    File /nonfatal /r "${SOURCEDIR}\x64\*.*"
    
    ; Reports
    SetOutPath "$INSTDIR\Reports"
    File /nonfatal /r "${SOURCEDIR}\Reports\*.*"
    
    SetOutPath "$INSTDIR"
    
    ; Cấp full quyền cho thư mục cài đặt (để user ghi DB file)
    nsExec::ExecToLog 'icacls "$INSTDIR" /grant *S-1-5-32-545:(OI)(CI)F /T'
    
    ; Create shortcuts
    CreateDirectory "$SMPROGRAMS\${APPNAME}"
    CreateShortCut "$SMPROGRAMS\${APPNAME}\${APPNAME}.lnk" "$INSTDIR\${APPEXE}"
    CreateShortCut "$SMPROGRAMS\${APPNAME}\Uninstall.lnk" "$INSTDIR\uninstall.exe"
    CreateShortCut "$DESKTOP\${APPNAME}.lnk" "$INSTDIR\${APPEXE}"
    
    ; Write uninstaller
    WriteUninstaller "$INSTDIR\uninstall.exe"
    
    ; Add/Remove Programs registry
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "DisplayName" "${APPNAME}"
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "UninstallString" "$\"$INSTDIR\uninstall.exe$\""
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "Publisher" "${COMPANYNAME}"
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}" "DisplayVersion" "${APP_VERSION}"
SectionEnd

Section "Uninstall"
    ; Remove shortcuts
    Delete "$DESKTOP\${APPNAME}.lnk"
    RMDir /r "$SMPROGRAMS\${APPNAME}"
    
    ; Remove files
    RMDir /r "$INSTDIR"
    
    ; Remove registry
    DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APPNAME}"
SectionEnd
