using System;
using System.Collections.Generic;

namespace Business_Object.Models
{
    public partial class Area
    {
        public Area()
        {
            Rooms = new HashSet<Room>();
        }

        public string AreaId { get; set; } = null!;
        public string AreaName { get; set; } = null!;
        public bool Discontinued { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
