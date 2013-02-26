/* ============================================================================
 *
 * Title:      SimulateTransations.sql
 *
 * Description:   Similates SQL reverse replication transactions
 *
 * Author:     Steve Ives
 *          Synergex Professional Services Group
 *
 * Date:    7th September 2012
 *
 * ============================================================================
 */

USE [SqlReverseReplication]
GO

BEGIN TRANSACTION
GO

INSERT INTO Person (FirstName, LastName, Email, DateOfBirth, HireDate) VALUES('Steve','Ivey','steve@steveives.com','7/19/1964','11/1/1997')
GO

INSERT INTO Person (FirstName, LastName, Email) VALUES('William','Hawkins','william.hawkins@synergex.com')
GO

INSERT INTO Person (FirstName, LastName, Email) VALUES('Richard','Morris','richard.morris@synergex.com')
GO

UPDATE Person SET DateOfBirth='12/20/1964' where FirstName='Richard' and LastName='Morris'
GO


UPDATE Person SET Email='steve.ives@synergex.com' where FirstName='Steve' and LastName='Ivey'
GO

DELETE FROM Person WHERE FirstName='William' and LastName='Hawkins'
GO

UPDATE Person SET LastName='Ives' where FirstName='Steve' and LastName='Ivey'
GO

COMMIT TRANSACTION
GO