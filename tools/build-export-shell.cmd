@echo off
rem Build tools\export-playlist.exe with the built-in .NET csc (exe is gitignored).
rem Keep this file ASCII-only: cmd parses batch files in the OEM codepage.
setlocal
set CSC=%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\csc.exe
if not exist "%CSC%" set CSC=%WINDIR%\Microsoft.NET\Framework\v4.0.30319\csc.exe
if not exist "%CSC%" (
  echo csc.exe not found; cannot build.
  exit /b 1
)
"%CSC%" /nologo /codepage:65001 /target:exe /out:"%~dp0export-playlist.exe" "%~dp0export-playlist-shell.cs"
if errorlevel 1 exit /b 1
echo Built %~dp0export-playlist.exe
