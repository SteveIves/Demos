cls
rem Generate .NET class wrappers
gennet -o SRC:MyClassLibrary.dbl NETBIN:MyClassLibrary.dll mscorlib
if errorlevel 1 goto error
rem Prototype the .NET class wrappers
dblproto SRC:MyClassLibrary.dbl
if errorlevel 1 goto error
rem Compile the .NET class wrappers
dbl -qrelax:interop -W0 -o OBJ:MyClassLibrary.dbo SRC:MyClassLibrary.dbl
if errorlevel 1 goto error
rem Put the .NET class wrappers into an OLB
dblibr -ca LIB:MyClassLibrary.olb OBJ:MyClassLibrary.dbo
:error
