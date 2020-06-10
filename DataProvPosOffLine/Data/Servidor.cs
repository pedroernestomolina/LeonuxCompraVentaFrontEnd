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

        public OOB.Resultado Servidor_EnviarData()
        {
            var result = new OOB.Resultado();

            var fichaDTO = new DtoLibPosOffLine.Servidor.EnviarData.Ficha();
            fichaDTO.Ventas = new List<DtoLibPosOffLine.Servidor.EnviarData.Venta>();
            fichaDTO.Ventas.Add(new DtoLibPosOffLine.Servidor.EnviarData.Venta());
            var r01 = MyData.Servidor_EnviarData(fichaDTO);
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
                if (r01.Entidad.Jornadas != null) 
                {
                    if (r01.Entidad.Jornadas.Count > 0) 
                    {
                        var listJor = r01.Entidad.Jornadas.Select(s =>
                        {
                            var jor = new OOB.LibVenta.PosOffline.Servidor.PrepararData.Jornada()
                            {
                                Id = s.Id,
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
                                        TipoDocumento = (OOB.LibVenta.PosOffline.Servidor.PrepararData.Enumerados.EnumTipoDocumento) d.TipoDocumento,
                                        TranporteAuto = d.TranporteAuto,
                                        TranporteCodigo = d.TranporteCodigo,
                                        TranporteNombre = d.TranporteNombre,
                                        UsuarioAuto = d.UsuarioAuto,
                                        UsuarioCodigo = d.UsuarioCodigo,
                                        UsuarioNombre = d.UsuarioNombre,
                                        VendedorAuto = d.VendedorAuto,
                                        VendedorCodigo = d.VendedorCodigo,
                                        VendedorNombre = d.VendedorNombre,

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

    }

}