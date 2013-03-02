@echo off
setlocal
call "c:\Program Files (x86)\synergex\SynergyDE\dbl\dblvars32.bat" > nul
set CODEGEN_ROOT=C:\Dev\CodeGen
set CODEGEN_BAT=%CODEGEN_ROOT%\bat
set CODEGEN_EXE=%CODEGEN_ROOT%\exe
set CODEGEN_TPLDIR=.
set CODEGEN_OUTDIR=.\ClientApp\Styles
set RPSMFIL=.\rps\rpsmain.ism
set RPSTFIL=.\rps\rpstext.ism
set PATH=%CODEGEN_BAT%;%PATH%
call codegen -s PERSON -t XamlStyle -r -v
endlocal