using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Operador.Movimiento
{

    public class Ficha
    {

        public int cntFactura { get; set; }
        public int cntNDebito { get; set; }
        public int cntNCredito { get; set; }
        public decimal montoFactura { get; set; }
        public decimal montoNDebito { get; set; }
        public decimal montoNCredito { get; set; }

        public int cntDocContado { get; set; }
        public decimal montoDocContado { get; set; }
        public int cntDocCredito { get; set; }
        public decimal montoDocCredito { get; set; }

        public decimal cntEfecitvo { get; set; }
        public decimal montoEfectivo { get; set; }

        public decimal cntDivisa { get; set; }
        public decimal montoDivisa { get; set; }

        public decimal cntElectronico { get; set; }
        public decimal montoElectronico { get; set; }

        public decimal cntOtros { get; set; }
        public decimal montoOtros { get; set; }


        public Ficha()
        {
            cntDivisa = 0.0m;
            cntDocContado = 0;
            cntDocCredito = 0;
            cntEfecitvo = 0;
            cntElectronico = 0;
            cntFactura = 0;
            cntNCredito = 0;
            cntNDebito = 0;
            cntOtros = 0;

            montoDivisa = 0.0m;
            montoDocContado = 0.0m;
            montoDocCredito = 0.0m;
            montoEfectivo = 0.0m;
            montoElectronico = 0.0m;
            montoFactura = 0.0m;
            montoNCredito = 0.0m;
            montoNDebito = 0.0m;
            montoOtros = 0.0m;
        }

    }

}