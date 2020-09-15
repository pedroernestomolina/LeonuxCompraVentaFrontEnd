using DataProvPosOffLine.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.Data
{

    public partial class DataProv : IData
    {

        public OOB.Resultado Servidor_Test()
        {
            var result = new OOB.Resultado();

            var r01 = MyData.Servidor_Test();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

        public OOB.Resultado Servidor_ActualizarData()
        {
            var result = new OOB.Resultado();

            var r01 = MyData.Servidor_ActualizarData();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Servidor.PrepararData.Ficha> Servidor_PrepararData()
        {
            var result = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Servidor.PrepararData.Ficha>();

            var r01 = MyData.Servidor_RecogerDataEnviar();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            var rt = new OOB.LibVenta.PosOffline.Servidor.PrepararData.Ficha(); ;
            if (r01.Entidad != null)
            {

                if (r01.Entidad.Series != null)
                {
                    if (r01.Entidad.Series.Count > 0)
                    {
                        var ls = new List<OOB.LibVenta.PosOffline.Servidor.PrepararData.Serie>();
                        foreach (var rs in r01.Entidad.Series)
                        {
                            var nr = new OOB.LibVenta.PosOffline.Servidor.PrepararData.Serie()
                            {
                                Auto = rs.Auto,
                                Control = rs.Control,
                                Correlativo = rs.Correlativo,
                                SerieNombre = rs.SerieNombre,
                            };
                            ls.Add(nr);
                        }
                        rt.Series = ls;
                    }
                }

                if (r01.Entidad.Jornadas != null)
                {
                    if (r01.Entidad.Jornadas.Count > 0)
                    {
                        var listJor = r01.Entidad.Jornadas.Select(s =>
                        {
                            var jor = new OOB.LibVenta.PosOffline.Servidor.PrepararData.Jornada()
                            {
                                Id = s.Id,
                                Cierre = new OOB.LibVenta.PosOffline.Servidor.PrepararData.MovimientoCierre()
                                {
                                    autoUsuario = s.Cierre.autoUsuario,
                                    codigoUsuario = s.Cierre.codigoUsuario,
                                    usuario = s.Cierre.usuario,
                                    fecha = s.Cierre.fecha,
                                    hora = s.Cierre.hora,
                                    prefijo = s.Cierre.prefijo,
                                    diferencia = s.Cierre.diferencia,
                                    efectivo = s.Cierre.efectivo,
                                    divisa = s.Cierre.divisa,
                                    tarjeta = s.Cierre.tarjeta,
                                    otros = s.Cierre.otros,
                                    devolucion = s.Cierre.devolucion,
                                    subTotal = s.Cierre.subTotal,
                                    total = s.Cierre.total,
                                    mEfectivo = s.Cierre.mEfectivo,
                                    mDivisa = s.Cierre.mDivisa,
                                    mTarjeta = s.Cierre.mTarjeta,
                                    mOtro = s.Cierre.otros,
                                    mSubTotal = s.Cierre.mSubTotal,
                                    mTotal = s.Cierre.mTotal,
                                    firma = s.Cierre.firma,
                                    mFirma = s.Cierre.mFirma,
                                    //
                                    cntDivisa=s.Cierre.cntDivisa,
                                    cntDivisaUsu = s.Cierre.cntDivisaUsu,
                                    cntDoc=s.Cierre.cntDoc,
                                    cntDocFac = s.Cierre.cntDocFac,
                                    cntDocNcr = s.Cierre.cntDocNcr,
                                    montoFac=s.Cierre.montoFac,
                                    montoNcr=s.Cierre.montoNcr,
                                },
                                Documentos = s.Documentos.Select(d =>
                                {
                                    var doc = new OOB.LibVenta.PosOffline.Servidor.PrepararData.Documento()
                                    {
                                        AnoRelacion = d.AnoRelacion,
                                        Aplica = d.Aplica,
                                        Base1 = d.Base1,
                                        Base2 = d.Base2,
                                        Base3 = d.Base3,
                                        CambioDar = d.CambioDar,
                                        CargoMonto_1 = d.CargoMonto_1,
                                        CargoPorc_1 = d.CargoPorc_1,
                                        CiRif = d.CiRif,
                                        ClienteDirFiscal = d.ClienteDirFiscal,
                                        ClienteId = d.ClienteId,
                                        ClienteNombre = d.ClienteNombre,
                                        ClienteTelefono = d.ClienteTelefono,
                                        CobradorAuto = d.CobradorAuto,
                                        CobradorCodigo = d.CobradorCodigo,
                                        CobradorNombre = d.CobradorNombre,
                                        CodigoSucursal = d.CodigoSucursal,
                                        PrefijoSucursal = d.Prefijo,
                                        Control = d.Control,
                                        DepositoAuto = d.DepositoAuto,
                                        DepositoCodigo = d.DepositoCodigo,
                                        DepositoNombre = d.DepositoNombre,
                                        DesctoMonto_1 = d.DesctoMonto_1,
                                        DesctoMonto_2 = d.DesctoMonto_2,
                                        DesctoPorc_1 = d.DesctoPorc_1,
                                        DesctoPorc_2 = d.DesctoPorc_2,
                                        DocumentoNro = d.DocumentoNro,
                                        Estacion = d.Estacion,
                                        FactorCambio = d.FactorCambio,
                                        Fecha = d.Fecha,
                                        Hora = d.Hora,
                                        Id = d.Id,
                                        IdJornada = d.IdJornada,
                                        IdOperador = d.IdOperador,
                                        Impuesto1 = d.Impuesto1,
                                        Impuesto2 = d.Impuesto2,
                                        Impuesto3 = d.Impuesto3,
                                        IsActiva = d.IsActiva,
                                        IsCredito = d.IsCredito,
                                        MesRelacion = d.MesRelacion,
                                        MontoBase = d.MontoBase,
                                        MontoCostoVenta = d.MontoCostoVenta,
                                        MontoDivisa = d.MontoDivisa,
                                        MontoExento = d.MontoExento,
                                        MontoImpuesto = d.MontoImpuesto,
                                        MontoRecibido = d.MontoRecibido,
                                        MontoSubt = d.MontoSubt,
                                        MontoSubtImpuesto = d.MontoSubtImpuesto,
                                        MontoSubtNeto = d.MontoSubtNeto,
                                        MontoTotal = d.MontoTotal,
                                        MontoUtilidad = d.MontoUtilidad,
                                        MontoUtilidadPorc = d.MontoUtilidadPorc,
                                        MontoVentaNeta = d.MontoVentaNeta,
                                        Renglones = d.Renglones,
                                        Serie = d.Serie,
                                        Signo = d.Signo,
                                        TasaIva1 = d.TasaIva1,
                                        TasaIva2 = d.TasaIva2,
                                        TasaIva3 = d.TasaIva3,
                                        TipoDocumento = (OOB.LibVenta.PosOffline.Servidor.PrepararData.Enumerados.EnumTipoDocumento)d.TipoDocumento,
                                        TranporteAuto = d.TranporteAuto,
                                        TranporteCodigo = d.TranporteCodigo,
                                        TranporteNombre = d.TranporteNombre,
                                        UsuarioAuto = d.UsuarioAuto,
                                        UsuarioCodigo = d.UsuarioCodigo,
                                        UsuarioNombre = d.UsuarioNombre,
                                        VendedorAuto = d.VendedorAuto,
                                        VendedorCodigo = d.VendedorCodigo,
                                        VendedorNombre = d.VendedorNombre,
                                        Tarifa = d.Tarifa,
                                        SaldoPendiente = d.SaldoPendiente,
                                        AutoConceptoMov = d.AutoConceptoMov,
                                        CodigoConceptoMov = d.CodigoConceptoMov,
                                        NombreConceptoMov = d.NombreConceptoMov,

                                        Detalles = d.Detalles.Select(dt =>
                                        {
                                            var detalle = new OOB.LibVenta.PosOffline.Servidor.PrepararData.DocumentoDetalle()
                                            {
                                                AutoDepartamento = dt.AutoDepartamento,
                                                AutoGrupo = dt.AutoGrupo,
                                                AutoProducto = dt.AutoProducto,
                                                AutoSubGrupo = dt.AutoSubGrupo,
                                                AutoTasa = dt.AutoTasa,
                                                Cantidad = dt.Cantidad,
                                                CantidadUnd = dt.CantidadUnd,
                                                Categoria = dt.Categoria,
                                                CodigoProducto = dt.CodigoProducto,
                                                CostoCompraUnd = dt.CostoCompraUnd,
                                                CostoPromedioUnd = dt.CostoPromedioUnd,
                                                CostoVenta = dt.CostoVenta,
                                                Decimales = dt.Decimales,
                                                DiaEmpaqueGarantia = dt.DiaEmpaqueGarantia,
                                                EmpaqueCodigo = dt.EmpaqueCodigo,
                                                EmpaqueContenido = dt.EmpaqueContenido,
                                                EmpaqueDescripcion = dt.EmpaqueDescripcion,
                                                EsPesado = dt.EsPesado,
                                                Id = dt.Id,
                                                MontoDscto_1 = dt.MontoDscto_1,
                                                MontoDscto_2 = dt.MontoDscto_2,
                                                MontoDscto_3 = dt.MontoDscto_3,
                                                MontoIva = dt.MontoIva,
                                                NombreProducto = dt.NombreProducto,
                                                Notas = dt.Notas,
                                                PorcDscto_1 = dt.PorcDscto_1,
                                                PorcDscto_2 = dt.PorcDscto_2,
                                                PorcDscto_3 = dt.PorcDscto_3,
                                                PrecioFinal = dt.PrecioFinal,
                                                PrecioItem = dt.PrecioItem,
                                                PrecioNeto = dt.PrecioNeto,
                                                PrecioSugerido = dt.PrecioSugerido,
                                                PrecioUnd = dt.PrecioUnd,
                                                Tarifa = dt.Tarifa,
                                                TasaIva = dt.TasaIva,
                                                TipoIva = dt.TipoIva,
                                                Total = dt.Total,
                                                TotalDescuento = dt.TotalDescuento,
                                                TotalNeto = dt.TotalNeto,
                                                UtilidadMonto = dt.UtilidadMonto,
                                                UtilidadPorct = dt.UtilidadPorct,
                                                CostoCompra = dt.CostoCompra,
                                                CostoPromedio = dt.CostoPromedio,
                                            };
                                            return detalle;
                                        }).ToList(),

                                        MetodosPago = d.MetodosPago.Select(p =>
                                        {
                                            var pago = new OOB.LibVenta.PosOffline.Servidor.PrepararData.DocumentoPago()
                                            {
                                                AutoMedioCobro = p.AutoMedioCobro,
                                                CodigoMedioCobro = p.CodigoMedioCobro,
                                                Id = p.Id,
                                                LoteNro = p.LoteNro,
                                                MedioCobro = p.MedioCobro,
                                                MontoImporte = p.MontoImporte,
                                                MontoRecibido = p.MontoRecibido,
                                                ReferenciaNro = p.ReferenciaNro,
                                                Tasa = p.Tasa,
                                            };
                                            return pago;
                                        }).ToList(),
                                    };
                                    return doc;
                                }).ToList(),
                            };
                            return jor;
                        }).ToList();
                        rt.Jornadas = listJor;
                    }
                }
            }
            result.Entidad = rt;

            return result;
        }

        public OOB.Resultado Servidor_EnviarData(OOB.LibVenta.PosOffline.Servidor.EnviarData.Ficha ficha)
        {
            var result = new OOB.Resultado();

            var fichaDTO = new DtoLibPosOffLine.Servidor.EnviarData.Ficha()
            {
                Jornadas = ficha.Jornadas.Select(s =>
                {
                    var nr = new DtoLibPosOffLine.Servidor.EnviarData.Jornada()
                    {
                        Id = s.Id,
                        EstatusTransmitida = s.EstatusTransmitida,
                    };
                    return nr;
                }).ToList(),


                Series = ficha.Series.Select(s =>
                {
                    var nr = new DtoLibPosOffLine.Servidor.EnviarData.Serie()
                    {
                        Auto = s.Auto,
                        Correlativo = s.Correlativo,
                    };
                    return nr;
                }).ToList(),
            };

            var Fechas = new List<DateTime>();
            var Movimientos = new List<DtoLibPosOffLine.Servidor.EnviarData.Movimiento>();
            foreach (var mv in ficha.Movimientos)
            {
                var lf = mv.Documentos.GroupBy(g => g.Fecha).Select(r => new { r.Key }).ToList();
                foreach (var r in lf)
                {
                    Fechas.Add(r.Key.Date);
                };

                var _prefijo = mv.Prefijo;

                var c = mv.Cierre;
                var _cierre = new DtoLibPosOffLine.Servidor.EnviarData.MovCierre()
                {
                    autoUsuario = c.autoUsuario,
                    codigoUsuario = c.codigoUsuario,
                    usuario = c.usuario,
                    fecha = c.fecha,
                    hora = c.hora,
                    diferencia = c.diferencia,
                    efectivo = c.efectivo,
                    divisa = c.divisa,
                    debito = c.debito,
                    otros = c.otros,
                    firma = c.firma,
                    devolucion = c.devolucion,
                    subTotal = c.subTotal,
                    total = c.total,
                    mfectivo = c.mfectivo,
                    mdivisa = c.mdivisa,
                    mdebito = c.mdebito,
                    motros = c.motros,
                    mfirma = c.mfirma,
                    msubtotal = c.msubtotal,
                    mtotal = c.mtotal,
                    cntDivisa = (int)c.cntDivisa,
                    cntDivisaUsuario = (int) c.cntDivisaUsuario,
                    cntDoc = c.cntDoc,
                    cntDocFac = c.cntDocFac,
                    cntDocNcr = c.cntDocNcr,
                    montoFac = c.montoFac,
                    montoNcr = c.montoNcr,
                };

                var Documentos = mv.Documentos.Select(d =>
                {
                    DtoLibPosOffLine.Servidor.EnviarData.CxCPago pago = null;
                    if (d.DocPago != null)
                    {
                        pago = new DtoLibPosOffLine.Servidor.EnviarData.CxCPago();

                        var p = d.DocPago.Pago;
                        pago.Pago = new DtoLibPosOffLine.Servidor.EnviarData.CxC()
                        {
                            Acumulado = p.Acumulado,
                            Agencia = p.Agencia,
                            AutoAgencia = p.AutoAgencia,
                            AutoCliente = p.AutoCliente,
                            AutoDocumento = p.AutoDocumento,
                            AutoVendedor = p.AutoVendedor,
                            Castigop = p.Castigop,
                            CCobranza = p.CCobranza,
                            CCobranzap = p.CCobranzap,
                            CDepartamento = p.CDepartamento,
                            CiRif = p.CiRif,
                            Cliente = p.Cliente,
                            CodigoCliente = p.CodigoCliente,
                            CVentas = p.CVentas,
                            CVentasp = p.CVentasp,
                            Dias = p.Dias,
                            Documento = p.Documento,
                            EstatusAnulado = p.EstatusAnulado,
                            EstatusCancelado = p.EstatusCancelado,
                            Fecha = p.Fecha,
                            FechaVencimiento = p.FechaVencimiento,
                            Importe = p.Importe,
                            ImporteNeto = p.ImporteNeto,
                            Nota = p.Nota,
                            Numero = p.Numero,
                            Resta = p.Resta,
                            Serie = p.Serie,
                            Signo = p.Signo,
                            TipoDocumento = p.TipoDocumento,
                        };

                        var r = d.DocPago.Recibo;
                        pago.Recibo = new DtoLibPosOffLine.Servidor.EnviarData.CxCRecibo()
                        {
                            Fecha = r.Fecha,
                            AutoUsuario = r.AutoUsuario,
                            Importe = r.Importe,
                            Usuario = r.Usuario,
                            MontoRecibido = r.MontoRecibido,
                            Cobrador = r.Cobrador,
                            AutoCliente = r.AutoCliente,
                            Cliente = r.Cliente,
                            CiRif = r.CiRif,
                            Codigo = r.Codigo,
                            EstatusAnulado = r.EstatusAnulado,
                            Direccion = r.Direccion,
                            Telefono = r.Telefono,
                            AutoCobrador = r.AutoCobrador,
                            Anticipos = r.Anticipos,
                            Cambio = r.Cambio,
                            Nota = r.Nota,
                            CodigoCobrador = r.CodigoCobrador,
                            AutoCxC = r.AutoCxC,
                            Retenciones = r.Retenciones,
                            Descuentos = r.Descuentos,
                            Hora = r.Hora,
                            Cierre = r.Cierre,
                        };

                        var dd = d.DocPago.Documento;
                        pago.Documento = new DtoLibPosOffLine.Servidor.EnviarData.CxCDocumento()
                        {
                            Id = dd.Id,
                            Fecha = dd.Fecha,
                            TipoDocumento = dd.TipoDocumento,
                            Documento = dd.Documento,
                            Importe = dd.Importe,
                            Operacion = dd.Operacion,
                            FechaRecepcion = dd.FechaRecepcion,
                            Dias = dd.Dias,
                            CastigoP = dd.CastigoP,
                            ComisionP = dd.ComisionP,
                        };

                        pago.MetodoPago = d.DocPago.MediosPago.Select(mp =>
                        {
                            var nmp = new DtoLibPosOffLine.Servidor.EnviarData.CxCMetodoPago()
                            {
                                AutoMedioPago = mp.AutoMedioPago,
                                AutoAgencia = mp.AutoAgencia,
                                Medio = mp.Medio,
                                Codigo = mp.Codigo,
                                MontoRecibido = mp.MontoRecibido,
                                Fecha = mp.Fecha,
                                EstatusAnulado = mp.EstatusAnulado,
                                Numero = mp.Numero,
                                Agencia = mp.Agencia,
                                AutoUsuario = mp.AutoUsuario,
                                Lote = mp.Lote,
                                Referencia = mp.Referencia,
                                AutoCobrador = mp.AutoCobrador,
                                Cierre = mp.Cierre,
                                FechaAgencia = mp.FechaAgencia,
                            };
                            return nmp;
                        }).ToList();
                    }


                    //SE CREA EL DOCUMENTO
                    var nr = new DtoLibPosOffLine.Servidor.EnviarData.Documento()
                    {
                        AnoRelacion = d.AnoRelacion,
                        AnticipoIva = d.AnticipoIva,
                        Aplica = d.Aplica,
                        AutoCliente = d.AutoCliente,
                        AutoCxC = d.AutoCxC,
                        AutoRecibo = d.AutoRecibo,
                        AutoRemision = d.AutoRemision,
                        AutoTransporte = d.AutoTransporte,
                        AutoUsuario = d.AutoUsuario,
                        AutoVendedor = d.AutoVendedor,
                        Base1 = d.Base1,
                        Base2 = d.Base2,
                        Base3 = d.Base3,
                        Cambio = d.Cambio,
                        Cargos = d.Cargos,
                        Cargosp = d.Cargosp,
                        DenominacionFiscal = d.DenominacionFiscal,
                        CiBeneficiario = d.CiBeneficiario,
                        Cierre = d.Cierre,
                        CiRif = d.CiRif,
                        CiTitular = d.CiTitular,
                        Clave = d.Clave,
                        CodigoCliente = d.CodigoCliente,
                        CodigoSucursal = d.CodigoSucursal,
                        CodigoTransporte = d.CodigoTransporte,
                        CodigoUsuario = d.CodigoUsuario,
                        CodigoVendedor = d.CodigoVendedor,
                        Columna = d.Columna,
                        ComprobanteRetencion = d.ComprobanteRetencion,
                        ComprobanteRetencionIslr = d.ComprobanteRetencionIslr,
                        CondicionPago = d.CondicionPago,
                        Control = d.Control,
                        Costo = d.Costo,
                        Descuento1 = d.Descuento1,
                        Descuento1p = d.Descuento1p,
                        Descuento2 = d.Descuento2,
                        Descuento2p = d.Descuento2p,
                        Despachado = d.Despachado,
                        Dias = d.Dias,
                        DiasValidez = d.DiasValidez,
                        DirDespacho = d.DirDespacho,
                        DirFiscal = d.DirFiscal,
                        DocumentoNombre = d.DocumentoNombre,
                        DocumentoNro = d.DocumentoNro,
                        DocumentoRemision = d.DocumentoRemision,
                        DocumentoTipo = d.DocumentoTipo,
                        Estacion = d.Estacion,
                        EstatusAnulado = d.EstatusAnulado,
                        EstatusCierreContable = d.EstatusCierreContable,
                        EstatusValidado = d.EstatusValidado,
                        Exento = d.Exento,
                        Expendiente = d.Expendiente,
                        FactorCambio = d.FactorCambio,
                        Fecha = d.Fecha,
                        FechaPedido = d.FechaPedido,
                        FechaRegistro = d.FechaRegistro,
                        FechaRetencion = d.FechaRetencion,
                        FechaVencimiento = d.FechaVencimiento,
                        Hora = d.Hora,
                        Impuesto = d.Impuesto,
                        Impuesto1 = d.Impuesto1,
                        Impuesto2 = d.Impuesto2,
                        Impuesto3 = d.Impuesto3,
                        MBase = d.MBase,
                        MesRelacion = d.MesRelacion,
                        MontoDivisa = d.MontoDivisa,
                        Neto = d.Neto,
                        NombreBeneficiario = d.NombreBeneficiario,
                        NombreTitular = d.NombreTitular,
                        Nota = d.Nota,
                        OrdenCompra = d.OrdenCompra,
                        Pedido = d.Pedido,
                        Planilla = d.Planilla,
                        RazonSocial = d.RazonSocial,
                        Recibo = d.Recibo,
                        Renglones = d.Renglones,
                        RetencionIslr = d.RetencionIslr,
                        RetencionIva = d.RetencionIva,
                        SaldoPendiente = d.SaldoPendiente,
                        Serie = d.Serie,
                        Signo = d.Signo,
                        Situacion = d.Situacion,
                        SubTotal = d.SubTotal,
                        SubTotalImpuesto = d.SubTotalImpuesto,
                        SubTotalNeto = d.SubTotalNeto,
                        Tarifa = d.Tarifa,
                        Tasa1 = d.Tasa1,
                        Tasa2 = d.Tasa2,
                        Tasa3 = d.Tasa3,
                        TasaRetencionIslr = d.TasaRetencionIslr,
                        TasaRetencionIva = d.TasaRetencionIva,
                        Telefono = d.Telefono,
                        TercerosIva = d.TercerosIva,
                        Tipo = d.Tipo,
                        TipoCliente = d.TipoCliente,
                        TipoRemision = d.TipoRemision,
                        Total = d.Total,
                        Transporte = d.Transporte,
                        Usuario = d.Usuario,
                        Utilidad = d.Utilidad,
                        Utilidadp = d.Utilidadp,
                        Vendedor = d.Vendedor,
                        Prefijo = d.PrefijoSucursal,


                        //SE CREA LA CXC DEL DOCUMENTO
                        DocCxC = new DtoLibPosOffLine.Servidor.EnviarData.CxC()
                        {
                            Acumulado = d.DocCxC.Acumulado,
                            Agencia = d.DocCxC.Agencia,
                            AutoAgencia = d.DocCxC.AutoAgencia,
                            AutoCliente = d.DocCxC.AutoCliente,
                            AutoDocumento = d.DocCxC.AutoDocumento,
                            AutoVendedor = d.DocCxC.AutoVendedor,
                            Castigop = d.DocCxC.Castigop,
                            CCobranza = d.DocCxC.CCobranza,
                            CCobranzap = d.DocCxC.CCobranzap,
                            CDepartamento = d.DocCxC.CDepartamento,
                            CiRif = d.DocCxC.CiRif,
                            Cliente = d.DocCxC.Cliente,
                            CodigoCliente = d.DocCxC.CodigoCliente,
                            CVentas = d.DocCxC.CVentas,
                            CVentasp = d.DocCxC.CVentasp,
                            Dias = d.DocCxC.Dias,
                            Documento = d.DocCxC.Documento,
                            EstatusAnulado = d.DocCxC.EstatusAnulado,
                            EstatusCancelado = d.DocCxC.EstatusCancelado,
                            Fecha = d.DocCxC.Fecha,
                            FechaVencimiento = d.DocCxC.FechaVencimiento,
                            Importe = d.DocCxC.Importe,
                            ImporteNeto = d.DocCxC.ImporteNeto,
                            Nota = d.DocCxC.Nota,
                            Numero = d.DocCxC.Numero,
                            Resta = d.DocCxC.Resta,
                            Serie = d.DocCxC.Serie,
                            Signo = d.DocCxC.Signo,
                            TipoDocumento = d.DocCxC.TipoDocumento,
                        },


                        //PAGO DEL DOCUMENTO
                        DocCxCPago = pago,


                        //DETALLES DE DOCUMENTO
                        Detalles = d.Detalles.Select(ddt =>
                        {
                            var ndt = new DtoLibPosOffLine.Servidor.EnviarData.DocumentoDetalle()
                            {
                                Auto = ddt.Auto,
                                AutoCliente = ddt.AutoCliente,
                                AutoDepartamento = ddt.AutoDepartamento,
                                AutoDeposito = ddt.AutoDeposito,
                                AutoGrupo = ddt.AutoGrupo,
                                AutoProducto = ddt.AutoProducto,
                                AutoSubGrupo = ddt.AutoSubGrupo,
                                AutoTasa = ddt.AutoTasa,
                                AutoVendedor = ddt.AutoVendedor,
                                Cantidad = ddt.Cantidad,
                                CantidadUnd = ddt.CantidadUnd,
                                Categoria = ddt.Categoria,
                                Cobranza = ddt.Cobranza,
                                Cobranzap = ddt.Cobranzap,
                                CobranzapVendedor = ddt.CobranzapVendedor,
                                CobranzaVendedor = ddt.CobranzaVendedor,
                                Codigo = ddt.Codigo,
                                CodigoDeposito = ddt.CodigoDeposito,
                                CodigoVendedor = ddt.CodigoVendedor,
                                ContenidoEmpaque = ddt.ContenidoEmpaque,
                                Corte = ddt.Corte,
                                CostoCompra = ddt.CostoCompra,
                                CostoPromedioUnd = ddt.CostoPromedioUnd,
                                CostoUnd = ddt.CostoUnd,
                                CostoVenta = ddt.CostoVenta,
                                Decimales = ddt.Decimales,
                                Deposito = ddt.Deposito,
                                Descuento1 = ddt.Descuento1,
                                Descuento1p = ddt.Descuento1p,
                                Descuento2 = ddt.Descuento2,
                                Descuento2p = ddt.Descuento2p,
                                Descuento3 = ddt.Descuento3,
                                Descuento3p = ddt.Descuento3p,
                                Detalle = ddt.Detalle,
                                DiasGarantia = ddt.DiasGarantia,
                                Empaque = ddt.Empaque,
                                EstatusAnulado = ddt.EstatusAnulado,
                                EstatusChecked = ddt.EstatusChecked,
                                EstatusCorte = ddt.EstatusCorte,
                                EstatusGarantia = ddt.EstatusGarantia,
                                EstatusSerial = ddt.EstatusSerial,
                                Fecha = ddt.Fecha,
                                Hora = ddt.Hora,
                                Impuesto = ddt.Impuesto,
                                Nombre = ddt.Nombre,
                                PrecioFinal = ddt.PrecioFinal,
                                PrecioItem = ddt.PrecioItem,
                                PrecioNeto = ddt.PrecioNeto,
                                PrecioSugerido = ddt.PrecioSugerido,
                                PrecioUnd = ddt.PrecioUnd,
                                Signo = ddt.Signo,
                                Tarifa = ddt.Tarifa,
                                Tasa = ddt.Tasa,
                                Tipo = ddt.Tipo,
                                Total = ddt.Total,
                                TotalDescuento = ddt.TotalDescuento,
                                TotalNeto = ddt.TotalNeto,
                                Utilidad = ddt.Utilidad,
                                Utilidadp = ddt.Utilidadp,
                                Ventas = ddt.Ventas,
                                Ventasp = ddt.Ventasp,
                                VentaspVendedor = ddt.VentaspVendedor,
                                VentasVendedor = ddt.VentasVendedor,
                                X = ddt.X,
                                Y = ddt.Y,
                                Z = ddt.Z,
                            };
                            return ndt;
                        }).ToList(),


                        //KARDEX DEL DOCUMENTO
                        MovKardex = d.MovKardex.Select(dmk =>
                        {
                            var nmk = new DtoLibPosOffLine.Servidor.EnviarData.ProductoKardex()
                            {
                                AutoConcepto = dmk.AutoConcepto,
                                AutoDeposito = dmk.AutoDeposito,
                                AutoProducto = dmk.AutoProducto,
                                Cantidad = dmk.Cantidad,
                                CantidadBono = dmk.CantidadBono,
                                CantidadUnd = dmk.CantidadUnd,
                                Codigo = dmk.Codigo,
                                CodigoSucursal = dmk.CodigoSucursal,
                                CostoUnd = dmk.CostoUnd,
                                Documento = dmk.Documento,
                                Entidad = dmk.Entidad,
                                EstatusAnulado = dmk.EstatusAnulado,
                                Fecha = dmk.Fecha,
                                Hora = dmk.Hora,
                                Modulo = dmk.Modulo,
                                Nota = dmk.Nota,
                                PrecioUnd = dmk.PrecioUnd,
                                Siglas = dmk.Siglas,
                                Signo = dmk.Signo,
                                Total = dmk.Total,
                                CodigoConcepto = dmk.CodigoConcepto,
                                NombreConcepto = dmk.NombreConcepto,
                                CodigoDeposito = dmk.CodigoDeposito,
                                NombreDeposito = dmk.NombreDeposito,
                            };
                            return nmk;
                        }).ToList(),


                        // ACTUALIZACION DEL LO
                        ActDeposito = d.ActDeposito.Select(dp =>
                        {
                            var ndp = new DtoLibPosOffLine.Servidor.EnviarData.ProductoDeposito()
                            {
                                AutoDeposito = dp.AutoDeposito,
                                AutoProducto = dp.AutoProducto,
                                CantUnd = dp.CantUnd,
                            };
                            return ndp;
                        }).ToList(),
                    };
                    return nr;
                }).ToList();

                var mov = new DtoLibPosOffLine.Servidor.EnviarData.Movimiento();
                mov.Documentos = Documentos;
                mov.Prefijo = _prefijo;
                mov.Cierre = _cierre;
                Movimientos.Add(mov);
            };
            fichaDTO.Movimientos = Movimientos;
            fichaDTO.FechasMov = Fechas;

            var r01 = MyData.Servidor_EnviarData(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

    }

}