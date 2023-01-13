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
        public string DescripcionActividad { get; set; } = null!;
        public int IdActividadBase { get; set; }
        public int IdUsuarioActividad { get; set; }
        public bool ActividadHabilitada { get; set; }
        public int IdPeriodicidadActividad { get; set; }

        public Periodicidad? PeriodicidadVar { get; set; }
        public DateTime ultimaFechaAsigado;
        public void CargarPeriodicidad()
        {
           this.PeriodicidadVar= new Periodicidad().Get<Periodicidad>("IdPeriodicidad = " + IdPeriodicidadActividad).First();
        }

        public object ActualizarActividad(ActividadGeneral act)
        {
            act.ActividadHabilitada = false;
            act.Update("IdActividad");// se le pasan todos  ls parametros y actualiza antes de insertar uno nuevo
            act.ActividadHabilitada = true;
            act.IdActividadBase = (int)act.IdActividad;
            act.IdActividad = null;
            return act.IdActividad = (int)act.Save();

        }


    }
}
