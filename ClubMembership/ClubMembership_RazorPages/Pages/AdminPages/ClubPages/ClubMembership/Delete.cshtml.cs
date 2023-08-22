using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubMembership_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace ClubMembership_RazorPages.Pages.AdminPages.ClubPages.ClubMembership
{
    public class DeleteModel : PageModel
    {
        private readonly IMembershipService _service;

        public DeleteModel(IMembershipService service)
        {
            _service = service;        }

        [BindProperty]
      public Membership Membership { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            string account = HttpContext.Session.GetString("account");
            if (account == null)
            {
                return RedirectToPage("/Login");
            }
            else
                if (account != "Admin")
            {
                return RedirectToPage("/Login");
            }

            var membership = _service.Get(id);

            if (membership == null)
            {
                return NotFound();
            }
            else 
            {
                Membership = membership;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var membership = _service.Get(id);

            if (membership != null)
            {
               _service.Delete(membership);
            }

            return RedirectToPage("./Index", new {id=membership.ClubId});
        }
    }
}
