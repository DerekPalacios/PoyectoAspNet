using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
#nullable disable

namespace CAPA_NEGOCIO.Models
{
    public partial class EspeciePollo : EntityClass
    {
        //public EspeciePollo()
        //{
        //    Produccions = new HashSet<Produccion>();
        //}

        public int? IdEspecie { get; set; }
        public string Descripccion { get; set; } 
        public string PaisOrigen { get; set; } 
        public decimal? PrecioUnit { get; set; }
        public int SemanasProduccion { get; set; }
        //public virtual ICollection<Produccion> Produccions { get; set; }
    }
}
