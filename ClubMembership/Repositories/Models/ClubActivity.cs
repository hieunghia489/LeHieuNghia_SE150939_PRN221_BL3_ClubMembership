using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public partial class ClubActivity
    {
        public ClubActivity()
        {
            Participants = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public int? ClubId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }

        public virtual Club? Club { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
