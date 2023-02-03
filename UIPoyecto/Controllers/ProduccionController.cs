using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CAPA_NEGOCIO.Models;
using CAPA_NEGOCIO.Models.SubModel;
using System.Collections.Generic;
using CAPA_NEGOCIO.Security;
using System.Linq;

namespace UIPoyecto.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProduccionController : ControllerBase
    {


        public ProduccionController()
        {
            AuthNetCore.loginIN("MarioVado", "12345");

        }

        //gets ->


        ///<summary>
        ///Extrae los detalles de alimento by id produccion
        ///</summary>
        ///<returns></returns>
        [HttpGet]
        public object GetDetalleEtapaAimentoProduccionByIdProduccion(int IdProduccion)
        {
            return new DetalleEtapaAlimentoProduccion().Get<DetalleEtapaAlimentoProduccion>("IdProduccionDetalleAlimento = " + IdProduccion);
        }






        ///<summary>
        ///Extrae las producciones en literal
        ///</summary>
        ///<returns></returns>

        [HttpGet]
        public object GetProduccionBasica()
        {
            return new Produccion().Get<Produccion>();
        }

        ///<summary>
        ///Extrae las producciones activas en literal
        ///</summary>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetProduccionActivaBasica()
        {
            return new Produccion().Get<Produccion>("EstadoProduccion = 1");
        }

        ///<summary>
        ///Extrae una produccion segun el id para la vista de detalles de produccion
        ///</summary>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetDetalleProduccionByIdProduccion(int IdProduccion)
        {
            var resp = from produccionDetalle in new ProduccionForDetailView().Get<ProduccionForDetailView>("IdProduccion = " + IdProduccion)
                       select new
                       {
                           estado = produccionDetalle.EstadoProduccion,
                           nombre = produccionDetalle.Nombre,
                           Id = produccionDetalle.IdProduccion,
                           lote = produccionDetalle.Lote,
                           quintalesUtilizados = produccionDetalle.QuintUtil,
                           fechaIngreso = produccionDetalle.FechaDeIngreso.ToShortDateString(),
                           fechaSalida = produccionDetalle.FechaSalida.ToShortDateString(),
                       };
            return resp;
        }


        ///<summary>
        ///Extrae los datos de produccion con una vista smple calculada
        ///</summary>
        ///<remarks>
        ///datos traidos dede una sola vista
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetVistaListaProduccionSimpleCalculada()
        {
            var listaProduccionSimple = from detallepro in new VistaListaProduccionSimpleCalculada().Get<VistaListaProduccionSimpleCalculada>()
                                        select new
                                        {
                                            estado = detallepro.Estado,
                                            id = detallepro.IdProduccion,
                                            galera = detallepro.NombreGalera,
                                            Lote = detallepro.LoteActual,
                                            peso = detallepro.PesoPromedioSemanal,
                                            actividades = new Produccion().GetProgresoActividadDiaria((int)detallepro.IdProduccion),
                                            tratamientos = new Produccion().GetProgresoTratamientoDiaria((int)detallepro.IdProduccion)
                                        };

            return listaProduccionSimple;

        }


        [HttpGet]
        public object GetVistaListaProduccionSimpleCalculadaFilteredByLote(int lote)
        {
            var listaProduccionSimple = from detallepro in new VistaListaProduccionSimpleCalculada().Get<VistaListaProduccionSimpleCalculada>(" Estado = 1 ")
                                        where detallepro.LoteActual == lote
                                        select new
                                        {
                                            estado = detallepro.Estado,
                                            id = detallepro.IdProduccion,
                                            galera = detallepro.NombreGalera,
                                            Lote = 200,
                                            peso = 0,
                                            Actividades = new Produccion().GetProgresoActividadDiaria((int)detallepro.IdProduccion),
                                            tratamientos = new Produccion().GetProgresoTratamientoDiaria((int)detallepro.IdProduccion)
                                        };


            return listaProduccionSimple;
        }
        //[HttpGet]
        //public object GetVistaListaProduccionSimpleCalculadaFilteredByLote(int loteInicial, int loteFinal)
        //{
        //    var listaProduccionSimple = from detallepro in new VistaListaProduccionSimpleCalculada().Get<VistaListaProduccionSimpleCalculada>(" Estado = 1 ")
        //                                where detallepro.LoteActual >= loteInicial && detallepro.LoteActual <= loteFinal
        //                                select new
        //                                {
        //                                    estado = detallepro.Estado,
        //                                    id = detallepro.IdProduccion,
        //                                    galera = detallepro.NombreGalera,
        //                                    Lote = detallepro.LoteActual,
        //                                    peso = detallepro.PesoPromedioSemanal,
        //                                    actividades = new Produccion().GetProgresoActividadDiaria((int)detallepro.IdProduccion),
        //                                    tratamientos = new Produccion().GetProgresoTratamientoDiaria((int)detallepro.IdProduccion)
        //                                };


        //    return listaProduccionSimple;
        //}
        [HttpGet]
        public object GetVistaListaProduccionSimpleCalculadaFilteredByMes(int mes)
        {
            var listaProduccionSimple = from detallepro in new VistaListaProduccionSimpleCalculada().Get<VistaListaProduccionSimpleCalculada>(" Estado = 1 ")
                                        where (detallepro.FechaDeIngreso.Month <= mes && mes <= detallepro.FechaSalida.Month)
                                        select new
                                        {
                                            estado = detallepro.Estado,
                                            id = detallepro.IdProduccion,
                                            galera = detallepro.NombreGalera,
                                            Lote = 200,
                                            peso = 0,
                                            Actividades = new Produccion().GetProgresoActividadDiaria((int)detallepro.IdProduccion),
                                            tratamientos = new Produccion().GetProgresoTratamientoDiaria((int)detallepro.IdProduccion)
                                        };


            return listaProduccionSimple;
        }
        //[HttpGet]
        //public object GetVistaListaProduccionSimpleCalculadaFilteredByMes(int mesInicio, int mesFinal)
        //{
        //    var listaProduccionSimple = from detallepro in new VistaListaProduccionSimpleCalculada().Get<VistaListaProduccionSimpleCalculada>(" Estado = 1 ")
        //                                where detallepro.FechaDeIngreso.Month >= mesInicio && detallepro.FechaDeIngreso.Month <= mesFinal || detallepro.FechaSalida.Month >= mesInicio && detallepro.FechaSalida.Month <= mesFinal
        //                                select new
        //                                {
        //                                    estado = detallepro.Estado,
        //                                    id = detallepro.IdProduccion,
        //                                    galera = detallepro.NombreGalera,
        //                                    Lote = detallepro.LoteActual,
        //                                    peso = detallepro.PesoPromedioSemanal,
        //                                    actividades = new Produccion().GetProgresoActividadDiaria((int)detallepro.IdProduccion),
        //                                    tratamientos = new Produccion().GetProgresoTratamientoDiaria((int)detallepro.IdProduccion)
        //                                };


        //    return listaProduccionSimple;
        //}



        ///<summary>
        ///Extrae los datos de produccion con una vista smple calculada
        ///</summary>
        ///<remarks>
        ///datos traidos dede una sola vista
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetVistaListaProduccionSimpleCalculadaActiva()
        {
            var listaProduccionSimple = from detallepro in new VistaListaProduccionSimpleCalculada().Get<VistaListaProduccionSimpleCalculada>(" Estado = 1 ")
                                        select new
                                        {
                                            estado = detallepro.Estado,
                                            id = detallepro.IdProduccion,
                                            galera = detallepro.NombreGalera,
                                            Lote = 200,
                                            peso = 0,
                                            Actividades = new Produccion().GetProgresoActividadDiaria((int)detallepro.IdProduccion),
                                            tratamientos = new Produccion().GetProgresoTratamientoDiaria((int)detallepro.IdProduccion)
                                        };

            return listaProduccionSimple;

        }



        [HttpGet]
        public object GetVistaDetalleProduiccionCardProduccion()
        {
            var detalleCardProduccion = new VistaDetalleCardProduccion().Get<VistaDetalleCardProduccion>();
            return detalleCardProduccion;
        }


        //posts ->


        [HttpPost]
        public object SaveProD(Produccion newPro)
        {
            newPro.IdUsuarioRegistro =(int)AuthNetCore.User.UserId;
            var res = newPro.GuardarProduccionCompleta(newPro);
            return res;
            //return 1;
        }

    }
}
