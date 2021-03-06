/****** INSERT INTO SCHEDULES ******/
SELECT TOP 1000 [ScheduleID]
      ,[Sequence]
      ,[ETA]
	  ,[WaypointID]
  FROM [dbe23b13d1adfa41179ccfa7bc00f3296d].[dbo].[Schedules]

  /**** Run these lines together to reset the id's ****/
  DELETE FROM Schedules


/******ROUTE: 51 Pearl******/
	/******SCHEDULES FOR WAYPOINT: RIDGE AND PEARL******/
  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (1, '8:00', 1)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (2, '8:30', 1)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (3, '9:00', 1)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (4, '9:30', 1)

  /****** SCHEDULES FOR WAYPOINT: York and Pearl******/
  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (1, '9:00', 2)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (2, '10:00', 2)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (3, '10:30', 2)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (4, '11:00', 2)

  /****** SCHEDULES FOR WAYPOINT: West 130th and Pearl******/
  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (1, '9:30', 3)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (2, '10:00', 3)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (3, '10:30', 3)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (4, '11:00', 3)

  /****** SCHEDULES FOR WAYPOINT: Smith and Pearl******/
  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (1, '9:30', 4)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (2, '10:00', 4)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (3, '10:30', 4)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (4, '11:00', 4)


/******ROUTE: 45 Ridge******/
	/******SCHEDULES FOR WAYPOINT: Parma Transit Center******/
  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (1, '8:00', 5)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (2, '8:30', 5)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (3, '9:00', 5)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (4, '9:30', 5)

  /****** SCHEDULES FOR WAYPOINT: Ridge & Brookpark******/
  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (1, '9:00', 6)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (2, '10:00', 6)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (3, '10:30', 6)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (4, '11:00', 6)

  /****** SCHEDULES FOR WAYPOINT: Denison & Ridge******/
  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (1, '9:30', 7)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (2, '10:00', 7)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (3, '10:30', 7)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (4, '11:00', 7)

  /****** SCHEDULES FOR WAYPOINT: E 12 & Rockwell******/
  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (1, '9:30', 8)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (2, '10:00', 8)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (3, '10:30', 8)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (4, '11:00', 8)

  
/******ROUTE: 26 Detroit WAYPOINTS******/
	/******SCHEDULES FOR WAYPOINT: Rocky River Loop******/
  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (1, '8:00', 9)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (2, '8:30', 9)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (3, '9:00', 9)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (4, '9:30', 9)

  /****** SCHEDULES FOR WAYPOINT: Detroit & Warren******/
  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (1, '9:00', 10)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (2, '10:00', 10)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (3, '10:30', 10)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (4, '11:00', 10)

  /****** SCHEDULES FOR WAYPOINT: W 65 & Detroit******/
  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (1, '9:30', 11)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (2, '10:00', 11)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (3, '10:30', 11)
  
  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (4, '11:00', 11)

  /****** SCHEDULES FOR WAYPOINT: Superior & W 3******/
  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (1, '9:30', 12)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (2, '10:00', 12)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (3, '10:30', 12)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (4, '11:00', 12)

    
/******ROUTE: 26 Detroit WAYPOINTS******/
	/******SCHEDULES FOR WAYPOINT: Pearl & Bagley******/
  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (1, '8:00', 13)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (2, '8:30', 13)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (3, '9:00', 13)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (4, '9:30', 13)

  /****** SCHEDULES FOR WAYPOINT: Front & Bagley******/
  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (1, '9:00', 14)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (2, '10:00', 14)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (3, '10:30', 14)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (4, '11:00', 14)

  /****** SCHEDULES FOR WAYPOINT: Brookpark Rapid Station******/
  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (1, '9:30', 15)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (2, '10:00', 15)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (3, '10:30', 15)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (4, '11:00', 15)

  /****** SCHEDULES FOR WAYPOINT: Lorain & Rocky River******/
  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (1, '9:30', 16)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (2, '10:00', 16)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (3, '10:30', 16)

  INSERT INTO Schedules (Sequence, ETA, WaypointID)
  VALUES (4, '11:00', 16)
