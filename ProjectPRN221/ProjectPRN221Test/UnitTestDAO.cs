using Business_Object.Models;
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

		public void TestGetGroupById()
		{
			string groupName = "SE1601";
			string subjectId = "PRN211";
			Group group = GroupDAO.Instance.GetGroupByGroupNameAndSubjectId(groupName, subjectId);
			Assert.AreEqual(groupName, group.GroupName);
		}
	}
}
