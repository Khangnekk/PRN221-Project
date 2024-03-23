using System;
using System.Collections.Generic;

namespace Business_Object.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Groups = new HashSet<Group>();
        }

        public string SubjectId { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
        public bool Discontinued { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
