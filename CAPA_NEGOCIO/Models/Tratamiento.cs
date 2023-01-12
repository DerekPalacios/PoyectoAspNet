using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
#nullable disable

namespace CAPA_NEGOCIO.Models
{
    public partial class Tratamiento : EntityClass
    {
        public Tratamiento(bool v)
        {
            this.CargarPeriodicidad();
        }
        public Tratamiento()
        {

        }

        public int? IdTratamiento { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public string DosisDiariaRecomendada { get; set; } = null!;
        public int? IdPeridiocidadRecomendada { get; set; }
        public int? IdUsuarioRegistro { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? IdViaAdministracionRecomendada { get; set; }

        public int? LoteAdministracionRecomendada { get; set; }

        public int DosisTotalesRecomendadas { get; set; }
        public int DosisDiariaAplicada { get; set; }
        public int? DosisTotales { get; set; }
        public string DescripcionDosisdiaria { get; set; }
        public Periodicidad PeriodicidadVar;
        public void CargarPeriodicidad()
        {
            this.PeriodicidadVar = new Periodicidad().Get<Periodicidad>(" IdPeriodicidad = " + IdPeridiocidadRecomendada).First();
        }


        //public virtual TblUsuario IdUsuarioRegistroNavigation { get; set; } = null!;
        //public virtual ICollection<TratamientoProduccionAsignado> TratamientoProduccions { get; set; }
    }
}
