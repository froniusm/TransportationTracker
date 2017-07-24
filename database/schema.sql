-- *************************************************************************************************
-- This script creates all of the database objects (tables, constraints, etc) for the database
-- *************************************************************************************************

USE [TransportationDB] 

CREATE TABLE [dbo].[LOOKUPRole](  
    [LOOKUPRoleID] [int] IDENTITY(1,1) NOT NULL,
    [RoleName] [varchar](100) DEFAULT '',
    [RoleDescription] [varchar](500) DEFAULT '',
    [RowCreatedSYSUserID] [int] NOT NULL,
    [RowCreatedDateTime] [datetime]  DEFAULT GETDATE(),
    [RowModifiedSYSUserID] [int] NOT NULL,
    [RowModifiedDateTime] [datetime] DEFAULT GETDATE(),
PRIMARY KEY (LOOKUPRoleID)  
    )


CREATE TABLE [dbo].[SYSUser](  
    [SYSUserID] [int] IDENTITY(1,1) NOT NULL,
    [LoginName] [varchar](50) NOT NULL,
    [PasswordEncryptedText] [varchar](200) NOT NULL,
    [RowCreatedSYSUserID] [int] NOT NULL,
    [RowCreatedDateTime] [datetime] DEFAULT GETDATE(),
    [RowModifiedSYSUserID] [int] NOT NULL,
    [RowMOdifiedDateTime] [datetime] DEFAULT GETDATE(),
    PRIMARY KEY (SYSUserID)
)


CREATE TABLE [dbo].[SYSUserProfile](  
    [SYSUserProfileID] [int] IDENTITY(1,1) NOT NULL,
    [SYSUserID] [int] NOT NULL,
    [FirstName] [varchar](50) NOT NULL,
    [LastName] [varchar](50) NOT NULL,
    [Email] [varchar](100) NOT NULL,
	[PhoneNumber] [varchar](22) NOT NULL,
    [RowCreatedSYSUserID] [int] NOT NULL,
    [RowCreatedDateTime] [datetime] DEFAULT GETDATE(),
    [RowModifiedSYSUserID] [int] NOT NULL,
    [RowModifiedDateTime] [datetime] DEFAULT GETDATE(),
    PRIMARY KEY (SYSUserProfileID)
    )

ALTER TABLE [dbo].[SYSUserProfile]  WITH CHECK ADD FOREIGN KEY([SYSUserID])  
REFERENCES [dbo].[SYSUser] ([SYSUserID])  


CREATE TABLE [dbo].[SYSUserRole](  
    [SYSUserRoleID] [int] IDENTITY(1,1) NOT NULL,
    [SYSUserID] [int] NOT NULL,
    [LOOKUPRoleID] [int] NOT NULL,
    [IsActive] [bit] DEFAULT (1),
    [RowCreatedSYSUserID] [int] NOT NULL,
    [RowCreatedDateTime] [datetime] DEFAULT GETDATE(),
    [RowModifiedSYSUserID] [int] NOT NULL,
    [RowModifiedDateTime] [datetime] DEFAULT GETDATE(),
    PRIMARY KEY (SYSUserRoleID)
)

ALTER TABLE [dbo].[SYSUserRole]  WITH CHECK ADD FOREIGN KEY([LOOKUPRoleID])  
REFERENCES [dbo].[LOOKUPRole] ([LOOKUPRoleID])  

ALTER TABLE [dbo].[SYSUserRole]  WITH CHECK ADD FOREIGN KEY([SYSUserID])  
REFERENCES [dbo].[SYSUser] ([SYSUserID])  


CREATE TABLE [dbo].[Routes] (
	[RouteID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Day] [varchar](10) NOT NULL,
	[IsPrivate] [bit] NOT NULL,
	PRIMARY KEY (RouteID)
)


CREATE TABLE [dbo].[Waypoints] (
	[WaypointID] [int] IDENTITY(1,1) NOT NULL,
	[RouteID] [int] NOT NULL,
	[Intersection] [varchar](200) NOT NULL,
	[Coordinate] [decimal](12,9) NOT NULL,
	PRIMARY KEY (WaypointID)
)

ALTER TABLE [dbo].[Waypoints]  WITH CHECK ADD FOREIGN KEY([RouteID])  
REFERENCES [dbo].[Routes] ([RouteID])  


CREATE TABLE [dbo].[Schedules] (
	[ScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[Sequence] [int] NOT NULL,
	[ETA] [time] NOT NULL,
	PRIMARY KEY (ScheduleID)
)

CREATE TABLE [dbo].[WaypointsSchedule] (
	[ScheduleID] [int] NOT NULL,
	[WaypointID] [int] NOT NULL,
	PRIMARY KEY (ScheduleID, WaypointID)
)

ALTER TABLE [dbo].[WaypointsSchedule] WITH CHECK ADD FOREIGN KEY ([ScheduleID])
REFERENCES [dbo].[Schedules] ([ScheduleID])

ALTER TABLE [dbo].[WaypointsSchedule] WITH CHECK ADD FOREIGN KEY ([WaypointID])
REFERENCES [dbo].[Waypoints] ([WaypointID])


CREATE TABLE [dbo].[UserRoutes] (
	[SYSUserID] [int] NOT NULL,
	[RouteID] [int] NOT NULL,
	PRIMARY KEY (SYSUserID, RouteID)
)

ALTER TABLE [dbo].[UserRoutes] WITH CHECK ADD FOREIGN KEY ([SYSUserID])
REFERENCES [dbo].[SYSUser] ([SYSUserID])

ALTER TABLE [dbo].[UserRoutes] WITH CHECK ADD FOREIGN KEY ([RouteID])
REFERENCES [dbo].[Routes] ([RouteID])

