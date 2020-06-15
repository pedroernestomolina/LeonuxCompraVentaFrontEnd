using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Configuracion.Serie
{

    public class Ficha
    {

        public string ParaFactura { get; set; }
        public string ParaNotaCredito { get; set; }
        public string ParaNotaDebito { get; set; }
        public string ParaNotaEnrega { get; set; }

        public string ControlParaFactura { get; set; }
        public string ControlParaNotaCredito { get; set; }
        public string ControlParaNotaDebito { get; set; }
        public string ControlParaNotaEnrega { get; set; }

    }

}