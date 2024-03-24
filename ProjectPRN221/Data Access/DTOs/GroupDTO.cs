using Business_Object.Models;

namespace Data_Access.DTOs
{
	public class GroupDTO
	{
		public string GroupId { get; set; } = null!;
		public string SubjectId { get; set; } = null!;
		public string LecturerId { get; set; } = null!;
		public string? Semester { get; set; }
		public string? Year { get; set; }
		public bool Discontinued { get; set; }

		public virtual Subject Subject { get; set; } = null!;
	}

	public class GroupDTOCreate
	{
		public string GroupId { get; set; } = null!;
		public string SubjectId { get; set; } = null!;
		public string LecturerId { get; set; } = null!;
		public string? Semester { get; set; }
		public string? Year { get; set; }
		public bool Discontinued { get; set; }

		public virtual Subject Subject { get; set; } = null!;
	}
}
