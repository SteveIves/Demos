prompt $n$g
cls
rem Prototype the Synergy form
dblproto SRC:frmEmployee.dbl
if errorlevel 1 goto error
rem Compile the Synergy form
dbl -qrelax:interop -W0 -do OBJ:frmEmployee.dbo SRC:frmEmployee.dbl
if errorlevel 1 goto error
rem Compile the test program
dbl -W0 -do OBJ:WinForm2.dbo SRC:WinForm2.dbl
if errorlevel 1 goto error
rem Link the test program
dblink -do EXE:WinForm2.dbr OBJ:WinForm2.dbo OBJ:frmEmployee.dbo LIB:DotNetWrappers.olb
if errorlevel 1 goto error
goto exit
:error
echo There was an error!
:exit
