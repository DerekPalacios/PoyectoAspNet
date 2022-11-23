using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;

#nullable disable

namespace CAPA_NEGOCIO.Models
{
    public partial class LineaAlimento : EntityClass
    {
        public int IdLineaAlimento { get; set; }
        public int IdMarcaLinea { get; set; }
        public string DescripcionLinea { get; set; }
        public string NombreLinea { get; set; }
    }
}
