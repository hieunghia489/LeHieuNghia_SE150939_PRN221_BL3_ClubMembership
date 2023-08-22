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

namespace ClubMembership_RazorPages.Pages.AdminPages.ClubPages.ClubMembership
{
    public class EditModel : PageModel
    {
        private readonly IMembershipService _service;

        public EditModel(IMembershipService service)
        {
            _service = service;        }

        [BindProperty]
        public Membership thisMember { get; set; } = default!;
        [BindProperty]
        public string currectCode { get; set; }

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
            thisMember = membership;
            currectCode = thisMember.Code;
            ViewData["MemberCode"] = new SelectList(_service.GetAllByClub(thisMember.ClubId.Value), "Code", "Code");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if(_service.GetByCode(thisMember.Code) != null)
            {
                if(_service.GetByCode(thisMember.Code).Id!=thisMember.Id)
                {
ViewData["Nofication"] = "This Code has been used before. Please check Code Used";
                ViewData["MemberCode"] = new SelectList(_service.GetAllByClub(thisMember.ClubId.Value), "Code", "Code");
                    currectCode = _service.Get(thisMember.Id).Code;
                return Page();
                }
                
            }
            if (thisMember.LeaveDate != null)
            {
                if(thisMember.JoinDate.CompareTo(thisMember.LeaveDate) != -1)
                {
                    ViewData["Nofication"] = "A member can't leave before join to club.Please check date again";
                    ViewData["MemberCode"] = new SelectList(_service.GetAllByClub(thisMember.ClubId.Value), "Code", "Code");
                    currectCode = _service.Get(thisMember.Id).Code;

                    return Page();
                }
            }
            thisMember.Status = true;
            _service.Update(thisMember);
            return RedirectToPage("./Index", new {id= thisMember.ClubId.Value});
        }

    }
}
