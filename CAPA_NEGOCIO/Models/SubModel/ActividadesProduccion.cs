using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
using System.Linq;

namespace CAPA_NEGOCIO.Models.SubModel
{
    public partial class ActividadesProduccion : EntityClass
    {
        public string NombreActividad { get; set; }
        public string DescripcionActividad { get; set; }
        public DateTime FechaAsignacionActividad { get; set; }
        public bool Estado { get; set; }
        public int IdProduccion { get; set; }
        public int IdActividadProduccion  { get; set; }

        public string NombreUsuario { get; set; }



    }
}
