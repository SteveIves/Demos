rem
rem IMPORTANT: The logical name EXE must be set either system wide, or in synergy.ini
rem            for ReverseReplicator
rem
dbssvc -r -c ReverseReplicator -d "Synergy/DE Reverse Replication Server" EXE:ReverseReplicator.dbr
sc config ReverseReplicator depend= lanmanworkstation/Eventlog/SynLM/MSSQL$SQLEXPRESS
net start ReverseReplicator

