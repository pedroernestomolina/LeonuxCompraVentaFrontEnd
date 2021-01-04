using DataProvCajaBanco.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCajaBanco.Data
{

    public partial class DataProv: IData
    {

        public OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ArqueoCajaPos.Ficha> CajaBanco_ArqueoCajaPos(OOB.LibCajaBanco.Reporte.Movimiento.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ArqueoCajaPos.Ficha>();

            var filtroDTO = new DtoLibCajaBanco.Reporte.Movimiento.Filtro();
            filtroDTO.autoSucursal = filtro.autoSucursal;
            filtroDTO.desdeFecha = filtro.desdeFecha;
            filtroDTO.hastaFecha = filtro.hastaFecha;

            var r01 = MyData.CajaBanco_ArqueoCajaPos(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCajaBanco.Reporte .Movimiento .ArqueoCajaPos .Ficha >();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibCajaBanco.Reporte.Movimiento.ArqueoCajaPos.Ficha ()
                        {
                            autoCierre = s.autoCierre,
                            autoUsuario = s.autoUsuario,
                            codigoUsuario = s.codigoUsuario,
                            equipo = s.equipo,
                            fecha = s.fecha,
                            hora = s.hora,
                            nombreUsuario = s.nombreUsuario,
                            sucursal = s.sucursal,
                            diferencia = s.diferencia,
                            efectivo = s.efectivo,
                            divisa = s.divisa,
                            cntDivisa = s.cntdivisa,
                            tarjeta = s.tarjeta,
                            otros = s.otros,
                            firma = s.firma,
                            devolucion = s.devolucion,
                            subtotal = s.subtotal,
                            total = s.total,
                            mefectivo = s.mefectivo,
                            mdivisa = s.mdivisa,
                            mtarjeta = s.mtarjeta,
                            motros = s.motros,
                            msubtotal = s.msubtotal,
                            mtotal = s.mtotal,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenInventario.Ficha> Reporte_ResumenInventario(OOB.LibCajaBanco.Reporte.Movimiento.ResumenInventario.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenInventario.Ficha>();

            var filtroDTO = new DtoLibCajaBanco.Reporte.Movimiento.Inventario.Filtro()
            {
                autoDeposito = filtro.autoDeposito,
                desdeFecha = filtro.desdeFecha,
                hastaFecha = filtro.hastaFecha,
            };
            var r01 = MyData.Reporte_InventarioResumen(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenInventario.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var entrada = 0.0m;
                        var salida = 0.0m;
                        var entradaOt = 0.0m;
                        var tEntrada = 0.0m;
                        var tSalida= 0.0m;

                        if (s.entradas.HasValue)
                            entrada = s.entradas.Value;
                        if (s.salidas.HasValue)
                            salida = s.salidas.Value;
                        if (s.entradasOt.HasValue)
                            entradaOt = s.entradasOt.Value;
                        if (s.tEntradas.HasValue)
                            tEntrada = s.tEntradas.Value;
                        if (s.tSalidas.HasValue)
                            tSalida = s.tSalidas.Value;

                        return new OOB.LibCajaBanco.Reporte.Movimiento.ResumenInventario.Ficha()
                        {
                            codigoPrd = s.codigoPrd,
                            nombrePrd = s.nombrePrd,
                            entradas = entrada,
                            salidas = salida,
                            decimales=s.decimales,
                            entradasOt=entradaOt,
                            tEntradas=tEntrada,
                            tSalidas=tSalida,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVenta.Ficha> Reporte_ResumenVenta(OOB.LibCajaBanco.Reporte.Movimiento.ResumenVenta.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVenta.Ficha>();

            var filtroDTO = new DtoLibCajaBanco.Reporte.Movimiento.ResumenVenta.Filtro()
            {
                codigoSucursal= filtro.codigoSucursal,
                desdeFecha = filtro.desdeFecha,
                hastaFecha = filtro.hastaFecha,
            };
            var r01 = MyData.Reporte_VentaResumen (filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVenta.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVenta.Ficha()
                        {
                            clienteNombre = s.clienteNombre,
                            clienteRif = s.clienteRif,
                            condicionPago = s.condicionPago,
                            descuento = s.descuento,
                            documento = s.documento,
                            documentoNombre = s.documentoNombre,
                            estacion = s.estacion,
                            fecha = s.fecha,
                            hora = s.hora,
                            renglones = s.renglones,
                            serie = s.serie,
                            signo = s.signo,
                            tipo = s.tipo,
                            total = s.total,
                            usuarioCodigo = s.usuarioCodigo,
                            usuarioNombre = s.usuarioNombre,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Habladores.Ficha> Reporte_Habladores(OOB.LibCajaBanco.Reporte.Habladores.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Habladores.Ficha>();

            var filtroDTO = new DtoLibCajaBanco.Reporte.Habladores.Filtro()
            {
            };
            var r01 = MyData.Reporte_Habladores (filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCajaBanco.Reporte.Habladores.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibCajaBanco.Reporte.Habladores.Ficha()
                        {
                            autoPrd = s.autoPrd,
                            codigoPrd = s.codigoPrd,
                            nombrePrd = s.nombrePrd,
                            pdivisaFull_1 = s.pdivisaFull_1,
                            pdivisaFull_2 = s.pdivisaFull_1,
                            pdivisaFull_3 = s.pdivisaFull_3,
                            pdivisaFull_4 = s.pdivisaFull_4,
                            pdivisaFull_5 = s.pdivisaFull_5,
                            pneto_1 = s.pneto_1,
                            pneto_2 = s.pneto_2,
                            pneto_3 = s.pneto_3,
                            pneto_4 = s.pneto_4,
                            pneto_5 = s.pneto_5,
                            tasaIva = s.tasaIva,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDetalle.Ficha> Reporte_ResumenVentaDetalle(OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDetalle.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDetalle.Ficha>();

            var filtroDTO = new DtoLibCajaBanco.Reporte.Movimiento.FacturaDetalle.Filtro()
            {
                codigoSucursal = filtro.codigoSucursal,
                desdeFecha = filtro.desdeFecha,
                hastaFecha = filtro.hastaFecha,
            };
            var r01 = MyData.Reporte_VentaDetalle(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDetalle.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDetalle.Ficha()
                        {
                            auto = s.auto,
                            cantidadUnd = s.cantidadUnd,
                            documento = s.documento,
                            fecha = s.fecha,
                            hora= s.hora,
                            decimales="2",
                            nombreProducto = s.nombreProducto,
                            precioUnd = s.precioUnd,
                            renglones = s.renglones,
                            total = s.total,
                            totalRenglon = s.totalRenglon,
                            usuarioCodigo = s.usuarioCodigo,
                            usuarioNombre = s.usuarioNombre,
                            signo=s.signo,
                            documentoNombre=s.documentoNombre,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorProducto.Ficha> Reporte_ResumenVentaPorProducto(OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorProducto.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorProducto.Ficha>();

            var filtroDTO = new DtoLibCajaBanco.Reporte.Movimiento.VentasPorProducto.Filtro()
            {
                codigoSucursal = filtro.codigoSucursal,
                desdeFecha = filtro.desdeFecha,
                hastaFecha = filtro.hastaFecha,
            };
            var r01 = MyData.Reporte_VentaPorProducto (filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorProducto.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorProducto.Ficha()
                        {
                            cantidad = s.cantidad,
                            codigoPrd = s.codigoPrd,
                            nombreDocumento = s.nombreDocumento,
                            nombrePrd = s.nombrePrd,
                            signo = s.signo,
                            totalMonto = s.totalMonto,
                            totalMontoDivisa = s.totalMontoDivisa,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaSucursal.Ficha> Reporte_ResumenVentaSucursal(OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaSucursal.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaSucursal.Ficha>();

            var filtroDTO = new DtoLibCajaBanco.Reporte.Movimiento.ResumenVentaSucursal.Filtro()
            {
                codigoSucursal = filtro.codigoSucursal,
                desdeFecha = filtro.desdeFecha,
                hastaFecha = filtro.hastaFecha,
            };
            var r01 = MyData.Reporte_ResumenVentaSucursal(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaSucursal.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaSucursal.Ficha()
                        {
                            cntMov = s.cntMov,
                            codigoSuc = s.codigoSuc,
                            montoDivisa = s.montoDivisa,
                            montoTotal = s.montoTotal,
                            nombreSuc = s.nombreSuc,
                            signo = s.signo,
                            tipoDoc = s.tipoDoc,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaProductoSucursal.Ficha> Reporte_ResumenVentaProductoSucursal(OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaProductoSucursal.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaProductoSucursal.Ficha>();

            var filtroDTO = new DtoLibCajaBanco.Reporte.Movimiento.VentasPorProductoSucursal.Filtro()
            {
                codigoSucursal = filtro.codigoSucursal,
                desdeFecha = filtro.desdeFecha,
                hastaFecha = filtro.hastaFecha,
            };
            var r01 = MyData.Reporte_VentaPorProductoSucursal(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaProductoSucursal.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaProductoSucursal.Ficha()
                        {
                            codigoSuc = s.codigoSuc,
                            nombreSuc = s.nombreSuc,
                            cantidad = s.cantidad,
                            codigoPrd = s.codigoPrd,
                            nombreDocumento = s.nombreDocumento,
                            nombrePrd = s.nombrePrd,
                            signo = s.signo,
                            totalMonto = s.totalMonto,
                            totalMontoDivisa = s.totalMontoDivisa,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Ficha> Reporte_CobranzaDiaria(OOB.LibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Ficha>();

            var filtroDTO = new DtoLibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Filtro()
            {
                codSucursal= filtro.codSucursal,
                desdeFecha = filtro.desdeFecha,
                hastaFecha = filtro.hastaFecha,
            };
            var r01 = MyData.Reporte_CobranzaDiara(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Ficha()
                        {
                            auto = s.auto,
                            cambio = s.cambio,
                            ciRif = s.ciRif,
                            cliente = s.cliente,
                            codEstacion = s.codEstacion,
                            codSuc = s.codSuc,
                            documentoNro = s.documentoNro,
                            fecha = s.fecha,
                            hora = s.hora,
                            importe = s.importe,
                            loteNro = s.loteNro,
                            medioPagoCod = s.medioPagoCod,
                            medioPagoDesc = s.medioPagoDesc,
                            montoRecibido = s.montoRecibido,
                            operacion = s.operacion,
                            reciboNro = s.reciboNro,
                            refNro = s.refNro,
                            tipoDocumento = s.tipoDocumento,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

    }

}