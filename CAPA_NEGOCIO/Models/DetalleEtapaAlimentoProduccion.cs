using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;

#nullable disable

namespace CAPA_NEGOCIO.Models
{
    public partial class DetalleEtapaAlimentoProduccion : EntityClass
    {
        public int IdDetalleEstapaAlimentoProduccion { get; set; }
        public int IdEtapaAlimentoProduccion { get; set; }
        public int IdAlimentoProduccion { get; set; }

        public decimal QuintalesAlimento { get; set; }
        public int IdProduccionDetalleAlimento { get; set; } 



    }
}
