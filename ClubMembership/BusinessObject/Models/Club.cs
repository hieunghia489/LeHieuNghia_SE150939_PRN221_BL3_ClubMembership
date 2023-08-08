using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Club
    {
        public Club()
        {
            ClubActivities = new HashSet<ClubActivity>();
            ClubBoards = new HashSet<ClubBoard>();
            Memberships = new HashSet<Membership>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string? Logo { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<ClubActivity> ClubActivities { get; set; }
        public virtual ICollection<ClubBoard> ClubBoards { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
