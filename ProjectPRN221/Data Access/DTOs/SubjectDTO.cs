namespace Data_Access.DTOs
{
	public class SubjectDTOCreate
	{
		public string SubjectId { get; set; } = null!;
		public string SubjectName { get; set; } = null!;
		public bool Discontinued { get; set; }
	}
}
