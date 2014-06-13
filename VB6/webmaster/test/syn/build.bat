rem Build Script
set RPSMFIL=C:\webmaster\test\rps\rpsmain.ism
set RPSTFIL=C:\webmaster\test\rps\rpstext.ism
dblibr -c c:\webmaster\test\syn\testproj.olb
dbl -XT salesrep_read
dblibr -a c:\webmaster\test\syn\testproj.olb salesrep_read
dbl -XT salesrep_write
dblibr -a c:\webmaster\test\syn\testproj.olb salesrep_write
dbl -XT salesrep_list
dblibr -a c:\webmaster\test\syn\testproj.olb salesrep_list
dbl -XT login
dblibr -a c:\webmaster\test\syn\testproj.olb login
dbl -XT logout
dblibr -a c:\webmaster\test\syn\testproj.olb logout
dblink -l c:\webmaster\test\syn\testproj.elb c:\webmaster\test\syn\testproj.olb
