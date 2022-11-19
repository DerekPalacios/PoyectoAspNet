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
        ///Guarda galera basico
        ///</summary>
        ///<returns></returns>

        [HttpPost]
        public object SaveAlimento(Alimento NewAl)
        {
            return NewAl.IdAlimento = (int)NewAl.Save();
        }

        [HttpGet]
        public object GetAlimentos()
        {
            var obj = from Alimento in new Alimento().Get<Alimento>()
                      select new
                      {
                          IdAlimento = Alimento.IdAlimento,
                          Nombre = Alimento.Nombre,
                          Descripcion = Alimento.Descripcion,
                          MarcaId = Alimento.IdMarca
                      };
            return obj;

        }


    }
}