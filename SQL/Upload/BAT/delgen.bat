@echo off
echo Deleting generated routines
for %%f in (%SRC%\generated\*.dbl) do call delfile %%~nf

