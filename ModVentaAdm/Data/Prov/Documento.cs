using ModVentaAdm.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Prov 
{

    public partial class DataPrv : IData
    {

        public OOB.Resultado.Lista<OOB.Documento.Lista.Ficha> Documento_Get_Lista(OOB.Documento.Lista.Filtro filtro)
        {
            var result = new OOB.Resultado.Lista<OOB.Documento.Lista.Ficha>();

            var filtroDTO = new DtoLibPos.Documento.Lista.Filtro()
            {
                idArqueo = filtro.idArqueo,
                idCliente=filtro.idCliente,
                codSucursal = filtro.codSucursal,
                codTipoDocumento = filtro.codTipoDocumento,
                fecha = new DtoLibPos.Documento.Lista.Filtro.Fecha() { desde = filtro.desde, hasta = filtro.hasta },
            };
            var r01 = MyData.Documento_Get_Lista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var lst = new List<OOB.Documento.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.Documento.Lista.Ficha()
                        {
                            CiRif = s.CiRif,
                            Control = s.Control,
                            DocCodigo = s.DocCodigo,
                            DocNombre = s.DocNombre,
                            DocNumero = s.DocNumero,
                            DocSigno = s.DocSigno,
                            Estatus = s.Estatus,
                            FechaEmision = s.FechaEmision,
                            HoraEmision = s.HoraEmision,
                            Id = s.Id,
                            Monto = s.Monto,
                            NombreRazonSocial = s.NombreRazonSocial,
                            Renglones = s.Renglones,
                            Serie = s.Serie,
                            MontoDivisa = s.MontoDivisa,
                            DocAplica = s.DocAplica,
                            DocSituacion = s.DocSituacion,
                            SucursalCod = s.SucursalCod,
                            SucursalDesc = s.SucursalDesc,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.ListaD = lst;

            return result;
        }

        public OOB.Resultado.FichaEntidad<OOB.Documento.Entidad.Ficha> Documento_GetById(string idAuto)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Documento.Entidad.Ficha>();

            var r01 = MyData.Documento_GetById(idAuto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            var s = r01.Entidad;
            var nr = new OOB.Documento.Entidad.Ficha()
            {
                AnoRelacion = s.AnoRelacion,
                AnticipoIva = s.AnticipoIva,
                Aplica = s.Aplica,
                Auto = s.Auto,
                AutoCliente = s.AutoCliente,
                AutoRemision = s.AutoRemision,
                AutoTransporte = s.AutoTransporte,
                AutoUsuario = s.AutoUsuario,
                AutoVendedor = s.AutoVendedor,
                Base1 = s.Base1,
                Base2 = s.Base2,
                Base3 = s.Base3,
                Cambio = s.Cambio,
                Cargos = s.Cargos,
                Cargosp = s.Cargosp,
                CiBeneficiario = s.CiBeneficiario,
                Cierre = s.Cierre,
                CierreFtp = s.CierreFtp,
                CiRif = s.CiRif,
                CiTitular = s.CiTitular,
                Clave = s.Clave,
                CodigoCliente = s.CodigoCliente,
                CodigoSucursal = s.CodigoSucursal,
                CodigoTransporte = s.CodigoTransporte,
                CodigoUsuario = s.CodigoUsuario,
                CodigoVendedor = s.CodigoVendedor,
                Columna = s.Columna,
                ComprobanteRetencion = s.ComprobanteRetencion,
                ComprobanteRetencionIslr = s.ComprobanteRetencionIslr,
                CondicionPago = s.CondicionPago,
                Control = s.Control,
                Costo = s.Costo,
                DenominacionFiscal = s.DenominacionFiscal,
                Descuento1 = s.Descuento1,
                Descuento1p = s.Descuento1p,
                Descuento2 = s.Descuento2,
                Descuento2p = s.Descuento2p,
                Despachado = s.Despachado,
                Dias = s.Dias,
                DiasValidez = s.DiasValidez,
                DirDespacho = s.DirDespacho,
                DirFiscal = s.DirFiscal,
                DocumentoNombre = s.DocumentoNombre,
                DocumentoNro = s.DocumentoNro,
                DocumentoRemision = s.DocumentoRemision,
                DocumentoTipo = s.DocumentoTipo,
                Estacion = s.Estacion,
                EstatusAnulado = s.EstatusAnulado,
                EstatusCierreContable = s.EstatusCierreContable,
                EstatusValidado = s.EstatusValidado,
                Exento = s.Exento,
                Expendiente = s.Expendiente,
                FactorCambio = s.FactorCambio,
                Fecha = s.Fecha,
                FechaPedido = s.FechaPedido,
                FechaVencimiento = s.FechaVencimiento,
                Hora = s.Hora,
                Impuesto = s.Impuesto,
                Impuesto1 = s.Impuesto1,
                Impuesto2 = s.Impuesto2,
                Impuesto3 = s.Impuesto3,
                MBase = s.MBase,
                MesRelacion = s.MesRelacion,
                MontoDivisa = s.MontoDivisa,
                Neto = s.Neto,
                NombreBeneficiario = s.NombreBeneficiario,
                NombreTitular = s.NombreTitular,
                Nota = s.Nota,
                OrdenCompra = s.OrdenCompra,
                Pedido = s.Pedido,
                Planilla = s.Planilla,
                Prefijo = s.Prefijo,
                RazonSocial = s.RazonSocial,
                Renglones = s.Renglones,
                RetencionIslr = s.RetencionIslr,
                RetencionIva = s.RetencionIva,
                SaldoPendiente = s.SaldoPendiente,
                Serie = s.Serie,
                Signo = s.Signo,
                Situacion = s.Situacion,
                SubTotal = s.SubTotal,
                SubTotalImpuesto = s.SubTotalImpuesto,
                SubTotalNeto = s.SubTotalNeto,
                Tarifa = s.Tarifa,
                Tasa1 = s.Tasa1,
                Tasa2 = s.Tasa2,
                Tasa3 = s.Tasa3,
                TasaRetencionIslr = s.TasaRetencionIslr,
                TasaRetencionIva = s.TasaRetencionIva,
                Telefono = s.Telefono,
                TercerosIva = s.TercerosIva,
                Tipo = s.Tipo,
                TipoCliente = s.TipoCliente,
                TipoRemision = s.TipoRemision,
                Total = s.Total,
                Transporte = s.Transporte,
                Usuario = s.Usuario,
                Utilidad = s.Utilidad,
                Utilidadp = s.Utilidadp,
                Vendedor = s.Vendedor,
                AutoDocCxC = s.AutoDocCxC,
                AutoReciboCxC = s.AutoReciboCxC,
                items = s.items.Select(ss =>
                {
                    var xr = new OOB.Documento.Entidad.FichaItem()
                    {
                        EstatusPesado = ss.EstatusPesado,
                        AutoCliente = ss.AutoCliente,
                        AutoDepartamento = ss.AutoDepartamento,
                        AutoDeposito = ss.AutoDeposito,
                        AutoGrupo = ss.AutoGrupo,
                        AutoProducto = ss.AutoProducto,
                        AutoSubGrupo = ss.AutoSubGrupo,
                        AutoTasa = ss.AutoTasa,
                        AutoVendedor = ss.AutoVendedor,
                        Cantidad = ss.Cantidad,
                        CantidadUnd = ss.CantidadUnd,
                        Categoria = ss.Categoria,
                        CierreFtp = ss.CierreFtp,
                        Cobranza = ss.Cobranza,
                        Cobranzap = ss.Cobranzap,
                        CobranzapVendedor = ss.CobranzapVendedor,
                        CobranzaVendedor = ss.CobranzaVendedor,
                        Codigo = ss.Codigo,
                        CodigoDeposito = ss.CodigoDeposito,
                        CodigoVendedor = ss.CodigoVendedor,
                        ContenidoEmpaque = ss.ContenidoEmpaque,
                        Corte = ss.Corte,
                        CostoCompra = ss.CostoCompra,
                        CostoPromedioUnd = ss.CostoPromedioUnd,
                        CostoUnd = ss.CostoUnd,
                        CostoVenta = ss.CostoVenta,
                        Decimales = ss.Decimales,
                        Deposito = ss.Deposito,
                        Descuento1 = ss.Descuento1,
                        Descuento1p = ss.Descuento1p,
                        Descuento2 = ss.Descuento2,
                        Descuento2p = ss.Descuento2p,
                        Descuento3 = ss.Descuento3,
                        Descuento3p = ss.Descuento3p,
                        Detalle = ss.Detalle,
                        DiasGarantia = ss.DiasGarantia,
                        Empaque = ss.Empaque,
                        EstatusAnulado = ss.EstatusAnulado,
                        EstatusChecked = ss.EstatusChecked,
                        EstatusCorte = ss.EstatusCorte,
                        EstatusGarantia = ss.EstatusGarantia,
                        EstatusSerial = ss.EstatusSerial,
                        Impuesto = ss.Impuesto,
                        Nombre = ss.Nombre,
                        PrecioFinal = ss.PrecioFinal,
                        PrecioItem = ss.PrecioItem,
                        PrecioNeto = ss.PrecioNeto,
                        PrecioSugerido = ss.PrecioSugerido,
                        PrecioUnd = ss.PrecioUnd,
                        Signo = ss.Signo,
                        Tarifa = ss.Tarifa,
                        Tasa = ss.Tasa,
                        Tipo = ss.Tipo,
                        Total = ss.Total,
                        TotalDescuento = ss.TotalDescuento,
                        TotalNeto = ss.TotalNeto,
                        Utilidad = ss.Utilidad,
                        Utilidadp = ss.Utilidadp,
                        Ventas = ss.Ventas,
                        Ventasp = ss.Ventasp,
                        VentaspVendedor = ss.VentaspVendedor,
                        VentasVendedor = ss.VentasVendedor,
                        X = ss.X,
                        Y = ss.Y,
                        Z = ss.Z,
                    };
                    return xr;
                }).ToList(),
            };
            result.Entidad = nr;

            return result;
        }

    }

}