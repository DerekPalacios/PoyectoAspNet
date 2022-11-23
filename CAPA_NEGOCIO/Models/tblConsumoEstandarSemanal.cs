using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;

#nullable disable

namespace CAPA_NEGOCIO.Models
{
    public partial class tblConsumoEstandarSemanal : EntityClass
    {
        public int IdConsumoEstandarSemanal { get; set; }
        public int SemanaProduccion { get; set; }
        public decimal PesoUnitarioEsperado { get; set; }

        public int IdEtapaAlimento { get; set; }

    }
}
