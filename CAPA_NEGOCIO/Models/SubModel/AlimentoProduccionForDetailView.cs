using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
using System.Linq;

namespace CAPA_NEGOCIO.Models.SubModel
{
    public partial class AlimentoProduccionForDetailView : EntityClass
    {

public string Nombre { get; set; }
public string NombreEtapa { get; set; }
public int QuintalesAlimento { get; set; }
public int IdProduccion { get; set; }





    }
}
