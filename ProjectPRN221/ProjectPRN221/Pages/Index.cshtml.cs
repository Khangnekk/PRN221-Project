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
		public List<SessionDTORaw> filterSessionsRaw = new List<SessionDTORaw>();
		public List<SessionDTORaw> nonFilterSessionsRaw = new List<SessionDTORaw>();

		private readonly ISessionRepository sessionRepository = new SessionRepository();
		public void OnGet()
		{
			Message = string.Empty;
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
					filterSessionsRaw = SessionHelper.GetFinalFilteredSessions(originalSessionsRaw);
					nonFilterSessionsRaw = SessionHelper.GetNonFilteredSessions(originalSessionsRaw, filterSessionsRaw);

					foreach (var session in filterSessionsRaw)
					{
						var sessionsAfterConvert = SessionHelper.ConvertToSessionDTOCreates(session);
						foreach (var item in sessionsAfterConvert)
						{
							sessionRepository.SaveSessionDTO(item);
						}
						//sessionRepository.SaveRangeSession(sessionsAfterConvert);
					}

					Message = "✅ Import Schedule Status: Done";
					break;
				case ".csv":
					originalSessionsRaw = CsvFileHelper.CsvFileReader(sr);
					filterSessionsRaw = SessionHelper.GetFinalFilteredSessions(originalSessionsRaw);
					nonFilterSessionsRaw = SessionHelper.GetNonFilteredSessions(originalSessionsRaw, filterSessionsRaw);

					foreach (var session in filterSessionsRaw)
					{
						var sessionsAfterConvert = SessionHelper.ConvertToSessionDTOCreates(session);

					}
					Message = "✅ Import Schedule Status: Done";
					break;
				case ".xml":
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<SessionDTORaw>));
					originalSessionsRaw = (List<SessionDTORaw>)xmlSerializer.Deserialize(sr);
					filterSessionsRaw = SessionHelper.GetFinalFilteredSessions(originalSessionsRaw);
					nonFilterSessionsRaw = SessionHelper.GetNonFilteredSessions(originalSessionsRaw, filterSessionsRaw);

					foreach (var session in filterSessionsRaw)
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
