using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
using System.Linq;
#nullable disable

namespace CAPA_NEGOCIO.Models
{
    public partial class Tratamiento : EntityClass
    {
        //public Tratamiento()
        //{
        //    TratamientoProduccions = new HashSet<TratamientoProduccion>();
        //}

        public int IdTratamiento { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public string DosisDiariaRecomendada { get; set; } = null!;
        public int IdPeridiocidadRecomendada { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal CostoTratamientoCompleto { get; set; }
        public int DosisTotales { get; set; }
       public Periodicidad PeriodicidadVar;
        public void CargarPeriodicidad()
        {
            this.PeriodicidadVar = new Periodicidad().Get<Periodicidad>("IdPeriodicidad = " + IdPeridiocidadRecomendada).First();
        }


        //public virtual TblUsuario IdUsuarioRegistroNavigation { get; set; } = null!;
        //public virtual ICollection<TratamientoProduccion> TratamientoProduccions { get; set; }
    }
}
