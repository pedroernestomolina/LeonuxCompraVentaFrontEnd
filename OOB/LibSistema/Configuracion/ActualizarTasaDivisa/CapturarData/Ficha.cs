using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibSistema.Configuracion.ActualizarTasaDivisa.CapturarData
{
    
    public class Ficha
    {

        public string autoPrd { get; set; }
        public bool isAdmDivisa { get; set; }
        public decimal costoDivisa { get; set; }
        public decimal costoMoneda { get; set; }
        public int contenido { get; set; }
        public decimal precioFullDivisa_1 { get; set; }
        public decimal precioFullDivisa_2 { get; set; }
        public decimal precioFullDivisa_3 { get; set; }
        public decimal precioFullDivisa_4 { get; set; }
        public decimal precioFullDivisa_5 { get; set; }
        public decimal tasaIva { get; set; }

    }

}