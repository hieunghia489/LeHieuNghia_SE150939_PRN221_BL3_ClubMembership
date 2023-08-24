using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubMembership_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Models;

namespace ClubMembership_RazorPages.Pages.AdminPages.ClubPages.ClubActivities
{
    public class AdjustModel : PageModel
    {
        private readonly IClubActivityService _clubActivityService;
        private readonly IParticipantService _participantService;
        private readonly IMembershipService _membershipService;

        public AdjustModel(IClubActivityService clubActivityService,IParticipantService participantService, IMembershipService membershipService)
        {
            _clubActivityService = clubActivityService;
            _participantService = participantService;
            _membershipService = membershipService;
        }

        public IActionResult OnGet(int id)
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
            List<Membership> listAllMember = _membershipService.GetCurrentByClub(ClubActivity.ClubId.Value);
             participants = _participantService.GetByActivity(ClubActivity.Id);
            List<Membership> listMember=new List<Membership>();
            foreach(var member in listAllMember)
            {
                bool check = false;
                foreach(var p in participants)
                {
                    if(p.MembershipId == member.Id)
                    {
                        check = true;
                        break;
                    }
                }
                if(!check) listMember.Add(member);
            }
        ViewData["MembershipId"] = new SelectList(listMember, "Id", "Code");

            return Page();
        }

        [BindProperty]
        public Participant Participant { get; set; } = default!;
        [BindProperty]
        public ClubActivity ClubActivity { get; set; }
        [BindProperty]
        public List<Participant> participants { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ClubActivity = _clubActivityService.Get(Participant.ClubActivityId.Value);
         if(Participant.JoinDate.CompareTo(ClubActivity.StartDate) ==-1|| Participant.JoinDate.CompareTo(ClubActivity.EndDate) == 1)
            {
                ViewData["Nofication"] = "Make sure date join between Start and End date";
                List<Membership> listAllMember = _membershipService.GetCurrentByClub(ClubActivity.ClubId.Value);
                participants = _participantService.GetByActivity(ClubActivity.Id);
                List<Membership> listMember = new List<Membership>();
                foreach (var member in listAllMember)
                {
                    bool check = false;
                    foreach (var p in participants)
                    { 
                        if (p.MembershipId == member.Id)
                        {
                            check = true;
                            break;
                        }
                    }
                    if (!check) listMember.Add(member);
                }
                ViewData["MembershipId"] = new SelectList(listMember, "Id", "Code");
                return Page();  
            }
            Participant.Status = true;
         _participantService.Added(Participant);

            return RedirectToPage("./Details", new {id=ClubActivity.Id});
        }
    }
}
