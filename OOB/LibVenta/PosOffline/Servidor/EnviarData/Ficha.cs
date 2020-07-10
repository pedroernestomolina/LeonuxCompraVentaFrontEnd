using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibVenta.PosOffline.Servidor.EnviarData
{
    
    public class Ficha
    {

        public List<Jornada> Jornadas { get; set; }
        public List<Movimiento> Movimientos { get; set; }
        public List<Serie> Series { get; set; }


        public Ficha()
        {
            Jornadas = new List<Jornada>();
            Movimientos = new List<Movimiento>();
            Series = new List<Serie>();
        }

        public Ficha(OOB.LibVenta.PosOffline.Servidor.PrepararData.Ficha data)
            :this()
        {
            Jornadas = data.Jornadas.Select(s =>
            {
                var nj = new OOB.LibVenta.PosOffline.Servidor.EnviarData.Jornada()
                {
                    Id = s.Id,
                    EstatusTransmitida = "T",
                };
                return nj;
            }).ToList();

            Series= data.Series.Select(s =>
            {
                var ns = new OOB.LibVenta.PosOffline.Servidor.EnviarData.Serie()
                {
                    Auto=s.Auto,
                    Correlativo=s.Correlativo,
                };
                return ns;
            }).ToList();


            foreach (var jor in data.Jornadas)
            {
                var prefijo = jor.Cierre.prefijo;

                var c=jor.Cierre;
                var cierre = new OOB.LibVenta.PosOffline.Servidor.EnviarData.MovCierre()
                {
                    autoUsuario = c.autoUsuario,
                    codigoUsuario = c.codigoUsuario,
                    usuario = c.usuario,
                    fecha = c.fecha,
                    hora = c.hora,
                    diferencia = c.diferencia,
                    efectivo = c.efectivo,
                    divisa = c.divisa,
                    debito = c.tarjeta,
                    otros = c.otros,
                    firma = c.firma,
                    devolucion = c.devolucion,
                    subTotal = c.subTotal,
                    total = c.total,
                    mfectivo = c.mEfectivo,
                    mdivisa = c.mDivisa,
                    mdebito = c.mTarjeta,
                    motros = c.mOtro,
                    mfirma = c.mFirma,
                    msubtotal = c.mSubTotal,
                    mtotal = c.mTotal,
                };

                var listDoc = new List<Documento>();
                listDoc = jor.Documentos.Where(w => w.IsActiva).Select(d =>
                {
                    var nd = new OOB.LibVenta.PosOffline.Servidor.EnviarData.Documento()
                    {
                        AnoRelacion = d.AnoRelacion,
                        AnticipoIva = 0,
                        Aplica = d.Aplica,
                        AutoCliente = "0000000001",
                        AutoCxC = "",
                        AutoRecibo = "",
                        AutoRemision = "",
                        AutoTransporte = d.TranporteAuto,
                        AutoUsuario = d.UsuarioAuto,
                        AutoVendedor = d.VendedorAuto,
                        Base1 = d.Base1,
                        Base2 = d.Base2,
                        Base3 = d.Base3,
                        Cambio = d.CambioDar,
                        Cargos = d.CargoMonto_1,
                        Cargosp = d.CargoPorc_1,
                        CiBeneficiario = "",
                        Cierre = "",
                        CiRif = d.CiRif,
                        CiTitular = "",
                        Clave = "",
                        CodigoCliente = "01",
                        CodigoSucursal = d.CodigoSucursal,
                        CodigoTransporte = d.TranporteCodigo,
                        CodigoUsuario = d.UsuarioCodigo,
                        CodigoVendedor = d.VendedorCodigo,
                        Columna = "1",
                        ComprobanteRetencion = "",
                        ComprobanteRetencionIslr = "",
                        CondicionPago = d.CondicionPago,
                        Control = d.Control,
                        Costo = d.MontoCostoVenta,
                        DenominacionFiscal = "No Contribuyente",
                        Descuento1 = d.DesctoMonto_1,
                        Descuento1p = d.DesctoPorc_1,
                        Descuento2 = d.DesctoMonto_2,
                        Descuento2p = d.DesctoPorc_2,
                        Despachado = "",
                        Dias = 0,
                        DiasValidez = 0,
                        DirDespacho = "",
                        DirFiscal = d.ClienteDirFiscal,
                        DocumentoNombre = d.DocumentoNombreVenta,
                        DocumentoNro = d.DocumentoNro,
                        DocumentoRemision = "",
                        DocumentoTipo = "Ventas",
                        Estacion = d.Estacion,
                        EstatusAnulado = d.EstatusAnulado,
                        EstatusCierreContable = "0",
                        EstatusValidado = "0",
                        Exento = d.MontoExento,
                        Expendiente = "",
                        FactorCambio = d.FactorCambio,
                        Fecha = d.Fecha,
                        FechaPedido = d.Fecha,
                        FechaRegistro = d.Fecha,
                        FechaRetencion = new DateTime(2000, 01, 01),
                        FechaVencimiento = d.Fecha,
                        Hora = d.Hora,
                        Impuesto = d.MontoImpuesto,
                        Impuesto1 = d.Impuesto1,
                        Impuesto2 = d.Impuesto2,
                        Impuesto3 = d.Impuesto3,
                        MBase = d.MontoBase,
                        MesRelacion = d.MesRelacion,
                        MontoDivisa = d.MontoDivisa,
                        Neto = d.MontoVentaNeta,
                        NombreBeneficiario = "",
                        NombreTitular = "",
                        Nota = "",
                        OrdenCompra = "",
                        Pedido = "",
                        Planilla = "",
                        RazonSocial = d.ClienteNombre,
                        Recibo = "",
                        Renglones = d.Renglones,
                        RetencionIslr = 0.0m,
                        RetencionIva = 0.0m,
                        SaldoPendiente = d.SaldoPendiente,
                        Serie = d.Serie,
                        Signo = d.Signo,
                        Situacion = "Procesado",
                        SubTotal = d.MontoSubt,
                        SubTotalImpuesto = d.MontoSubtImpuesto,
                        SubTotalNeto = d.MontoSubtNeto,
                        Tarifa = d.Tarifa,
                        Tasa1 = d.TasaIva1,
                        Tasa2 = d.TasaIva2,
                        Tasa3 = d.TasaIva3,
                        TasaRetencionIslr = 0.0m,
                        TasaRetencionIva = 0.0m,
                        Telefono = d.ClienteTelefono,
                        TercerosIva = 0,
                        Tipo = d.Codigo,
                        TipoCliente = "",
                        TipoRemision = "",
                        Total = d.MontoTotal,
                        Transporte = d.TranporteNombre,
                        Usuario = d.UsuarioNombre,
                        Utilidad = d.MontoUtilidad,
                        Utilidadp = d.MontoUtilidadPorc,
                        Vendedor = d.VendedorNombre,
                        PrefijoSucursal = d.PrefijoSucursal,


                        DocCxC = new CxC()
                        {
                            CCobranza = 0.0m,
                            CCobranzap = 0.0m,
                            Fecha = d.Fecha,
                            TipoDocumento = d.TipoDocumentoCxC,
                            Documento = d.DocumentoNro,
                            FechaVencimiento = d.Fecha,
                            Nota = "",
                            Importe = d.MontoTotal,
                            Acumulado = d.AcumuladoCxC,
                            AutoCliente = "0000000001",
                            Cliente = d.ClienteNombre,
                            CiRif = d.CiRif,
                            CodigoCliente = "01",
                            EstatusCancelado = d.EstatusPagado,
                            Resta = d.SaldoPendiente,
                            EstatusAnulado = d.EstatusAnulado,
                            AutoDocumento = "",
                            Numero = "",
                            AutoAgencia = "0000000001",
                            Agencia = "",
                            Signo = d.Signo,
                            AutoVendedor = d.VendedorAuto,
                            CDepartamento = 0.0m,
                            CVentas = 0.0m,
                            CVentasp = 0.0m,
                            Serie = d.Serie,
                            ImporteNeto = d.MontoVentaNeta,
                            Dias = 0,
                            Castigop = 0.0m,
                        },

                        //DocPago = ((d.TipoDocumento != PrepararData.Enumerados.EnumTipoDocumento.NotaCredito) || (!d.IsCredito)) ? new CxCPago(d) : null,
                        DocPago = (d.IsCredito || d.TipoDocumento == PrepararData.Enumerados.EnumTipoDocumento.NotaCredito) ? null : new CxCPago(d),

                        Detalles = d.Detalles.Select(dt =>
                        {
                            var md = new OOB.LibVenta.PosOffline.Servidor.EnviarData.DocumentoDetalle()
                            {
                                Auto = "",
                                AutoCliente = "0000000001",
                                AutoDepartamento = dt.AutoDepartamento,
                                AutoDeposito = d.DepositoAuto,
                                AutoGrupo = dt.AutoGrupo,
                                AutoProducto = dt.AutoProducto,
                                AutoSubGrupo = dt.AutoSubGrupo,
                                AutoTasa = dt.AutoTasa,
                                AutoVendedor = d.VendedorAuto,
                                Cantidad = dt.Cantidad,
                                CantidadUnd = dt.CantidadUnd,
                                Categoria = dt.Categoria,
                                Cobranza = 0.0m,
                                Cobranzap = 0.0m,
                                CobranzapVendedor = 0.0m,
                                CobranzaVendedor = 0.0m,
                                Codigo = dt.CodigoProducto,
                                CodigoDeposito = d.DepositoCodigo,
                                CodigoVendedor = d.VendedorCodigo,
                                ContenidoEmpaque = dt.EmpaqueContenido,
                                Corte = "",
                                CostoCompra = dt.CostoCompra,
                                CostoPromedioUnd = dt.CostoPromedioUnd,
                                CostoUnd = dt.CostoCompraUnd,
                                CostoVenta = dt.CostoVenta,
                                Decimales = dt.Decimales,
                                Deposito = d.DepositoNombre,
                                Descuento1 = 0.0m,
                                Descuento1p = 0.0m,
                                Descuento2 = 0.0m,
                                Descuento2p = 0.0m,
                                Descuento3 = 0.0m,
                                Descuento3p = 0.0m,
                                Detalle = "",
                                DiasGarantia = 0,
                                Empaque = dt.EmpaqueDescripcion,
                                EstatusAnulado = d.EstatusAnulado,
                                EstatusChecked = "1",
                                EstatusCorte = "0",
                                EstatusGarantia = "0",
                                EstatusSerial = "0",
                                Fecha = d.Fecha,
                                Hora = d.Hora,
                                Impuesto = dt.MontoIva,
                                Nombre = dt.NombreProducto,
                                PrecioFinal = dt.PrecioFinal,
                                PrecioItem = dt.PrecioItem,
                                PrecioNeto = dt.PrecioNeto,
                                PrecioSugerido = dt.PrecioSugerido,
                                PrecioUnd = dt.PrecioUnd,
                                Signo = d.Signo,
                                Tarifa = dt.Tarifa,
                                Tasa = dt.TasaIva,
                                Tipo = d.Codigo,
                                Total = dt.Total,
                                TotalDescuento = dt.TotalDescuento,
                                TotalNeto = dt.TotalNeto,
                                Utilidad = dt.UtilidadMonto,
                                Utilidadp = dt.UtilidadPorct,
                                Ventas = 0.0m,
                                Ventasp = 0.0m,
                                VentaspVendedor = 0.0m,
                                VentasVendedor = 0.0m,
                                X = 1.0m,
                                Y = 1.0m,
                                Z = 1.0m,
                            };
                            return md;
                        }).ToList(),

                        MovKardex = d.Detalles.Select(dt =>
                        {
                            var mk = new OOB.LibVenta.PosOffline.Servidor.EnviarData.ProductoKardex()
                            {
                                AutoConcepto = d.AutoConceptoMov,
                                AutoDeposito = d.DepositoAuto,
                                AutoProducto = dt.AutoProducto,
                                Cantidad = dt.CantidadUnd,
                                CantidadBono = 0,
                                CantidadUnd = dt.CantidadUnd,
                                Codigo = d.Codigo,
                                CodigoSucursal = d.CodigoSucursal,
                                CostoUnd = dt.CostoPromedioUnd,
                                Documento = d.DocumentoNro,
                                Entidad = "NO CONTRIBUYENTE NA",
                                EstatusAnulado = d.EstatusAnulado,
                                Fecha = d.Fecha,
                                Hora = d.Hora,
                                Modulo = "Ventas",
                                Nota = "",
                                PrecioUnd = dt.PrecioUnd,
                                Siglas = d.Siglas,
                                Signo = d.Signo * (-1),
                                Total = dt.CostoVenta,
                            };
                            return mk;
                        }).ToList(),

                        ActDeposito = d.Deposito.GroupBy(g => new { g.AutoProducto, g.AutoDeposito }).
                        Select(gc => new OOB.LibVenta.PosOffline.Servidor.EnviarData.ProductoDeposito()
                        {
                            AutoDeposito = gc.Key.AutoDeposito,
                            AutoProducto = gc.Key.AutoProducto,
                            CantUnd = gc.Sum(t => t.CantidadUnd),
                        }).ToList(),
                    };

                    var auto = 1;
                    foreach (var det in nd.Detalles)
                    {
                        det.Auto = auto.ToString().Trim().PadLeft(10, '0');
                        auto += 1;
                    }
                    return nd;
                }).ToList();

                var mov = new Movimiento();
                mov.Cierre=cierre;
                mov.Documentos=listDoc;
                mov.Prefijo = prefijo;
                Movimientos.Add(mov);
            }
        }
    }

}