using System;
using System.Collections.Generic;

namespace Business_Object.Models
{
    public partial class TimeSlot
    {
        public TimeSlot()
        {
            Sessions = new HashSet<Session>();
        }

        public int TimeslotId { get; set; }
        public string TimeslotName { get; set; } = null!;
        public string? TimeslotDescription { get; set; }
        public bool Discontinued { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
