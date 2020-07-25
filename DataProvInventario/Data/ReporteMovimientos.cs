using DataProvInventario.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.Data
{
    
    public partial class DataProv: IData
    {

        public OOB.ResultadoLista<OOB.LibInventario.Reportes.Movimientos.ArqueoCajaPos.Ficha> CajaBanco_ArqueoVentaPos(OOB.LibInventario.Reportes.Movimientos.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.Movimientos.ArqueoCajaPos.Ficha>();

            var filtroDTO = new DtoLibInventario.Reportes.Movimientos.Filtro();
            filtroDTO.autoSucursal = filtro.autoSucursal;
            filtroDTO.desdeFecha = filtro.desdeFecha;
            filtroDTO.hastaFecha = filtro.hastaFecha;

            var r01 = MyData.CajaBanco_ArqueoVentaPos(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Reportes.Movimientos.ArqueoCajaPos.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.Movimientos.ArqueoCajaPos.Ficha()
                        {
                            autoCierre=s.autoCierre,
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
                            cntDivisa=s.cntdivisa,
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

    }

}