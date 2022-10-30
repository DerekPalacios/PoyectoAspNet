using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CAPA_NEGOCIO.Models;
using CAPA_NEGOCIO.Security;
using System.Collections.Generic;

namespace UIPoyecto.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GaleraController : ControllerBase
    {
        public GaleraController()
        {
            AuthNetCore.loginIN("x", "y");
        }

        [HttpPost]
        public object SaveGalera(Galera NewGal)
        {
            return NewGal.IdGalera = (int)NewGal.Save();
        }

        [HttpGet]
        public List<Galera> GetGalera()
        {

            return new Galera().Get<Galera>().FindAll(x=>x.EstadoProd==false);

        }





    }
}
