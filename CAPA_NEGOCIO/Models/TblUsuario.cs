using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
#nullable disable

namespace CAPA_NEGOCIO.Models
{
    public partial class TblUsuario : EntityClass
    {
        //public TblUsuario()
        //{
        //    DetalleDiarioProduccions = new HashSet<DetalleDiarioProduccion>();
        //    DetalleSemanals = new HashSet<DetalleSemanal>();
        //    DetalleTratamientoAplicados = new HashSet<DetalleTratamientoAplicado>();
        //    Produccions = new HashSet<Produccion>();
        //    TratamientoProduccions = new HashSet<TratamientoProduccion>();
        //    Tratamientos = new HashSet<Tratamiento>();
        //}

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int IdCargo { get; set; }
        public string ContraseñaSesion { get; set; } = null!;
        public string NumeroCelular { get; set; } = null!;
        public string CorreoElecronico { get; set; } = null!;

        //public virtual TblCargoUsuario IdCargoNavigation { get; set; } = null!;
        //public virtual ICollection<DetalleDiarioProduccion> DetalleDiarioProduccions { get; set; }
        //public virtual ICollection<DetalleSemanal> DetalleSemanals { get; set; }
        //public virtual ICollection<DetalleTratamientoAplicado> DetalleTratamientoAplicados { get; set; }
        //public virtual ICollection<Produccion> Produccions { get; set; }
        //public virtual ICollection<TratamientoProduccion> TratamientoProduccions { get; set; }
        //public virtual ICollection<Tratamiento> Tratamientos { get; set; }
    }
}
