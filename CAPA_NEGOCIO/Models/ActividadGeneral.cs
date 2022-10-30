using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
using System.Linq;

namespace CAPA_NEGOCIO.Models
{
    public partial class ActividadGeneral : EntityClass
    {
        public int? IdActividad { get; set; }
        public string NombreActividad { get; set; } = null!;
        public string DescripcionActividad { get; set; }
        public int? IdActividadBase { get; set; } = null!;
        public int IdPeriodicidadActividad { get; set; }
        public int IdUsuarioActividad { get; set; }
        public bool ActividadHabilitada { get; set; }

        public Periodicidad PeriodicidadVar { get; set; }
        public DateTime ultimaFechaAsigado;
        public void CargarPeriodicidad()
        {
           this.PeriodicidadVar= new Periodicidad().Get<Periodicidad>("IdPeriodicidad = " + IdPeriodicidadActividad).First();
        }

    }
}
