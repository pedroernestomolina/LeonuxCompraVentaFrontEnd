using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.TasaDivisa.Sist
{
    
    public class data2
    {

        private OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha it;
        private decimal valorDivisa;

        public string AutoPrd { get { return it.autoPrd; } }
        public decimal CostoDivisa 
        {
            get 
            {
                var rt = 0.0m;
                rt=  it.costoMoneda/ valorDivisa ;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            } 
        }


        public data2(OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha it, decimal montoDivisa)
        {
            this.it = it;
            this.valorDivisa = montoDivisa;
        }

    }

}