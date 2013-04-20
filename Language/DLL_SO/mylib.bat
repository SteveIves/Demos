REM ------------------------------------
REM Script to build custom DLL mylib.dll
REM ------------------------------------

setlocal

call "C:\Program Files (x86)\Microsoft Visual Studio 11.0\VC\vcvarsall.bat"

cl -nologo -MD -Ox -DWIN32 -DWINDOWS -c -GF -Ob2 -DNDEBUG -I "%DBLDIR%\csrc" power.c
lib -nologo -def:mylib.def -out:mylib.lib power.obj "%DBLDIR%\lib\xclapi.obj"
link -nologo -opt:ref -dll -out:mylib.dll power.obj mylib.exp "%DBLDIR%\lib\xclapi.obj" "%DBLDIR%\lib\xclapif.obj"

REM This command only required if using Visual Studio 2005
rem mt -nologo -manifest mylib.dll.manifest  -outputresource:mylib.dll;2

endlocal

if exist mylib.dll.manifest del mylib.dll.manifest
if exist mylib.exp del mylib.exp
if exist mylib.lib del mylib.lib

pause