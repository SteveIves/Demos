@echo off
echo Creating object library LIB:AspProviders.olb
if exist "%LIB%\AspProviders.olb" del /q "%LIB%\AspProviders.olb"
dblibr -c "%LIB%\AspProviders.olb"
for %%f in (*.dbl) do call bldd %%~nf
echo DEBUG Linking EXE:AspProviders.elb
dblink -ld EXE:AspProviders.elb LIB:AspProviders.olb

