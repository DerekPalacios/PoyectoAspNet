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

        ///<summary>
        ///Guardar Actividad general
        ///</summary>
        ///<remarks>
        ///envio de a ctividades generales nuevas solamente
        ///</remarks>
        ///<returns></returns>
        ///

        [HttpPost]
        public object SaveActividadGeneral(ActividadGeneral NewAct)
        {
            return NewAct.IdActividad = (int)NewAct.Save();
        }

        ///<summary>
        ///Guardar  actuaizar la actividad general
        ///</summary>
        ///<remarks>
        ///aqui la actividad no es actualizada, simplemente crea una nueva y hace referencia a una vieja
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpPost]
        public object UpdateActividadGeneral(ActividadGeneral UpdAct)
        {

            UpdAct.IdActividadBase = (int)UpdAct.IdActividad;
            UpdAct.IdActividad = null;


            return UpdAct.IdActividad = (int)UpdAct.Save();
        }


        [HttpGet]
        public object GetActividadProduccionActiva(int id)
        {

            return  new ActividadProduccion().Get<ActividadProduccion>("IdActividadProduccion + " + id );


            

        }


    }
}
