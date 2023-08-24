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
    public class IndexModel : PageModel
    {
        private readonly IClubActivityService _service;
        private readonly IParticipantService _participantService;

        public IndexModel(IClubActivityService service, IParticipantService participantService)
        {
            _service = service;
            _participantService = participantService;
        }

        public IList<ClubActivity> AllClubActivity { get;set; } = default!;
        public int[]ListParticipants { get; set; }
        public int clubID { get; set; }

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
            AllClubActivity = _service.GetAllByClub(id);
            ListParticipants = new int[100];
            foreach (var activity in AllClubActivity)
            {
                IList<Participant> list=_participantService.GetByActivity(activity.Id);
                ListParticipants[activity.Id] = list.Count();
                int i = list.Count();
            }
            clubID = id;
            return Page();
        }
    }
}
