namespace Data_Access.DTOs
{
	public class AreaDTOCreate
	{
		public string AreaId { get; set; }
		public string AreaName { get; set; } = null!;
	}

	public class AreaDTO
	{
		public string AreaId { get; set; }
		public string AreaName { get; set; } = null!;
		public bool Discontinued { get; set; }
	}
}
