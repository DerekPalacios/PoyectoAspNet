using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
using System.Linq;
using System.Diagnostics.Contracts;
#nullable disable

namespace CAPA_NEGOCIO.Models
{

    public partial class TratamientoProduccionAsignado : EntityClass
    {
        //si es true en el ctor carga la peridiocidad, else, carga el nombre del tratamiento
        public TratamientoProduccionAsignado(bool x)
        {
            if (x)
            {
                this.CargarPeriodicidad();

            }
            else
            {
                this.CargarNombreTratamiento();
            }
        }
        public TratamientoProduccionAsignado()
        {
        }
        public int IdTratamientoProduccion { get; set; }
        public int IdProduccion { get; set; }
        public int IdTratamiento { get; set; }
        public int DosisTotalesAplicada { get; set; }
        public int IdPeridiocidadTratamiento { get; set; }
        public int DosisDiaria { get; set; }//quitar
        public int? IdViaAdministracionAplicacada { get; set; }

        public decimal? CostoTratamiento { get; set; }

        public DateTime? FechaAsignacion { get; set; }

        public int IdUsuarioAsigna { get; set; }

        public bool EstadoAplicacion { get; set; }

        public bool EstadoCompletado { get; set; }

        public bool? CambioEstadoPermitidoTratamientoProduccion { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public decimal ProgresoAplicacion { get; set; }//quitar
        public bool TratamientoSanitario { get; set; }
        public string nombreTatamiento;
        DateTime ultimaFechaAplicacion;
        Periodicidad PeriodicidadVar;
        private void CargarPeriodicidad()
        {
            this.PeriodicidadVar = new Periodicidad().Get<Periodicidad>("IdPeriodicidad = " + IdPeridiocidadTratamiento).First();
        }
        public void CargarNombreTratamiento()
        {
            nombreTatamiento = new Tratamiento().Get<Tratamiento>("IdTratamiento = " + this.IdTratamiento).First().Nombre;
        }
        public void GenerarTratamientoDiario()
        {
            //trabajar aca


            Produccion produccionAplicado = new Produccion().Get<Produccion>("IdProduccion = " + this.IdProduccion).First();

            DateTime FechaRecorridoActual = produccionAplicado.FechaDeIngreso;
            int aplicaciones = this.DosisTotalesAplicada / this.DosisDiaria;
            if (DateTime.Today > FechaRecorridoActual)
            {
                FechaRecorridoActual = DateTime.Today;
            }
            for (int i = 0; i < aplicaciones; i++)
            {
                if (i == 0)
                {
                    this.CargarPeriodicidad();
                    this.ultimaFechaAplicacion = FechaRecorridoActual;
                }

                if (FechaRecorridoActual == this.ultimaFechaAplicacion)
                {
                    new AplicacionTratamientoDiario
                    {
                        IdTratamientoProduccion = this.IdTratamientoProduccion,
                        FechaAplicacion = FechaRecorridoActual,
                        IdUsuarioVerifica = null,
                        EstadoAplicacion = 0
                    }
                    .Save();


                    this.ultimaFechaAplicacion.AddDays((int)this.PeriodicidadVar.DiasSalto);
                }
                FechaRecorridoActual.AddDays(1);

            }






        }



        public object GuardarTratamientoProduccionCompleto(TratamientoProduccionAsignado tratamientoProduccion)
        {
            tratamientoProduccion.IdTratamientoProduccion = (int)tratamientoProduccion.Save();


            return 0;
        }


    }
}
