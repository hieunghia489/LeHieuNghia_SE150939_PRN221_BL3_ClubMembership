using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubMembership_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace ClubMembership_RazorPages.Pages.AdminPages.ClubPages.ClubActivities
{
    public class DetailsModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;
        private readonly IParticipantService _participantService;
        
        public DetailsModel(IClubActivityService clubActivityService,IParticipantService participantService)
        {
            _clubActivityService = clubActivityService;
            _participantService = participantService;
        }
        [BindProperty]
      public ClubActivity ClubActivity { get; set; } = default!;
        [BindProperty]

        public IList<Participant> Participants { get; set; }
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
           ClubActivity=_clubActivityService.Get(id);
            Participants = _participantService.GetByActivity(ClubActivity.Id);
            return Page();

        }
    }
}
