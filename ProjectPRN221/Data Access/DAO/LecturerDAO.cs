using Business_Object.Models;

namespace Data_Access.DAO
{
	public class LecturerDAO
	{
		private static readonly ProjectPRN221Context context = new ProjectPRN221Context();
		public static Lecturer GetLecturerById(string lecturerId)
		{
			return context.Lecturers.SingleOrDefault(l => l.LecturerId == lecturerId);
		}
	}
}
