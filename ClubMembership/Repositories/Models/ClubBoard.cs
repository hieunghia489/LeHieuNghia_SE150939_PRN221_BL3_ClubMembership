using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class ClubBoard
    {
        public ClubBoard()
        {
            GroupMembers = new HashSet<GroupMember>();
        }

        public int Id { get; set; }
        public int? ClubId { get; set; }
        public string Semester { get; set; } = null!;
        public DateTime StartSemester { get; set; }
        public DateTime? EndSemester { get; set; }
        public bool? Status { get; set; }

        public virtual Club? Club { get; set; }
        public virtual ICollection<GroupMember> GroupMembers { get; set; }
    }
}
