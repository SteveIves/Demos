/* ============================================================================
 *
 * Title:         CreateDatabase.sql
 *
 * Description:   Creates a SQL Server database for the ReverseReplicator demo
 *
 * Author:        Steve Ives
 *                Synergex Professional Services Group
 *
 * Date:          7th September 2012
 *
 * ============================================================================
 */

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

/*
 * Create a new database
 */

CREATE DATABASE SqlReverseReplication
GO

ALTER DATABASE SqlReverseReplication
   SET COMPATIBILITY_LEVEL = 100
GO

IF (FULLTEXTSERVICEPROPERTY('IsFullTextInstalled') = 1)
BEGIN
   EXEC SqlReverseReplication.[dbo].[sp_fulltext_database] @action = 'enable'
END
GO

ALTER DATABASE SqlReverseReplication
   SET ANSI_NULL_DEFAULT OFF
GO

ALTER DATABASE SqlReverseReplication
   SET ANSI_NULLS OFF
GO

ALTER DATABASE SqlReverseReplication
   SET ANSI_PADDING OFF
GO

ALTER DATABASE SqlReverseReplication
   SET ANSI_WARNINGS OFF
GO

ALTER DATABASE SqlReverseReplication
   SET ARITHABORT OFF
GO

ALTER DATABASE SqlReverseReplication
   SET AUTO_CLOSE OFF
GO

ALTER DATABASE SqlReverseReplication
   SET AUTO_CREATE_STATISTICS ON
GO

ALTER DATABASE SqlReverseReplication
   SET AUTO_SHRINK OFF
GO

ALTER DATABASE SqlReverseReplication
   SET AUTO_UPDATE_STATISTICS ON
GO

ALTER DATABASE SqlReverseReplication
   SET CURSOR_CLOSE_ON_COMMIT OFF
GO

ALTER DATABASE SqlReverseReplication
   SET CURSOR_DEFAULT  GLOBAL
GO

ALTER DATABASE SqlReverseReplication
   SET CONCAT_NULL_YIELDS_NULL OFF
GO

ALTER DATABASE SqlReverseReplication
   SET NUMERIC_ROUNDABORT OFF
GO

ALTER DATABASE SqlReverseReplication
   SET QUOTED_IDENTIFIER OFF
GO

ALTER DATABASE SqlReverseReplication
   SET RECURSIVE_TRIGGERS OFF
GO

ALTER DATABASE SqlReverseReplication
   SET DISABLE_BROKER
GO

ALTER DATABASE SqlReverseReplication
   SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO

ALTER DATABASE SqlReverseReplication
   SET DATE_CORRELATION_OPTIMIZATION OFF
GO

ALTER DATABASE SqlReverseReplication
   SET TRUSTWORTHY OFF
GO

ALTER DATABASE SqlReverseReplication
   SET ALLOW_SNAPSHOT_ISOLATION OFF
GO

ALTER DATABASE SqlReverseReplication
   SET PARAMETERIZATION SIMPLE
GO

ALTER DATABASE SqlReverseReplication
   SET READ_COMMITTED_SNAPSHOT OFF
GO

ALTER DATABASE SqlReverseReplication
   SET HONOR_BROKER_PRIORITY OFF
GO

ALTER DATABASE SqlReverseReplication
   SET READ_WRITE
GO

ALTER DATABASE SqlReverseReplication
   SET RECOVERY SIMPLE
GO

ALTER DATABASE SqlReverseReplication
   SET MULTI_USER
GO

ALTER DATABASE SqlReverseReplication
   SET PAGE_VERIFY CHECKSUM
GO

ALTER DATABASE SqlReverseReplication
   SET DB_CHAINING OFF
GO

/* ============================================================================
 * Set context to the newly created database
 */

USE SqlReverseReplication
GO

/* ============================================================================
Enable nested triggers. This is needed so that instructions deleted within
triggers are moved to the history table.
 
Seems like this may not be the problem, messages say these settings are
already enabled!

EXEC sp_configure 'show advanced options', 1;
GO
RECONFIGURE ;
GO
EXEC sp_configure 'nested triggers', 1 ;
GO
RECONFIGURE;
GO
*/

/* ============================================================================
 * Create the replication instructions table
 */

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE ToReplicate
   (
      AuditLogId  bigint      IDENTITY(1,1)  NOT NULL,
      ChangeDate  datetime             NOT NULL,
      TableName      varchar(30)             NOT NULL,
      ChangeType  varchar(8)              NOT NULL,
      RowGuid     uniqueidentifier        NOT NULL,
      CONSTRAINT PK_ToReplicate
         PRIMARY KEY CLUSTERED
         (
            AuditLogID ASC
         )
         WITH
         (
            PAD_INDEX = OFF,
            STATISTICS_NORECOMPUTE = OFF,
            IGNORE_DUP_KEY = OFF,
            ALLOW_ROW_LOCKS = ON,
            ALLOW_PAGE_LOCKS = ON
         )
         ON [PRIMARY]
   )
   ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

ALTER TABLE ToReplicate
   ADD CONSTRAINT DF_AuditLog_ChangeDate
      DEFAULT (getdate())
      FOR ChangeDate
GO

/*
 * Create an index for RowGuid and ChangeType on the replication instructions table for trigger performance
 */

CREATE NONCLUSTERED INDEX IX_ToReplicate_RowGuid_ChangeType
   ON ToReplicate
   (
      RowGuid ASC,
      ChangeType ASC
   )
   WITH
   (
      PAD_INDEX  = OFF,
      STATISTICS_NORECOMPUTE = OFF,
      SORT_IN_TEMPDB = OFF,
      IGNORE_DUP_KEY = OFF,
      DROP_EXISTING = OFF,
      ONLINE = OFF,
      ALLOW_ROW_LOCKS = ON,
      ALLOW_PAGE_LOCKS = ON
   )
   ON [PRIMARY]
GO

/* ============================================================================
 * Create the replication history table
 */

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE ReplicationHistory
   (
      AuditLogId   bigint			NOT NULL,
      ChangeDate   datetime         NOT NULL,
      TableName    varchar(30)      NOT NULL,
      ChangeType   varchar(8)		NOT NULL,
      RowGuid      uniqueidentifier NOT NULL,
       CONSTRAINT PK_ReplicationHistory
         PRIMARY KEY CLUSTERED
         (
            AuditLogID ASC
         )
         WITH
         (
            PAD_INDEX = OFF,
            STATISTICS_NORECOMPUTE = OFF,
            IGNORE_DUP_KEY = OFF,
            ALLOW_ROW_LOCKS = ON,
            ALLOW_PAGE_LOCKS = ON
         )
         ON [PRIMARY]
   )
   ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

/*
 * Create a DELETE trigger on the ToReplicate table to move instructions that have been
 * processed into the ReplicationHistory table.
 */

CREATE TRIGGER ToReplicate_LogDelete
   ON dbo.ToReplicate
   FOR DELETE
   AS
   BEGIN
      INSERT INTO ReplicationHistory (AuditLogId,ChangeDate,TableName,ChangeType,RowGuid)
         SELECT d.AuditLogId,d.ChangeDate,d.TableName,d.ChangeType,d.RowGuid FROM deleted d
   END
GO

/* ============================================================================
 * Create the table(s) to be replicated
 */

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE Person
   (
      PersonID		int       IDENTITY(1,1) NOT NULL,
      FirstName		varchar(20)             NOT NULL,
      LastName		varchar(20)             NOT NULL,
      Email			varchar(50)             NOT NULL,
      DateOfBirth	date					NULL,
      HireDate		date					NULL,
      Notes			varchar(512)            NULL,
      RowGuid		uniqueidentifier        NOT NULL,
      CONSTRAINT PK_Person
         PRIMARY KEY CLUSTERED
         (
            PersonID ASC
         )
         WITH
         (
            PAD_INDEX = OFF,
            STATISTICS_NORECOMPUTE = OFF,
            IGNORE_DUP_KEY = OFF,
            ALLOW_ROW_LOCKS = ON,
            ALLOW_PAGE_LOCKS = ON
         )
         ON [PRIMARY]
   )
   ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE Person
   ADD CONSTRAINT DF_Person_RowGuid
      DEFAULT (newid())
      FOR RowGuid
GO

/*
 * Create an index on the RowGuid column in the Person table
 */

CREATE UNIQUE NONCLUSTERED INDEX IX_Person_RowGuid
   ON Person
   (
      RowGuid ASC
   )
   WITH
   (
      PAD_INDEX = OFF,
      STATISTICS_NORECOMPUTE = OFF,
      SORT_IN_TEMPDB = OFF,
      IGNORE_DUP_KEY = OFF,
      DROP_EXISTING = OFF,
      ONLINE = OFF,
      ALLOW_ROW_LOCKS = ON,
      ALLOW_PAGE_LOCKS = ON
   )
   ON [PRIMARY]
GO

/*
 * Add an INSERT trigger
 */

CREATE TRIGGER Person_LogInsert
   ON Person
   FOR INSERT
   AS
   BEGIN
      INSERT INTO ToReplicate (ChangeDate,TableName,ChangeType,RowGuid)
         SELECT getdate(),'Person','INSERT',i.RowGuid FROM inserted i
   END
GO

/*
 * Add an UPDATE trigger
 */

CREATE TRIGGER Person_LogUpdate
   ON Person
   FOR UPDATE
   AS
   BEGIN
      /* Get the GUID of the updated row */
      DECLARE @rowid UNIQUEIDENTIFIER  = (SELECT d.RowGuid  FROM deleted d)
      /* If there are earlier UPDATE transactions for the same row then delete then, we only need one */
      IF EXISTS (SELECT RowGuid FROM ToReplicate WHERE RowGuid=@rowid AND ChangeType='UPDATE')
            DELETE FROM ToReplicate WHERE RowGuid=@rowid AND ChangeType='UPDATE'
      INSERT INTO ToReplicate (ChangeDate,TableName,ChangeType,RowGuid)
         SELECT getdate(),'Person','UPDATE',d.RowGuid FROM deleted d
   END
GO

/*
 * Add a DELETE trigger
 */

CREATE TRIGGER Person_LogDelete
	ON Person
	FOR DELETE
	AS
	BEGIN
		/* Is there a pending INSERT for the row that is now being deleted? */
		IF EXISTS (SELECT RowGuid FROM ToReplicate WHERE RowGuid=(SELECT d.RowGuid FROM deleted d) AND ChangeType='INSERT')
		BEGIN
			/* No. Wipe out all references to the row and don't record the DELETE */
			DELETE FROM ToReplicate WHERE RowGuid=(SELECT d.RowGuid FROM deleted d)
		END
		ELSE
		BEGIN
			/* No INSERT. Wipe out all references to the row and record the DELETE */
			DELETE FROM ToReplicate WHERE RowGuid=(SELECT d.RowGuid FROM deleted d)
			INSERT INTO ToReplicate(ChangeDate,TableName,ChangeType,RowGuid) SELECT getdate(),'Person','DELETE',d.RowGuid FROM deleted d
		END
	END
GO
