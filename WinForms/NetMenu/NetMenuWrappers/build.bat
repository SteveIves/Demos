gennet40 -o NETSRC:NetMenuWrappers.dbl NETDLL:NetMenuComponent.dll
dblproto NETSRC:NetMenuWrappers.dbl
dbl -qrelax:interop -o NETOBJ:NetMenuWrappers.dbo NETSRC:NetMenuWrappers.dbl
dblibr -c NETOBJ:NetMenuWrappers.olb NETOBJ:NetMenuWrappers.dbo