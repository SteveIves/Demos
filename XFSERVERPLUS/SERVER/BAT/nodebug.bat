@echo off
echo Creating object library LIB:server.olb
del "%LIB%\server.olb"
dblibr -c LIB:server.olb
for %%f in (%SRC%\*.dbl) do call bldn %%~nf
echo Linking EXE:server.elb
dblink -l EXE:server.elb LIB:server.olb
