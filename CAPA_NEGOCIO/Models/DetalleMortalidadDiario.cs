using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
#nullable disable

namespace CAPA_NEGOCIO.Models
{
    public partial class DetalleMortalidadDiario : EntityClass
    {
        public int IdDetalleMortalidad { get; set; }
        public int IdDetalleDiario { get; set; }
        public int CantidadPerdida { get; set; }
        public string DetalleMuerte { get; set; } = null!;
        public string DescripcionEvento { get; set; } = null!;

        public virtual DetalleDiarioProduccion IdDetalleDiarioNavigation { get; set; } = null!;
    }
}
