dbssvc -cReplicationServer -r -d"Synergy/DE Replication Server" EXE:replicator.dbr
sc config ReplicationServer depend= lanmanworkstation/Eventlog/SynLM/MSSQLSERVER
