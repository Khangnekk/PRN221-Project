using Business_Object.Models;
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

			//context.SaveChanges();
		}

		public void SaveRangeSession(List<Session> sessions)
		{
			context.Sessions.AddRange(sessions);

			//context.SaveChanges();	
		}
	}
}
