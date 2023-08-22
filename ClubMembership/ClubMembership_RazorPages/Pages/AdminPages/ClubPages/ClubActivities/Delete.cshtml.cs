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
    public class DeleteModel : PageModel
    {
        private readonly Repositories.Models.ClubMembershipContext _context;

        public DeleteModel(Repositories.Models.ClubMembershipContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ClubActivity ClubActivity { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ClubActivities == null)
            {
                return NotFound();
            }

            var clubactivity = await _context.ClubActivities.FirstOrDefaultAsync(m => m.Id == id);

            if (clubactivity == null)
            {
                return NotFound();
            }
            else 
            {
                ClubActivity = clubactivity;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ClubActivities == null)
            {
                return NotFound();
            }
            var clubactivity = await _context.ClubActivities.FindAsync(id);

            if (clubactivity != null)
            {
                ClubActivity = clubactivity;
                _context.ClubActivities.Remove(ClubActivity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
