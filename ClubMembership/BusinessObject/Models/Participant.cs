using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Participant
    {
        public int Id { get; set; }
        public int? MembershipId { get; set; }
        public int? ClubActivityId { get; set; }
        public bool? Attend { get; set; }
        public string Mission { get; set; } = null!;
        public DateTime JoinDate { get; set; }
        public bool? Status { get; set; }

        public virtual ClubActivity? ClubActivity { get; set; }
        public virtual Membership? Membership { get; set; }
    }
}
