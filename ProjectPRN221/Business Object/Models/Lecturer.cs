using System;
using System.Collections.Generic;

namespace Business_Object.Models
{
    public partial class Lecturer
    {
        public Lecturer()
        {
            Sessions = new HashSet<Session>();
        }

        public string LecturerId { get; set; } = null!;
        public string LecturerName { get; set; } = null!;
        public string LecturerEmail { get; set; } = null!;
        public int LecturerGender { get; set; }
        public DateTime? LecturerDob { get; set; }
        public string? LecturerPhone { get; set; }
        public bool Discontinued { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
