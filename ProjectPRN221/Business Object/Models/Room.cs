using System;
using System.Collections.Generic;

namespace Business_Object.Models
{
    public partial class Room
    {
        public Room()
        {
            Sessions = new HashSet<Session>();
        }

        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;
        public string AreaId { get; set; } = null!;
        public bool Discontinued { get; set; }

        public virtual Area Area { get; set; } = null!;
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
