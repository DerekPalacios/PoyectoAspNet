using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAPA_NEGOCIO.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UIPoyecto.Pages.GaleraPages
{
    public class Index : PageModel
    {
        public IActionResult OnGet()
        {
            if (AuthNetCore.VerifyAuthenticate())
            {
                return Page();
            }
            else
            {
                return RedirectToPage("../Login");
            }

        }
    }
}