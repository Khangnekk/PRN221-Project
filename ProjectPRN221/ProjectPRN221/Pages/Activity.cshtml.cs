using Data_Access.DTOs;
using Data_Access.Repository;
using Data_Access.Repository.Implement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectPRN221.Pages
{
	public class ActivityModel : PageModel
	{
		private readonly IAreaRepository areaRepository = new AreaRepository();
		private readonly ITimeSlotRepository timeSlotRepository = new TimeSlotRepository();


		public List<AreaDTO> Areas { get; set; }
		public List<TimeSlotDTO> TimeSlots { get; set; }

		[BindProperty]
		public int AreaId { get; set; }


		public void OnGet()
		{
			Areas = areaRepository.GetAllAreas();
			TimeSlots = timeSlotRepository.GetTimeSlots();

		}
	}
}
