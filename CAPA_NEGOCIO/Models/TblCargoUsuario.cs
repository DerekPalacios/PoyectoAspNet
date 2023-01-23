using CAPA_DATOS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CAPA_NEGOCIO.Models
{
    public partial class TblCargoUsuario : EntityClass
    {
       
        public int IdCargo { get; set; }
        public string DescripcionCargo { get; set; } = null!;

    }
}

