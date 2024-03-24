namespace Data_Access.DTOs
{
	public class GroupDTO
	{
		public int GroupId { get; set; }
		public string GroupName { get; set; } = null!;
		public string SubjectId { get; set; } = null!;
		public string LecturerId { get; set; } = null!;
		public string? Semester { get; set; }
		public string? Year { get; set; }
		public bool? Discontinued { get; set; }
	}

	public class GroupDTOCreate
	{
		public string GroupName { get; set; } = null!;
		public string SubjectId { get; set; } = null!;
		public string LecturerId { get; set; } = null!;
		public string? Semester { get; set; }
		public string? Year { get; set; }
		public bool? Discontinued { get; set; }
	}
}
