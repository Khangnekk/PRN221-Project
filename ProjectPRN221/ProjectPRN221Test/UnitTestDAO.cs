using Data_Access.DAO;

namespace ProjectPRN221Test
{
	public class UnitTestDAO
	{
		[Test]
		public void TestGetAreas()
		{
			var listAreas = AreaDAO.Instance.GetAreas();
			Assert.AreEqual(5, listAreas.Count);
		}
	}
}
