using Data_Access.DTOs;
using Data_Access.Repository;
using Data_Access.Repository.Implement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN221.Helper;
using System.Data;

namespace ProjectPRN221.Pages
{
	public class ActivityAllModel : PageModel
	{

		private IHttpContextAccessor httpContextAccessor;
		private readonly ITimeSlotRepository timeSlotRepository = new TimeSlotRepository();
		private readonly ISessionRepository sessionRepository = new SessionRepository();
		public List<TimeSlotDTO> TimeSlots { get; set; }
		[BindProperty]
		public string requireDate { get; set; }
		public List<DateTime> WeekDates { get; set; }
		[BindProperty(SupportsGet = true)]
		public string LecturerId { get; set; }
		public List<SessionDTO> CurrentSessions { get; set; }
		public string Message { get; set; }
		public ActivityAllModel(IHttpContextAccessor httpContextAccessor)
		{
			this.httpContextAccessor = httpContextAccessor;
			this.WeekDates = new List<DateTime>();
		}
		void GetData()
		{
			TimeSlots = timeSlotRepository.GetTimeSlots();
		}

		public void OnGet()
		{
			GetData();
		}

		public void OnPostSearch()
		{
			GetData();
			WebSessionHelper webSessionHelper = new WebSessionHelper(httpContextAccessor.HttpContext!.Session);
			webSessionHelper.SetCurrentLecturerId(LecturerId);
			CurrentSessions = sessionRepository.GetSessionsByLecturerId(LecturerId);
			webSessionHelper.SetSessionDTOs(CurrentSessions);
		}

		public void OnPostViewThisWeek()
		{
			GetData();
			WeekDates = DateTimeHelper.GetWeekDates(DateTime.Parse(requireDate));
			WebSessionHelper webSessionHelper = new WebSessionHelper(httpContextAccessor.HttpContext!.Session);
			CurrentSessions = webSessionHelper.GetSessionDTOs();
			CurrentSessions = CurrentSessions
				.Where(cs => cs.Date >= WeekDates.FirstOrDefault()
				&& cs.Date <= WeekDates.LastOrDefault())
				.ToList();
		}
	}
}
