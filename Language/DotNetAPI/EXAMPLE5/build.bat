cls
rem Generate .NET class wrappers
gennet -o SRC:NetWrappers.dbl System.Xml mscorlib
if errorlevel 1 goto error
rem Prototype the .NET class wrappers
dblproto SRC:NetWrappers.dbl
if errorlevel 1 goto error
rem Compile the .NET class wrappers
dbl -qrelax:interop -W0 -o OBJ:NetWrappers.dbo SRC:NetWrappers.dbl
if errorlevel 1 goto error
rem Put the .NET class wrappers into an OLB
dblibr -ca LIB:NetWrappers.olb OBJ:NetWrappers.dbo
if errorlevel 1 goto error
rem Compile the demo program
dbl -W0 -o OBJ:XmlValidation.dbo SRC:XmlValidation.dbl
if errorlevel 1 goto error
rem Link the demo program
dblink -o EXE:XmlValidation.dbr OBJ:XmlValidation.dbo LIB:NetWrappers.olb DBLDIR:synxml.elb
:error

