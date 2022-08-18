; -- Example1.iss --
; Demonstrates copying 3 files and creating an icon.

; SEE THE DOCUMENTATION FOR DETAILS ON CREATING .ISS SCRIPT FILES!

#define MyAppName "Gerador.NET"
#define MyAppExeName "Gerador.exe"
#define MyAppVersion "2014.0.1"
#define MyAppPublisher "MARCOS MORAIS SOUSA"
#define MyAppURL "hhttp://mmstec.com"
#define MyAppUninstalName "Remover"
#define MyAppUninstalExeName "unins000.exe"

[Setup]
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\MMSTEC\{#MyAppName}
DefaultGroupName=MMSTEC\{#MyAppName}
UninstallDisplayIcon={app}\{#MyAppExeName}
Compression=lzma2
SolidCompression=yes
;OutputDir=userdocs:Inno Setup Examples Output
OutputDir=C:\MMSTEC\INSTALADORES
OutputBaseFilename=Instalar_{#MyAppName}_v{#MyAppVersion}

[Languages]
Name: br; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"


[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Messages]
br.BeveledLabel=Marcos Morais [Português (Brasil)]

[Files]
Source: "Gerador.Library.dll"; DestDir: "{app}"
Source: "Gerador.Entity.dll"; DestDir: "{app}"
Source: "Gerador.Connection.dll"; DestDir: "{app}"
Source: "Gerador.Dal.dll"; DestDir: "{app}"
Source: "Gerador.Business.dll"; DestDir: "{app}"
Source: "Gerador.exe"; DestDir: "{app}"
;Source: "Gerador.exe.manifest"; DestDir: "{app}";
Source: "flag.ini"; DestDir: "{app}"

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{#MyAppUninstalName}"; Filename: "{app}\{#MyAppUninstalExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
