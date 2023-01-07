using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;

#nullable disable

namespace CAPA_NEGOCIO.Models
{
    public partial class EtapaAlimentoProduccion : EntityClass
    {
        public int IdEtapaAlimento { get; set; }

        public string DescripcionEtapa { get; set; }

        public string NombreEtapa { get; set; }
    }
}
