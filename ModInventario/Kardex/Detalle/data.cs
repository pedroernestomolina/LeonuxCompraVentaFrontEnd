using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Kardex.Detalle
{
    
    public class data
    {


        private OOB.LibInventario.Kardex.Movimiento.Detalle.Data reg;
        private decimal precioCosto;
        private string estatus;



        public string FechaHora { get { return reg.fecha.ToShortDateString() + "/" + reg.hora; } }
        public string Siglas { get { return reg.Siglas.ToString(); } }
        public string Documento { get { return reg.documento; } }
        public string Entidad { get { return reg.entidad; } }
        public decimal PrecioCosto { get { return precioCosto; } }
        public string CntInventario { get { return reg.cantidadUnd.ToString(); } }
        public string Nota { get { return reg.nota; } }
        public string Estatus { get { return estatus; } }


        public data(OOB.LibInventario.Kardex.Movimiento.Detalle.Data reg)
        {
            this.reg = reg;
            precioCosto = reg.costoUnd;
            estatus = "OK";
            if (reg.isAnulado) { estatus = "ANULADO"; }
            if (reg.Modulo == OOB.LibInventario.Kardex.Enumerados.EnumModulo.Venta)
            {
                precioCosto = reg.precioUnd;
            }
        }

    }

}