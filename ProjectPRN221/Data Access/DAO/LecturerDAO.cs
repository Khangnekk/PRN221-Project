using Business_Object.Models;

namespace Data_Access.DAO
{
	public class LecturerDAO : DAO<Lecturer>
	{
		private static LecturerDAO instance;
		private static readonly object padlock = new object();

		private LecturerDAO() { }
		public static LecturerDAO Instance
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
							instance = new LecturerDAO();
						}
					}
				}
				return instance;
			}
		}
		public Lecturer GetLecturerById(string lecturerId)
		{
			return context.Lecturers.SingleOrDefault(l => l.LecturerId == lecturerId);
		}
	}
}
