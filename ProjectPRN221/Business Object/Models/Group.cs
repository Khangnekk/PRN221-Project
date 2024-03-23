using System;
using System.Collections.Generic;

namespace Business_Object.Models
{
    public partial class Group
    {
        public Group()
        {
            Sessions = new HashSet<Session>();
        }

        public string GroupId { get; set; } = null!;
        public string SubjectId { get; set; } = null!;
        public string LecturerId { get; set; } = null!;
        public string? Semester { get; set; }
        public string? Year { get; set; }
        public bool Discontinued { get; set; }

        public virtual Subject Subject { get; set; } = null!;
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
