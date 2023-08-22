using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace ClubMembership_RazorPages.Pages.AdminPages.ClubPages.ClubActivities
{
    public class EditModel : PageModel
    {
        private readonly Repositories.Models.ClubMembershipContext _context;

        public EditModel(Repositories.Models.ClubMembershipContext context)
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

            var clubactivity =  await _context.ClubActivities.FirstOrDefaultAsync(m => m.Id == id);
            if (clubactivity == null)
            {
                return NotFound();
            }
            ClubActivity = clubactivity;
           ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "Code");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ClubActivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubActivityExists(ClubActivity.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ClubActivityExists(int id)
        {
          return (_context.ClubActivities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
