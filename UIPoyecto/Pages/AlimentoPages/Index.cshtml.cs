using CAPA_NEGOCIO.Security;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace UIPoyecto.Pages.AlimentoPages
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