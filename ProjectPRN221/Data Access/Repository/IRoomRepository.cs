using Data_Access.DTOs;

namespace Data_Access.Repository
{
	public interface IRoomRepository
	{
		public List<RoomDTO> GetRoomDTOsByAreaId(string areaId);
		public List<RoomDTO> GetRoomDTOs();
	}
}
