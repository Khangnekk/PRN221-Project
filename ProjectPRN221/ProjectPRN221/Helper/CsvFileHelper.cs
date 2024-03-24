using CsvHelper;
using Data_Access.DTOs;
using System.Globalization;

namespace ProjectPRN221.Helper
{
	public static class CsvFileHelper
	{
		public static List<SessionDTORaw> CsvFileReader(Stream reader)
		{
			var records = new List<SessionDTORaw>();
			try
			{
				using (var streamReader = new StreamReader(reader))
				using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
				{
					records = csv.GetRecords<SessionDTORaw>().ToList();
				}
			}
			catch (CsvHelperException ex)
			{
				Console.WriteLine("Error reading CSV file: " + ex.Message);
			}
			return records;
		}
	}
}
