﻿using Microsoft.AspNetCore.Http;
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
            AuthNetCore.loginIN("MarioVado", "12345");
            //AuthNetCore.loginIN("admin", "admin");
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
            var obj = from Usuario in new UsuarioParaTabla().Get<UsuarioParaTabla>()
                      select new
                      {
                          idUsuario = Usuario.IdUsuario,
                          Nombre = Usuario.NombreUsuario,
                          correo = Usuario.CorreoElecronico,
                          telefono = Usuario.NumeroCelular,
                          cargo = Usuario.NombreCargo
                      };
            return obj;

        }

        [HttpGet]
        public object GetRolesUsuarios()
        {
            var obj = from Usuario in new TblCargoUsuario().Get<TblCargoUsuario>()
                      select new
                      {
                          iscargo = Usuario.IdCargo,
                          Cargo = Usuario.NombreCargo,
                          descripcion = Usuario.DescripcionCargo
                      };
            return obj;

        }

        [HttpGet]
        public object GetLogUser()
        {
            var obj = AuthNetCore.User;
            return obj;

        }

            [HttpPost]
        public object SaveCargoUsuario(TblCargoUsuario NewAl)
        {
            if (NewAl.IdCargo != 0)
            {
                return updateCargo(NewAl);
            }
            var x =NewAl.Save();
            return x;
        }
        [HttpPost]
        public object updateCargo(TblCargoUsuario linea)
        {
            return linea.Update("IdCargo");
        }


        [HttpGet]
        public object getCurrentUser()
        {
            string name =AuthNetCore.User.user.ToString();
            return name;
        }



    }
}
