using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;

#nullable disable

namespace CAPA_NEGOCIO.Models
{
    public partial class Alimento : EntityClass
    {
        //public Alimento()
        //{
        //    Produccions = new HashSet<Produccion>();
        //}

        public int? IdAlimento { get; set; }
        public string Nombre { get; set; } = null!;
        public int? IdMarca { get; set; }
        public string Descripcion { get; set; } = null!;

        //public virtual MarcaAlimento IdMarcaNavigation { get; set; } = null!;
        //public virtual ICollection<Produccion> Produccions { get; set; }
    }
}
