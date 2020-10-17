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

        public OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroProducto.Ficha> Reportes_MaestroProducto(OOB.LibInventario.Reportes.MaestroProducto.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroProducto.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.MaestroProducto.Filtro()
            {
                autoDepartamento = filtro.autoDepartamento,
                autoTasa = filtro.autoTasa,
                admDivisa = (DtoLibInventario.Reportes.enumerados.EnumAdministradorPorDivisa)filtro.admDivisa,
                categoria = (DtoLibInventario.Reportes.enumerados.EnumCategoria)filtro.categoria,
                estatus = (DtoLibInventario.Reportes.enumerados.EnumEstatus)filtro.estatus,
                origen = (DtoLibInventario.Reportes.enumerados.EnumOrigen)filtro.origen,
            };
            var r01 = MyData.Reportes_MaestroProducto(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Reportes.MaestroProducto.Ficha>() ;
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.MaestroProducto.Ficha()
                        {
                            admDivisa = (OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa) s.admDivisa,
                            categoria = (OOB.LibInventario.Reportes.enumerados.EnumCategoria) s.categoria,
                            codigoPrd = s.codigoPrd,
                            contenidoPrd = s.contenidoPrd,
                            departamento = s.departamento,
                            empaque = s.empaque,
                            estatus = (OOB.LibInventario.Reportes.enumerados.EnumEstatus) s.estatus,
                            modeloPrd = s.modeloPrd,
                            nombrePrd = s.nombrePrd,
                            origen = (OOB.LibInventario.Reportes.enumerados.EnumOrigen) s.origen,
                            referenciaPrd = s.referenciaPrd,
                            tasaIva = s.tasaIva,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroInventario.Ficha> Reportes_MaestroInventario(OOB.LibInventario.Reportes.MaestroInventario.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroInventario.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.MaestroInventario.Filtro()
            {
                admDivisa = (DtoLibInventario.Reportes.enumerados.EnumAdministradorPorDivisa)filtro.admDivisa,
                autoDepartamento = filtro.autoDepartamento,
                estatus = (DtoLibInventario.Reportes.enumerados.EnumEstatus)filtro.estatus,
            };
            var r01 = MyData.Reportes_MaestroInventario(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Reportes.MaestroInventario.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.MaestroInventario.Ficha()
                        {
                            admDivisa = (OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa)s.admDivisa,
                            codigoPrd = s.codigoPrd,
                            departamento = s.departamento,
                            estatus = (OOB.LibInventario.Reportes.enumerados.EnumEstatus)s.estatus,
                            modeloPrd = s.modeloPrd,
                            nombrePrd = s.nombrePrd,
                            referenciaPrd = s.referenciaPrd,
                            costoDivisaUnd = s.costoDivisaUnd,
                            costoUnd = s.costoUnd,
                            decimales = s.decimales,
                            existencia = s.existencia,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibInventario.Reportes.Top20.Ficha> Reportes_Top20(OOB.LibInventario.Reportes.Top20.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.Top20.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.Top20.Filtro()
            {
                Desde = filtro.Desde,
                Hasta = filtro.Hasta,
                Modulo = (DtoLibInventario.Reportes.enumerados.EnumModulo) filtro.Modulo,
                autoDeposito=filtro.autoDeposito,
            };
            var r01 = MyData.Reportes_Top20(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Reportes.Top20.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.Top20.Ficha()
                        {
                            cntUnd = s.cntUnd,
                            cntDoc = s.cntDoc,
                            nombre = s.nombre,
                            decimales = s.decimales,
                            esPesado = s.esPesado,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

    }

}
