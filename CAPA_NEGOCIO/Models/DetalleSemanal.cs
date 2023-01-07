using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
#nullable disable

namespace CAPA_NEGOCIO.Models
{
    public partial class DetalleSemanal : EntityClass
    {
        public int IdDetalleSem { get; set; }
        public int IdProduccionSem { get; set; }
        public decimal ConsumoSem { get; set; }
        public decimal Pesajepromedio { get; set; }
        public int MuestraPesaje { get; set; }
        public DateTime FechaInicioSemana { get; set; }
        public DateTime FechaFinalSemana { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public int IdConsumoEstandarSemanal { get; set; }
    }
}
