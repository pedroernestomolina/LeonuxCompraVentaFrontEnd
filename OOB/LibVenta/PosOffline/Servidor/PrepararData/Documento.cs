using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Servidor.PrepararData
{
    
    public class Documento
    {

        public class ActDeposito
        {

            public string AutoDeposito { get; set; }
            public string AutoProducto { get; set; }
            public decimal CantidadUnd { get; set; }

        }

        public int Id { get; set; }
        public int IdJornada { get; set; }
        public int IdOperador { get; set; }

        public string DocumentoNro { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }

        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public string CiRif { get; set; }
        public string ClienteDirFiscal { get; set; }
        public string ClienteTelefono { get; set; }

        public decimal MontoExento { get; set; }
        public decimal MontoBase { get; set; }
        public decimal MontoImpuesto { get; set; }
        public decimal Base1 { get; set; }
        public decimal Base2 { get; set; }
        public decimal Base3 { get; set; }
        public decimal Impuesto1 { get; set; }
        public decimal Impuesto2 { get; set; }
        public decimal Impuesto3 { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal TasaIva1 { get; set; }
        public decimal TasaIva2 { get; set; }
        public decimal TasaIva3 { get; set; }

        public string MesRelacion { get; set; }
        public string AnoRelacion { get; set; }
        public string Control { get; set; }
        public decimal DesctoMonto_1 { get; set; }
        public decimal DesctoMonto_2 { get; set; }
        public decimal DesctoPorc_1 { get; set; }
        public decimal DesctoPorc_2 { get; set; }
        public decimal CargoMonto_1 { get; set; }
        public decimal CargoPorc_1 { get; set; }
        public bool IsActiva { get; set; }
        public Enumerados.EnumTipoDocumento TipoDocumento { get; set; }
        public string Aplica { get; set; }
        public int Signo { get; set; }
        public string Serie { get; set; }
        public string CodigoSucursal { get; set; }

        public decimal MontoSubtNeto { get; set; }
        public decimal MontoSubtImpuesto { get; set; }
        public decimal MontoSubt { get; set; }
        public decimal MontoVentaNeta { get; set; }
        public decimal MontoCostoVenta { get; set; }
        public decimal MontoUtilidad { get; set; }
        public decimal MontoUtilidadPorc { get; set; }
        public decimal FactorCambio { get; set; }
        public decimal MontoDivisa { get; set; }
        public string Estacion { get; set; }
        public int Renglones { get; set; }

        public string UsuarioAuto { get; set; }
        public string UsuarioCodigo { get; set; }
        public string UsuarioNombre { get; set; }

        public string DepositoAuto { get; set; }
        public string DepositoCodigo { get; set; }
        public string DepositoNombre { get; set; }

        public string VendedorAuto { get; set; }
        public string VendedorCodigo { get; set; }
        public string VendedorNombre { get; set; }

        public string TranporteAuto { get; set; }
        public string TranporteCodigo { get; set; }
        public string TranporteNombre { get; set; }

        public string CobradorAuto { get; set; }
        public string CobradorCodigo { get; set; }
        public string CobradorNombre { get; set; }

        public decimal MontoRecibido { get; set; }
        public decimal CambioDar { get; set; }
        public bool IsCredito { get; set; }

        public string Tarifa { get; set; }
        public decimal SaldoPendiente { get; set; }
        public string AutoConceptoVenta { get; set; }
        public string CodigoConceptoVenta { get; set; }
        public string NombreConceptoVenta { get; set; }
        public string AutoConceptoDevVenta { get; set; }
        public string CodigoConceptoDevVenta { get; set; }
        public string NombreConceptoDevVenta { get; set; }


        public List<DocumentoDetalle> Detalles { get; set; }
        public List<DocumentoPago> MetodosPago { get; set; }
        public List<ActDeposito> Deposito 
        {
            get 
            {
                var list = Detalles.Select(s =>
                {
                    var nr = new ActDeposito()
                    {
                         AutoDeposito= DepositoAuto,
                         AutoProducto=s.AutoProducto,
                         CantidadUnd=s.CantidadUnd*Signo,
                    };
                    return nr;
                }).ToList();
                return list;
            }
        }

        public string DocumentoNombre
        {
            get
            {
                var t = "";
                switch (TipoDocumento)
                {
                    case Enumerados.EnumTipoDocumento.Factura:
                        t = "FACTURA";
                        break;
                    case Enumerados.EnumTipoDocumento.NotaCredito:
                        t = "NOTA CREDITO";
                        break;
                }
                return t;
            }
        }

        public string DocumentoNombreVenta
        {
            get
            {
                var t = "";
                switch (TipoDocumento)
                {
                    case Enumerados.EnumTipoDocumento.Factura:
                        t = "VENTA";
                        break;
                    case Enumerados.EnumTipoDocumento.NotaCredito:
                        t = "NOTA CREDITO";
                        break;
                }
                return t;
            }
        }

        public string TipoDocumentoCxC 
        {
            get
            {
                var t = "";
                switch (TipoDocumento)
                {
                    case Enumerados.EnumTipoDocumento.Factura:
                        t = "FAC";
                        break;
                    case Enumerados.EnumTipoDocumento.NotaCredito:
                        t = "NCR";
                        break;
                }
                return t;
            }
        }

        public string Siglas 
        {
            get 
            {
                var t = "";
                switch (TipoDocumento) 
                {
                    case Enumerados.EnumTipoDocumento.Factura:
                        t = "FAC";
                        break;
                    case Enumerados.EnumTipoDocumento.NotaCredito:
                        t = "NCR";
                        break;
                }
                return t;
            }
        }

        public string Codigo
        {
            get
            {
                var t = "";
                switch (TipoDocumento)
                {
                    case Enumerados.EnumTipoDocumento.Factura:
                        t = "01";
                        break;
                    case Enumerados.EnumTipoDocumento.NotaCredito:
                        t = "03";
                        break;
                }
                return t;
            }
        }

        public string EstatusAnulado 
        {
            get 
            {
                var t="";
                t = IsActiva ? "0" : "1";
                return t; 
            }
        }

        public string AutoConcepto
        {
            get
            {
                var t = "";
                switch (TipoDocumento)
                {
                    case Enumerados.EnumTipoDocumento.Factura:
                        t = AutoConceptoVenta;
                        break;
                    case Enumerados.EnumTipoDocumento.NotaCredito:
                        t = AutoConceptoDevVenta;
                        break;
                }
                return t;
            }
        }

        public string CondicionPago 
        {
            get
            {
                var t = "CONTADO";
                if (IsCredito) 
                {
                    t = "CREDITO";
                }
                return t;
            }
        }

        public decimal AcumuladoCxC 
        {
            get 
            {
                var monto = MontoTotal;
                if (IsCredito) 
                {
                    monto = 0.0m;
                }
                return monto;
            }
        }

        public string EstatusPagado
        {
            get
            {
                var estatus = IsCredito?"0":"1";
                return estatus;
            }
        }

        public Documento()
        {
            Detalles = new List<DocumentoDetalle>();
            MetodosPago = new List<DocumentoPago>();
        }

    }

}