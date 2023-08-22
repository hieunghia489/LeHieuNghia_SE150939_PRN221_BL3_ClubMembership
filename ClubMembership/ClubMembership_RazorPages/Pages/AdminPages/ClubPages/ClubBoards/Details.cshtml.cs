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
    public class DetailsModel : PageModel
    {
        private readonly IClubBoardService _clubBoardService;
        private readonly IGroupMemberService _groupMemberService;

        public DetailsModel(IClubBoardService clubBoardService, IGroupMemberService groupMemberService)
        {
            _clubBoardService = clubBoardService;
            _groupMemberService = groupMemberService;
        }


        public ClubBoard ClubBoard { get; set; } = default!; 
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
            var clubboard =_clubBoardService.Get(id);
            if (clubboard == null)
            {
                return NotFound();
            }
            else 
            {
                ClubBoard = clubboard;
                GroupMembers = _groupMemberService.GetByClubBoard(id);
            }
            return Page();
        }
    }
}
