prompt $n$g 
cls
rem Generate .NET class wrappers
gennet -o GENSRC:DotNetWrappers.dbl System.Windows.Forms System.Drawing mscorlib
if errorlevel 1 goto error
rem Prototype the .NET class wrappers
dblproto GENSRC:DotNetWrappers.dbl
if errorlevel 1 goto error
rem Compile the .NET class wrappers
dbl -qrelax:interop -W0 -o OBJ:DotNetWrappers.dbo GENSRC:DotNetWrappers.dbl
if errorlevel 1 goto error
rem Put the .NET class wrappers into an OLB
dblibr -ca LIB:DotNetWrappers.olb OBJ:DotNetWrappers.dbo
:error
