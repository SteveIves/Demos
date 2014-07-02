================================================================================

Synergy/DE SQL Database Replication Example
===========================================

Introduction
------------

This is an example of the replication of a Synergy applications ISAM data to
a SQL Server database, in near real-time.  The replication is performed by
a Synergy program running as a Windows service.  As the Synergy application
creates, amends and deletes records from the ISAM files, the IO routines which
are used to isteract with the ISAM files also record these "transactions" in a
transaction log file called DAT:action.ism.  The replication server then comes
along, reads the transactions, and makes the corresponding changes to the SQL
Server database.

There are several advantages to taking this kind of approach, some of the major
ones being:

  - You don't have to totally re-design your Synergy applications to store the
    actual application data in SQL Server.  To do this properly would be a very
    major re-write for any application.

  - You don't put the overhead of writing the data to both ISAM and SQL Server
    into your actual user applications, the performance overhead of which can
    be very significant.

  - You don't make your user applications directly dependent on the database
    being started.  If the database, or replication server are not started then
    the transactions will simply build up in the log file until such time as
    they are started.

There will, of course, be some work to do in the Synergy applications.  This is
not a project that will heppen overnight.  In order to be successful with this
type of project, the major requirements are:

  - Having a consistent and unique key available in each of the ISAM files that
    is to be replicated.  Synergex currently recommends adding an A20 field to
    the end of each replicated record layout, and populating that field with a
    unique timestamp value (from %DATETIME) of the time that each record was
    created.  This will require a file conversion of any ISAM file which is to
    be replicated.

  - Having consistently named file-specific IO routines for each data file to
    be replicated.  These routines are easy to create (you could even base them
    on the routines in this example) but what can take time is ensuring that
    all create, amend or delete operations to the file, anywhere in your
    applications, use these routines.

  - Having consistently named table and function specific SQL database access
    routines.  Again, these routines are easy to create, and again can be based
    on the examples provided with this demonstration.

Requirements
------------

This example was originally created using Synergy/DE V9.1.3 on a Windows system,
and should work on any higher version.  In theory the software should also work
on UNIX and OpenVMS, although some environmental setup would be required.  The
database used during testing was Microsoft SQL Server 2005 and the code should
work with any later version of SQL Server.

Development Environment
-----------------------

Use workbench and open the Workspace SQLReplication.vpw This workspace contains
three projects, as follows:

application.vpj Contains a UI Toolkit application that includes an employee
                maintenance function. The replicator program can be started,
                stopped and controlled via menu items in the application.

library.vpj     Contains subroutines and functions that are used both by the
                UI Toolkit application, and the replicator progrma.

replicator.vpj  Contains the replicator program.



Running Replicator as a Windows Service
---------------------------------------

To register the service:

        dbssvc -cReplicationServer -r -d"Synergy/DE Replication Server" EXE:replicator.dbr
        sc config ReplicationServer depend= lanmanworkstation/Eventlog/SynLM/MSSQLSERVER

To start the service:

        net start ReplicationServer

To stop the service

        net stop ReplicationServer

To unregister the service:

        dbssvc -cReplicationServer -x

