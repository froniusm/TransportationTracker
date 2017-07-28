-- *****************************************************************************
-- This script contains INSERT statements for populating tables with seed data
-- *****************************************************************************

USE [TransportationDB] 

-- *********
-- User Roles
-- *********

INSERT INTO LOOKUPRole (RoleName,RoleDescription,RowCreatedSYSUserID,RowModifiedSYSUserID)  
       VALUES ('Admin','Can Create, Edit, Update, Delete',1,1);
INSERT INTO LOOKUPRole (RoleName,RoleDescription,RowCreatedSYSUserID,RowModifiedSYSUserID)  
       VALUES ('Member','Read only',1,1);

INSERT INTO SYSUser (LoginName,PasswordEncryptedText, RowCreatedSYSUserID, RowModifiedSYSUserID)  
VALUES ('Admin','Admin',1,1)  

INSERT INTO SYSUserRole (SYSUserID,LOOKUPRoleID,IsActive,RowCreatedSYSUserID, RowModifiedSYSUserID)  
VALUES (2,1,1,1,1)  

DELETE FROM SYSUser WHERE SYSUserID = 2; 
