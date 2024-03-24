using Data_Access.DTOs;

namespace Data_Access.Repository
{
	public interface ITimeSlotRepository
	{
		List<TimeSlotDTO> GetTimeSlots();
		void SaveSession(SessionDTOCreate sessionDTOCreate);
	}
}
