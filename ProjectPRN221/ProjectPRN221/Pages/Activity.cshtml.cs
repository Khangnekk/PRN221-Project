using Data_Access.DTOs;
using Data_Access.Repository;
using Data_Access.Repository.Implement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN221.Helper;
namespace ProjectPRN221.Pages
{
	public class ActivityModel : PageModel
	{
		private readonly IAreaRepository areaRepository = new AreaRepository();
		private readonly ITimeSlotRepository timeSlotRepository = new TimeSlotRepository();
		private readonly ISessionRepository sessionRepository = new SessionRepository();
		private readonly IRoomRepository roomRepository = new RoomRepository();

		private IHttpContextAccessor httpContextAccessor;

		public ActivityModel(IHttpContextAccessor httpContextAccessor)
		{
			this.httpContextAccessor = httpContextAccessor;
		}

		public List<AreaDTO> Areas { get; set; }
		public List<TimeSlotDTO> TimeSlots { get; set; }
		public List<SessionDTO> CurrentSessions { get; set; }
		public List<RoomDTO> CurrentRooms { get; set; }

		public string Message { get; set; }

		[BindProperty]
		public string AreaId { get; set; }
		[BindProperty]
		public string DateView { get; set; }
		[BindProperty(SupportsGet = true)]
		public string LecturerId { get; set; }

		void GetData()
		{
			Areas = areaRepository.GetAllAreas();
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

		public void OnPostView()
		{
			GetData();
			CurrentRooms = roomRepository.GetRoomDTOsByAreaId(AreaId);
			WebSessionHelper webSessionHelper = new WebSessionHelper(httpContextAccessor.HttpContext!.Session);
			CurrentSessions = webSessionHelper.GetSessionDTOs();
			CurrentSessions = CurrentSessions.Where(cs => cs.Date == DateTime.Parse(DateView)).ToList();
			LecturerId = webSessionHelper.GetCurrentLecturerId();
		}
	}
}
