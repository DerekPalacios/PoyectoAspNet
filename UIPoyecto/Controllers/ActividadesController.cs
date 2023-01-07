using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CAPA_NEGOCIO.Models;
using CAPA_NEGOCIO.Models.SubModel;
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

            UpdAct.IdActividadBase = (int)UpdAct.IdActividad;
            UpdAct.IdActividad = null;


            return UpdAct.IdActividad = (int)UpdAct.Save();
        }

        [HttpGet]
        public object GetActividadProduccionActiva()
        {

            var actividadProduccionActiva = new ActividadProduccionActiva().Get<ActividadProduccionActiva>();


            return actividadProduccionActiva;

        }


    }
}
