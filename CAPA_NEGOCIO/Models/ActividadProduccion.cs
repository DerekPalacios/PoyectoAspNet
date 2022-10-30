using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
namespace CAPA_NEGOCIO.Models
{
    public partial class ActividadProduccion : EntityClass
    {
        public int? IdActividadProduccion { get; set; }
        public int? IdActividad { get; set; }
        public int? IdProduccion { get; set; }
        public int? IdUsuarioVerifica { get; set; }

        public DateTime FechaAsignacionActividad { get; set; }
        public bool Estado { get; set; }
    }
}
