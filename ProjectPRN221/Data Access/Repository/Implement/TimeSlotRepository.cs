using AutoMapper;
using Business_Object.Models;
using Data_Access.DAO;
using Data_Access.DTOs;
using Data_Access.Mapper;

namespace Data_Access.Repository.Implement
{
	public class TimeSlotRepository : ITimeSlotRepository
	{
		private IMapper mapper;

		public TimeSlotRepository()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new ApplicationMapper());
			});
			mapper = config.CreateMapper();
		}
		public List<TimeSlotDTO> GetTimeSlots()
		{
			return mapper.Map<List<TimeSlot>, List<TimeSlotDTO>>(TimeSlotDAO.GetTimeSlots());
		}
	}
}
