/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [RouteID]
      ,[Name]
      ,[Day]
      ,[IsPrivate]
  FROM [dbe23b13d1adfa41179ccfa7bc00f3296d].[dbo].[Routes]

  /**** Run these lines to delete all routes waypoints and Schedules then reset the id's ****/
  DELETE FROM Routes
  DBCC CHECKIDENT (Routes, RESEED, 0)
  DBCC CHECKIDENT (Waypoints, RESEED, 0)
  DBCC CHECKIDENT (Schedules, RESEED, 0)

  INSERT INTO Routes (Name, Day, IsPrivate)
  VALUES ('51 Pearl', 'Wednesday', 0)

  INSERT INTO Routes (Name, Day, IsPrivate)
  VALUES ('45 ridge', 'Wednesday', 0)

  INSERT INTO Routes (Name, Day, IsPrivate)
  VALUES ('26 Detroit', 'Wednesday', 0)

  INSERT INTO Routes (Name, Day, IsPrivate)
  VALUES ('86 Rocky River Dr. - Bagley', 'Wednesday', 1)