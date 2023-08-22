using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubMembership_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Models;

namespace ClubMembership_RazorPages.Pages.AdminPages.ClubPages.ClubMembership
{
    public class CreateModel : PageModel
    {
        private readonly IMembershipService _service;
        private readonly IClubService _clubService;
        private readonly IStudentService _studentService;

        public IList<Student> GetValidStudent(int id)
        {
            IList<Student> students = (IList<Student>)_studentService.GetAll();
            IList<Student> studentActive = new List<Student>();
            IList<Membership> members = _service.GetCurrentByClub(id);
            foreach (Student student in students)
            {
                bool existed = false;
                if (student.Status == true)
                {
                    foreach (Membership member in members)
                    {
                        if (member.StudentId == student.Id)
                        {
                            existed = true;
                            break;
                        }
                    }
                    if (existed == false)
                        studentActive.Add(student);
                }
            }
            return studentActive;
        }
        public CreateModel(IMembershipService service,IClubService clubService,IStudentService studentService)
        {
            _service = service;  
        _clubService=clubService;
            _studentService=studentService; 
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
            club = _clubService.Get(id);

        ViewData["StudentId"] = new SelectList(GetValidStudent(id), "Id", "Code");
            ViewData["MemberCode"] = new SelectList(_service.GetAllByClub(club.Id), "Code", "Code");

            return Page();
        }

        [BindProperty]
        public Membership Membership { get; set; } = default!;
        [BindProperty]
        public Club club { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Membership.ClubId = club.Id;
            
          if ( Membership == null)
            {
                ViewData["Nofication"] = "There are some mistake in your form. Please check again";
                ViewData["StudentId"] = new SelectList(GetValidStudent(club.Id), "Id", "Code");
                ViewData["MemberCode"] = new SelectList(_service.GetAllByClub(club.Id), "Code", "Code");
                return Page();
            }
          if(_service.GetByCode(Membership.Code)!=null) {
                ViewData["Nofication"] = "This Code has been used before. Please check code in Code used";
                ViewData["StudentId"] = new SelectList(GetValidStudent(club.Id), "Id", "Code");
                ViewData["MemberCode"] = new SelectList(_service.GetAllByClub(club.Id), "Code", "Code");
                return Page();
            }
          if(Membership.LeaveDate!=null)
            {
                if (Membership.JoinDate.CompareTo(Membership.LeaveDate) ==1)
                {
                    ViewData["Nofication"] = "A member can't leave before join";
                    ViewData["StudentId"] = new SelectList(GetValidStudent(club.Id), "Id", "Code");
                    ViewData["MemberCode"] = new SelectList(_service.GetAllByClub(club.Id), "Code", "Code");
                    return Page();
                }
            }
            _service.Added(Membership);

            return RedirectToPage("./Index",new { id=club.Id});
        }
    }
}
