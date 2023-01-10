using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CAPA_NEGOCIO.Models;
using System.Collections.Generic;
using CAPA_NEGOCIO.Security;
using System.Linq;

namespace UIPoyecto.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlimentoController : ControllerBase
    {
        public AlimentoController()
        {
            AuthNetCore.loginIN("admin", "admin");
            //aca hay que insertar las validaciones de ussuarios 
        }


        //insercion de datos

        ///<summary>
        ///Guarda alimento basico
        ///</summary>
        ///<returns></returns>

        [HttpPost]
        public object SaveAlimento(Alimento NewAl)
        {
            return NewAl.IdAlimento = (int)NewAl.Save();
        }

        ///<summary>
        ///Guarda Linea basico basico
        ///</summary>
        ///<returns></returns>

        [HttpPost]
        public object SaveLineaAlimento(LineaAlimento linea)
        {
            return linea.IdLineaAlimento = (int)linea.Save();
        }

        ///<summary>
        ///Guarda Marca Linea Alimento basico
        ///</summary>
        ///<returns></returns>

        [HttpPost]
        public object SaveMarcaLineaAlimento(MarcaLineaAlimento marca)
        {
            return marca.IdMarca = (int)marca.Save();
        }

        ///<summary>
        ///Guarda Etapa Alimento basico
        ///</summary>
        ///<returns></returns>

        [HttpPost]
        public object SaveEtapaAlimento (EtapaAlimentoProduccion etapa)
        {
            return etapa.IdEtapaAlimento = (int)etapa.Save();
        }

        ///<summary>
        ///Guarda Detalle de Alimento Aplicado por Etapa en produccion
        ///</summary>
        ///<returns></returns>

        [HttpPost]
        public object SaveDetalleAlimentoProduccion(DetalleEtapaAlimentoProduccion detalleEtapa)
        {
            return detalleEtapa.IdDetalleEstapaAlimentoProduccion = (int)detalleEtapa.Save();
        }

        ///<summary>
        ///Guarda lista Detalle de Alimento Aplicado por Etapa en produccion
        ///</summary>
        ///<returns></returns>

        [HttpPost]
        public object SaveListaDetalleAlimentoProduccion(List<DetalleEtapaAlimentoProduccion> detalleEtapa)
        {
            return new DetalleEtapaAlimentoProduccion().GuardarColleccionDetallesAlimentoProduccion(detalleEtapa);
        }

        //extraccion de datos ------------------------------------------------------------------


        ///<summary>
        ///Regresa informacion de alimento de simplificada
        ///</summary>
        ///<returns></returns>

        [HttpGet]
        public object GetAlimentos()
        {
            var obj = from Alimento in new Alimento().Get<Alimento>()
                      select new
                      {
                          IdAlimento = Alimento.IdAlimento,
                          Nombre = Alimento.Nombre,
                          Descripcion = Alimento.Descripcion
                      };
            return obj;

        }

        ///<summary>
        ///Regresa informacion de alimento completa
        ///</summary>
        ///<returns></returns>

        [HttpGet]
        public object GetAlimentoCompleto()
        {
            var obj = from Alimento in new Alimento().Get<Alimento>()
                      select new
                      {
                          IdAlimento = Alimento.IdAlimento,
                          Nombre = Alimento.Nombre,
                          Descripcion = Alimento.Descripcion,
                          Etapa = Alimento.cargarNombreEtapa(),
                          Linea = Alimento.cargarNombreLinea(),
                      };
            return obj;

        }

        ///<summary>
        ///Regresa lista basica de linea de alimentacion
        ///</summary>
        ///<returns></returns>

        [HttpGet]
        public object GetLineaAlimento()
        {
            var obj = from Linea in new LineaAlimento().Get<LineaAlimento>()
                      select new
                      {
                          idLinea = Linea.IdLineaAlimento,
                          Nombre = Linea.NombreLinea,
                          Descripcion = Linea.DescripcionLinea,
                          NombreMarca = Linea.cargarNombreMarcaAlimento()
                      };
            return obj;

        }

        ///<summary>
        ///Regresa lista basica de Marca de linea de alimentacion
        ///</summary>
        ///<returns></returns>

        [HttpGet]
        public object GetMarcaLineaAlimento()
        {
            var obj = from Marca in new MarcaLineaAlimento().Get<MarcaLineaAlimento>()
                      select new
                      {
                          IdMarca = Marca.IdMarca,
                          Nombre = Marca.Nombre,
                          Descripcion = Marca.DescripcionMarca
                      };
            return obj;

        }

        ///<summary>
        ///Regresa lista basica de Etapa de alimento
        ///</summary>
        ///<returns></returns>

        [HttpGet]
        public object GetEtapaAlimento()
        {
            var obj = from Etapa in new EtapaAlimentoProduccion().Get<EtapaAlimentoProduccion>()
                      select new
                      {
                          IdEtapa = Etapa.IdEtapaAlimento,
                          Nombre = Etapa.NombreEtapa,
                          Descripcion = Etapa.DescripcionEtapa
                      };
            return obj;

        }












    }
}