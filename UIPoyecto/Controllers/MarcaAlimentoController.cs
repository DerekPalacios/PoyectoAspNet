using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CAPA_NEGOCIO.Models;
using System.Collections.Generic;
using CAPA_NEGOCIO.Security;

namespace UIPoyecto.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]
    public class MarcaAlimentoController : ControllerBase
    {
        public MarcaAlimentoController()
        {
            AuthNetCore.loginIN("admin", "admin");
            //aca hay que insertar las validaciones de ussuarios 
        }
        [HttpGet]
        public List<MarcaLineaAlimento> GetMarcaAlimento()
        {
            return new MarcaLineaAlimento().Get<MarcaLineaAlimento>();
        
        }
        [HttpPost]
        public object SaveMarcaAlimento(MarcaLineaAlimento NewMA)
        {
            
            return NewMA.Save();
        }



    }
}
