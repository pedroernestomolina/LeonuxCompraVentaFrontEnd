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
                        var exFisica = 0.0m;
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

    }

}