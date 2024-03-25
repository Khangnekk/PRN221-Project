namespace Data_Access.DTOs
{
	public class RoomDTO
	{
		public int RoomId { get; set; }
		public string RoomName { get; set; } = null!;
		public string AreaId { get; set; } = null!;
		public bool Discontinued { get; set; }
	}
}
