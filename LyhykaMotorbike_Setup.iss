; Inno Setup Script for Lyhyka Motorbike (AN68)
; Build: Open this file in Inno Setup Compiler and click Build

#define MyAppName "Lyhyka Motorbike AN68"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Lyhyka"
#define MyAppExeName "AN68.exe"
#define SourceDir "Lyhyka\bin\Debug"

[Setup]
AppId={{A3B5C7D9-E1F2-4A6B-8C0D-2E4F6A8B0C2D}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputDir=Output
OutputBaseFilename=LyhykaMotorbike_AN68_Setup
SetupIconFile=
Compression=lzma
SolidCompression=yes
WizardStyle=modern
PrivilegesRequired=admin

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; Main executable and config
Source: "{#SourceDir}\AN68.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\AN68.exe.config"; DestDir: "{app}"; Flags: ignoreversion

; Database files
Source: "{#SourceDir}\Motobike.db"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist
Source: "{#SourceDir}\Motobike-oto.db"; DestDir: "{app}"; Flags: ignoreversion onlyifdoesntexist

; Core DLLs
Source: "{#SourceDir}\Lyhyka.DBCore.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\Lyhyka.DBCore.dll.config"; DestDir: "{app}"; Flags: ignoreversion

; DevExpress DLLs
Source: "{#SourceDir}\DevExpress.*.dll"; DestDir: "{app}"; Flags: ignoreversion

; Entity Framework
Source: "{#SourceDir}\EntityFramework.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\EntityFramework.SqlServer.dll"; DestDir: "{app}"; Flags: ignoreversion

; SQLite
Source: "{#SourceDir}\System.Data.SQLite.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Data.SQLite.EF6.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Data.SQLite.Linq.dll"; DestDir: "{app}"; Flags: ignoreversion

; Microsoft ReportViewer
Source: "{#SourceDir}\Microsoft.ReportViewer.*.dll"; DestDir: "{app}"; Flags: ignoreversion

; Microsoft SqlServer Types
Source: "{#SourceDir}\Microsoft.SqlServer.Types.dll"; DestDir: "{app}"; Flags: ignoreversion

; PDF Viewer
Source: "{#SourceDir}\PdfiumViewer.dll"; DestDir: "{app}"; Flags: ignoreversion

; Newtonsoft JSON
Source: "{#SourceDir}\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion

; Microsoft Extensions
Source: "{#SourceDir}\Microsoft.Extensions.*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\Microsoft.Bcl.*.dll"; DestDir: "{app}"; Flags: ignoreversion

; System libraries
Source: "{#SourceDir}\System.Buffers.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Configuration.ConfigurationManager.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Diagnostics.DiagnosticSource.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Drawing.Common.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Formats.Asn1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.IO.Pipelines.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Memory.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Net.Http.WinHttpHandler.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Numerics.Vectors.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Runtime.CompilerServices.Unsafe.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Security.*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Text.*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Threading.Tasks.Extensions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.ValueTuple.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\stdole.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\EnvDTE.dll"; DestDir: "{app}"; Flags: ignoreversion

; Native DLLs (x86/x64)
Source: "{#SourceDir}\x86\*"; DestDir: "{app}\x86"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#SourceDir}\x64\*"; DestDir: "{app}\x64"; Flags: ignoreversion recursesubdirs createallsubdirs

; Reports
Source: "{#SourceDir}\Reports\*"; DestDir: "{app}\Reports"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
