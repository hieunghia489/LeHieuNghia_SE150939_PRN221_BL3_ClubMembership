using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubMembership_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Models;

namespace ClubMembership_RazorPages.Pages.AdminPages.ClubPages
{
    public class CreateClubModel : PageModel
    {
        private readonly IClubService _clubService;

        public CreateClubModel(IClubService clubService)
        {
            _clubService = clubService;
        }

        public IActionResult OnGet()
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
            return Page();
        }

        [BindProperty]
        public Club Club { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid ||  Club == null)
            {
                return Page();
            }
          if(_clubService.GetByCode(Club.Code)!=null) {
                ViewData["Nofication"] = "This Club Code has been used. Please try another one";
                return Page();
            }
         _clubService.Added(Club);
            return RedirectToPage("./Clubs");
        }
    }
}
