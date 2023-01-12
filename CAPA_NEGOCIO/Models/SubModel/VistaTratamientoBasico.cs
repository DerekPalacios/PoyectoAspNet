using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
using System.Linq;

namespace CAPA_NEGOCIO.Models.SubModel
{
    public partial class VistaTratamientoBasico : EntityClass
    {

        public string IdTratamiento { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string NombrePeriodicidad { get; set; }
        public string TipoAdministracion { get; set; }
        public string DosisDiariaRecomendada { get; set; }
        public string DescripcionDosisdiaria { get; set; }
        public string DosisTotalesRecomendadas { get; set; }
        public string IdPeriodicidad { get; set; }
        public string IdViaAdministracion { get; set; }






    }
}
