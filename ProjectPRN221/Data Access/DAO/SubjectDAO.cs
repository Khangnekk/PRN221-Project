using Business_Object.Models;

namespace Data_Access.DAO
{
	public class SubjectDAO
	{
		private static readonly ProjectPRN221Context context = new ProjectPRN221Context();

		public static Subject GetSubjectById(string subjectId)
		{
			return context.Subjects.SingleOrDefault(s => s.SubjectId == subjectId);
		}
	}
}
