using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CAPA_NEGOCIO.Models;
using System.Collections.Generic;
using CAPA_NEGOCIO.Security;
using System.Linq;
using CAPA_NEGOCIO.Models.SubModel;
using Microsoft.EntityFrameworkCore.Design;

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

        ///<summary>
        ///Extrae los datos especie basico
        ///</summary>
        ///<remarks>
        ///datos traidos dede una sola vista
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetEspeciesBasico()
        {
            var obj = from Especie in new EspeciePollo().Get<EspeciePollo>()
                      select new
                      {
                          Id = Especie.IdEspecie,
                          Descripccion = Especie.Descripccion,
                          precio = Especie.PrecioUnit,
                          Origen = Especie.PaisOrigen,
                          semanas = Especie.SemanasProduccion
                      };

            return obj;

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




        ///<summary>
        ///Guardar informacion de especie basico
        ///</summary>
        ///<remarks>
        ///guardar de informacion de especie basico
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpPost]
        public object SaveEspeciePollo(EspeciePollo NesEspeciePollo)
        {
            if (NesEspeciePollo.IdEspecie != 0)
            {
                return UpdateEspecie(NesEspeciePollo);
            }

            return NesEspeciePollo.Save();
        }

        ///<summary>
        ///Actualiza informacion de especie basico
        ///</summary>
        ///<remarks>
        ///Actualizacion de informacion de especie basico
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpPost]
        public object UpdateEspecie(EspeciePollo upd)
        {
            return (int)upd.Update("IdEspecie");
        }


    }
}
