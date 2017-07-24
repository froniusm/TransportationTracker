-- *****************************************************************************
-- This script contains INSERT statements for populating tables with seed data
-- *****************************************************************************

USE [TransportationDB] 

INSERT INTO LOOKUPRole (RoleName,RoleDescription,RowCreatedSYSUserID,RowModifiedSYSUserID)  
       VALUES ('Admin','Can Create, Edit, Update, Delete',1,1);
INSERT INTO LOOKUPRole (RoleName,RoleDescription,RowCreatedSYSUserID,RowModifiedSYSUserID)  
       VALUES ('Member','Read only',1,1);