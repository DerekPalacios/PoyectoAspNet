using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;

#nullable disable

namespace CAPA_NEGOCIO.Models
{
    public partial class tblConsumoEstandarDiario : EntityClass
    {
        public int IdConsumoDiario { get; set; }
        public string DiaProduccion { get; set; }
        public string ConsumoUnitario { get; set; }
    }
}
