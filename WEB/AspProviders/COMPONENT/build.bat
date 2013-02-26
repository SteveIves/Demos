@echo off
setlocal

CD /D %ROOT%COMPONENT

PATH=%PATH%;%XFNLNET%

rem Make .NET compilers available
if exist "C:\Program Files (x86)\Microsoft Visual Studio 9.0\Common7\Tools" (
  call "C:\Program Files (x86)\Microsoft Visual Studio 9.0\Common7\Tools\vsvars32.bat" > nul
) else (
  call "C:\Program Files\Microsoft Visual Studio 9.0\Common7\Tools\vsvars32.bat" > nul
)

rem Romove old COM+ application
echo Romoving old COM+ application...
regsvcs /u /quiet SynergyAspProvider\SynergyAspProvider.dll

rem Remove old Assembly from GAC
echo Removing old Assembly from GAC...
gacutil /silent /u SynergyAspProvider\SynergyAspProvider.dll

rem Create the Synergy XML file from the SMC and Repository
echo Generating XML file...
if exist SynergyAspProvider.xml del /q SynergyAspProvider.xml
dbs DBLDIR:genxml -f SynergyAspProvider.xml -i AspProvider -s %XFPL_SMCPATH%
if not exist SynergyAspProvider.xml goto noxml

rem Generate C# source code from XML file
echo Generating C# source code...
gencs -f SynergyAspProvider.xml -d . -n Synergex.Psg -o .\SynergyAspProvider

rem Compile .NET Assembly
echo Compiling .NET Assembly...
cd SynergyAspProvider
call SynergyAspProvider.bat -p

rem Add assembly to Global Assembly Cache (GAC)
echo Registering Assembly in GAC...
gacutil /nologo /i SynergyAspProvider.dll

rem Create COM+ Application
echo Creating COM+ Application...
regsvcs /quiet /c SynergyAspProvider.dll

cd ..

goto end

:noxml
echo Failed to crteate XML file!
goto end

:end
endlocal
pause

