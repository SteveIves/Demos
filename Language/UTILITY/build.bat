@echo off
echo Creating OBJ:utility.olb ...
del %OBJ%\utility.olb
dblibr -c %OBJ%\utility.olb
echo Compiling all source files ...
for %%f in (*.dbl) do call bld %%~nf
echo Linking UT:utility.elb ...
dblink -ld UT:utility.elb OBJ:utility.olb