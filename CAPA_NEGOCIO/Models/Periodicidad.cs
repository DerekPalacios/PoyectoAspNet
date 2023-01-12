using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;

namespace CAPA_NEGOCIO.Models
{
    public partial class Periodicidad : EntityClass
    {
        public int? IdPeriodicidad { get; set; }
        public string? NombrePeriodicidad { get; set; }
        public string? DescripcionPeriodicidad { get; set; }
        public int? DiasSalto { get; set; }
    }
}
