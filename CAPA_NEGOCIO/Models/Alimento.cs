using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

        public int IdAlimento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int IdEtapaAlimentoRecomendado { get; set; }
        public int IdLineaAlimentoRecomendado { get; set; } 

        //public virtual MarcaLineaAlimento IdMarcaNavigation { get; set; } = null!;
        //public virtual ICollection<Produccion> Produccions { get; set; }

        public string _nombreEtapa;
        public string _nombreLinea ;

        public string cargarNombreLinea()
        {
            return new LineaAlimento().Get<LineaAlimento>("IdLineaAlimento = " + IdLineaAlimentoRecomendado)
               .First().NombreLinea;
        }

        public string cargarNombreEtapa()
        {
            return new EtapaAlimentoProduccion().Get<EtapaAlimentoProduccion>("IdEtapaAlimento = " + IdEtapaAlimentoRecomendado)
               .First().NombreEtapa;
        }
    }
}
