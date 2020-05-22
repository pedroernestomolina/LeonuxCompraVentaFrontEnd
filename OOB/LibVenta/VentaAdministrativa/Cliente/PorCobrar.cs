using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.Cliente
{
    
    public class PorCobrar
    {

        public string AutoDocumento { get; set; }
        public Enumerados.enumTipoDocumentoPorCobrar TipoDocumento { get; set; }
        public string Documento { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal MontoDocumento { get; set; }
        public decimal Abonado { get; set; }
        public int Signo { get; set; }
        public bool IsAdministrativo { get; set; }


        public string TipoDocumentoDescripcion 
        {
            get 
            {
                var rt = "";
                switch (TipoDocumento) 
                {
                    case Enumerados.enumTipoDocumentoPorCobrar.Factura:
                        rt = "FACTURA";
                        break;
                    case Enumerados.enumTipoDocumentoPorCobrar.NotaDebito:
                        rt = "NOTA/DEBITO";
                        break;
                    case Enumerados.enumTipoDocumentoPorCobrar.NotaCredito:
                        rt = "NOTA/CREDITO";
                        break;
                }
                return rt;
            }
        }

        public decimal MontoPendiente 
        {
            get 
            {
                return (MontoDocumento - Abonado)*Signo;
            }
        }

        public bool IsDocumentoFactura
        {
            get
            {
                return (TipoDocumento == Enumerados.enumTipoDocumentoPorCobrar.Factura || TipoDocumento == Enumerados.enumTipoDocumentoPorCobrar.NotaDebito);
            }
        }

    }

}