/****** INSERT DATA INTO WAYPOINTSSCHEDULE ASSOCIATION  ******/
SELECT TOP 1000 [ScheduleID]
      ,[WaypointID]
  FROM [dbe23b13d1adfa41179ccfa7bc00f3296d].[dbo].[WaypointsSchedule]

INSERT INTO WaypointsSchedule (ScheduleID, WaypointID)
VALUES (3,3)