using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.VentaDocumento
{
    
    public class AgregarMetodoPago
    {

        public Enumerados.EnumTipoMedioPago TipoMedioPago { get; set; }
        public string autoMedioPago { get; set; }
        public string codigoMedioPago { get; set; }
        public string descripcionMedioPago { get; set; }
        public decimal Importe { get; set; }
        public decimal MontoRecibido { get; set; }
        public decimal Tasa { get; set; }
        public string Lote { get; set; }
        public string Referencia { get; set; }

    }

}