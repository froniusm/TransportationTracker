/****** INSERT INTO WAYPOINTS  ******/
SELECT TOP 1000 [WaypointID]
      ,[RouteID]
      ,[Intersection]
      ,[Latitude]
      ,[Longitude]
  FROM [dbe23b13d1adfa41179ccfa7bc00f3296d].[dbo].[Waypoints]

  INSERT INTO Waypoints (RouteID, Intersection, Latitude, Longitude)
  VALUES (1,'intersection',0,0)