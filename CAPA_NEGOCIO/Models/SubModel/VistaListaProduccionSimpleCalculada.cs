using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
using System.Linq;

namespace CAPA_NEGOCIO.Models.SubModel
{
    public partial class VistaListaProduccionSimpleCalculada : EntityClass
    {
        public int? IdProduccion { get; set; }
        public string NombreGalera { get; set; }
        public decimal? Tamaño { get; set; }
        public decimal? ConsumoAlimento { get; set; }
        public int? MuertesTotales { get; set; }
        public int? LoteActual { get; set; }
        public decimal? PesoPromedioSemanal { get; set; }
        public bool Estado { get; set; }


    }
}
