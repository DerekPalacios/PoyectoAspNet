using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;

namespace CAPA_NEGOCIO.Models
{
    public partial class Periodicidad : EntityClass
    {
        public int IdPeriodicidad { get; set; }
        public int NombrePeriodicidad { get; set; }
        public int DescripcionPeriodicidad { get; set; }
        public int DiasSalto { get; set; }
        public DateTime ultimaFechaAsignado;
    }
}
