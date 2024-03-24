using Business_Object.Models;

namespace Data_Access.DAO
{
	public class RoomDAO : DAO<Room>
	{
		private static RoomDAO instance;
		private static readonly object padlock = new object();

		private RoomDAO() { }
		public static RoomDAO Instance
		{
			get
			{
				if (instance == null)
				{
					lock (padlock)
					{
						if (instance == null)
						{
							instance = new RoomDAO();
						}
					}
				}
				return instance;
			}
		}
		public Room GetRoomByRoomRaw(string roomRaw)
		{
			string areaId = roomRaw.Split("-")[0];
			string roomName = roomRaw.Split("-")[1];
			return context.Rooms.SingleOrDefault(r => r.RoomName.Contains(roomName) && r.AreaId == areaId);
		}
	}
}
