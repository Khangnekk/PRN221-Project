using Business_Object.Models;

namespace Data_Access.DTOs
{
	public class SessionDTORaw
	{
		public string SubjectId { get; set; }
		public string GroupId { get; set; }
		public string RoomRaw { get; set; }
		public DateTime FirstDate { get; set; }
		public string TimeslotRaw { get; set; }
		public string LecturerId { get; set; }
		public int TotalSession { get; set; }
		public bool Online { get; set; }
	}

	public class SessionDTOCreate
	{
		public string GroupId { get; set; } = null!;
		public int RoomId { get; set; }
		public DateTime Date { get; set; }
		public int TimeslotId { get; set; }
		public string LecturerId { get; set; } = null!;
		public int SessionNo { get; set; }
		public bool? Online { get; set; }
		public virtual GroupDTOCreate Group { get; set; } = null!;
		public virtual Lecturer Lecturer { get; set; } = null!;
		public virtual Room Room { get; set; } = null!;
		public virtual TimeSlot Timeslot { get; set; } = null!;
	}

	public class SessionDTO
	{
		public int SessionId { get; set; }
		public string GroupId { get; set; } = null!;
		public int RoomId { get; set; }
		public DateTime Date { get; set; }
		public int TimeslotId { get; set; }
		public string LecturerId { get; set; } = null!;
		public int SessionNo { get; set; }
		public bool? Online { get; set; }
		public bool Discontinued { get; set; }

		public virtual Group Group { get; set; } = null!;
		public virtual Lecturer Lecturer { get; set; } = null!;
		public virtual Room Room { get; set; } = null!;
		public virtual TimeSlot Timeslot { get; set; } = null!;
	}
}
