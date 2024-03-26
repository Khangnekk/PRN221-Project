using Data_Access.DTOs;
using Data_Access.Repository;
using Data_Access.Repository.Implement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN221.Helper;

namespace ProjectPRN221.Pages
{
	public class ChangeScheduleModel : PageModel
	{
		private IHttpContextAccessor httpContextAccessor;
		private readonly ISessionRepository sessionRepository = new SessionRepository();
		private readonly ITimeSlotRepository timeSlotRepository = new TimeSlotRepository();
		private readonly IRoomRepository roomRepository = new RoomRepository();
		public ChangeScheduleModel(IHttpContextAccessor httpContextAccessor)
		{
			this.httpContextAccessor = httpContextAccessor;
		}
		[BindProperty]
		public int SessionID { get; set; }
		public SessionDTO CurrentChangeSession { get; set; }
		public List<RoomDTO> AllRooms { get; set; }
		public List<TimeSlotDTO> TimeSlots { get; set; }

		[BindProperty(SupportsGet = true)]
		public string MappingDate { get; set; }
		[BindProperty]
		public int RoomId { get; set; }
		[BindProperty]
		public int TimeslotId { get; set; }
		[BindProperty]
		public string LecturerId { get; set; } = null!;
		public string Message { get; set; }
		void GetData()
		{
			TimeSlots = timeSlotRepository.GetTimeSlots();
			AllRooms = roomRepository.GetRoomDTOs();
		}

		public void OnGet(int SessionId)
		{
			GetData();
			SessionID = SessionId;
			CurrentChangeSession = sessionRepository.GetSession(SessionID);
			WebSessionHelper webSessionHelper = new WebSessionHelper(httpContextAccessor.HttpContext!.Session);
			webSessionHelper.SetCurrentSessionId(SessionID);
			TimeslotId = CurrentChangeSession.TimeslotId;
			RoomId = CurrentChangeSession.RoomId;
			LecturerId = CurrentChangeSession.LecturerId;
		}

		public void OnPostTestChange()
		{
			GetData();
			WebSessionHelper webSessionHelper = new WebSessionHelper(httpContextAccessor.HttpContext!.Session);
			SessionID = webSessionHelper.GetCurrentSessionId();
			CurrentChangeSession = sessionRepository.GetSession(SessionID);
			DateTime dateTime = DateTime.Parse(MappingDate);
			CurrentChangeSession.Date = dateTime;
			CurrentChangeSession.RoomId = RoomId;
			CurrentChangeSession.TimeslotId = TimeslotId;
			if (LecturerId != null)
				CurrentChangeSession.LecturerId = LecturerId;

			Message = sessionRepository.UpdateSession(CurrentChangeSession);
		}

		public void OnPostSaveChange()
		{

		}
	}
}
