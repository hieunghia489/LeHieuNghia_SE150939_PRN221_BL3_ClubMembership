using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubMembership_Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace ClubMembership_RazorPages.Pages.AdminPages
{
    public class StudentsModel : PageModel
    {
        private readonly IStudentService _studentService;
        private readonly IGradeService  _gradeService;
        private readonly IMajorService  _majorService;


        public StudentsModel( IStudentService studentService,IMajorService majorService,IGradeService gradeService)
        {
            _studentService = studentService;
            _gradeService = gradeService;
            _majorService = majorService;
        }

        public IList<Student> Student { get;set; } = default!;
        public IList<Grade> Grades { get;set; } = default!;
        public IList<Major> Majors { get;set; } = default!;

        public async Task<IActionResult> OnGet()
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
            Student = (IList<Student>)_studentService.GetAll();
            Grades=(IList<Grade>)_gradeService.GetAll();
            Majors=(IList<Major>)_majorService.GetAll();
            return Page();
        }
    }
}
