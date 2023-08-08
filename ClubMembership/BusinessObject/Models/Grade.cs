using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Grade
    {
        public Grade()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
