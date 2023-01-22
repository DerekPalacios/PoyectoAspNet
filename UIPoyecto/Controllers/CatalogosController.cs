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
    public class CatalogosController : ControllerBase
    {
        public CatalogosController()
        {
            //aca hay que insertar las validaciones de ussuarios 

            AuthNetCore.loginIN("admin", "admin");
        }



        ///<summary>
        ///Extrae los datos de la peridiocidad
        ///</summary>
        ///<remarks>
        ///registros de peridiocidad para mostrar en un ddl
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetPeridiocidadDropdown()
        {
            var obj = from Perio in new Periodicidad().Get<Periodicidad>()
                      select new
                      {
                          idPeriodicidad = Perio.IdPeriodicidad,
                          Nombre = Perio.NombrePeriodicidad,
                          salto = Perio.DiasSalto
                      };
            return obj;

        }



        ///<summary>
        ///Extrae los datos de usuarios
        ///</summary>
        ///<remarks>
        ///registros de usuarios 
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetUsuariosActivos()
        {
            var obj = from Usuario in new TblUsuario().Get<TblUsuario>()
                      select new
                      {
                          idUsuario = Usuario.IdUsuario,
                          Nombre = Usuario.NombreUsuario,
                          correo = Usuario.CorreoElecronico,
                          telefono = Usuario.NumeroCelular
                      };
            return obj;

        }








    }
}
