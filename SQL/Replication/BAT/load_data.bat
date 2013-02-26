setlocal
if exist %DAT%\action.ism del /q %DAT%\action.ism
if exist %DAT%\action.is1 del /q %DAT%\action.is1
if exist %DAT%\department.ism del /q %DAT%\department.ism
if exist %DAT%\department.is1 del /q %DAT%\department.is1
if exist %DAT%\employee.ism del /q %DAT%\employee.ism
if exist %DAT%\employee.is1 del /q %DAT%\employee.is1
fconvert -it DAT:department.seq -oi DAT:department.ism -d XDL:department.xdl
fconvert -it DAT:employee.seq -oi DAT:employee.ism -d XDL:employee.xdl
cd %DAT%
dbs dbldir:bldism -k XDL:replication.xdl
cd %ROOT%
endlocal
