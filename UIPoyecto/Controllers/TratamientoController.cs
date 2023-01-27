using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CAPA_NEGOCIO.Models;
using System.Collections.Generic;
using CAPA_NEGOCIO.Security;
using System.Linq;
using System;
using CAPA_NEGOCIO.Models.SubModel;

namespace UIPoyecto.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TratamientoController : ControllerBase
    {
        public TratamientoController()
        {
            //aca hay que insertar las validaciones de ussuarios 
            AuthNetCore.loginIN("MarioVado", "12345");
            // AuthNetCore.loginIN("admin", "admin");
        }

        [HttpPost]
        public object SaveTratamiento(Tratamiento NewTrat)
        {
            return NewTrat.IdTratamiento = (int)NewTrat.Save();
        }

        //POSTS  --------------------------------------------------


        ///<summary>
        ///Guardar Via de administracion de tratamiento basico
        ///</summary>
        ///<returns></returns>
        ///

        [HttpPost]
        public object SaveViaAdministracionTratamiento(ViaAdministracionTratamiento administracionTratamiento)
        {
            return administracionTratamiento.IdViaAdministracion = (int)administracionTratamiento.Save();
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
            tratamientoProduccion.IdUsuarioAsigna =(int)AuthNetCore.User.UserId;
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
        ///Extrae un modelo de tratamiento para asignar un tratamiento existente a una nueva produccion
        ///</summary>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetTratamientoByIdTratamiento(int IdTratamiento)
        {
            var obj = from tratamientiAsignado in new TratamientoAsignacionNuevaProduccion().Get<TratamientoAsignacionNuevaProduccion>("IdTratamiento = " + IdTratamiento)
                      select new
                      {
                          id = tratamientiAsignado.IdTratamiento,
                          nombreTratamiento = tratamientiAsignado.Nombre,
                          marca = tratamientiAsignado.Marca,
                          dosisRecomendada = tratamientiAsignado.DosisDiariaRecomendada,
                          lote=tratamientiAsignado.LoteAdministracionRecomendada,
                          idVia = tratamientiAsignado.IdViaAdministracionRecomendada,
                          descripcion = tratamientiAsignado.Descripcion,
                          descripcionDosis = tratamientiAsignado.DescripcionDosisdiaria,
                          dosisTotales = tratamientiAsignado.DosisTotalesRecomendadas,
                          nombrePeridiocidad = tratamientiAsignado.NombrePeriodicidad,
                          idPeridiocidad = tratamientiAsignado.IdPeriodicidad,
                          administracion = tratamientiAsignado.TipoAdministracion
                      };
            return obj.First();

        }



        ///<summary>
        ///Extrae los tratamientos en literal
        ///</summary>
        ///<returns></returns>
        ///

        [HttpGet]
        public object GetTratamientosBasico()
        {
            return new VistaTratamientoBasico().Get<VistaTratamientoBasico>();
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
        public object GetDetalleActividadDiariaTratamientoByIdProduccion(int IdProduccion)
        {
            var obj = from detalleTratamiento in new ActividadDiariaTratamiento().Get<ActividadDiariaTratamiento>("IdProduccion = " + IdProduccion)
                      select new
                      {
                          estado = detalleTratamiento.EstadoAlplicacion,
                          id = detalleTratamiento.IdActividadTratamiento,
                          fechaAsignacion = detalleTratamiento.FechaAplicacion,
                          sanitario = detalleTratamiento.CambioEstadoPermitidoActividadTratamiento,
                          usuario = "N/C"

                      };
            return obj;
        }

        [HttpGet]
        public object GetDetalleActividadDiariaTratamientoByIdTratamientoProduccion(int IdTratamientoProduccion)
        {
            var obj = from detalleTratamiento in new DetallesTratamientoDiario().Get<DetallesTratamientoDiario>("IdProduccion = " + IdTratamientoProduccion)
                      select new
                      {
                          id = detalleTratamiento.IdActividadTratamiento,
                          aplicacion = detalleTratamiento.FechaAplicacion,
                          sanitario = detalleTratamiento.TratamientoSanitario,
                          administracion = detalleTratamiento.TipoAdministracion
                      };
            return obj;
        }

        [HttpGet]
        public object GetTratamientoProduccionAsignado()
        {
            var obj = from tratamientiAsignado in new TratamientoProduccionAsignado().Get<TratamientoProduccionAsignado>()
                      select new
                      {
                          id = tratamientiAsignado.IdViaAdministracionAplicacada,
                          dosis = tratamientiAsignado.DosisDiariaAplicada,
                          asignacion = tratamientiAsignado.FechaAsignacion,
                          progreso = tratamientiAsignado.ProgresoAplicacion
                      };
            return obj;
        }
        [HttpGet]
        public object GetTratamientoProduccionAsignadoByIdProduccion(int IdProduccion)
        {
            var obj = from tratamientiAsignado in new TratamientoProduccionAsignado().Get<TratamientoProduccionAsignado>("IdProduccion = " + IdProduccion)
                      select new
                      {
                          id = tratamientiAsignado.IdViaAdministracionAplicacada,
                          dosis = tratamientiAsignado.DosisDiariaAplicada,
                          asignacion = tratamientiAsignado.FechaAsignacion,
                          progreso = tratamientiAsignado.ProgresoAplicacion
                      };
            return obj;
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
                          Dosis = Tratamiento.DosisTotalesRecomendadas
                      };
            return obj;

        }
    }
}
