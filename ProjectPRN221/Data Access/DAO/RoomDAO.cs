using Business_Object.Models;
using Microsoft.EntityFrameworkCore;

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
			Room? room = new Room();
			string areaId = roomRaw.Split("-")[0];
			string roomName = roomRaw.Split("-")[1];
			room = context.Rooms
				.Include(r => r.Area)
				.SingleOrDefault(r => r.RoomName.Contains(roomName) && r.AreaId == areaId);
			return room;
		}

		public List<Room> GetRoomsByAreaId(string areaId)
		{
			List<Room> rooms = new List<Room>();
			rooms = context.Rooms
				.Include(a => a.Area)
				.Where(r => areaId == "-1" || r.AreaId == areaId)
				.ToList();
			return rooms;
		}
	}
}
