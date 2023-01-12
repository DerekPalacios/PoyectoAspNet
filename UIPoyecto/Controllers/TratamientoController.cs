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
    public class TratamientoController : ControllerBase
    {
        public TratamientoController()
        {
            //aca hay que insertar las validaciones de ussuarios 

            AuthNetCore.loginIN("admin", "admin");
        }

        [HttpPost]
        public object SaveTratamiento(Tratamiento NewTrat)
        {
            return NewTrat.IdTratamiento = (int)NewTrat.Save();
        }

        //POSTS  --------------------------------------------------

        [HttpPost]
        public object SaveTratamientoProduccion(TratamientoProduccionAsignado NewTrat)
        {
            try
            {
                NewTrat.IdTratamientoProduccion = (int)NewTrat.Save();
                NewTrat.GenerarTratamientoDiario();
                return NewTrat.IdTratamientoProduccion;
            }
            catch
            {
                return 0;
            }
        }





        ///<summary>
        ///Guardar Via de administracion de tratamiento basico
        ///</summary>
        ///<returns></returns>
        ///

        [HttpPost]
        public object SaveViaAdministracionTratamiento(ViaAdministracionTratamiento administracionTratamiento)
        {
            return  administracionTratamiento.IdViaAdministracion = (int)administracionTratamiento.Save();
        }


        ///<summary>
        ///Guardar tratamiento de produccion asignado
        ///</summary>
        ///<remarks>
        ///podes mandar todos los bool de estado en false para que no te compliques
        ///</remarks>
        ///<returns></returns>
        ///

        [HttpPost]
        public object SaveTratamiendoProduccionAsignado(TratamientoProduccionAsignado tratamientoProduccion)
        {
            //se aplican reglas de negocio por la generacion de actividades de tratamiento, asi que 
            //van cargados al modelo directamente
            return tratamientoProduccion.GuardarTratamientoProduccionCompleto(tratamientoProduccion);
        }


        //GETS-----------------------------------------------

        ///<summary>
        ///Extrae las vias de administracion de tratamiento basicos
        ///</summary>
        ///<returns></returns>
        ///

        [HttpGet]
        public object GetViaAdministracionBasico()
        {
            return new ViaAdministracionTratamiento().Get<ViaAdministracionTratamiento>();
        }

        



        ///<summary>
        ///Extrae los tratamientos en literal
        ///</summary>
        ///<returns></returns>
        ///

        [HttpGet]
        public object GetTratamientosBasico()
        {
            return new Tratamiento().Get<Tratamiento>();
        }


        [HttpGet]
        public object GetTratamientosProduccion()
        {
                //con false carga el nombre del tratamiento
            List<TratamientoProduccionAsignado> tratamientosProd = (List<TratamientoProduccionAsignado>)new TratamientoProduccionAsignado(false)
                .Get<TratamientoProduccionAsignado>()
                .Select(x => { x.CargarNombreTratamiento(); return x; });
            return tratamientosProd;
        }

        [HttpGet]
        public object GetTratamientoDiarioaByIdTratamientoProduccion(int idTraProd)
        {
            List<AplicacionTratamientoDiario> AplicacionDiaria = (List<AplicacionTratamientoDiario>)new AplicacionTratamientoDiario()
                .Get<AplicacionTratamientoDiario>("IdTratamientoProduccion = " + idTraProd);
            return AplicacionDiaria;
        }
        [HttpGet]
        public object GetTratamientoDiarioaByFechaAplicacion(DateTime fechaFiltro)
        {
            List<AplicacionTratamientoDiario> AplicacionDiaria = (List<AplicacionTratamientoDiario>)new AplicacionTratamientoDiario()
                .Get<AplicacionTratamientoDiario>("FechaAplicacion = " + fechaFiltro);
            return AplicacionDiaria;
        }


        [HttpGet]
        public object GetTratamientoConPeridiocidad()
        {
           
            //con true carga peridiocidad
            var obj = from Tratamiento in new Tratamiento(true).Get<Tratamiento>()
                      select new
                      {
                          IdTratamiento = Tratamiento.IdTratamiento,
                          Nombre = Tratamiento.Nombre,
                          Descripcion = Tratamiento.Descripcion,
                          Marca = Tratamiento.Marca,
                          DosisRecomendada = Tratamiento.DosisDiariaRecomendada,
                          Periodicidad = Tratamiento.PeriodicidadVar,
                          IdUsuario = Tratamiento.IdUsuarioRegistro,
                          FechaRegsitro = Tratamiento.FechaRegistro,
                          Dosis = Tratamiento.DosisTotales
                      };
            return obj;

        }
    }
}
