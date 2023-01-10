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
        ///Regresa lista basica de Marca de linea de alimentacion
        ///</summary>
        ///<returns></returns>

        [HttpGet]
        public object Get()
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

    }
}