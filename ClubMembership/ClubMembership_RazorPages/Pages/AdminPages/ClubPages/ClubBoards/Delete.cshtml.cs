using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubMembership_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace ClubMembership_RazorPages.Pages.AdminPages.ClubPages.ClubBoards
{
    public class DeleteModel : PageModel
    {
        private readonly IClubBoardService _clubBoardService;
        private readonly IGroupMemberService _groupMemberService;

        public DeleteModel(IClubBoardService clubBoardService, IGroupMemberService groupMemberService)
        {
            _clubBoardService = clubBoardService;_groupMemberService = groupMemberService;        }

        [BindProperty]
      public ClubBoard ClubBoard { get; set; } = default!;
        [BindProperty]
        public IList<GroupMember> GroupMembers { get; set; }
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
            var clubboard = _clubBoardService.Get(id);

            if (clubboard == null)
            {
                return NotFound();
            }
            else 
            {
                ClubBoard = clubboard;
                GroupMembers = _groupMemberService.GetByClubBoard(ClubBoard.Id);
                if (_clubBoardService.GetCurrentByClub(ClubBoard.ClubId.Value).Id == id)
                {
                    ViewData["Nofication"] = "This is the current Board. You need to create a present one to delete this one";
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            ClubBoard=_clubBoardService.Get(id);
            _clubBoardService.Delete(ClubBoard);
            GroupMembers = _groupMemberService.GetByClubBoard(ClubBoard.Id);
            foreach (var groupMember in GroupMembers)
            {
                _groupMemberService.Delete(groupMember);
            }

            return RedirectToPage("./Index", new {id=ClubBoard.ClubId});
        }
    }
}
