@echo off
REM ------------------------------------
REM Script to build custom DLL b64.dll
REM ------------------------------------

setlocal

call "C:\Program Files\Microsoft Visual Studio 8\VC\vcvarsall.bat"

cl -nologo -MD -Ox -DWIN32 -DWINDOWS -c -GF -Ob2 -DNDEBUG b64.c
lib -nologo -def:b64.def -out:b64.lib b64.obj
link -nologo -opt:ref -dll -out:b64.dll b64.obj b64.exp

REM This command only required if using Visual Studio 2005
mt -nologo -manifest b64.dll.manifest  -outputresource:b64.dll;2

endlocal

pause