@echo off
set DEVROOT=%~dp0
cd /d %DEVROOT%
cd
set RPSMFIL=%DEVROOT%rps\rpsmain.ism
set RPSTFIL=%DEVROOT%rps\rpstext.ism
set DAT=%DEVROOT%data
start SynNetWcfWithAppDomainProtection.sln
exit
