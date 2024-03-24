using Data_Access.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN221.Helper;
using System.Text.Json;
using System.Xml.Serialization;

namespace ProjectPRN221.Pages
{
	public class IndexModel : PageModel
	{

		[BindProperty]
		public IFormFile FormFile { get; set; }
		public string Message { get; set; }
		public List<SessionDTORaw> filterSessions = new List<SessionDTORaw>();
		public List<SessionDTORaw> nonFilterSessions = new List<SessionDTORaw>();

		public void OnGet()
		{
			Message = string.Empty;
		}

		public void OnPostImportSchedule()
		{
			var fileExtension = Path.GetExtension(FormFile.FileName).ToLower();
			Stream sr = FormFile.OpenReadStream();
			List<SessionDTORaw> originalSessions = new List<SessionDTORaw>();

			switch (fileExtension)
			{
				case ".json":
					originalSessions = JsonSerializer.Deserialize<List<SessionDTORaw>>(sr);
					filterSessions = SessionHelper.GetFinalFilteredSessions(originalSessions);
					nonFilterSessions = SessionHelper.GetNonFilteredSessions(originalSessions, filterSessions);

					foreach (var session in filterSessions)
					{
						var sessionsAfterConvert = SessionHelper.ConvertToSessionDTOCreates(session);

					}

					Message = "✅ Import Schedule Status: Done";
					break;
				case ".csv":
					originalSessions = CsvFileHelper.CsvFileReader(sr);
					filterSessions = SessionHelper.GetFinalFilteredSessions(originalSessions);
					nonFilterSessions = SessionHelper.GetNonFilteredSessions(originalSessions, filterSessions);

					foreach (var session in filterSessions)
					{
						var sessionsAfterConvert = SessionHelper.ConvertToSessionDTOCreates(session);

					}
					Message = "✅ Import Schedule Status: Done";
					break;
				case ".xml":
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<SessionDTORaw>));
					originalSessions = (List<SessionDTORaw>)xmlSerializer.Deserialize(sr);
					filterSessions = SessionHelper.GetFinalFilteredSessions(originalSessions);
					nonFilterSessions = SessionHelper.GetNonFilteredSessions(originalSessions, filterSessions);

					foreach (var session in filterSessions)
					{
						var sessionsAfterConvert = SessionHelper.ConvertToSessionDTOCreates(session);

					}
					//DBContext.AddRange(services);
					//DBContext.SaveChanges();
					OnGet();
					Message = "✅ Import Schedule Status: Done";
					break;
				default:
					Message = "❌ Import Schedule: Fail. Cannot read data from file";
					break;
			}
		}
	}
}
