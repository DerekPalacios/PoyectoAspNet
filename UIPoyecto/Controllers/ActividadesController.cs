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
            AuthNetCore.loginIN("MarioVado", "12345");
            // AuthNetCore.loginIN("admin", "admin");
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
            return UpdAct.ActualizarActividad(UpdAct);
        }


        [HttpGet]
        public object GetActividadProduccionActiva(int id)
        {
            return  new ActividadProduccion().Get<ActividadProduccion>("IdActividadProduccion + " + id );

        }


        ///<summary>
        ///Extraer datos de actividades por id de produccion
        ///</summary>
        ///<remarks>
        ///jala los datos de las aactividades por produccion,esten activas o no, las jala todas
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetActividadesByIdProduccion(int IdProduccion)
        {

            var resp = from activicidades in new ActividadesProduccion().Get<ActividadesProduccion>("IdProduccion = " + IdProduccion)
                       select new
                       {
                           estado = activicidades.Estado,
                           id = activicidades.IdActividadProduccion,
                           fechaAsignacion = activicidades.FechaAsignacionActividad.ToShortDateString(),
                           nombre = activicidades.NombreActividad,
                           descripcion = activicidades.DescripcionActividad,
                           usuario = activicidades.NombreUsuario == "null" ? activicidades.NombreUsuario : "N/C"
                       };



            return resp;

        }
        ///<summary>
        ///Extraer datos de actividades por id de produccion y fecha 
        ///</summary>
        ///<remarks>
        ///jala los datos de las aactividades por produccion,esten activas o no, las jala todas
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetActividadesByIdProduccionFecha(int IdProduccion, string Fecha)
        {

            var resp = from activicidades in new ActividadesProduccion().Get<ActividadesProduccion>("IdProduccion = " + IdProduccion + " and FechaAsignacionActividad = "+ Fecha)
                       select new
                       {
                           estado = activicidades.Estado,
                           id = activicidades.IdActividadProduccion,
                           fechaAsignacion = activicidades.FechaAsignacionActividad.ToShortDateString(),
                           nombre=activicidades.NombreActividad,
                           descripcion=activicidades.DescripcionActividad,
                           usuario = activicidades.NombreUsuario == "null" ? activicidades.NombreUsuario: "N/C" 
                       };


            return resp;

        }



    }
}
