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
            AuthNetCore.loginIN("admin", "admin");

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
                                            tam = detallepro.Tamaño,
                                            Consumo = detallepro.ConsumoAlimento,
                                            Decesos = detallepro.MuertesTotales,
                                            Lote = detallepro.LoteActual,
                                            peso = detallepro.PesoPromedioSemanal,
                                        };

            return listaProduccionSimple;

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
        public object GetVistaListaProduccionSimpleCalculadaActiva()
        {
            var listaProduccionSimple = from detallepro in new VistaListaProduccionSimpleCalculada().Get<VistaListaProduccionSimpleCalculada>(" Estado = 1 ")
                                        select new
                                        {
                                            estado = detallepro.Estado,
                                            id = detallepro.IdProduccion,
                                            galera = detallepro.NombreGalera,
                                            tam = detallepro.Tamaño,
                                            Consumo = detallepro.ConsumoAlimento,
                                            Decesos = detallepro.MuertesTotales,
                                            Lote = detallepro.LoteActual,
                                            peso = detallepro.PesoPromedioSemanal,
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
            var res = newPro.GuardarProduccionCompleta(newPro);
            return res;
            //return 1;
        }

    }
}
