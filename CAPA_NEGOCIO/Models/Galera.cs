using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;

#nullable disable

namespace CAPA_NEGOCIO.Models
{
    public partial class Galera : EntityClass
    {
        //public Galera()
        //{
        //    Produccions = new HashSet<Produccion>();
        //}

        public int? IdGalera { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal? DimensionL { get; set; }
        public decimal? DimensionA { get; set; }
        public decimal? Latitud { get; set; } = null!;
        public decimal? Longitud { get; set; } = null!;
        public int? CapMproduccion { get; set; }
        public bool EstadoProd { get; set; }

        //public virtual ICollection<Produccion> Produccions { get; set; }
    }
}
