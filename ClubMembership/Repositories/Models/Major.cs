using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Major
    {
        public Major()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool? Status { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
