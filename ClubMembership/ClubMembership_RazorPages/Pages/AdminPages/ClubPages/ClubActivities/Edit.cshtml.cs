using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubMembership_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace ClubMembership_RazorPages.Pages.AdminPages.ClubPages.ClubActivities
{
    public class EditModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;
        private readonly IParticipantService _participantService;

        public EditModel(IClubActivityService clubActivityService, IParticipantService participantService)
        {
            _clubActivityService = clubActivityService;
            _participantService = participantService;
        }

        [BindProperty]
        public ClubActivity ClubActivity { get; set; } = default!;
        [BindProperty]
        public IList<Participant> Participants { get; set; }
        [BindProperty]
        public bool[] Attent { get; set; }
        [BindProperty]
        public string[] Missions { get; set; }  
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
           
            ClubActivity = _clubActivityService.Get(id);
            Participants = _participantService.GetByActivity(ClubActivity.Id);
            Attent = new bool[Participants.Count];
            Missions = new string[Participants.Count];
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ClubActivity = _clubActivityService.Get(ClubActivity.Id);
            Participants = _participantService.GetByActivity(ClubActivity.Id);
            for(int i=0;i< Participants.Count;i++)
            {
                Participants[i].Attend = Attent[i];
                Participants[i].Mission = Missions[i];
                _participantService.Update(Participants[i]);
            }
            return RedirectToPage("./Details", new {id=ClubActivity.Id});
        }

    }
}
