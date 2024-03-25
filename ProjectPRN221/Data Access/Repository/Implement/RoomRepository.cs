using AutoMapper;
using Business_Object.Models;
using Data_Access.DAO;
using Data_Access.DTOs;
using Data_Access.Mapper;

namespace Data_Access.Repository.Implement
{
	public class RoomRepository : IRoomRepository
	{
		private IMapper mapper;

		public RoomRepository()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new ApplicationMapper());
			});
			mapper = config.CreateMapper();
		}

		public List<RoomDTO> GetRoomDTOsByAreaId(string areaId)
		{
			List<RoomDTO> roomDTOs = new List<RoomDTO>();
			return mapper.Map<List<Room>, List<RoomDTO>>(RoomDAO.Instance.GetRoomsByAreaId(areaId));
		}

		public List<RoomDTO> GetRoomDTOs()
		{
			List<RoomDTO> roomDTOs = new List<RoomDTO>();
			return mapper.Map<List<Room>, List<RoomDTO>>(RoomDAO.Instance.GetRooms());
		}

	}
}
