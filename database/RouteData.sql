/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [RouteID]
      ,[Name]
      ,[Day]
      ,[IsPrivate]
  FROM [dbe23b13d1adfa41179ccfa7bc00f3296d].[dbo].[Routes]

  INSERT INTO Routes (Name, Day, IsPrivate)
  VALUES ('51 Pearl', 'Wednesday', 0)