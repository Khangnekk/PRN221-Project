using Data_Access.DAO;
using Data_Access.DTOs;
using Data_Access.Repository;
using Data_Access.Repository.Implement;
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
		public string Message2 { get; set; }
		public List<SessionDTORaw> filterSessionsRaw = new List<SessionDTORaw>();
		public List<SessionDTORaw> nonFilterSessionsRaw = new List<SessionDTORaw>();

		private readonly ISessionRepository sessionRepository = new SessionRepository();
		public void OnGet()
		{
			Message = string.Empty;
			Message2 = string.Empty;
		}

		public void OnPostImportSchedule()
		{
			var fileExtension = Path.GetExtension(FormFile.FileName).ToLower();
			Stream sr = FormFile.OpenReadStream();
			List<SessionDTORaw> originalSessionsRaw = new List<SessionDTORaw>();

			switch (fileExtension)
			{
				case ".json":
					originalSessionsRaw = JsonSerializer.Deserialize<List<SessionDTORaw>>(sr);
					ProcessImport(originalSessionsRaw);
					break;
				case ".csv":
					originalSessionsRaw = CsvFileHelper.CsvFileReader(sr);
					ProcessImport(originalSessionsRaw);
					break;
				case ".xml":
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<SessionDTORaw>));
					ProcessImport(originalSessionsRaw);
					break;
				default:
					Message = "❌ Import Schedule: Fail. Cannot read data from file";
					break;
			}
		}

		void ProcessImport(List<SessionDTORaw> originalSessionsRaw)
		{
			filterSessionsRaw = SessionHelper.GetFinalFilteredSessions(originalSessionsRaw);
			nonFilterSessionsRaw = SessionHelper.GetNonFilteredSessions(originalSessionsRaw, filterSessionsRaw);

			foreach (var session in filterSessionsRaw)
			{
				var sessionsAfterConvert = SessionHelper.ConvertToSessionDTOCreates(session);
				foreach (var item in sessionsAfterConvert)
				{
					Message2 = "🔔 All schedules are new schedules";
					if (SessionDAO.Instance.IsExistingSession(item))
					{
						Message = "✅ Import Schedule Status: Done.";
						Message2 = "⚠️ Automatically skipped duplicate schedules";
					}
					else
					{
						sessionRepository.SaveSessionDTO(item);
						Message = "✅ Import Schedule Status: Done";
					}
				}
			}
		}
	}
}
