using DataProvPosOffLine.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.Data
{

    public partial class DataProv: IData
    {

        public OOB.ResultadoId VentaDocumento_Agregar(OOB.LibVenta.PosOffline.VentaDocumento.Agregar ficha)
        {
            var rt = new OOB.ResultadoId();

            var agregarDTO = new DtoLibPosOffLine.VentaDocumento.Agregar()
            {
                IdJornada = ficha.IdJornada,
                IdOperador = ficha.IdOperador,
                Aplica = ficha.Aplica,
                AutoUsuario = ficha.AutoUsuario,
                ClienteId = ficha.ClienteId,
                ClienteCiRif = ficha.ClienteCiRif,
                ClienteDirFiscal = ficha.ClienteDirFiscal,
                ClienteNombreRazonSocial = ficha.ClienteNombreRazonSocial,
                ClienteTelefono = ficha.ClienteTelefono,
                Control = ficha.Control,
                Documento = ficha.Documento,
                Estacion = ficha.Estacion,
                EstatusDocumento = ficha.IsDocumentoActivo ? 1 : 0,
                FactorCambio = ficha.FactorCambio,
                MontoBase = ficha.MontoBase,
                MontoBase_1 = ficha.MontoBase_1,
                MontoBase_2 = ficha.MontoBase_2,
                MontoBase_3 = ficha.MontoBase_3,
                MontoCargo_1 = ficha.MontoCargo_1,
                MontoCostoVenta = ficha.MontoCostoVenta,
                MontoDescuento_1 = ficha.MontoDescuento_1,
                MontoDescuento_2 = ficha.MontoDescuento_2,
                MontoDivisa = ficha.MontoDivisa,
                MontoExento = ficha.MontoExento,
                MontoImpuesto = ficha.MontoImpuesto,
                MontoIva_1 = ficha.MontoIva_1,
                MontoIva_2 = ficha.MontoIva_2,
                MontoIva_3 = ficha.MontoIva_3,
                MontoSubTotal = ficha.MontoSubTotal,
                MontoSubTotalImpuesto = ficha.MontoSubTotalImpuesto,
                MontoSubTotalNeto = ficha.MontoSubTotalNeto,
                MontoTotal = ficha.MontoTotal,
                MontoUtilidad = ficha.MontoUtilidad,
                MontoVentaNeta = ficha.MontoVentaNeta,
                PorcCargo_1 = ficha.PorcCargo_1,
                PorcDescuento_1 = ficha.PorcDescuento_1,
                PorcDescuento_2 = ficha.PorcDescuento_2,
                PorcUtilidad = ficha.PorcUtilidad,
                Renglones = ficha.Renglones,
                Serie = ficha.Serie,
                SignoDocumento = ficha.SignoDocumento,
                TasaIva_1 = ficha.TasaIva_1,
                TasaIva_2 = ficha.TasaIva_2,
                TasaIva_3 = ficha.TasaIva_3,
                TipoDocumento = (int)ficha.TipoDocumento,
                UsuarioCodigo = ficha.UsuarioCodigo,
                UsuarioDescripcion = ficha.UsuarioDescripcion,
                CodigoSucursal = ficha.CodioSucursal,
                Prefijo=ficha.PrefijoSucursal,
                AutoDeposito = ficha.AutoDeposito,
                CodigoDeposito = ficha.CodigoDeposito,
                DescripcionDeposito = ficha.DescripcionDeposito,
                AutoVendedor = ficha.AutoVendedor,
                CodigoVendedor = ficha.CodigoVendedor,
                NombreVendedor = ficha.NombreVendedor,
                AutoCobrador = ficha.AutoCobrador,
                CodigoCobrador = ficha.CodigoCobrador,
                NombreCobrador = ficha.NombreCobrador,
                AutoTransporte = ficha.AutoTransporte,
                CodigoTransporte = ficha.CodigoTransporte,
                NombreTransporte = ficha.NombreTransporte,
                MontoRecibido = ficha.MontoRecibido,
                CambioDar = ficha.CambioDar,
                IsCredito = ficha.IsCredito,
                HoraEmision = DateTime.Now.ToShortTimeString(),
                Tarifa = ficha.Tarifa,
                SaldoPendiente = ficha.SaldoPendiente,
                AutoConceptoMov = ficha.AutoConceptoMov,
                CodigoConceptoMov = ficha.CodigoConceptoMov,
                NombreConceptoMov = ficha.NombreConceptoMov,
            };

            var agregarItemDto = ficha.Items.Select(s =>
            {
                var t = new DtoLibPosOffLine.VentaDocumento.AgregarItem()
                {
                    AutoDepartamento=s.AutoDepartamento,
                    AutoGrupo=s.AutoGrupo,
                    AutoProducto=s.AutoProducto,
                    AutoSubGrupo=s.AutoSubGrupo,
                    AutoTasa=s.AutoTasa,
                    Cantidad=s.Cantidad,
                    CantidadUnd=s.CantidadUnd,
                    Categoria=s.Categoria,
                    CodigoPrd=s.CodigoPrd,
                    CostoCompraUnd=s.CostoCompraUnd,
                    CostoPromedioUnd=s.CostoPromedioUnd,
                    CostoVenta=s.CostoVenta,
                    Decimales=s.Decimales,
                    DiasEmpaqueGarantia=s.DiasEmpaqueGarantia,
                    EmpaqueCodigo=s.EmpaqueCodigo,
                    EmpaqueContenido=s.EmpaqueContenido,
                    EmpaqueDescripcion=s.EmpaqueDescripcion,
                    MontoDscto_1=s.MontoDscto_1,
                    MontoDscto_2=s.MontoDscto_2,
                    MontoDscto_3=s.MontoDscto_3,
                    MontoIva = s.MontoIva,
                    MontoUtilidad = s.MontoUtilidad,
                    NombrePrd=s.NombrePrd,
                    Notas=s.Notas,
                    PorcDscto_1=s.PorcDscto_1,
                    PorcDscto_2=s.PorcDscto_2,
                    PorcDscto_3=s.PorcDscto_3,
                    PorctUtilidad=s.PorctUtilidad,
                    PrecioFinal=s.PrecioFinal,
                    PrecioItem=s.PrecioItem,
                    PrecioNeto=s.PrecioNeto,
                    PrecioSugerido=s.PrecioSugerido,
                    PrecioUnd=s.PrecioUnd,
                    TarifaPrecio=s.TarifaPrecio,
                    TasaIva=s.TasaIva,
                    Total=s.Total,
                    TotalNeto=s.TotalNeto,
                    TotalDescuento=s.TotalDescuento,
                    EsPesado=s.EsPesado?1:0,
                    TipoIva=s.TipoIva,
                    CostoCompra=s.CostoCompra,
                    CostoPromedio=s.CostoPromedio,
                };

                return t;
            }).ToList();
            agregarDTO.Items = agregarItemDto;


            var agregarMetodsPago = ficha.MetodosPago.Select(m =>
            {
                var nr = new DtoLibPosOffLine.VentaDocumento.AgregarMetodoPago()
                {
                    autoMedioPago = m.autoMedioPago,
                    codigoMedioPago = m.codigoMedioPago,
                    descripcionMedioPago = m.descripcionMedioPago,
                    Importe = m.Importe,
                    MontoRecibido = m.MontoRecibido,
                    Tasa = m.Tasa,
                    Lote = m.Lote,
                    Referencia = m.Referencia,
                };
                return nr;
            }).ToList();
            agregarDTO.MetodosPago = agregarMetodsPago;

            var agregarItemsEliminarDto = ficha.ItemsEliminar.Select(s =>
            {
                var nr = new DtoLibPosOffLine.VentaDocumento.AgregarItemLimpiar()
                {
                    Id=s.IdEliminar,
                };
                return nr;
            }).ToList();
            agregarDTO.ItemsLimpiar = agregarItemsEliminarDto;


            var r01 = MyData.VentaDocumento_Agregar(agregarDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Id = r01.Id;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibVenta.PosOffline.VentaDocumento.Ficha> VentaDocumento_Lista(OOB.LibVenta.PosOffline.VentaDocumento.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibVenta.PosOffline.VentaDocumento.Ficha>();

            var filtroDTO = new DtoLibPosOffLine.VentaDocumento.Lista.Filtro();
            filtroDTO.IdJornada = filtro.IdJornada;
            var r01 = MyData.VentaDocumento_Lista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibVenta.PosOffline.VentaDocumento.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibVenta.PosOffline.VentaDocumento.Ficha()
                        {
                            ClienteCiRif = s.CiRif,
                            Control = s.Control,
                            Documento = s.Documento,
                            Fecha = s.FechaEmision,
                            Hora = s.HoraEmision,
                            Id = s.Id,
                            IsActiva = s.IsActivo,
                            MontoTotal = s.Monto,
                            ClienteNombre = s.NombreRazonSocial,
                            Signo = s.Signo,
                            TipoDocumento = (OOB.LibVenta.PosOffline.VentaDocumento.Enumerados.EnumTipoDocumento) s.TipoDocumento,
                            Renglones=s.Renglones,
                            Serie=s.Serie,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.Resultado VentaDocumento_Anular(int idDocumento)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.VentaDocumento_Anular(idDocumento);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.VentaDocumento.Ficha> VentaDocumento_Cargar(int idDocumento)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.VentaDocumento.Ficha>();

            var r01 = MyData.VentaDocumento_Cargar(idDocumento);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var d=s.Detalles;
            var nr = new OOB.LibVenta.PosOffline.VentaDocumento.Ficha()
            {
                Control = s.Control,
                Documento = s.Documento,
                Fecha = s.Fecha,
                Hora = s.Hora,
                ClienteId = s.ClienteId,
                ClienteCiRif = s.CiRif,
                ClienteNombre = s.ClienteNombre,
                ClienteDirFiscal = s.ClienteDirFiscal,
                ClienteTelefono = s.ClienteTelefono,
                Renglones = s.Renglones,
                Signo = s.Signo,
                TipoDocumento = (OOB.LibVenta.PosOffline.VentaDocumento.Enumerados.EnumTipoDocumento)s.TipoDocumento,
                Base1 = s.Base1,
                Base2 = s.Base2,
                Base3 = s.Base3,
                Impuesto1 = s.Impuesto1,
                Impuesto2 = s.Impuesto2,
                Impuesto3 = s.Impuesto3,
                MontoBase = s.MontoBase,
                MontoExento = s.MontoExento,
                MontoImpuesto = s.MontoImpuesto,
                MontoTotal = s.MontoTotal,
                TasaIva1 = s.TasaIva1,
                TasaIva2 = s.TasaIva2,
                TasaIva3 = s.TasaIva3,
                AnoRelacion = s.AnoRelacion,
                Aplica = s.Aplica,
                CargoMonto_1 = s.CargoMonto_1,
                CargoPorc_1 = s.CargoPorc_1,
                CodigoSucursal = s.CodigoSucursal,
                DesctoMonto_1 = s.DesctoMonto_1,
                DesctoMonto_2 = s.DesctoMonto_2,
                DesctoPorc_1 = s.DesctoPorc_1,
                DesctoPorc_2 = s.DesctoPorc_2,
                IsActiva = s.IsActiva,
                MesRelacion = s.MesRelacion,
                Serie = s.Serie,
                Estacion = s.Estacion,
                FactorCambio = s.FactorCambio,
                MontoCostoVenta = s.MontoCostoVenta,
                MontoDivisa = s.MontoDivisa,
                MontoSubt = s.MontoSubt,
                MontoSubtImpuesto = s.MontoSubtImpuesto,
                MontoSubtNeto = s.MontoSubtNeto,
                MontoUtilidad = s.MontoUtilidad,
                MontoUtilidadPorc = s.MontoUtilidadPorc,
                MontoVentaNeta = s.MontoVentaNeta,
                CambioDar = s.CambioDar,
                CobradorAuto = s.CobradorAuto,
                CobradorCodigo = s.CobradorCodigo,
                CobradorNombre = s.CobradorNombre,
                DepositoAuto = s.DepositoAuto,
                DepositoCodigo = s.DepositoCodigo,
                DepositoNombre = s.DepositoNombre,
                IsCredito = s.IsCredito,
                MontoRecibido = s.MontoRecibido,
                TranporteAuto = s.TranporteAuto,
                TranporteCodigo = s.TranporteCodigo,
                TranporteNombre = s.TranporteNombre,
                UsuarioAuto = s.UsuarioAuto,
                UsuarioCodigo = s.UsuarioCodigo,
                UsuarioNombre = s.UsuarioNombre,
                VendedorAuto = s.VendedorAuto,
                VendedorCodigo = s.VendedorCodigo,
                VendedorNombre = s.VendedorNombre,
                Tarifa = s.Tarifa,
                SaldoPendiente = s.SaldoPendiente,
                AutoConceptoMov = s.AutoConceptoMov,
                CodigoConceptoMov = s.CodigoConceptoMov,
                NombreConceptoMov = s.NombreConceptoMov,
            };
            var det = d.Select(t =>
            {
                var dt = new OOB.LibVenta.PosOffline.VentaDocumento.FichaDetalle()
                {
                    AutoDepartamento = t.AutoDepartamento,
                    AutoGrupo = t.AutoGrupo,
                    AutoProducto = t.AutoProducto,
                    AutoSubGrupo = t.AutoSubGrupo,
                    AutoTasa = t.AutoTasa,
                    Cantidad = t.Cantidad,
                    CantidadUnd = t.CantidadUnd,
                    Categoria = t.Categoria,
                    CodigoProducto = t.CodigoProducto,
                    CostoCompraUnd = t.CostoCompraUnd,
                    CostoPromedioUnd = t.CostoPromedioUnd,
                    CostoVenta = t.CostoVenta,
                    Decimales = t.Decimales,
                    DiaEmpaqueGarantia = t.DiaEmpaqueGarantia,
                    EmpaqueContenido = t.EmpaqueContenido,
                    EmpaqueDescripcion = t.EmpaqueDescripcion,
                    Id = t.Id,
                    MontoDscto_1 = t.MontoDscto_1,
                    MontoDscto_2 = t.MontoDscto_2,
                    MontoDscto_3 = t.MontoDscto_3,
                    MontoIva = t.MontoIva,
                    NombreProducto = t.NombreProducto,
                    Notas = t.Notas,
                    PorcDscto_1 = t.PorcDscto_1,
                    PorcDscto_2 = t.PorcDscto_2,
                    PorcDscto_3 = t.PorcDscto_3,
                    PrecioFinal = t.PrecioFinal,
                    PrecioItem = t.PrecioItem,
                    PrecioNeto = t.PrecioNeto,
                    PrecioSugerido = t.PrecioSugerido,
                    PrecioUnd = t.PrecioUnd,
                    Tarifa = t.Tarifa,
                    TasaIva = t.TasaIva,
                    Total = t.Total,
                    TotalDescuento = t.TotalDescuento,
                    TotalNeto = t.TotalNeto,
                    UtilidadMonto = t.UtilidadMonto,
                    UtilidadPorct = t.UtilidadPorct,
                    EmpaqueCodigo = t.EmpaqueCodigo,
                    EsPesado = t.EsPesado,
                    TipoIva = t.TipoIva,
                    CostoCompra=t.CostoCompra,
                    CostoPromedio=t.CostoPromedio,
                };
                return dt;
            }).ToList();

            nr.MediosPago = new List<OOB.LibVenta.PosOffline.VentaDocumento.FichaPago>();
            if (s.MediosPago != null) 
            {
                if (s.MediosPago.Count > 0) 
                {
                    var lmp = s.MediosPago.Select(mp =>
                    {
                        var rmp = new OOB.LibVenta.PosOffline.VentaDocumento.FichaPago()
                        {
                            Codigo = mp.Codigo,
                            Descripcion = mp.Descripcion,
                            Importe = mp.Importe,
                            Lote = mp.Lote,
                            MontoRecibido = mp.Importe,
                            Referencia = mp.Referencia,
                            Tasa = mp.Tasa,
                        };
                        return rmp;
                    }).ToList();
                    nr.MediosPago = lmp;
                }
            }
            nr.Detalles = det;
            rt.Entidad = nr;

            return rt;
        }

    }

}