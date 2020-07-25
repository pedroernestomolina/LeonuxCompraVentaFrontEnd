using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Servidor.EnviarData
{
    
    public class CxCPago
    {

        public CxC Pago { get; set; }
        public CxCRecibo Recibo { get; set; }
        public CxCDocumento Documento { get; set; }
        public List<CxCMedioPago> MediosPago { get; set; }


        public CxCPago(OOB.LibVenta.PosOffline.Servidor.PrepararData.Documento doc)
        {
            if (!doc.IsCredito)
            {
                var d = doc;
                Pago = new CxC()
                {
                    CCobranza = 0.0m,
                    CCobranzap = 0.0m,
                    Fecha = d.Fecha,
                    TipoDocumento = "PAG",
                    Documento = "",
                    FechaVencimiento = d.Fecha,
                    Nota = "",
                    Importe = d.MontoRecibido,
                    Acumulado = 0 ,
                    AutoCliente = "0000000001",
                    Cliente = d.ClienteNombre,
                    CiRif = d.CiRif,
                    CodigoCliente = "01",
                    EstatusCancelado = "0",
                    Resta = 0.0m ,
                    EstatusAnulado = d.EstatusAnulado,
                    AutoDocumento = "",
                    Numero = "",
                    AutoAgencia = "0000000001",
                    Agencia = "",
                    Signo = -1 ,
                    AutoVendedor = d.VendedorAuto,
                    CDepartamento = 0.0m,
                    CVentas = 0.0m,
                    CVentasp = 0.0m,
                    Serie = "",
                    ImporteNeto = 0.0M ,
                    Dias = 0,
                    Castigop = 0.0m,
                };

                Recibo = new CxCRecibo()
                {
                    Fecha = d.Fecha,
                    AutoUsuario = d.UsuarioAuto,
                    Importe = d.MontoTotal,
                    Usuario = d.UsuarioNombre,
                    MontoRecibido = d.MontoRecibido,
                    Cobrador = d.CobradorNombre,
                    AutoCliente = "0000000001",
                    Cliente = d.ClienteNombre,
                    CiRif = d.CiRif,
                    Codigo = "01",
                    EstatusAnulado = d.EstatusAnulado,
                    Direccion = d.ClienteDirFiscal,
                    Telefono = d.ClienteTelefono,
                    AutoCobrador = d.CobradorAuto,
                    Anticipos = 0.0m,
                    Cambio = d.CambioDar,
                    Nota = "",
                    CodigoCobrador = d.CobradorCodigo,
                    AutoCxC = "",
                    Retenciones = 0.0m,
                    Descuentos=0.0m,
                    Hora=d.Hora,
                    Cierre="",
                };

                Documento = new CxCDocumento()
                {
                    Id = 1,
                    Fecha = d.Fecha,
                    TipoDocumento = "FAC",
                    Documento = d.DocumentoNro,
                    Importe = d.MontoTotal,
                    Operacion = "Pago",
                    FechaRecepcion = new DateTime(2000, 01, 01),
                    Dias = 0,
                    CastigoP = 0.0m,
                    ComisionP = 0.0m,
                };

                MediosPago = d.MetodosPago.Select(s =>
                {
                    var lote = s.LoteNro ;
                    var referencia = s.ReferenciaNro ;
                    var montoRecibido = s.MontoRecibido;
                    if (s.Tasa > 1)
                    {
                        lote = s.MontoRecibido.ToString();
                        referencia = s.Tasa.ToString();
                        montoRecibido = s.MontoRecibido * s.Tasa;
                    }

                    var mp = new OOB.LibVenta.PosOffline.Servidor.EnviarData.CxCMedioPago()
                    {
                        AutoMedioPago = s.AutoMedioCobro,
                        AutoAgencia = "",
                        Medio = s.MedioCobro,
                        Codigo = s.CodigoMedioCobro,
                        MontoRecibido = montoRecibido,
                        Fecha = d.Fecha,
                        EstatusAnulado = d.EstatusAnulado,
                        Numero = "",
                        Agencia = "",
                        AutoUsuario = d.UsuarioAuto,
                        Lote = lote ,
                        Referencia = referencia ,
                        AutoCobrador=d.CobradorAuto,
                        Cierre = "",
                        FechaAgencia = new DateTime(2000, 01, 01),
                    };
                    return mp;
                }).ToList();
            }
            else 
            {
                Pago = null;
                Recibo = null;
                Documento = null;
                MediosPago = null;
            }
        }

    }

}