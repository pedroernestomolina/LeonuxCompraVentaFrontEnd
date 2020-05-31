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

            var tipoDocumento = 1;
            if (ficha.TipoDocumento != OOB.LibVenta.PosOffline.VentaDocumento.Enumerados.EnumTipoDocumento.Factura){tipoDocumento = 2;}
            var agregarDTO = new DtoLibPosOffLine.VentaDocumento.Agregar()
            {
                Aplica = ficha.Aplica,
                AutoUsuario = ficha.AutoUsuario,
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
                TipoDocumento = tipoDocumento,
                UsuarioCodigo = ficha.UsuarioCodigo,
                UsuarioDescripcion = ficha.UsuarioDescripcion,
                CodigoSucursal = ficha.CodioSucursal,
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
                IsCredito=ficha.IsCredito,
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
                    CostoPromedioUnd=s.CostoCompraUnd,
                    CostoVenta=s.CostoVenta,
                    Decimales=s.Decimales,
                    DiasEmpaqueGarantia=s.DiasEmpaqueGarantia,
                    EmpaqueCodigo=s.EmpaqueCodigo,
                    EmpaqueContenido=s.EmpaqueContenido,
                    EmpaqueDescripcion=s.EmpaqueDescripcion,
                    MontoDscto_1=s.MontoDscto_1,
                    MontoDscto_2=s.MontoDscto_2,
                    MontoDscto_3=s.MontoDscto_3,
                    MontoIva=s.MontoIva,
                    MontoUtilidad=s.MontoUtilidad,
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
                            CiRif = s.CiRif,
                            Control = s.Control,
                            Documento = s.Documento,
                            FechaEmision = s.FechaEmision,
                            HoraEmision = s.HoraEmision,
                            Id = s.Id,
                            IsActivo = s.IsActivo,
                            Monto = s.Monto,
                            NombreRazonSocial = s.NombreRazonSocial,
                            Signo = s.Signo,
                            TipoDocumento = (OOB.LibVenta.PosOffline.VentaDocumento.Enumerados.EnumTipoDocumento) s.TipoDocumento,
                            Renglones=s.Renglones,
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

    }

}