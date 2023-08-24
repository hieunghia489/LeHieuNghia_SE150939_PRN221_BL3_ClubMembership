using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubMembership_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Models;

namespace ClubMembership_RazorPages.Pages.AdminPages.ClubPages.ClubBoards
{
    public class CreateModel : PageModel
    {
        private readonly IClubBoardService _clubBoardService;
        private readonly IGroupMemberService _groupMemberService;
        private readonly IMembershipService _membershipService;

        public CreateModel(IClubBoardService clubBoardService, IGroupMemberService groupMemberService,IMembershipService membershipService)
        {
            _clubBoardService = clubBoardService;
            _groupMemberService = groupMemberService;
            _membershipService = membershipService;
        }

        public  async Task<IActionResult> OnGet(int id)
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
            Memberships =_membershipService.GetCurrentByClub(id);
            currentBoard=_clubBoardService.GetCurrentByClub(id);
            role = new string[Memberships.Count];
            return Page();
        }

        [BindProperty]
        public ClubBoard newBoard { get; set; } = default!;
        [BindProperty]
        public ClubBoard currentBoard { get; set; } = default!;

        [BindProperty]
        public string[] role { get; set; }
        [BindProperty]
        public IList<Membership> Memberships { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int id)
        {
            currentBoard = _clubBoardService.Get(id);
            Console.WriteLine(currentBoard.EndSemester);
            Console.WriteLine(newBoard.StartSemester);
            Memberships = _membershipService.GetCurrentByClub(currentBoard.ClubId.Value);
            
            if (newBoard == null || role == null)
            {
                ViewData["Nofication"] = "Please check again all form information. You can't change it after create";
                return Page();
            }
            if (newBoard.EndSemester == null)
            {
                newBoard.EndSemester=newBoard.StartSemester.AddMonths(4);
            }
            if (newBoard.StartSemester.CompareTo(currentBoard.EndSemester) == -1)
            {
                ViewData["Nofication"] = "Date start a new board must be after the previous board end";
                return Page();
            }
            newBoard.ClubId = currentBoard.ClubId;
            newBoard.Status = true;
            _clubBoardService.Add(newBoard);
            int newBoardID = _clubBoardService.GetAllByClub(currentBoard.ClubId.Value).LastOrDefault().Id;
            for(int i = 0; i < Memberships.Count; i++)
            {
                var groupMember = new GroupMember();
                groupMember.MembershipId = Memberships[i].Id;
                groupMember.ClubBoardId = newBoardID;
                groupMember.Status = true;
                groupMember.Role = role[i];
                _groupMemberService.Added(groupMember);
            }
            return RedirectToPage("./Index", new { id = currentBoard.ClubId });
        }
    }
}
