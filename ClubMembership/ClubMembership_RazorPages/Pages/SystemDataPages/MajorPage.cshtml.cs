using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubMembership_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace ClubMembership_RazorPages.Pages.SystemDataPages
{
    public class MajorPageModel : PageModel
    {
        private readonly IMajorService _service;

        public MajorPageModel(IMajorService service)
        {
            _service = service;
        }

        public List<Major> Major { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_service != null)
            {
                Major = (List<Major>)_service.GetAll();
            }
           
        }
    }
}
