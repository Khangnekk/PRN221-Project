using Business_Object.Models;

namespace Data_Access.DAO
{
	public abstract class DAO<T>
	{
		protected ProjectPRN221Context context;

		protected DAO()
		{
			context = new ProjectPRN221Context();
		}
	}
}
