; -- Example1.iss --
; Demonstrates copying 3 files and creating an icon.

; SEE THE DOCUMENTATION FOR DETAILS ON CREATING .ISS SCRIPT FILES!



[Setup]
AppName=Gerador.MSSQL
AppVersion=1.1
AppPublisher=MMSTEC LTDA
DefaultDirName={pf}\MMSTEC\Gerador.MSSQL
DefaultGroupName=Gerador.MSSQL
UninstallDisplayIcon={app}\Gerador.exe
Compression=lzma2
SolidCompression=yes
OutputDir=userdocs:Inno Setup Examples Output

[Languages]
Name: br; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"

[Messages]
br.BeveledLabel=Português (Brasil)

[Files]
Source: "Gerador.Library.dll"; DestDir: "{app}"
Source: "Gerador.Entity.dll"; DestDir: "{app}"
Source: "Gerador.Connection.dll"; DestDir: "{app}"
Source: "Gerador.Data.dll"; DestDir: "{app}"
Source: "Gerador.Business.dll"; DestDir: "{app}"
Source: "Gerador.exe"; DestDir: "{app}"
Source: "Gerador.exe.manifest"; DestDir: "{app}";
Source: "flag.ini"; DestDir: "{app}"

[Icons]
Name: "{group}\Gerador.MSSQL"; Filename: "{app}\Gerador.exe"
Name: "{group}\Remover Gerador.MSSQL"; Filename: "{app}\unins000.exe"
Name: "{commondesktop}\Gerador.MSSQL"; Filename: "{app}\Gerador.exe"
