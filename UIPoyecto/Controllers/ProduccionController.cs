using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CAPA_NEGOCIO.Models;
using System.Collections.Generic;
using CAPA_NEGOCIO.Security;
using System.Linq;

namespace UIPoyecto.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProduccionController : ControllerBase
    {


        public ProduccionController()
        {
            AuthNetCore.loginIN("admin", "admin");

        }




        [HttpPost]
        public object SaveProD(Produccion newPro)
        {
            try
            {
                newPro.IdProduccion = (int)newPro.Save();
                newPro.GenerarActividadesDiarias();
                return 1;
            }
            catch (System.Exception)
            {

                return 0;
            }

        }

    }
}
