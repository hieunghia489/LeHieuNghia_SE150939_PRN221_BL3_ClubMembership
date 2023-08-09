using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Student
    {
        public Student()
        {
            Memberships = new HashSet<Membership>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string? Image { get; set; }
        public DateTime DateEnroll { get; set; }
        public int? MajorId { get; set; }
        public int? GradeId { get; set; }
        public bool? Status { get; set; }

        public virtual Grade? Grade { get; set; }
        public virtual Major? Major { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
