namespace ProjectPRN221.Helper
{
	public class DateTimeHelper
	{
		public static bool IsConvertibleToDateTime(string input)
		{
			return DateTime.TryParse(input, out _);
		}
	}
}
