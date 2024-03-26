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
				.ThenInclude(s => s.Subject)
				.Include(s => s.Lecturer)
				.Include(s => s.Timeslot)
				.Include(s => s.Room)
				.Where(a => a.Discontinued == false).ToList();
		}

		public Session GetSessionById(int sessionId)
		{
			Session? session = new Session();
			session = context.Sessions
				.Include(s => s.Group)
				.ThenInclude(s => s.Subject)
				.Include(s => s.Lecturer)
				.Include(s => s.Timeslot)
				.Include(s => s.Room)
				.FirstOrDefault(s => s.SessionId == sessionId && s.Discontinued == false);
			return session;
		}

		public List<Session> GetSessionsByLecturerId(string lecturerId)
		{
			List<Session> sessions = GetSessions()
				.Where(s => s.LecturerId == lecturerId)
				.ToList();
			return sessions;
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

		public string UpdateSessionAsync(Session updatedSession)
		{
			try
			{
				var existingSession = context.Sessions.FirstOrDefault(s => s.SessionId == updatedSession.SessionId);

				if (existingSession == null)
				{
					return "Session not found.";
				}

				// Check if the updated session conflicts with another session
				var conflictingSession = context.Sessions.FirstOrDefault(s =>
					s.SessionId != updatedSession.SessionId &&
					s.Date == updatedSession.Date &&
					s.TimeslotId == updatedSession.TimeslotId);

				if (conflictingSession != null)
				{
					return "The updated overlaps slot with another session";
				}

				// Check if there's already a session with the same lecturer, date, and timeslot
				var existingLecturerSession = context.Sessions.FirstOrDefault(s =>
					s.SessionId != updatedSession.SessionId &&
					s.LecturerId == updatedSession.LecturerId &&
					s.Date == updatedSession.Date &&
					s.TimeslotId == updatedSession.TimeslotId);

				if (existingLecturerSession != null)
				{
					return "Another session with the same lecturer already exists for the given date and timeslot.";
				}

				// Check if there's a session with the same room, date, and timeslot
				var existingRoomSession = context.Sessions.FirstOrDefault(s =>
					s.SessionId != updatedSession.SessionId &&
					s.RoomId == updatedSession.RoomId &&
					s.Date == updatedSession.Date &&
					s.TimeslotId == updatedSession.TimeslotId);

				if (existingRoomSession != null)
				{
					return "Another session with the same room already exists for the given date and timeslot.";
				}

				// Update the session and save changes
				existingSession.GroupId = updatedSession.GroupId;
				existingSession.RoomId = updatedSession.RoomId;
				existingSession.Date = updatedSession.Date;
				existingSession.TimeslotId = updatedSession.TimeslotId;
				existingSession.LecturerId = updatedSession.LecturerId;
				existingSession.SessionNo = updatedSession.SessionNo;
				existingSession.Online = updatedSession.Online;
				existingSession.Discontinued = updatedSession.Discontinued;

				context.SaveChangesAsync();

				return "Session updated successfully.";
			}
			catch (Exception ex)
			{
				return $"Error updating session: {ex.Message}";
			}
		}
	}
}
