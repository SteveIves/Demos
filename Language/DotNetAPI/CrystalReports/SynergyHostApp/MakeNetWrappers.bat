rem
rem If need to gennet from an x86 assembly, fake it out with:
rem
rem At a VS command prompt:
rem
rem C:\> CORFLAGS /32BIT+ GENNET40.EXE
rem
rem To return to notmal:
rem
rem C:\> CORFLAGS /32BIT- GENNET40.EXE
rem
gennet -o SRC:NetWrappers.dbl NET:MyReports.dll
dblproto SRC:NetWrappers.dbl
dbl -qrelax:interop -o OBJ:NetWrappers.dbo SRC:NetWrappers.dbl
dblink -l EXE:NetWrappers.elb OBJ:NetWrappers.dbo

