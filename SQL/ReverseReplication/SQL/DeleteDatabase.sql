USE [master]
GO

/*
 * If the database exists, go to single user mode (drop existing connections)
 */

IF  EXISTS (SELECT name FROM sys.databases WHERE name = 'SqlReverseReplication')
   ALTER DATABASE SqlReverseReplication
      SET SINGLE_USER
      WITH ROLLBACK IMMEDIATE
GO

/*
 * If the database exists, drop it
 */

IF  EXISTS (SELECT name FROM sys.databases WHERE name = 'SqlReverseReplication')
   DROP DATABASE SqlReverseReplication
GO
