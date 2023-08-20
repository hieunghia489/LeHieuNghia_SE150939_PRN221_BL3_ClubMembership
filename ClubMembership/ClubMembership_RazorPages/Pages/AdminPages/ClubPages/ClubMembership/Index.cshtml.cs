 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace ClubMembership_RazorPages.Pages.AdminPages.ClubPages.ClubMembership
{
    public class IndexModel : PageModel
    {
        private readonly Repositories.Models.ClubMembershipContext _context;

        public IndexModel(Repositories.Models.ClubMembershipContext context)
        {
            _context = context;
        }

        public IList<Membership> Membership { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Memberships != null)
            {
                Membership = await _context.Memberships
                .Include(m => m.Club)
                .Include(m => m.Student).ToListAsync();
            }
        }
    }
}
