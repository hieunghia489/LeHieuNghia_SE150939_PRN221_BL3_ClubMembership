using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class Membership
    {
        public Membership()
        {
            GroupMembers = new HashSet<GroupMember>();
            Participants = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public int? StudentId { get; set; }
        public int? ClubId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public bool? Status { get; set; }

        public virtual Club? Club { get; set; }
        public virtual Student? Student { get; set; }
        public virtual ICollection<GroupMember> GroupMembers { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
