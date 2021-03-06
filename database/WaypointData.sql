/****** INSERT INTO WAYPOINTS  ******/
SELECT TOP 1000 [WaypointID]
      ,[RouteID]
      ,[Intersection]
      ,[Latitude]
      ,[Longitude]
  FROM [dbe23b13d1adfa41179ccfa7bc00f3296d].[dbo].[Waypoints]

  /****** INSERT INTO 51 Pearl WAYPOINTS  ******/
  INSERT INTO Waypoints (RouteID, Intersection, Latitude, Longitude)
  VALUES (1,'Ridge & Pearl',0,0)

  INSERT INTO Waypoints (RouteID, Intersection, Latitude, Longitude)
  VALUES (1,'York & Pearl',0,0)

  INSERT INTO Waypoints (RouteID, Intersection, Latitude, Longitude)
  VALUES (1,'West 130th & Pearl',0,0)

  INSERT INTO Waypoints (RouteID, Intersection, Latitude, Longitude)
  VALUES (1,'Smith & Pearl',0,0)

  /****** INSERT INTO 45 Ridge WAYPOINTS  ******/
  INSERT INTO Waypoints (RouteID, Intersection, Latitude, Longitude)
  VALUES (2,'Parma Transit Center',0,0)

  INSERT INTO Waypoints (RouteID, Intersection, Latitude, Longitude)
  VALUES (2,'Ridge & Brookpark',0,0)

  INSERT INTO Waypoints (RouteID, Intersection, Latitude, Longitude)
  VALUES (2,'Denison & Ridge',0,0)

  INSERT INTO Waypoints (RouteID, Intersection, Latitude, Longitude)
  VALUES (2,'E 12 & Rockwell',0,0)

  /****** INSERT INTO 26 Detroit WAYPOINTS  ******/
  INSERT INTO Waypoints (RouteID, Intersection, Latitude, Longitude)
  VALUES (3,'Rocky River Loop',0,0)

  INSERT INTO Waypoints (RouteID, Intersection, Latitude, Longitude)
  VALUES (3,'Detroit & Warren',0,0)

  INSERT INTO Waypoints (RouteID, Intersection, Latitude, Longitude)
  VALUES (3,'W 65 & Detroit',0,0)

  INSERT INTO Waypoints (RouteID, Intersection, Latitude, Longitude)
  VALUES (3,'Superior & W 3',0,0)

  /****** INSERT INTO 86 Rocky River(PRIVATE ROUTE) WAYPOINTS  ******/
  INSERT INTO Waypoints (RouteID, Intersection, Latitude, Longitude)
  VALUES (4,'Pearl & Bagley',0,0)

  INSERT INTO Waypoints (RouteID, Intersection, Latitude, Longitude)
  VALUES (4,'Front & Bagley',0,0)

  INSERT INTO Waypoints (RouteID, Intersection, Latitude, Longitude)
  VALUES (4,'Brookpark Rapid Station',0,0)

  INSERT INTO Waypoints (RouteID, Intersection, Latitude, Longitude)
  VALUES (4,'Lorain & Rocky River',0,0)