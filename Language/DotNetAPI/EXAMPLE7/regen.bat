del "%ROOT%hdr\*.dbh"
gennet -s -o SRC:DotNetWrappers.dbl "%ROOT%\GraphViewerClasses.xml"
dblproto SRC:DotNetWrappers.dbl
dbl -qrelax:interop -o OBJ:DotNetWrappers.dbo SRC:DotNetWrappers.dbl
dblibr -ca LIB:DotNetWrappers.olb OBJ:DotNetWrappers.dbo
