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
    public class IndexModel : PageModel
    {
        private readonly IMembershipService _service;

        public IndexModel(IMembershipService service)
        {
            _service = service;
        }

        public IList<Membership> CurrentMembership { get;set; } = default!;
        public IList<Membership> AllMembership { get; set; } = default!;

        public Club Club { get; set; }

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
            AllMembership = _service.GetAllByClub(id);
            CurrentMembership = _service.GetCurrentByClub(id);
            Club = AllMembership[0].Club;
            return Page();
        }
    }
}
