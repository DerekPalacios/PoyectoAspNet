using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CAPA_NEGOCIO.Models;
using System.Collections.Generic;
using CAPA_NEGOCIO.Security;
using System.Linq;
using System.Diagnostics;
using static Humanizer.In;
using System.Security.Cryptography;
using CAPA_NEGOCIO.Models.SubModel;

namespace UIPoyecto.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InformeController : ControllerBase
    {
        public InformeController()
        {

            AuthNetCore.loginIN("admin", "admin");
            //aca hay que insertar las validaciones de ussuarios 
        }


        













    }
}
