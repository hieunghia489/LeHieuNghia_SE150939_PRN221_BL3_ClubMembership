using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class GroupMember
    {
        public int Id { get; set; }
        public string Role { get; set; } = null!;
        public bool? Status { get; set; }
        public int? MembershipId { get; set; }
        public int? ClubBoardId { get; set; }

        public virtual ClubBoard? ClubBoard { get; set; }
        public virtual Membership? Membership { get; set; }
    }
}
