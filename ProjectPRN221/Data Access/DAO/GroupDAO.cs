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

		public Group GetGroupById(string groupId)
		{
			return context.Groups.SingleOrDefault(g => g.GroupId == groupId);
		}

		//public static void 
	}
}
