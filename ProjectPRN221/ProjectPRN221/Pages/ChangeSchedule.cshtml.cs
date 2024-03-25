using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN221.Helper;

namespace ProjectPRN221.Pages
{
	public class ChangeScheduleModel : PageModel
	{
		private IHttpContextAccessor httpContextAccessor;

		public ChangeScheduleModel(IHttpContextAccessor httpContextAccessor)
		{
			this.httpContextAccessor = httpContextAccessor;
		}
		[BindProperty]
		public int SessionID { get; set; }

		public void OnGet(int SessionId)
		{
			SessionID = SessionId;
			WebSessionHelper webSessionHelper = new WebSessionHelper(httpContextAccessor.HttpContext!.Session);
			webSessionHelper.SetCurrentSessionId(SessionID);
		}
	}
}
