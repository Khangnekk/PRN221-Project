using System;
using System.Collections.Generic;

namespace Business_Object.Models
{
    public partial class Session
    {
        public int SessionId { get; set; }
        public int GroupId { get; set; }
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
