using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectPRN221.Pages
{
	public class IndexModel : PageModel
	{

		[BindProperty]
		public IFormFile FormFile { get; set; }
		public string Message { get; set; }
		public IndexModel()
		{

		}

		public void OnGet()
		{
			Message = string.Empty;
		}

		public void OnPost()
		{
			if (ValidateFile(FormFile))
			{
				Stream sr = FormFile.OpenReadStream();
				Message = "✅ Import Schedule: Success";
			}
			else
			{
				Message = "❌ Import Schedule: Failur. Only JSON, CSV, and XML files are allowed.";
				Page();
			}
		}

		private bool ValidateFile(IFormFile file)
		{
			if (file == null || file.Length == 0)
			{
				return false;
			}

			var allowedExtensions = new[] { ".json", ".csv", ".xml" };
			var fileExtension = Path.GetExtension(file.FileName).ToLower();

			if (!allowedExtensions.Contains(fileExtension))
			{
				return false;
			}

			return true;
		}

	}
}
