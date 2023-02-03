using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
using System.Linq;

namespace CAPA_NEGOCIO.Models.SubModel
{
    public partial class produccionbyactividades : EntityClass
    {
        public string NombreActividad { get; set; }
        public DateTime FechaAsignacionActividad { get; set; }
        public int IdProduccion { get; set; }
        public int IdActividad { get; set; }
        public string Nombre { get; set; }
    }
}
