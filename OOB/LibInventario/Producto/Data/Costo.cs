using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OOB.LibInventario.Producto.Data
{
    
    public class Costo
    {

        public decimal costoProveedor { get; set; }
        public decimal costoImportacion { get; set; }
        public decimal costoVario { get; set; }
        public decimal costoDivisa { get; set; }
        public decimal costo { get; set; }
        public decimal costoPromedio { get; set; }
        public DateTime? fechaUltCambio { get; set; }


        public Costo()
        {
            costoProveedor = 0.0m;
            costoImportacion = 0.0m;
            costoVario = 0.0m;
            costoDivisa = 0.0m;
            costo = 0.0m;
            costoPromedio = 0.0m;
            fechaUltCambio = null;
        }

    }

}