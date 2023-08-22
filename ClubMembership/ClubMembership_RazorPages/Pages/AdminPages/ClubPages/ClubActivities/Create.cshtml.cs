﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Models;

namespace ClubMembership_RazorPages.Pages.AdminPages.ClubPages.ClubActivities
{
    public class CreateModel : PageModel
    {
        private readonly Repositories.Models.ClubMembershipContext _context;

        public CreateModel(Repositories.Models.ClubMembershipContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClubId"] = new SelectList(_context.Clubs, "Id", "Code");
            return Page();
        }

        [BindProperty]
        public ClubActivity ClubActivity { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ClubActivities == null || ClubActivity == null)
            {
                return Page();
            }

            _context.ClubActivities.Add(ClubActivity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}