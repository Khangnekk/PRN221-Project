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

		public void OnGet()
		{
			Message = string.Empty;
		}

		public void OnPostImportSchedule()
		{
			var fileExtension = Path.GetExtension(FormFile.FileName).ToLower();
			Stream sr = FormFile.OpenReadStream();
			List<SessionDTORaw> sessions = new List<SessionDTORaw>();
			switch (fileExtension)
			{
				case ".json":
					sessions = JsonSerializer.Deserialize<List<SessionDTORaw>>(sr);
					var sessionsAfterConvert = SessionHelper.ConvertToSessionDTOCreates(sessions.FirstOrDefault());
					Message = "✅ Import Schedule: Success";
					break;
				case ".csv":
					sessions = CsvFileHelper.CsvFileReader(sr);
					Message = "✅ Import Schedule: Success";
					break;
				case ".xml":
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<SessionDTORaw>));
					sessions = (List<SessionDTORaw>)xmlSerializer.Deserialize(sr);
					//DBContext.AddRange(services);
					//DBContext.SaveChanges();
					OnGet();
					Message = "✅ Import Schedule: Success";
					break;
				default:
					Message = "❌ Import Schedule: Fail. Cannot read data from file";
					break;
			}
		}
	}
}
