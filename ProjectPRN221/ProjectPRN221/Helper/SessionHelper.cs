using Data_Access.DAO;
using Data_Access.DTOs;

namespace ProjectPRN221.Helper
{
	public class SessionHelper
	{
		public static List<SessionDTOCreate> ConvertToSessionDTOCreates(SessionDTORaw rawSession)
		{
			List<SessionDTOCreate> sessionDTOCreates = new List<SessionDTOCreate>();

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
							SessionDTOCreate sessionDTOCreate = new SessionDTOCreate();
							sessionDTOCreate.GroupId = rawSession.GroupId;
							sessionDTOCreate.RoomId = RoomDAO.GetRoomByRoomRaw(rawSession.RoomRaw).RoomId;
							sessionDTOCreate.Date = currentDate;
							//TimeslotId = timeslotId,
							sessionDTOCreate.LecturerId = rawSession.LecturerId;
							sessionDTOCreate.SessionNo = sessionCount + 1;
							sessionDTOCreate.Online = rawSession.Online;

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

							sessionDTOCreate.Room = RoomDAO.GetRoomByRoomRaw(rawSession.RoomRaw);
							sessionDTOCreate.Lecturer = LecturerDAO.GetLecturerById(rawSession.LecturerId);
							sessionDTOCreate.Timeslot = TimeSlotDAO.GetTimeSlotById(sessionDTOCreate.TimeslotId);
							sessionDTOCreate.Group = GroupDAO.GetGroupById(rawSession.GroupId);
							sessionDTOCreate.Group.Subject = SubjectDAO.GetSubjectById(rawSession.SubjectId);


							sessionDTOCreates.Add(sessionDTOCreate);
							sessionCount++;
						}
					}

					currentDate = currentDate.AddDays(1);
				}
			}

			return sessionDTOCreates;
		}
	}
}
