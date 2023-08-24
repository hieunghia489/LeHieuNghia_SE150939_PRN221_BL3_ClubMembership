using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubMembership_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace ClubMembership_RazorPages.Pages.AdminPages.ClubPages
{
    public class ClubsModel : PageModel
    {
        private readonly IClubService _clubService;
        private readonly IMembershipService _membershipService;
        private readonly IClubActivityService _clubActivityService;
        private readonly IClubBoardService _clubBoardService;

       public ClubsModel(IClubService clubService,IMembershipService membershipService,IClubActivityService clubActivityService, IClubBoardService clubBoardService)
        {
            _clubActivityService = clubActivityService;
            _clubService = clubService; 
            _membershipService = membershipService;
            _clubBoardService = clubBoardService;
        }

        public IList<Club> Club { get;set; } = default!;

        public int[] Members { get; set; } 
        public int[] Activities { get; set; }
        public int[] ClubBoards { get; set; }

        public async Task<IActionResult> OnGetAsync()
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
            Club = _clubService.GetAll(); 
            Members= new int[100];
                Activities= new int[100];
                ClubBoards= new int[100];
       foreach(var club in Club)
            {
               
                Members[club.Id] = _membershipService.GetCurrentByClub(club.Id).Count;
                Activities[club.Id] = _clubActivityService.GetAllByClub(club.Id).Count;
                ClubBoards[club.Id] = _clubBoardService.GetAllByClub(club.Id).Count;
            }
            return Page();
        }
    }
}
