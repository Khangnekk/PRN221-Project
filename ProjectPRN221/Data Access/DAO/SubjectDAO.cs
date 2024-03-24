using Business_Object.Models;

namespace Data_Access.DAO
{
	public class SubjectDAO : DAO<Subject>
	{
		private static SubjectDAO instance;
		private static readonly object padlock = new object();

		private SubjectDAO() { }
		public static SubjectDAO Instance
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
							instance = new SubjectDAO();
						}
					}
				}
				return instance;
			}
		}

		public Subject GetSubjectById(string subjectId)
		{
			return context.Subjects.SingleOrDefault(s => s.SubjectId == subjectId);
		}
	}
}
