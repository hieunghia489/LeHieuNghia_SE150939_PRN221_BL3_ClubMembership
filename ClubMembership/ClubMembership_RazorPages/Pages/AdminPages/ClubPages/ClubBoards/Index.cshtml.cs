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
    public class IndexModel : PageModel
    {
        private readonly IClubBoardService _clubBoardService;
        private readonly IGroupMemberService _groupMemberService;

        public IndexModel(IClubBoardService clubBoardService, IGroupMemberService groupMemberService)
        {
           _clubBoardService = clubBoardService;
            _groupMemberService = groupMemberService;
        }

        public IList<ClubBoard> listBoards { get;set; } = default!;
        public ClubBoard currentBoard { get; set; }
        public int[] groupMembers { get; set; }

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
            listBoards = _clubBoardService.GetAllByClub(id);
            currentBoard = _clubBoardService.GetCurrentByClub(id);
            groupMembers = new int[100];
            foreach(var board in listBoards)
            {
                groupMembers[board.Id] = _groupMemberService.GetByClubBoard(board.Id).Count;
            }
            return Page();
        }
    }
}
