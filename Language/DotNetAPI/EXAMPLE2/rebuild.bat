rem
rem Generate Synergyn wrapper classes
rem
gennet -o SRC:System.Xml.dbl System.Xml
if errorlevel 1 goto exit
rem
rem Prototype the wrappers
rem
dblproto SRC:System.Xml.dbl
if errorlevel 1 goto exit
rem
rem Compile the wrappers
rem
dbl -qrelaxed:interop -o OBJ:System.Xml.dbo SRC:System.Xml.dbl
if errorlevel 1 goto exit
rem
rem Create an OLB containing the wrappers
rem
dblibr -ca LIB:System.Xml.olb OBJ:System.Xml.dbo
if errorlevel 1 goto exit
rem
rem Compile the test program
rem
dbl -o OBJ:XslTransform.dbo SRC:XslTransform.dbl
if errorlevel 1 goto exit
rem
rem Link the test program
rem
dblink -do EXE:XslTransform.dbr OBJ:XslTransform.dbo LIB:System.Xml.olb
:exit