using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion
{

    public class series
    {

        public string ParaFactura { get; set; }
        public string ParaNotaCredito { get; set; }
        public string ParaNotaDebito { get; set; }
        public string ParaNotaEnrega { get; set; }

        public string ControlParaFactura { get; set; }
        public string ControlParaNotaCredito { get; set; }
        public string ControlParaNotaDebito { get; set; }
        public string ControlParaNotaEnrega { get; set; }

        public int CorrelativoParaFactura { get; set; }
        public int CorrelativoParaNtCredito { get; set; }
        public int CorrelativoParaNtDebito { get; set; }
        public int CorrelativoParaNtEntrega { get; set; }


        public series()
        {
            Limpiar();
        }

        private void Limpiar()
        {
            ParaFactura = "";
            ParaNotaCredito = "";
            ParaNotaDebito = "";
            ParaNotaEnrega = "";
            ControlParaFactura = "";
            ControlParaNotaCredito = "";
            ControlParaNotaDebito = "";
            ControlParaNotaEnrega = "";
            CorrelativoParaFactura = 0;
            CorrelativoParaNtCredito = 0;
            CorrelativoParaNtDebito = 0;
            CorrelativoParaNtEntrega = 0;
        }

        public void setSeries(OOB.LibVenta.PosOffline.Configuracion.Serie.Ficha e)
        {
            ParaFactura = e.ParaFactura;
            ParaNotaCredito = e.ParaNotaCredito;
            ParaNotaDebito = e.ParaNotaDebito;
            ParaNotaEnrega = e.ControlParaNotaEnrega;
            ControlParaFactura = e.ControlParaFactura;
            ControlParaNotaCredito = e.ControlParaNotaCredito;
            ControlParaNotaDebito = e.ControlParaNotaDebito;
            ControlParaNotaEnrega = e.ControlParaNotaEnrega;
            CorrelativoParaFactura = e.CorrelativoParaFactura;
            CorrelativoParaNtCredito = e.CorrelativoParaNtCredito;
            CorrelativoParaNtDebito = e.CorrelativoParaNtDebito;
            CorrelativoParaNtEntrega = e.CorrelativoParaNtEntrega;
        }

        public void IncrementaCorrelativoFactura()
        {
            CorrelativoParaFactura += 1;
        }

        public void IncrementaCorrelativoNtCredito()
        {
            CorrelativoParaNtCredito += 1;
        }

        public void IncrementaCorrelativoNtDebito()
        {
            CorrelativoParaNtDebito += 1;
        }

    }

}