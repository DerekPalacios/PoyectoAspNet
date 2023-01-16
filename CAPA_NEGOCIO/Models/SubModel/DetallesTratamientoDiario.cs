using CAPA_DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPA_NEGOCIO.Models.SubModel
{
    public partial class DetallesTratamientoDiario : EntityClass
    {

        public int IdActividadTratamiento { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public bool EstadoAlplicacion { get; set; }
        public int IdProduccion { get; set; }
        public int IdTratamientoProduccionAsignado { get; set; }
        public bool TratamientoSanitario { get; set; }
        public string TipoAdministracion { get; set; }


    }
}
