using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Reporte.Pago.Resumen
{
    
    public class Ficha
    {

        public decimal MontoNCredito { get; set; }
        public decimal MontoCambioDar { get; set; }
        public List<Detalle> Detalle{ get; set; }


        public Ficha()
        {
            MontoCambioDar = 0.0m;
            MontoNCredito = 0.0m;
            Detalle = null;
        }

    }

}