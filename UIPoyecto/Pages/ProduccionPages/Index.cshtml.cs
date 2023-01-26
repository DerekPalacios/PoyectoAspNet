using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAPA_NEGOCIO.Security;

namespace UIPoyecto.Pages
{
    public class IndexProduccionModel : PageModel
    {
        private readonly ILogger<IndexProduccionModel> _logger;

        public IndexProduccionModel(ILogger<IndexProduccionModel> logger)
        {
            _logger = logger;
        }

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
