using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAPA_DATOS;
#nullable disable

namespace CAPA_NEGOCIO.Models
{
    public partial class Produccion : EntityClass
    {
        //public Produccion()
        //{
        //    DetalleDiarioProduccions = new HashSet<DetalleDiarioProduccion>();
        //    DetalleSemanals = new HashSet<DetalleSemanal>();
        //    TratamientoProduccions = new HashSet<TratamientoProduccion>();
        //}

        public DateTime FechaDeIngreso { get; set; }
        public int? IdProduccion { get; set; }
        public int Lote { get; set; }
        public decimal CostoUnitLote { get; set; }
        public decimal QuintDisp { get; set; }
        public int IdAlimento { get; set; }
        public int IdEspecie { get; set; }
        public decimal QuintUtil { get; set; }
        public DateTime FechaSalida { get; set; }
        public int IdGalera { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public bool EstadoProduccion { get; set; }

        //public virtual Alimento IdAlimentoNavigation { get; set; } = null!;
        //public virtual EspeciePollo IdEspecieNavigation { get; set; } = null!;
        //public virtual Galera IdGaleraNavigation { get; set; } = null!;
        //public virtual TblUsuario IdUsuarioRegistroNavigation { get; set; } = null!;
        //public virtual ICollection<DetalleDiarioProduccion> DetalleDiarioProduccions { get; set; }
        //public virtual ICollection<DetalleSemanal> DetalleSemanals { get; set; }
        //public virtual ICollection<TratamientoProduccion> TratamientoProduccions { get; set; }


        public void GenerarActividadesDiarias()
        {
            List<ActividadGeneral> ActividadesDisponibles = new ActividadGeneral().Get<ActividadGeneral>().FindAll(x=>x.ActividadHabilitada);
            DateTime FechaRecorridoActual = this.FechaDeIngreso;
            int diasProducion = (this.FechaSalida - this.FechaDeIngreso).Days;
            for(int i = 0; i < diasProducion; i++)
            {
                foreach(ActividadGeneral ActividadGeneral in ActividadesDisponibles)
                {
                    
                    if (i == 0)
                    {
                        ActividadGeneral.CargarPeriodicidad();
                        ActividadGeneral.ultimaFechaAsigado = FechaRecorridoActual;
                    }
                    
                    if(FechaRecorridoActual == ActividadGeneral.ultimaFechaAsigado)
                    {
                        new ActividadProduccion
                        {
                            Estado = false,
                            IdActividad = ActividadGeneral.IdActividad,
                            IdProduccion = this.IdProduccion,
                            FechaAsignacionActividad = FechaRecorridoActual,
                            IdUsuarioVerifica = this.IdUsuarioRegistro,
                            //assignar el usuario que lo verifica aca
                        }
                        .Save();
                        ActividadGeneral.ultimaFechaAsigado.AddDays(ActividadGeneral.PeriodicidadVar.DiasSalto);
                    }
                    FechaRecorridoActual.AddDays(1);
                }
            }
        }
    




    } 

}
