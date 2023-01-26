using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAPA_NEGOCIO.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace UIPoyecto.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Usuario_Personal { get; set; }
        [BindProperty]
        public string Contrasena_Personal { get; set; }
        public string Msg { get; set; }
        public bool acceso { get; set; }
        public IActionResult OnGet()
        {
            acceso = AuthNetCore.VerifyAuthenticate();
            if (acceso)
            {
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            if (AuthNetCore.loginIN(Usuario_Personal, Contrasena_Personal))
            {
                return RedirectToPage("Index");
            }
            else
            {
                Msg = "Datos incorrectos";
                return Page();
            }
        }
    }
}