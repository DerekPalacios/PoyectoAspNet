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
    public class EspeciePolloController : ControllerBase
    {
        public EspeciePolloController()
        {
            AuthNetCore.loginIN("admin", "admin");

        }


        [HttpGet]
        public object GetEspeciesNombreCompuesto()
        {
            var obj = from Especie in new EspeciePollo().Get<EspeciePollo>()
                      select new
                      {
                          IdEspecie = Especie.IdEspecie,
                          Descripccion = Especie.Descripccion + "-- $" + Especie.PrecioUnit,
                          PaisOrigen = Especie.PaisOrigen,
                          PrecioUnit = Especie.PrecioUnit,
                          semanaProduccion = Especie.SemanasProduccion
                      };

            return obj;
        }
        [HttpPost]
        public object SaveEspeciePollo(EspeciePollo NesEspeciePollo)
        {
            return NesEspeciePollo.Save();
        }




    }
}
