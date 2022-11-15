using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
using System.Linq;

namespace CAPA_NEGOCIO.Models.SubModel
{
    public partial class VistaDetalleCardProduccion : EntityClass
    {
        public string Nombre { get; set; }
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaDeIngreso { get; set; }
        public bool EstadoProduccion { get; set; }
        public int? Lote { get; set; }
        public string Alimento { get; set; }
        public int? QuintDisp { get; set; }
        public int? Perdidas { get; set; } = 0;








    }
}
