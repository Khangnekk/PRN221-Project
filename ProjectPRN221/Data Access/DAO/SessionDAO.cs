using Business_Object.Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.DAO
{
	public class SessionDAO
	{
		private static ProjectPRN221Context context = new ProjectPRN221Context();

		public static List<Session> GetSessions()
		{
			return context.Sessions
				.Include(s => s.Group)
				.Include(s => s.Lecturer)
				.Include(s => s.Timeslot)
				.Include(s => s.Room)
				.Where(a => a.Discontinued == false).ToList();
		}
	}
}
