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

This example has only been tested on Synergy/DE V9.1.3 on a Windows system.  I
believe it should work under V9.1.1, but I have not tested it.  In theory the
software should also work on UNIX and OpenVMS, although some environmental
setup would be required.  The database used during testing was Microsoft SQL
Server 2005 Developer edition, with all the latest service packs and Windows
Update patches applied.

Development Environment
-----------------------

Use workbench and open the Workspace SqlReplication.vpw This workspace contains
six projects, as follows:

iolib.vpj       This project is used to develop an ELB called EXE:iolib.elb,
                which contains routines which are used to access the Synergy
                applications ISAM files.  If you need to rebuild these routines
                then make sure the project is active (bold in the project tree,
                if not then right-click it and select "set active project") and
                then pick "Rebuild" from the "Build" menu.

sqllib.vpj      This project is used to develop an ELB called EXE:sqllib.elb,
                which contains routines which are used to access the SQL Server
                database tables which mirror the applications ISAM files. These
                are the tables that will hold the replicated data. If you need
                to rebuild these routines then make sure the project is active
                (bold in the project tree, if not then right-click it and select
                "set active project") and then pick "Rebuild" from the "Build"
                menu.

tklib.vpj       This project is used to develop a set of miscellaneous routines
                which can be used by UI Toolkit applications. These routines are
                contained in EXE:tklib.elb.   If you need to rebuild these
                routines then make sure the project is active (bold in the
                project tree, if not then right-click it and select "set active
                project") and then pick "Rebuild" from the "Build" menu.

apps.vpj       This project is used to develop routines which are essentially
                user applications. There are two applications included with
                this demo, the first is an employee file maintenance routine
                called employee_maint_tab, and the second is a routine which
                displays an employee report, called EmployeePhoneList.dbl.
                These routines are held in EXE:apps.elb  If you need to
                rebuild these routines then make sure the project is active
                (bold in the project tree, if not then right-click it and
                select "set active project") and then pick "Rebuild" from the
                "Build" menu.

menu.vpj        This project is used to develop a very simple menu system which
                can be used to activate the applications in apps.elb.  The
                menu system is called menu.dbl and is compiled into EXE:menu.dbr.
                If you need to rebuild the menu program, make sure the project
                is active (bold in the project tree, if not then right-click
                it and select "set active project"), open the file menu.dbl in
                the editor, then "Compile", then "Build" from the "Build" menu.

replicator.vpj  This project is used to develop a program called replicator.dbl.
                This program executes as a Windows Service and performs the
                replication of the ISAM data to the SQL Server database.
                If you need to rebuild the menu program, make sure the project
                is active (bold in the project tree, if not then right-click
                it and select "set active project"), open the file
                replicator.dbl in the editor, then "Compile", then "Build" from
                the "Build" menu.

Setup
-----

If you wish to actually configure and execute this demo you will need:

  - Synergy/DE V9.1.3 Professional Series Workbench on a Windows system

  - A SQL Server 2005 database (express edition should be OK) and at least
    one Synergy/DE SQL connection license available.  If you wish to avoid
    editing the supplied example code then use a SQL Server database on the
    same computer that you intend to run the Synergy code on.  If you do not
    use a local database then you will need to edit replicator.dbl, change the
    value of the define SQL_SERVER, and recompile and link the program.

  - Create a new SQL Server login, and make a note of the username and password
    that you use.  If you wish to avoid editing the supplied example code then
    use username "ReplicationServer" and password "ReplicationPassword". If you
    do not use these default values then upi will need to edit replicator.dbl,
    change the values of the defines SQL_USERNAME and SQL_PASSWORD, then
    recompile and link the program.

  - Create a new SQL Server database, and set the owner of the database to be
    the new login account that you just created.  If you wish to avoid editing
    the supplied example code then name the database "SynergyReplication". If
    you do not use this default database name then you will need to edit
    replicator.dbl, change the value of the define SQL_DATABASE, then recompile
    and link the program.

  - Edit your Synergy.ini file and create a new section to allow you to define
    settings for the replicator program (replicator.dbr), like this:

        [replicator]
        EXE=C:\SQLREPLICATION\EXE
        DAT=C:\SQLREPLICATION\DAT

    Change the paths to the location where you extracted the demo files.

  - Start Workbench and open the workspace called SQLReplication.vpw.  Use the
    "Project > Open Workspace..." menu option to do this.  Make sure you can
    see the "Projects" window.  If it is not active then make it active, if it
    is not displayed then display it by selecting "View -> Toolbars" from the
    menu and checking the "Projects" option.

  - Make sure that the "replicator.vpj" project is the current project (it
    should appear bold when compared to the other projects in the workspace.
    If it does not then right-click the replicator.vpj project and select
    "Set Active Project".

  - If you edited the replicator.dbl program in order to change the database
    configuration options above then you sould recompile and relink the program.
    To do this, open the replicator.dbl source file, then select "Compile" then
    "Build" from the "Build" menu.  Make sure there are no errors displayed in
    the output window.

  - If your SQL Server service is not called the default "MSSQLSERVER" then
    you will need to edit the file "register_service.bat" and change the
    reference to the service name in the "sc" command".

  - From Workbench, open a command prompt by selecting "Tools > OS Shell" from
    the menu.  When the command promp opens you should already be in the
    projects SRC\REPLICATOR folder, but if not then go there.

  - Execute the file "register_service.bat" This creates a new Windows service.
    If you wish to verify that the service has been created then go to the
    Services application in Control Panel / Administrative Tools and make sure
    you can see a service called "Synergy Replication Server".

  - Now start the service.  You can either do this in the Services application,
    or you can execute the batch file start_service.bat. Check that the service
    starts OK.

  - Look in the Windows Application Event Log.  You should see two messages
    from ReplicationServer, one saying "Service Started" and one saying
    "Processing transactions".  If not then you should see an error message
    indicating what problem caused the replication server to fail to start. The
    most likely reason for failure will be failure to connect to or log in to
    the SQL Server database. Keep an eye on the event log, if ReplicationServer
    has a problem, that's where the information will be!

Running the demo
----------------

In order to see the replication happenning, use SQL Server Management Studio to
connect to the database, and display the list of tables in the database - there
aren't any at the moment.  Run the Synergy client application by selecting
"Execute" from the Workbench "Build Menu".

Pick the "Applications -> Employee Maintenance", then cick on the search button
to show a list of all of the employees in the ISAM file.  Souble click an
employee to edit it, then change something and click OK.

This will record an update operation in the replication servers transaction log.
Within five seconds it should pick up the entry, realize there is an update to
the database, and try to replicate the change.  The first time this happens
it will realize that the EMPLOYEE table doesn't exist in the database as yet,
so it should create the table, and then initiate a full load of the table from
the ISAM file.

Check Management studio, is the table and data there yet?  If not, check the
event log!

From now on, as you create, amend and delete employee records, those changes
should be replicated to the EMPLOYEE table in SQL server.  The example
replicator goes to sleep for five seconds if there is nothing to do, so you
should see any changes within that time frame.  If you are sitting looking at
the table in Management studio however, the table is not automatically
refreshed, you you'll have to refresh it manually each time you want to see
a change.

Enjoy!

