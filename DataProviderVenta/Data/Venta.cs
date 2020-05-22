using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Data
{

    public partial class DataProvider: DataProviderVenta.Infra.IData
    {

        public OOB.ResultadoAuto Venta_AgregarDocumento(OOB.LibVenta.Venta.Generar.Agregar ficha)
        {
            var result = new OOB.ResultadoAuto();

            var f = ficha;
            var fichaDTO = new DtoLibVenta.Venta.Agregar() 
            {
                AutoCliente = f.AutoCliente,
                AutoCobrador = f.AutoCobrador ,
                AutoUsuario = f.AutoUsuario ,
                AutoVendedor = f.AutoVendedor ,
                AutoTransporte = f.AutoTransporte ,
                ClienteCiRif = f.ClienteCiRif ,
                ClienteCodigo = f.ClienteCodigo ,
                ClienteDenominacionFiscal = f.ClienteDenominacionFiscal ,
                ClienteDirFiscal = f.ClienteDirFiscal ,
                ClienteNombre = f.ClienteNombre ,
                ClienteTarifa = f.ClienteTarifa ,
                ClienteTelefono = f.ClienteTelefono ,
                CobradorCodigo = f.CobradorCodigo ,
                CobradorNombre = f.CobradorNombre ,
                CodigoSucursal = f.CodigoSucursal ,
                Estacion = f.Estacion ,
                FactorCambio = f.FactorCambio ,
                MontoRecibido = f.MontoRecibido ,
                Renglones = f.Renglones ,
                UsuarioCodigo = f.UsuarioCodigo ,
                UsuarioNombre = f.UsuarioNombre ,
                VendedorCodigo = f.VendedorCodigo ,
                VendedorNombre = f.VendedorNombre ,
                TransporteCodigo = f.TransporteCodigo ,
                TransporteNombre = f.TransporteNombre ,
                CondicionPago =  (DtoLibVenta.Venta.Enumerados.enumCondicionPago)f.CondicionPago,
                DiasCredito = f.DiasCredito ,
                Notas = f.Notas ,
                SerialFiscal = f.SerialFiscal,
                CambioDar= f.CambioDar,
                CondicionPagoDescripcion=f.CondicionPagoDescripcion,
                DocumentoCodigo = f.DocumentoCodigo ,
                DocumentoSituacion = f.DocumentoSituacion ,
                DocumentoTipo = f.DocumentoTipo ,
                DocumentoNombre = f.DocumentoNombre ,
                DocumentoSigno=f.DocumentoSigno,
                MesRelacion = f.MesRelacion ,
                AnoRelacion = f.AnoRelacion ,
            };

            var e=ficha.AgregarEncabezado;
            var encabezado = new DtoLibVenta.Venta.AgregarEncabezado()
            {
                AutoRemision = e.AutoRemision,
                DepachadoPor = e.DepachadoPor,
                DireccionDespacho = e.DireccionDespacho,
                DocumentoRemision = e.DocumentoRemision,
                FechaPedido = e.FechaPedido,
                OrdenCompra = e.OrdenCompra,
                Pedido = e.Pedido,
                Serie = e.Serie,
                TipoRemision = e.TipoRemision,
            };
            fichaDTO.AgregarEncabezado = encabezado;

            var t = ficha.AgregarTotales;
            var totales = new DtoLibVenta.Venta.AgregarTotal()
            {
                VentaNeta =  t.VentaNeta,
                CostoVenta = t.CostoVenta,
                Utilidad = t.Utilidad,
                UtilidadPorc = t.UtilidadPorc,
                SubTotalNeto = t.SubTotalNeto,
                DescuentoMonto_1 = t.DescuentoMonto_1,
                DescuentoMonto_2 = t.DescuentoMonto_2,
                DescuentoPorct_1 = t.DescuentoPorct_1, 
                DescuentoPorct_2 = t.DescuentoPorct_2,
                CargoMonto = t.CargoMonto,
                CargoPorct = t.CargoPorct,
                SubTotal = t.SubTotal,
                SubTotalImpuesto = t.SubTotalImpuesto,
                MontoTotal = t.MontoTotal,
                MontoBase = t.MontoBase,
                MontoImpuesto = t.MontoImpuesto,
                MontoExento = t.MontoExento,
                MontoBase1 = t.MontoBase1,
                MontoBase2 = t.MontoBase2,
                MontoBase3 = t.MontoBase3,
                MontoImp1 = t.MontoImp1,
                MontoImp2 = t.MontoImp2,
                MontoImp3 = t.MontoImp3,
                Tasa1 = t.Tasa1,
                Tasa2 = t.Tasa2,
                Tasa3 = t.Tasa3,
                MontoDivisa = t.MontoDivisa,
                SaldoPendiente = t.SaldoPendiente ,
            };
            fichaDTO.AgregarTotales = totales;

            var cx = ficha.AgregarCxc;
            var cxc = new DtoLibVenta.Venta.AgregarCxc()
            {
                AutoCliente=cx.AutoCliente ,
                AutoVendedor=cx.AutoVendedor ,
                ClienteCiRif=cx.ClienteCiRif ,
                ClienteCodigo=cx.ClienteCodigo,
                ClienteNombre=cx.ClienteNombre,
                DocumentoVentaSerie=cx.DocumentoVentaSerie,
                DocumentoVentaTipo=cx.DocumentoVentaTipo,
                IsCancelado=cx.IsCancelado ,
                MontoAcumulado=cx.MontoAcumulado,
                MontoImporteNeto=cx.MontoImporteNeto ,
                MontoImporteTotal=cx.MontoImporteTotal,
                MontoResta=cx.MontoResta,
                Notas=cx.Notas,
                Signo=cx.Signo,
            };
            fichaDTO.AgregarCxc = cxc;

            if (ficha.AgregarCuerpo != null && ficha.AgregarCuerpo.Count > 0)
            {
                var lc = ficha.AgregarCuerpo.Select(c =>
                {
                    return new DtoLibVenta.Venta.AgregarCuerpo()
                    {
                        AutoDepartamento=c.AutoDepartamento,
                        AutoGrupo=c.AutoGrupo ,
                        AutoProducto=c.AutoProducto,
                        AutoSubGrupo=c.AutoSubGrupo,
                        AutoTasaImpuesto=c.AutoTasaImpuesto,
                        AutoCliente=c.AutoCliente,
                        AutoDeposito=c.AutoDeposito,
                        AutoVendedor=c.AutoVendedor,
                        Cantidad=c.Cantidad,
                        CantidadUnd=c.CantidadUnd,
                        Categoria=c.Categoria,
                        CodigoPrd=c.CodigoPrd,
                        CostoPromedioCompra=c.CostoCompraPromedio ,
                        CostoPromedioUnd=c.CostoPromedioUnd,
                        CostoUnd=c.CostoUnd,
                        CostoVenta=c.CostoVenta,
                        Decimales=c.Decimales ,
                        DepositoCodigo=c.DepositoCodigo ,
                        DepositoDescripcion=c.DepositoDescripcion,
                        DescuentoMonto_1=c.DescuentoMonto_1 ,
                        DescuentoMonto_2=c.DescuentoMonto_2,
                        DescuentoMonto_3=c.DescuentoMonto_3,
                        DescuentoPorc_1=c.DescuentoPorc_1,
                        DescuentoPorc_2=c.DescuentoPorc_2,
                        DescuentoPorc_3=c.DescuentoPorc_3,
                        DiasGarantia=c.DiasGarantia,
                        Empaque =c.Empaque ,
                        EmpaqueContenido=c.EmpaqueContenido ,
                        IsGarantia=c.IsGarantia ,
                        IsSerial=c.IsSerial ,
                        MontoDescuento=c.MontoDescuento ,
                        MontoImpuesto=c.MontoImpuesto ,
                        MontoTotal=c.MontoTotal ,
                        NombrePrd=c.NombrePrd,
                        Notas=c.Notas ,
                        PrecioFinal = c.PrecioFinal,
                        PrecioItem= c.PrecioItem,
                        PrecioNeto= c.PrecioNeto,
                        PrecioUnd= c.PrecioUnd,
                        Signo=c.Signo,
                        TarifaPrecio=c.TarifaPrecio ,
                        TasaIva=c.TasaIva,
                        Tipo=c.Tipo,
                        TotalItem=c.TotalItem,
                        TotalNeto=c.TotalNeto,
                        UtilidadMonto=c.UtilidadMonto ,
                        UtilidadPorc=c.UtilidadPorc,
                        VendedorCodigo=c.VendedorCodigo,
                    };
                }).ToList();
                fichaDTO.AgregarCuerpo = lc;
            }

            if (ficha.AgregarMovKardex != null && ficha.AgregarMovKardex.Count > 0)
            {
                var lmk = ficha.AgregarMovKardex.Select(mk =>
                {
                    return new DtoLibVenta.Venta.AgregarKardex()
                    {
                        AutoConcepto=mk.AutoConcepto,
                        AutoDeposito=mk.AutoDeposito,
                        AutoProducto=mk.AutoProducto,
                        Cantidad=mk.Cantidad,
                        CantidadUnd=mk.CantidadUnd,
                        Codigo=mk.Codigo,
                        CostoPromedioUnd=mk.CostoUndPromedio,
                        Entidad=mk.Entidad,
                        Modulo=mk.Modulo,
                        Notas=mk.Notas,
                        PrecioUnd=mk.PrecioUnd,
                        Siglas=mk.Siglas,
                        Signo=mk.Signo,
                        TotalCostoVenta=mk.TotalCostoVenta,
                    };
                }).ToList();
                fichaDTO.AgregarKardex = lmk;
            }

            if (ficha.AgregarActProductoDeposito != null && ficha.AgregarActProductoDeposito.Count > 0) 
            {
                var lmd = ficha.AgregarActProductoDeposito.Select(md =>
                {
                    return new DtoLibVenta.Venta.AgregarActProductoDeposito()
                    {
                        AutoDeposito = md.AutoDeposito,
                        AutoProducto = md.AutoProducto,
                        TotalUnd = md.TotalUnd,
                    };
                }).ToList();
                fichaDTO.AgregarActProductoDeposito = lmd;
            }

            var r01 = MyData.VentaAgregar(fichaDTO);
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