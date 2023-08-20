using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClubMembership_RazorPages.Pages.AdminPages
{
    public class HomepageModel : PageModel
    {
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
            return Page();
            
           
        }
    }
}
