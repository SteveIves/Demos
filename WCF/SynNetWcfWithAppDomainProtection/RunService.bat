@echo off
set DEVROOT=%~dp0
cd /d %DEVROOT%
set DAT=%DEVROOT%data
ServiceHost\Bin\Debug\ServiceHost.exe
