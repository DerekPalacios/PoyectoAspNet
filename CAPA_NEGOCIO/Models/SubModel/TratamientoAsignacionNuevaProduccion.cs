using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
#nullable disable
namespace CAPA_NEGOCIO.Models.SubModel
{
    public partial class TratamientoAsignacionNuevaProduccion : EntityClass
    {
        public int? IdTratamiento { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public int DosisDiariaRecomendada { get; set; }
        public int? LoteAdministracionRecomendada { get; set; }
        public int? IdViaAdministracionRecomendada { get; set; }
        public string DescripcionDosisdiaria { get; set; }
        public int DosisTotalesRecomendadas { get; set; }
        public int? IdPeriodicidad { get; set; }

        public string NombrePeriodicidad { get; set; }

        public string TipoAdministracion { get; set; }

    }
}
