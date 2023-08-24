using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubMembership_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace ClubMembership_RazorPages.Pages.AdminPages.ClubPages.ClubActivities
{
    public class CreateModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;
        private readonly IParticipantService _participantService;
        private readonly IMembershipService _membershipService;

        public CreateModel(IClubActivityService service, IParticipantService participantService, IMembershipService membershipService)
        {
            _clubActivityService = service;
            _participantService = participantService;
            _membershipService = membershipService;
        }

        public async Task<IActionResult> OnGet(int id)
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
            Memberships = _membershipService.GetCurrentByClub(id);
            Attent = new bool[Memberships.Count];
            return Page();
        }

        [BindProperty]
        public ClubActivity ClubActivity { get; set; } = default!;
        [BindProperty]
        public IList<Participant> Participants { get; set; }
        [BindProperty]
        public IList<Membership> Memberships { get; set; }
        [BindProperty]
        public bool[] Attent { get; set; }
        [BindProperty]
        public string[] Missions { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
           if (ClubActivity.StartDate==null|| ClubActivity.EndDate == null)
            {
                ViewData["Nofication"] = "This activity must have Start and End date";
                Memberships = _membershipService.GetCurrentByClub(ClubActivity.ClubId.Value);
                Attent = new bool[Memberships.Count];
                return Page();
            }
            if (ClubActivity.EndDate.Value.CompareTo(ClubActivity.StartDate) == -1)
            {
                Memberships = _membershipService.GetCurrentByClub(ClubActivity.ClubId.Value);
                Attent = new bool[Memberships.Count];
                ViewData["Nofication"] = "End date must be equal or after Start date";
                return Page();
            }
            _clubActivityService.Added(ClubActivity);
            int id = _clubActivityService.GetAllByClub(ClubActivity.ClubId.Value).Last().Id;
            Memberships = _membershipService.GetCurrentByClub(ClubActivity.ClubId.Value);
            for (int i=0;i<Memberships.Count;i++)
            {
                if (Attent[i])
                {
 Participant member=new Participant();
                member.Attend = Attent[i];
                member.JoinDate = ClubActivity.StartDate;
                member.MembershipId = Memberships[i].Id;
                member.Status = true;
                member.Mission= Missions[i];
                    member.ClubActivityId = id;
                    _participantService.Added(member);
                }
            }

            return RedirectToPage("./Index", new {id=ClubActivity.ClubId.Value});
        }
    }
}
