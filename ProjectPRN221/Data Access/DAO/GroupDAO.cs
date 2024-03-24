using Business_Object.Models;

namespace Data_Access.DAO
{
	public class GroupDAO
	{
		private static readonly ProjectPRN221Context context = new ProjectPRN221Context();

		public static Group GetGroupById(string groupId)
		{
			return context.Groups.SingleOrDefault(g => g.GroupId == groupId);
		}
	}
}
