using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CAPA_NEGOCIO.Models;
using CAPA_NEGOCIO.Security;
using System.Collections.Generic;
using System.Linq;

namespace UIPoyecto.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GaleraController : ControllerBase
    {
        public GaleraController()
        {
            AuthNetCore.loginIN("MarioVado", "12345");
            //AuthNetCore.loginIN("x", "y");
        }

        ///<summary>
        ///Guarda informacion de galera basico
        ///</summary>
        ///<remarks>
        ///guardado simple de informacion de galera
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpPost]
        public object SaveGalera(Galera NewGal)
        {

            if(NewGal.IdGalera != 0) 
            {
                return UpdateGalera(NewGal);
            }


            return NewGal.IdGalera = (int)NewGal.Save();
        }


        ///<summary>
        ///Actualiza informacion de galera basico
        ///</summary>
        ///<remarks>
        ///Actualizacion de informacion de galera basico
        ///</remarks>
        ///<returns></returns>
        ///
        [HttpPost]
        public object UpdateGalera(Galera updGalera)
        {
            return  (int)updGalera.Update("IdGalera");
        }

        [HttpGet]
        public List<Galera> GetGaleraSinProduccion()
        {

            return new Galera().Get<Galera>().FindAll(x => x.EstadoProd == false);

        }



        [HttpGet]
        public object getnormal(int idAlgo)
        {

            return idAlgo;
        }


        [HttpGet]
        public object GetGalera()
        {

            var obj = from Galera in new Galera().Get<Galera>()
                      select new
                      {
                          Id = Galera.IdGalera,
                          Nombre = Galera.Nombre,
                          Ancho = Galera.DimensionA,
                          Largo = Galera.DimensionL,
                          Latitud = Galera.Latitud,
                          Longitud = Galera.Longitud,
                          CapMax = Galera.CapMProduccion
                      };

            return obj;
        }




    }
}
