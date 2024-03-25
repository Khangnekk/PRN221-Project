namespace ProjectPRN221.Helper
{
	public class DateTimeHelper
	{
		public static bool IsConvertibleToDateTime(string input)
		{
			return DateTime.TryParse(input, out _);
		}

		public static List<DateTime> GetWeekDates(DateTime date)
		{
			List<DateTime> weekDates = new List<DateTime>();
			DateTime monday = date.AddDays(1 - (int)date.DayOfWeek);
			DateTime sunday = date.AddDays(7 - (int)date.DayOfWeek);
			weekDates = GetDateRange(monday, sunday);
			return weekDates;
		}

		public static List<DateTime> GetDateRange(DateTime startDate, DateTime endDate)
		{
			List<DateTime> dateList = new List<DateTime>();
			for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
			{
				dateList.Add(date);
			}

			return dateList;
		}
	}
}
