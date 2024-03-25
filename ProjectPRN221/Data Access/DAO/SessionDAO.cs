using Business_Object.Models;
using Data_Access.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.DAO
{
	public class SessionDAO : DAO<Session>
	{
		private static SessionDAO instance;
		private static readonly object padlock = new object();

		private SessionDAO() { }
		public static SessionDAO Instance
		{
			get
			{
				// Double-check locking for thread safety
				if (instance == null)
				{
					lock (padlock)
					{
						if (instance == null)
						{
							instance = new SessionDAO();
						}
					}
				}
				return instance;
			}
		}

		public List<Session> GetSessions()
		{
			return context.Sessions
				.Include(s => s.Group)
				.Include(s => s.Lecturer)
				.Include(s => s.Timeslot)
				.Include(s => s.Room)
				.Where(a => a.Discontinued == false).ToList();
		}

		public void SaveSession(Session session)
		{
			session.Discontinued = false;
			context.Sessions.Add(session);
			var room = context.Rooms.FirstOrDefault(r => r.RoomId == session.RoomId);
			var group = context.Groups.FirstOrDefault(r => r.GroupId == session.GroupId);
			var lecturer = context.Lecturers.FirstOrDefault(r => r.LecturerId == session.LecturerId);
			var timeslot = context.TimeSlots.FirstOrDefault(r => r.TimeslotId == session.TimeslotId);
			context.Entry<Room>(room).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			context.Entry<Group>(group).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			context.Entry<Lecturer>(lecturer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			context.Entry<TimeSlot>(timeslot).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			context.SaveChanges();
		}

		public void SaveRangeSession(List<Session> sessions)
		{
			context.Sessions.AddRange(sessions);

			//context.SaveChanges();	
		}

		public bool IsExistingSession(SessionDTOCreate sessionDTO)
		{
			var existingSession = context.Sessions.FirstOrDefault(s =>
				s.GroupId == sessionDTO.GroupId &&
				s.RoomId == sessionDTO.RoomId &&
				s.Date == sessionDTO.Date &&
				s.TimeslotId == sessionDTO.TimeslotId &&
				s.LecturerId == sessionDTO.LecturerId &&
				s.SessionNo == sessionDTO.SessionNo &&
				s.Online == sessionDTO.Online);
			if (existingSession != null)
				return true;
			return false;
		}
	}
}
