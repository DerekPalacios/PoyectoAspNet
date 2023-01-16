using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
using System.Linq;

namespace CAPA_NEGOCIO.Models.SubModel
{
    public partial class ProduccionForDetailView : EntityClass
    {

        public string Nombre { get; set; }
        public int IdProduccion { get; set; }
        public int Lote { get; set; }
        public int QuintUtil { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaDeIngreso { get; set; }
        public bool EstadoProduccion { get; set; }


    }
}
