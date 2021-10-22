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

        private decimal CalculaFull(decimal monto)
        {
            var rt =0.0m;
            rt = monto / ((it.tasaIva / 100) + 1);
            rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            return rt;
        }

        public decimal precioFullMoneda_EnDivisa(int id)
        {
            var rt = 0.0m;
            var pn = 0.0m;
            switch (id) 
            {
                case 1:
                    pn = it.precioNetoMoneda_1; break;
                case 2:
                    pn = it.precioNetoMoneda_2; break;
                case 3:
                    pn = it.precioNetoMoneda_3; break;
                case 4:
                    pn = it.precioNetoMoneda_4; break;
                case 5:
                    pn = it.precioNetoMoneda_5; break;
                case 6: //MAYOR 1
                    pn = it.precioNetoMonedaMay_1 ; break;
                case 7: //MAYOR 2
                    pn = it.precioNetoMonedaMay_2; break;
            }
            rt = CalculaFull(pn) / valorDivisa;
            rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            return rt;
        }


        public data2(OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData.Ficha it, decimal montoDivisa)
        {
            this.it = it;
            this.valorDivisa = montoDivisa;
        }

    }

}