param([string]$NSIPath, [string]$Version)
$lines = Get-Content $NSIPath
$result = @()
foreach ($line in $lines) {
    if ($line -match '^\s*!define\s+APP_VERSION') {
        $result += "!define APP_VERSION     `"$Version`""
    } elseif ($line -match '^\s*!define\s+OUTPUT_FILE') {
        $result += "!define OUTPUT_FILE     `"..\LyhykaMotorbike_AN68_Setup_v$Version.exe`""
    } else {
        $result += $line
    }
}
$result | Set-Content $NSIPath -Encoding ASCII
