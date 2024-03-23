using Business_Object.Models;

namespace Data_Access.DAO
{
	public class AreaDAO
	{
		private static ProjectPRN221Context context = new ProjectPRN221Context();

		public static List<Area> GetAreas()
		{
			return context.Areas.Where(a => a.Discontinued == false).ToList();
		}
	}
}
