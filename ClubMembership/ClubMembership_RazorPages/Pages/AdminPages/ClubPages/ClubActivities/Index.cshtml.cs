using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace ClubMembership_RazorPages.Pages.AdminPages.ClubPages.ClubActivities
{
    public class IndexModel : PageModel
    {
        private readonly Repositories.Models.ClubMembershipContext _context;

        public IndexModel(Repositories.Models.ClubMembershipContext context)
        {
            _context = context;
        }

        public IList<ClubActivity> ClubActivity { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ClubActivities != null)
            {
                ClubActivity = await _context.ClubActivities
                .Include(c => c.Club).ToListAsync();
            }
        }
    }
}
