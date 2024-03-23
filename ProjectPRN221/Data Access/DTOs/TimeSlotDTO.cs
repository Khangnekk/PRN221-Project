namespace Data_Access.DTOs
{

	public class TimeSlotDTOCreate
	{
		public string TimeslotName { get; set; } = null!;
		public string? TimeslotDescription { get; set; }
	}

	public class TimeSlotDTO
	{
		public int TimeslotId { get; set; }
		public string TimeslotName { get; set; } = null!;
		public string? TimeslotDescription { get; set; }
		public bool Discontinued { get; set; }

	}
}
