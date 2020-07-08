using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.VentaDocumento
{

    public class Enumerados
    {

        public enum EnumTipoDocumento { SinDefinir = -1, Factura = 1, NotaDebito, NotaCredito };
        public enum EnumTipoMedioPago { SinDefinir = -1, Efectivo = 1, Divisa, Electronico, Otros };

    }

}