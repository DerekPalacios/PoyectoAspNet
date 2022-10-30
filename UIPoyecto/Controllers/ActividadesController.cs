using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CAPA_NEGOCIO.Models;
using System.Collections.Generic;
using CAPA_NEGOCIO.Security;
using System.Linq;
using System;

namespace UIPoyecto.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {
        public ActividadesController()
        {

            //aca hay que insertar las validaciones de ussuarios 

            AuthNetCore.loginIN("admin", "admin");
        }

        [HttpPost]
        public object SaveActividadGeneral(ActividadGeneral NewAct)
        {
            return NewAct.IdActividad = (int)NewAct.Save();
        }

        [HttpPost]
        public object UpdateActividadGeneral(ActividadGeneral UpdAct)
        {

            UpdAct.IdActividadBase = UpdAct.IdActividad;
            UpdAct.IdActividad = null;


            return UpdAct.IdActividad = (int)UpdAct.Save();
        }

        public object GetActividadesByProduccion(int iodProduccion)
        {
            //hay qyue hacer un inner join y vamosa ver como se trabaja

            return 1;

        }


    }
}
