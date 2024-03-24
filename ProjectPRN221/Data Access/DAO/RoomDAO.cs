using Business_Object.Models;

namespace Data_Access.DAO
{
	public class RoomDAO
	{
		private static ProjectPRN221Context context = new ProjectPRN221Context();

		public static Room GetRoomByRoomRaw(string roomRaw)
		{
			string areaId = roomRaw.Split("-")[0];
			string roomName = roomRaw.Split("-")[1];
			return context.Rooms.SingleOrDefault(r => r.RoomName.Contains(roomName) && r.AreaId == areaId);
		}
	}
}
