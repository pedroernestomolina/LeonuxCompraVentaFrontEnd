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

        public OOB.ResultadoLista<OOB.LibVenta.PosOffline.Reporte.Pago.Detalle.Ficha> Reporte_Pago_Detalle(OOB.LibVenta.PosOffline.Reporte.Pago.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibVenta.PosOffline.Reporte.Pago.Detalle.Ficha>();

            var filtroDTO = new DtoLibPosOffLine.Reporte.Pago.Filtro();
            filtroDTO.IdOperador = filtro.IdOperador;

            var r01 = MyData.Reporte_Pago_Detalle(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibVenta.PosOffline.Reporte.Pago.Detalle.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var listPag = s.pagos.Select(p =>
                        {
                            var pag = new OOB.LibVenta.PosOffline.Reporte.Pago.Detalle.Pago()
                            {
                                codigo = p.codigo,
                                descripcion = p.descripcion,
                                importe = p.importe,
                                lote = p.lote,
                                montoRecibido = p.montoRecibido,
                                referencia = p.referencia,
                                tasa = p.tasa,
                                tipoMedioCobro = (OOB.LibVenta.PosOffline.Reporte.Pago.Enumerados.enumTipoMedioCobro) p.tipoMedioCobro,
                            };
                            return pag;
                        }).ToList();

                        var nr = new OOB.LibVenta.PosOffline.Reporte.Pago.Detalle.Ficha()
                        {
                            id=s.id,
                            aplica = s.aplica,
                            ciRif = s.ciRif,
                            dirFiscal = s.dirFiscal,
                            documento = s.documento,
                            estatus = (OOB.LibVenta.PosOffline.Reporte.Pago.Enumerados.enumEstatus) s.estatus,
                            fecha = s.fecha,
                            hora = s.hora,
                            monto = s.monto,
                            nombreRazaonSocial = s.nombreRazaonSocial,
                            signo = s.signo,
                            telefono = s.telefono,
                            tipoDoc = (OOB.LibVenta.PosOffline.Reporte.Pago.Enumerados.enumTipoDocumento) s.tipoDoc,
                            cambioDar= s.cambioDar,
                        };
                        nr.pagos = listPag;
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibVenta.PosOffline.Reporte.NCredito.Ficha> Reporte_NCredito(OOB.LibVenta.PosOffline.Reporte.NCredito.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibVenta.PosOffline.Reporte.NCredito.Ficha>();

            var filtroDTO = new DtoLibPosOffLine.Reporte.NCredito.Filtro();
            filtroDTO.IdOperador = filtro.IdOperador;

            var r01 = MyData.Reporte_NCredito (filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibVenta.PosOffline.Reporte.NCredito.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibVenta.PosOffline.Reporte.NCredito.Ficha ()
                        {
                            id = s.id,
                            aplica = s.aplica,
                            ciRif = s.ciRif,
                            dirFiscal = s.dirFiscal,
                            documento = s.documento,
                            estatus = (OOB.LibVenta.PosOffline.Reporte.NCredito.Enumerados.enumEstatus)s.estatus,
                            fecha = s.fecha,
                            hora = s.hora,
                            monto = s.monto,
                            nombreRazaonSocial = s.nombreRazaonSocial,
                            signo = s.signo,
                            telefono = s.telefono,
                            tipoDoc = (OOB.LibVenta.PosOffline.Reporte.NCredito.Enumerados.enumTipoDocumento)s.tipoDoc,
                        };
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Reporte.Pago.Resumen.Ficha> Reporte_Pago_Resumen(OOB.LibVenta.PosOffline.Reporte.Pago.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Reporte.Pago.Resumen.Ficha>();

            var filtroDTO = new DtoLibPosOffLine.Reporte.Pago.Filtro();
            filtroDTO.IdOperador = filtro.IdOperador;

            var r01 = MyData.Reporte_Pago_Resumen(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibVenta.PosOffline.Reporte.Pago.Resumen.Detalle>();
            if (r01.Entidad != null)
            {
                if (r01.Entidad.detalle != null)
                {
                    if (r01.Entidad.detalle.Count > 0)
                    {
                        list = r01.Entidad.detalle.Select(s =>
                        {
                            var pag = new OOB.LibVenta.PosOffline.Reporte.Pago.Resumen.Detalle()
                            {
                                codigo = s.codigo,
                                descripcion = s.descripcion,
                                importe = s.importe,
                                lote = s.lote,
                                montoRecibido = s.montoRecibido,
                                referencia = s.referencia,
                                tasa = s.tasa,
                                tipoMedioCobro = (OOB.LibVenta.PosOffline.Reporte.Pago.Enumerados.enumTipoMedioCobro)s.tipoMedioCobro,
                            };
                            return pag;
                        }).ToList();
                    }
                }
            }
            var reg = new OOB.LibVenta.PosOffline.Reporte.Pago.Resumen.Ficha()
            {
                MontoNCredito = r01.Entidad.montoNCredito,
                MontoCambioDar = r01.Entidad.montoCambioDar,
                Detalle = list,
            };
            rt.Entidad = reg;

            return rt;
        }

    }

}