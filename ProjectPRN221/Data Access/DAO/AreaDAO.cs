using Business_Object.Models;

namespace Data_Access.DAO
{
	public class AreaDAO : DAO<Area>
	{
		private static AreaDAO instance;
		private static readonly object padlock = new object();
		private AreaDAO() { }
		public static AreaDAO Instance
		{
			get
			{
				if (instance == null)
				{
					lock (padlock)
					{
						if (instance == null)
						{
							instance = new AreaDAO();
						}
					}
				}
				return instance;
			}
		}

		public List<Area> GetAreas()
		{
			return context.Areas.Where(a => a.Discontinued == false).ToList();
		}
	}
}
