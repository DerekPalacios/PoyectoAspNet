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

        [HttpPost]
        public object SaveTratamientoProduccion(TratamientoProduccion NewTrat)
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

        [HttpGet]
        public object GetTratamientosProduccion()
        {
            List<TratamientoProduccion> tratamientosProd = (List<TratamientoProduccion>)new TratamientoProduccion()
                .Get<TratamientoProduccion>()
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
        public object GetTratamientos()
        {
            List<Tratamiento> Tratamientos = (List<Tratamiento>)new Tratamiento()
                .Get<Tratamiento>()
                .Select(x => { x.CargarPeriodicidad(); return x; });

            var obj = from Tratamiento in Tratamientos
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
                          CostoTratamiento = Tratamiento.CostoTratamientoCompleto,
                          Dosis = Tratamiento.DosisTotales
                      };
            return obj;

        }
    }
}
