using System;
using System.Collections.Generic;

using CAPA_DATOS;

namespace CAPA_NEGOCIO.Models
{
    public partial class MarcaLineaAlimento : EntityClass
    {
        //public MarcaLineaAlimento()
        //{
        //    Alimentos = new HashSet<Alimento>();
        //}
        
        public int? IdMarca { get; set; }
        public string Nombre { get; set; }

        //public virtual ICollection<Alimento> Alimentos { get; set; }
    }
}