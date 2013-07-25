@echo off
echo Creating object library LIB:server.olb
del "%LIB%\server.olb"
dblibr -c LIB:server.olb
for %%f in (%SRC%\*.dbl) do call bldd %%~nf
echo Linking EXE:server.elb
dblink -ld EXE:server.elb LIB:server.olb
