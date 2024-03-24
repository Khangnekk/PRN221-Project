using Data_Access.DAO;
using Data_Access.DTOs;

namespace ProjectPRN221.Helper
{
	public class SessionHelper
	{
		public static List<SessionDTOCreate> ConvertToSessionDTOCreates(SessionDTORaw rawSession)
		{
			List<SessionDTOCreate> sessionDTOCreates = new List<SessionDTOCreate>();

			GroupDTOCreate group = new GroupDTOCreate();
			group.GroupId = rawSession.GroupId;
			group.SubjectId = rawSession.SubjectId;
			group.LecturerId = rawSession.LecturerId;
			group.Year = rawSession.FirstDate.Year.ToString();
			group.Discontinued = false;
			group.Subject = SubjectDAO.Instance.GetSubjectById(rawSession.SubjectId);


			char[] delimiters = { 'A', 'P' };
			string[] times = rawSession.TimeslotRaw.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

			foreach (var time in times)
			{
				char[] timeChars = time.ToCharArray();

				//int timeslotId = int.Parse(timeChars[0].ToString());
				List<DayOfWeek> daysOfWeek = new List<DayOfWeek>();

				for (int i = 0; i < timeChars.Length; i++)
				{
					switch (timeChars[i])
					{
						case '2':
							daysOfWeek.Add(DayOfWeek.Monday);
							break;
						case '3':
							daysOfWeek.Add(DayOfWeek.Tuesday);
							break;
						case '4':
							daysOfWeek.Add(DayOfWeek.Wednesday);
							break;
						case '5':
							daysOfWeek.Add(DayOfWeek.Thursday);
							break;
						case '6':
							daysOfWeek.Add(DayOfWeek.Friday);
							break;
						case '7':
							daysOfWeek.Add(DayOfWeek.Saturday);
							break;
						case '8':
							daysOfWeek.Add(DayOfWeek.Sunday);
							break;
					}
				}

				DateTime currentDate = rawSession.FirstDate;
				int sessionCount = 0;

				while (sessionCount < rawSession.TotalSession)
				{
					foreach (var dayOfWeek in daysOfWeek)
					{
						if (sessionCount >= rawSession.TotalSession)
							break;

						if (currentDate.DayOfWeek == dayOfWeek)
						{

							// New SessionDTOCreate
							SessionDTOCreate sessionDTOCreate = new SessionDTOCreate();
							sessionDTOCreate.GroupId = rawSession.GroupId;
							sessionDTOCreate.RoomId = RoomDAO.Instance.GetRoomByRoomRaw(rawSession.RoomRaw).RoomId;
							sessionDTOCreate.Date = currentDate;
							sessionDTOCreate.LecturerId = rawSession.LecturerId;
							sessionDTOCreate.SessionNo = sessionCount + 1;
							sessionDTOCreate.Online = rawSession.Online;
							// TimeSlot Handler
							if (rawSession.TimeslotRaw.StartsWith("A"))
							{
								if (sessionDTOCreate.SessionNo % 2 != 0)
									sessionDTOCreate.TimeslotId = 1;
								else
									sessionDTOCreate.TimeslotId = 2;
							}
							else if (rawSession.TimeslotRaw.StartsWith("P"))
							{
								if (sessionDTOCreate.SessionNo % 2 != 0)
									sessionDTOCreate.TimeslotId = 3;
								else
									sessionDTOCreate.TimeslotId = 4;
							}
							// Add Object
							sessionDTOCreate.Room = RoomDAO.Instance.GetRoomByRoomRaw(rawSession.RoomRaw);
							sessionDTOCreate.Lecturer = LecturerDAO.Instance.GetLecturerById(rawSession.LecturerId);
							sessionDTOCreate.Timeslot = TimeSlotDAO.Instance.GetTimeSlotById(sessionDTOCreate.TimeslotId);
							sessionDTOCreate.Group = group;
							sessionDTOCreates.Add(sessionDTOCreate);
							sessionCount++;
						}
					}

					currentDate = currentDate.AddDays(1);
				}
			}

			return sessionDTOCreates;
		}

		public static List<SessionDTORaw> GetFinalFilteredSessions(List<SessionDTORaw> sessions)
		{
			sessions = FilterSessionDTORaws_ByGroupTimeslotAndSubject(sessions);

			sessions = FilterSessionDTORaws_ByGroupTimeslotAndRoom(sessions);

			sessions = FilterSessionDTORawsBy_GroupTimeslotAndLecturer(sessions);

			sessions = FilterSessionDTORawsBy_GroupTimeslotAndSameLecturer(sessions);

			return sessions;
		}

		public static List<SessionDTORaw> GetNonFilteredSessions(List<SessionDTORaw> originalSessions, List<SessionDTORaw> filteredSessions)
		{
			List<SessionDTORaw> nonFilteredSessions = originalSessions.Except(filteredSessions).ToList();

			return nonFilteredSessions;
		}

		// Same Group, Same TimeSlot, Has Different Subject 
		public static List<SessionDTORaw> FilterSessionDTORaws_ByGroupTimeslotAndSubject(List<SessionDTORaw> sessions)
		{
			List<SessionDTORaw> filteredSessions = new List<SessionDTORaw>();

			foreach (var session in sessions)
			{
				bool hasDifferentSubject = filteredSessions.Any(s =>
					s.GroupId == session.GroupId &&
					s.TimeslotRaw == session.TimeslotRaw &&
					s.SubjectId != session.SubjectId);

				if (!hasDifferentSubject)
				{
					filteredSessions.Add(session);
				}
			}

			return filteredSessions;
		}

		// Same Group, Same TimeSlot, Has Different Room 
		public static List<SessionDTORaw> FilterSessionDTORaws_ByGroupTimeslotAndRoom(List<SessionDTORaw> sessions)
		{
			List<SessionDTORaw> filteredSessions = new List<SessionDTORaw>();

			foreach (var session in sessions)
			{
				bool hasDifferentRoomRaw = filteredSessions.Any(s =>
					s.GroupId == session.GroupId &&
					s.TimeslotRaw == session.TimeslotRaw &&
					s.RoomRaw != session.RoomRaw);

				if (!hasDifferentRoomRaw)
				{
					filteredSessions.Add(session);
				}
			}

			return filteredSessions;
		}

		// Same Group, Same TimeSlot, Has Different Lecturer 
		public static List<SessionDTORaw> FilterSessionDTORawsBy_GroupTimeslotAndLecturer(List<SessionDTORaw> sessions)
		{
			List<SessionDTORaw> filteredSessions = new List<SessionDTORaw>();

			foreach (var session in sessions)
			{
				bool hasDifferentLecturer = filteredSessions.Any(s =>
					s.GroupId == session.GroupId &&
					s.TimeslotRaw == session.TimeslotRaw &&
					s.LecturerId != session.LecturerId);

				if (!hasDifferentLecturer)
				{
					filteredSessions.Add(session);
				}
			}

			return filteredSessions;
		}

		// Same Lecturer, Same TimeSlot, Has Different Group
		public static List<SessionDTORaw> FilterSessionDTORawsBy_GroupTimeslotAndSameLecturer(List<SessionDTORaw> sessions)
		{
			List<SessionDTORaw> filteredSessions = new List<SessionDTORaw>();

			foreach (var session in sessions)
			{
				bool hasDifferentGroup = filteredSessions.Any(s =>
					s.GroupId != session.GroupId &&
					s.TimeslotRaw == session.TimeslotRaw &&
					s.LecturerId == session.LecturerId);

				if (!hasDifferentGroup)
				{
					filteredSessions.Add(session);
				}
			}

			return filteredSessions;
		}

	}
}
