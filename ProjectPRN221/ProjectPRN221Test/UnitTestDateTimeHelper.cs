using ProjectPRN221.Helper;

namespace ProjectPRN221Test
{
	internal class UnitTestDateTimeHelper
	{
		[Test]
		public void TestGetMonday()
		{
			DateTime expectDate = DateTime.Parse("2024-03-18");
			DateTime ranDate = DateTime.Parse("2024-03-18");
			DateTime date = DateTime.Parse("2024-03-24");
			int iGivenDate = (int)date.DayOfWeek;
			int iExpectDate = (int)expectDate.DayOfWeek;
			int iRanDate = (int)ranDate.DayOfWeek;
			List<DateTime> ex = DateTimeHelper.GetDateRange(expectDate, date);
			List<DateTime> ac = DateTimeHelper.GetWeekDates(ranDate);
			Assert.AreEqual(ex, ac);
		}
	}
}
