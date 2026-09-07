; ============================================================
; NSIS Script - Lyhyka Motorbike AN68 Setup
; ============================================================

Unicode True

; ---------- Thong tin chung ----------
!define APP_NAME        "Lyhyka Motorbike AN68"
!define APP_VERSION     "09.03.26.01"
!define APP_PUBLISHER   "Lyhyka"
!define APP_EXE         "AN68.exe"
!define INSTALL_DIR     "$PROGRAMFILES\Lyhyka\Motorbike_AN68"
!define REG_KEY         "Software\Microsoft\Windows\CurrentVersion\Uninstall\LyhykaMotorbikeAN68"
!define OUTPUT_FILE     "..\LyhykaMotorbike_AN68_Setup_v09.03.26.01.exe"
!define SOURCE_DIR      "..\Lyhyka\bin\Release"
!define APP_ICON        "..\Lyhyka\AN68.ico"

; ---------- Cau hinh installer ----------
Name "${APP_NAME} ${APP_VERSION}"
OutFile "${OUTPUT_FILE}"
InstallDir "${INSTALL_DIR}"
InstallDirRegKey HKCU "${REG_KEY}" "InstallLocation"
RequestExecutionLevel user
SetCompressor /SOLID lzma
SetCompressorDictSize 32

; ---------- Giao dien ----------
!include "MUI2.nsh"
!define MUI_ABORTWARNING
!define MUI_ICON    "${APP_ICON}"
!define MUI_UNICON  "${APP_ICON}"

; Cac trang cai dat
!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

; Cac trang go cai dat
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES

; Ngon ngu
!insertmacro MUI_LANGUAGE "Vietnamese"
!insertmacro MUI_LANGUAGE "English"

; ---------- Section cai dat ----------
Section "Cai dat chinh" SecMain

    SetOutPath "$INSTDIR"

    ; Copy toan bo file tu Release
    File /r "${SOURCE_DIR}\*.*"

    ; Tao shortcut Start Menu
    CreateDirectory "$SMPROGRAMS\${APP_NAME}"
    CreateShortCut "$SMPROGRAMS\${APP_NAME}\${APP_NAME}.lnk" \
        "$INSTDIR\${APP_EXE}" "" "$INSTDIR\${APP_EXE}" 0
    CreateShortCut "$SMPROGRAMS\${APP_NAME}\Go cai dat.lnk" \
        "$INSTDIR\Uninstall.exe" "" "$INSTDIR\Uninstall.exe" 0

    ; Tao shortcut Desktop
    CreateShortCut "$DESKTOP\${APP_NAME}.lnk" \
        "$INSTDIR\${APP_EXE}" "" "$INSTDIR\${APP_EXE}" 0

    ; Ghi registry de ho tro Add/Remove Programs cho user hien tai
    WriteRegStr   HKCU "${REG_KEY}" "DisplayName"      "${APP_NAME}"
    WriteRegStr   HKCU "${REG_KEY}" "DisplayVersion"   "${APP_VERSION}"
    WriteRegStr   HKCU "${REG_KEY}" "Publisher"        "${APP_PUBLISHER}"
    WriteRegStr   HKCU "${REG_KEY}" "InstallLocation"  "$INSTDIR"
    WriteRegStr   HKCU "${REG_KEY}" "UninstallString"  '"$INSTDIR\Uninstall.exe"'
    WriteRegStr   HKCU "${REG_KEY}" "DisplayIcon"      "$INSTDIR\${APP_EXE}"
    WriteRegDWORD HKCU "${REG_KEY}" "NoModify"         1
    WriteRegDWORD HKCU "${REG_KEY}" "NoRepair"         1

    ; Tao bo go cai dat
    WriteUninstaller "$INSTDIR\Uninstall.exe"

SectionEnd

; ---------- Section go cai dat ----------
Section "Uninstall"

    ; Xoa shortcut
    Delete "$DESKTOP\${APP_NAME}.lnk"
    Delete "$SMPROGRAMS\${APP_NAME}\${APP_NAME}.lnk"
    Delete "$SMPROGRAMS\${APP_NAME}\Go cai dat.lnk"
    RMDir  "$SMPROGRAMS\${APP_NAME}"

    ; Xoa thu muc cai dat
    Delete "$INSTDIR\Uninstall.exe"
    RMDir /r "$INSTDIR"

    ; Xoa registry
    DeleteRegKey HKCU "${REG_KEY}"

SectionEnd
