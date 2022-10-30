using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
using System.Linq;

namespace CAPA_NEGOCIO.Models.SubModel
{
    public partial class ActividadProduccionActiva : EntityClass
    {
        public int? IdActividad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? IdProduccion { get; set; }
        public bool Estado { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime? FechaActividad { get; set; }
    }
}
