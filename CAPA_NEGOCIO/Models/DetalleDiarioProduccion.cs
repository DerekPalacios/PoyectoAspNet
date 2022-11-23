using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
#nullable disable

namespace CAPA_NEGOCIO.Models
{
    public partial class DetalleDiarioProduccion : EntityClass
    {

        public int IdDetalle { get; set; }
        public decimal ConsumoAlimento { get; set; }
        public bool Tratamiento { get; set; }
        public bool Mortalidad { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaDetalleDiario { get; set; }
        public int IdProduccion { get; set; }
        public int IdConsumoEstandarDiario { get; set; }
    }
}
