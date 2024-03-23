namespace Data_Access.DTOs
{
	public class AeraDTOCreate
	{
		public int AreaId { get; set; }
		public string AreaName { get; set; } = null!;
	}

	public class AreaDTO
	{
		public int AreaId { get; set; }
		public string AreaName { get; set; } = null!;
		public bool Discontinued { get; set; }
	}
}
