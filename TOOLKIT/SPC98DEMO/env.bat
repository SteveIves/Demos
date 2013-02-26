REM Set environment variables for UI Toolkit demo.

set DEMOLOG=C:\FILES\DEMO\TOOLKIT\SPC98DEMO

REM Environment logical (set at startup)

set SFWINIPATH=%DEMOLOG%

REM Application Runtime logicals

set LIB=%DEMOLOG%\rpsdat

REM Application Compile logicals

set DBLDICTIONARY=LIB:RPSMAIN.ISM,LIB:RPSTEXT.ISM
set RPSMFIL=LIB:RPSMAIN.ISM
set RPSTFIL=LIB:RPSTEXT.ISM
set RPTRFIL=LIB:REPORTS.ISM

