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
        public object getnormal(int idAlgo)
        {

            return idAlgo;
        }


        [HttpGet]
        public object GetGalera()
        {

            var obj = from Galera in new Galera().Get<Galera>()
                      select new
                      {
                          Nombre = Galera.Nombre,
                          Ancho = Galera.DimensionA,
                          Largo = Galera.DimensionL,
                          Latitud = Galera.Latitud,
                          Longitud = Galera.Longitud,
                          CapMax = Galera.CapMProduccion
                      };

            return obj;
        }




    }
}
