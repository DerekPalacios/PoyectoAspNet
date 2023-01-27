using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CAPA_NEGOCIO.Models;
using System.Collections.Generic;
using CAPA_NEGOCIO.Security;
using System.Linq;
using System.Diagnostics;
using static Humanizer.In;
using System.Security.Cryptography;
using CAPA_NEGOCIO.Models.SubModel;

namespace UIPoyecto.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlimentoController : ControllerBase
    {
        public AlimentoController()
        {
            AuthNetCore.loginIN("MarioVado", "12345");
            // AuthNetCore.loginIN("admin", "admin");
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
            if (NewAl.IdAlimento != 0)
            {
                return updateAlimento(NewAl);
            }
            return NewAl.IdAlimento = (int)NewAl.Save();
        }
        [HttpPost]
        public object updateAlimento(Alimento linea)
        {
            return linea.Update("IdAlimento");
        }

        ///<summary>
        ///Guarda Linea basico basico
        ///</summary>
        ///<returns></returns>
        [HttpPost]
        public object SaveLineaAlimento(LineaAlimento linea)
        {
            if(linea.IdLineaAlimento!= 0)
            {
                return UpdateLineaAlimento(linea);
            }
            return linea.IdLineaAlimento = (int)linea.Save();
        }

        [HttpPost]
        public object UpdateLineaAlimento(LineaAlimento linea)
        {
            return linea.Update("IdLineaAlimento");
        }


        ///<summary>
        ///Guarda Marca Linea Alimento basico
        ///</summary>
        ///<returns></returns>

        [HttpPost]
        public object SaveMarcaLineaAlimento(MarcaLineaAlimento marca)
        {
            if (marca.IdMarca != 0)
            {
                return updateMarca(marca);
            }
            return marca.IdMarca = (int)marca.Save();
        }

        [HttpPost]
        public object updateMarca(MarcaLineaAlimento linea)
        {
            return linea.Update("IdMarca");
        }

        ///<summary>
        ///Guarda Etapa Alimento basico
        ///</summary>
        ///<returns></returns>

        [HttpPost]
        public object SaveEtapaAlimento (EtapaAlimentoProduccion etapa)
        {
            if (etapa.IdEtapaAlimento != 0)
            {
                return updateEtapa(etapa);
            }
            return etapa.IdEtapaAlimento = (int)etapa.Save();
        }

        [HttpPost]
        public object updateEtapa(EtapaAlimentoProduccion linea)
        {
            return linea.Update("IdEtapaAlimento");
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
        ///Extrae informacion de linea preparada apara dropdown
        ///</summary>
        ///<remarks>
        ///es el id, puesto con el nombre y la marca contatenados para una mejor legibilidad
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetLineaAlimentoDropdown()
        {
            var obj = from Linea in new LineaAlimento().Get<LineaAlimento>()
                      select new
                      {
                          idLinea = Linea.IdLineaAlimento,
                          Nombre = Linea.NombreLinea + " - " + Linea.cargarNombreMarcaAlimento()
                      };
            return obj;

        }


        ///<summary>
        ///Extrae los datos de alimento de la etapa de pre Inicio
        ///</summary>
        ///<remarks>
        ///datos de linea estandar por lo que se puede dejar una funcion estatica
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetAlimentoPreInicioDropdown()
        {
            var obj = from Aliemnto in new Alimento().Get<Alimento>("IdEtapaAlimentoRecomendado = 1")
                      select new
                      {
                          idAlimento = Aliemnto.IdAlimento,
                          Nombre = Aliemnto.Nombre 
                      };
            return obj;

        }


        ///<summary>
        ///Extrae los datos de alimento de la etapa de inicio
        ///</summary>
        ///<remarks>
        ///datos de linea estandar por lo que se puede dejar una funcion estatica
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetAlimentoInicioDropdown()
        {
            var obj = from Aliemnto in new Alimento().Get<Alimento>("IdEtapaAlimentoRecomendado = 2")
                      select new
                      {
                          idAlimento = Aliemnto.IdAlimento,
                          Nombre = Aliemnto.Nombre
                      };
            return obj;

        }

        ///<summary>
        ///Extrae los datos de alimento de la etapa de Desarrollo
        ///</summary>
        ///<remarks>
        ///datos de linea estandar por lo que se puede dejar una funcion estatica
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetAlimentoDesarrolloDropdown()
        {
            var obj = from Aliemnto in new Alimento().Get<Alimento>("IdEtapaAlimentoRecomendado = 3")
                      select new
                      {
                          idAlimento = Aliemnto.IdAlimento,
                          Nombre = Aliemnto.Nombre
                      };
            return obj;

        }

        ///<summary>
        ///Extrae los datos de alimento de la etapa de Finalizacion
        ///</summary>
        ///<remarks>
        ///datos de linea estandar por lo que se puede dejar una funcion estatica
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetAlimentoFinalizacionDropdown()
        {
            var obj = from Aliemnto in new Alimento().Get<Alimento>("IdEtapaAlimentoRecomendado = 4")
                      select new
                      {
                          idAlimento = Aliemnto.IdAlimento,
                          Nombre = Aliemnto.Nombre
                      };
            return obj;

        }

        ///<summary>
        ///Extrae los datos de alimento de todas las etapas
        ///</summary>
        ///<remarks>
        ///datos de linea estandar por lo que se puede dejar una funcion estatica
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetAlimentoAllDropdown()
        {
            var obj = from Aliemnto in new Alimento().Get<Alimento>()
                      select new
                      {
                          idAlimento = Aliemnto.IdAlimento,
                          Nombre = Aliemnto.Nombre
                      };
            return obj;

        }



        ///<summary>
        ///Extrae los datos de alimento de la etapa de pre Inicio filtrado por linea
        ///</summary>
        ///<remarks>
        ///datos de linea estandar por lo que se puede dejar una funcion estatica
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetAlimentoPreInicioDropdownByIdLinea(int IdLinea)
        {
            var obj = from Aliemnto in new Alimento().Get<Alimento>("IdEtapaAlimentoRecomendado = 1 and IdLineaAlimentoRecomendado = "+IdLinea)
                      select new
                      {
                          idAlimento = Aliemnto.IdAlimento,
                          Nombre = Aliemnto.Nombre
                      };
            return obj;

        }


        ///<summary>
        ///Extrae los datos de alimento de la etapa de inicio filtrado por linea
        ///</summary>
        ///<remarks>
        ///datos de linea estandar por lo que se puede dejar una funcion estatica
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetAlimentoInicioDropdownByIdLinea(int IdLinea)
        {
            var obj = from Aliemnto in new Alimento().Get<Alimento>("IdEtapaAlimentoRecomendado = 2 and IdLineaAlimentoRecomendado = " + IdLinea)
                      select new
                      {
                          idAlimento = Aliemnto.IdAlimento,
                          Nombre = Aliemnto.Nombre
                      };
            return obj;

        }

        ///<summary>
        ///Extrae los datos de alimento de la etapa de Desarrollo filtrado por linea
        ///</summary>
        ///<remarks>
        ///datos de linea estandar por lo que se puede dejar una funcion estatica
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetAlimentoDesarrolloDropdownByIdLinea(int IdLinea)
        {
            var obj = from Aliemnto in new Alimento().Get<Alimento>("IdEtapaAlimentoRecomendado = 3 and IdLineaAlimentoRecomendado = " + IdLinea)
                      select new
                      {
                          idAlimento = Aliemnto.IdAlimento,
                          Nombre = Aliemnto.Nombre
                      };
            return obj;

        }

        ///<summary>
        ///Extrae los datos de alimento de la etapa de Finalizacion filtrado por linea
        ///</summary>
        ///<remarks>
        ///datos de linea estandar por lo que se puede dejar una funcion estatica
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpGet]
        public object GetAlimentoFinalizacionDropdownByIdLinea(int IdLinea)
        {
            var obj = from Aliemnto in new Alimento().Get<Alimento>("IdEtapaAlimentoRecomendado = 4 and IdLineaAlimentoRecomendado = " + IdLinea)
                      select new
                      {
                          idAlimento = Aliemnto.IdAlimento,
                          Nombre = Aliemnto.Nombre
                      };
            return obj;

        }







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

        [HttpGet]
        public object GetIdLineaAlimentoByIdAlimento(int IdAlimento)
        {
            var obj = new Alimento().Get<Alimento>("IdAlimento = " + IdAlimento).First();
            return obj.IdLineaAlimentoRecomendado;
        }

        [HttpGet]
        public object GetIdEtapaAlimentoByIdAlimento(int IdAlimento)
        {
            var obj = new Alimento().Get<Alimento>("IdAlimento = " + IdAlimento).First();
            return obj.IdEtapaAlimentoRecomendado;
        }

        [HttpGet]
        public object GetIdMarcaLineaAlimentoByIdLineaAlimento(int IdLineaAlimento)
        {
            var obj = new LineaAlimento().Get<LineaAlimento>("IdLineaAlimento = " + IdLineaAlimento).First();
            return obj.IdMarcaLinea;
        }


        [HttpGet]
        public object GetLineaAlimentoSimple()
        {
            var obj = from Linea in new LineaAlimento().Get<LineaAlimento>()
                      select new
                      {
                          idLinea = Linea.IdLineaAlimento,
                          Nombre = Linea.NombreLinea,
                          Descripcion = Linea.DescripcionLinea,
                          idMarca = Linea.IdMarcaLinea
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




        ///<summary>
        ///Regresa lista de alimentos asignados por produccion
        ///</summary>
        ///<returns></returns>

        [HttpGet]
        public object GetAlimentoByIdProduccion(int IdProduccion)
        {
            var obj = from Alimento in new AlimentoProduccionForDetailView().Get<AlimentoProduccionForDetailView>("IdProduccion = " + IdProduccion)
                      select Alimento;
            return obj;

        }









    }
}