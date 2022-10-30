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
        public DetalleDiarioProduccion()
        {
            DetalleMortalidadDiarios = new HashSet<DetalleMortalidadDiario>();
        }

        public int IdDetalle { get; set; }
        public decimal ConsumoAlimento { get; set; }
        public bool Tratamiento { get; set; }
        public bool Mortalidad { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaDetalleDiario { get; set; }
        public int IdProduccion { get; set; }

        public virtual Produccion IdProduccionNavigation { get; set; } = null!;
        public virtual TblUsuario IdUsuarioRegistroNavigation { get; set; } = null!;
        public virtual ICollection<DetalleMortalidadDiario> DetalleMortalidadDiarios { get; set; }
    }
}
