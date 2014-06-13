@echo off

echo Deleting current files...

if exist %DAT%\department.ism del /q %DAT%\department.ism
if exist %DAT%\department.is1 del /q %DAT%\department.is1
if exist %DAT%\employee.ism del /q %DAT%\employee.ism
if exist %DAT%\employee.is1 del /q %DAT%\employee.is1

echo Creating new files...

fconvert -it DAT:department.seq -oi DAT:department.ism -d XDL:department.xdl
fconvert -it DAT:employee.seq   -oi DAT:employee.ism   -d XDL:employee.xdl
