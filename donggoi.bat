@echo off
setlocal enabledelayedexpansion

:: ============================================================
:: donggoi.bat - Build and Package Lyhyka Motorbike AN68
:: Usage: donggoi.bat [version]
:: Example: donggoi.bat 05.01.26.01
:: ============================================================

set "PROJECT_DIR=%~dp0"
set "MSBUILD=C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe"
set "NSIS=C:\Program Files (x86)\NSIS\makensis.exe"
set "NSI_SCRIPT=%PROJECT_DIR%Installer\LyhykaSetup.nsi"
set "UPDATE_PS1=%PROJECT_DIR%Installer\update_version.ps1"

cd /d "%PROJECT_DIR%"

if "%~1"=="" (
    set /p VERSION="Nhap version (vd: 05.01.26.01): "
) else (
    set "VERSION=%~1"
)

if "%VERSION%"=="" (
    echo [ERROR] Version is empty!
    pause
    exit /b 1
)

set "OUTPUT_EXE=%PROJECT_DIR%LyhykaMotorbike_AN68_Setup_v%VERSION%.exe"

echo.
echo ========================================
echo   DONG GOI LYHYKA MOTORBIKE AN68 v%VERSION%
echo ========================================
echo.

echo [1/4] Update version in LyhykaSetup.nsi...
powershell -NoProfile -ExecutionPolicy Bypass -File "%UPDATE_PS1%" -NSIPath "%NSI_SCRIPT%" -Version "%VERSION%"
if errorlevel 1 (
    echo [ERROR] Cannot update version!
    pause
    exit /b 1
)
echo [OK] Version updated!
echo.

echo [2/4] Build Release...
"%MSBUILD%" Lyhyka.sln /p:Configuration=Release /t:Rebuild /v:minimal
if errorlevel 1 (
    echo.
    echo [ERROR] Build FAILED!
    pause
    exit /b 1
)
echo.
echo [OK] Build OK!
echo.

echo [3/4] Create installer...
"%NSIS%" "%NSI_SCRIPT%"
if errorlevel 1 (
    echo.
    echo [ERROR] NSIS FAILED!
    pause
    exit /b 1
)
echo.
echo [OK] Installer created!
echo.

echo [4/4] Remove old files...
for %%f in ("%PROJECT_DIR%LyhykaMotorbike_AN68_Setup_v*.exe") do (
    if /i not "%%~nxf"=="LyhykaMotorbike_AN68_Setup_v%VERSION%.exe" (
        echo   Del: %%~nxf
        del "%%f" /f /q
    )
)
echo [OK] Done!
echo.

echo ========================================
echo   SUCCESS!
echo   File: LyhykaMotorbike_AN68_Setup_v%VERSION%.exe
echo ========================================
echo.
pause
