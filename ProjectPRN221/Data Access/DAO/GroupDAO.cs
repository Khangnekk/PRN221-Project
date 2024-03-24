using Business_Object.Models;

namespace Data_Access.DAO
{
	public class GroupDAO : DAO<Group>
	{
		private static GroupDAO instance;
		private static readonly object padlock = new object();

		private GroupDAO() { }
		public static GroupDAO Instance
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
							instance = new GroupDAO();
						}
					}
				}
				return instance;
			}
		}

		public Group GetGroupByGroupNameAndSubjectId(string groupname, string subjectId)
		{
			return context.Groups.SingleOrDefault(g => g.GroupName == groupname && g.SubjectId == subjectId);
		}

		public void SaveGroup(Group newGroup)
		{
			newGroup.Discontinued = false;
			context.Groups.Add(newGroup);
			var subject = context.Subjects.FirstOrDefault(s => s.SubjectId == newGroup.SubjectId);
			context.Entry<Subject>(subject).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			context.SaveChanges();
		}
	}
}
