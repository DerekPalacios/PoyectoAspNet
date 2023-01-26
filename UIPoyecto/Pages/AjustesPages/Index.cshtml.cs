using CAPA_NEGOCIO.Security;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace UIPoyecto.Pages.AjustesPages
{
    public class IndexModel : PageModel
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