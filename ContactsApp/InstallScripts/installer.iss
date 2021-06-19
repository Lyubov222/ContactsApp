#define MyAppExeName "ContactsAppUI.exe"
#define MyAppName "ContactsApp"
#define MyAppVersion "1.0.0"

[Setup]
AppId={{F786CD3E-3A63-4282-B639-5DE65EAD7B71}
AppName = {#MyAppName}
AppVersion={#MyAppVersion}
DefaultDirName = {pf}\{#MyAppName}
DisableProgramGroupPage = yes
OutputBaseFilename = ContactsAppSetup
Compression = lzma
SolidCompression = yes
OutputDir = "Installers"
SetupIconFile = "..\..\MainFormIcon.ico"

[languages]
Name: "en"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "Release\*.dll"; DestDir: "{app}"
Source: "Release\ContactsAppUI.exe"; DestDir: "{app}"
Source: "..\..\MainFormIcon.ico"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon;
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; IconFileName: "{app}\MainFormIcon.ico";  Tasks: desktopicon;