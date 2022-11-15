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



        [HttpGet]
        public object GetVistaListaProduccionSimpleCalculada()
        {
            var listaProduccionSimple = new VistaListaProduccionSimpleCalculada().Get<VistaListaProduccionSimpleCalculada>();

            return listaProduccionSimple;

        }

        [HttpGet]
        public object GetVistaDetalleProduiccionCardProduccion()
        {
            var detalleCardProduccion = new VistaDetalleCardProduccion().Get<VistaDetalleCardProduccion>();
            return detalleCardProduccion;
        }



        [HttpPost]
        public object SaveProD(Produccion newPro)
        {
            try
            {
                newPro.IdProduccion = (int)newPro.Save();
                newPro.GenerarActividadesDiarias();
                return 1;
            }
            catch (System.Exception)
            {

                return 0;
            }

        }

    }
}
