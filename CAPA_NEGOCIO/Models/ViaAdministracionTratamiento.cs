using CAPA_DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_NEGOCIO.Models
{
    public partial class ViaAdministracionTratamiento: EntityClass
    {
        public int IdViaAdministracion { get; set; }

        public string? TipoAdministracion { get; set; }

        public string? Descripcion { get; set; }

    }
}
