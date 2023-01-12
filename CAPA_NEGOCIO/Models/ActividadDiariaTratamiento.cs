using CAPA_DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_NEGOCIO.Models
{
    public partial class ActividadDiariaTratamiento : EntityClass
    {
        public int IdActividadTratamiento { get; set; }

        public int IdUsuarioVerifica { get; set; }

        public DateTime FechaAplicacion { get; set; }

        public bool EstadoAlplicacion { get; set; }

        public bool CambioEstadoPermitidoActividadTratamiento { get; set; }

        public int IdTratamientoProduccionAsignado { get; set; }
        DateTime ultimaFechaDeAplicacion;
    }
}
