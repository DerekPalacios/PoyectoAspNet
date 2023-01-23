using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
#nullable disable

namespace CAPA_NEGOCIO.Models.SubModel
{
    public partial class UsuarioParaTabla : EntityClass
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string NombreCargo { get; set; }
        public string ContraseñaSesion { get; set; } = null!;
        public string NumeroCelular { get; set; } = null!;
        public string CorreoElecronico { get; set; } = null!;
    }
}
