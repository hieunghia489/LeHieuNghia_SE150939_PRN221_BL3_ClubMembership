using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubMembership_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace ClubMembership_RazorPages.Pages.AdminPages.ClubPages.ClubMembership
{
    public class DeleteModel : PageModel
    {
        private readonly IMembershipService _service;
        private readonly IClubBoardService _clubBoardService;
        private readonly IGroupMemberService _groupMemberService;

        public DeleteModel(IMembershipService service, IClubBoardService clubBoardService,IGroupMemberService groupMemberService)
        {
            _service = service; _clubBoardService = clubBoardService; _groupMemberService = groupMemberService;
        }

        [BindProperty]
      public Membership Membership { get; set; } = default!;

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

            var membership = _service.Get(id);

            if (membership == null)
            {
                return NotFound();
            }
            else 
            {
                Membership = membership;
                ClubBoard currentBoard = _clubBoardService.GetCurrentByClub(Membership.ClubId.Value);
                IList<GroupMember> list = _groupMemberService.GetByClubBoard(currentBoard.Id);
                foreach (GroupMember member in list)
                {
                    if(member.Id== Membership.Id)
                    {
                        if (member.Role != "Member")
                        {
                            ViewData["Nofication"] = "This member is " + member.Role + " in current board. You can't delete this member at the momment";
                            break;
                        }
                    }
                }
            }
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var membership = _service.Get(id);

            if (membership != null)
            {
               _service.Delete(membership);
            }

            return RedirectToPage("./Index", new {id=membership.ClubId});
        }
    }
}
