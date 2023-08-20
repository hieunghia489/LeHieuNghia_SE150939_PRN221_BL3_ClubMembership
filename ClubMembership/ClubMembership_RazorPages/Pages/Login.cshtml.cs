using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ClubMembership_RazorPages.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
      public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
    
        public async Task<IActionResult> OnGet()
        {
            string account = HttpContext.Session.GetString("account");
            if(account != null) { 
            if(account=="Admin")
                return RedirectToPage("/AdminPages/Homepage"); 
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid||Email==null||Password==null)
            {
                return Page();
            }
            if (!Email.Contains("@") && !Email.Contains("."))
            {
                ViewData["Nofication"] = "Your Email is not valid";
                return Page();
            }
            string adminEmail = "admin@gmail.com";
            string adminPassword = "123";
            if (Email != adminEmail && Password != adminPassword)
            {
                ViewData["Nofication"] = "Wrong email or password";
                return Page();
            }
            HttpContext.Session.SetString("account","Admin");
            return RedirectToPage("/AdminPages/Homepage");
        }
    }
}
