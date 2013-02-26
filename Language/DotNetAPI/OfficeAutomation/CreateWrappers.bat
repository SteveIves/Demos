gennet -o SRC:OfficeAutomation.dbl EXE:OfficeAutomation.dll EXE:Interop.VBIDE.dll
dblproto SRC:OfficeAutomation.dbl
dbl -qrelax:interop -o OBJ:OfficeAutomation.dbo SRC:OfficeAutomation.dbl
dblink -l EXE:OfficeAutomation.elb OBJ:OfficeAutomation.dbo
