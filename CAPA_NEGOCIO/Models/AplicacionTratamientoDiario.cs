using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
namespace CAPA_NEGOCIO.Models
{
    public partial class AplicacionTratamientoDiario : EntityClass
    {

        public int? IdAplicacionTratamiento { get; set; }
        public int IdTratamientoProduccion { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public int? IdUsuarioVerifica { get; set; }
        public byte EstadoAplicacion { get; set; }
    }
}
