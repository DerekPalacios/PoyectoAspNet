using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CAPA_NEGOCIO.Models;
using CAPA_NEGOCIO.Security;
using System.Collections.Generic;
using System.Linq;

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
        public List<Galera> GetGaleraSinProduccion()
        {

            return new Galera().Get<Galera>().FindAll(x => x.EstadoProd == false);

        }

        [HttpGet]
        public object GetGalera()
        {

            var obj = from Galera in new Galera().Get<Galera>()
                      select new
                      {
                          nombre = Galera.Nombre,
                          ancho = Galera.DimensionA,
                          largo = Galera.DimensionL,
                          latitud = Galera.Latitud,
                          longitud = Galera.Longitud,
                          capmax = Galera.CapMproduccion
                      };

            return obj;
        }




    }
}
