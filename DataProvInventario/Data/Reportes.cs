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
                autoDeposito=filtro.autoDeposito,
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
                            codigo= s.codigo,
                            decimales = s.decimales,
                            esPesado = s.esPesado,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroExistencia.Ficha> Reportes_MaestroExistencia(OOB.LibInventario.Reportes.MaestroExistencia.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroExistencia.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.MaestroExistencia.Filtro()
            {
                autoDepartamento = filtro.autoDepartamento,
                autoDeposito = filtro.autoDeposito,
            };
            var r01 = MyData.Reportes_MaestroExistencia(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Reportes.MaestroExistencia.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var exFisica = 0.0m;
                        if (s.exFisica.HasValue)
                            exFisica = s.exFisica.Value;
                        return new OOB.LibInventario.Reportes.MaestroExistencia.Ficha()
                        {
                            autoDep = s.autoDep,
                            autoPrd = s.autoPrd,
                            codigoDep = s.codigoDep,
                            codigoPrd = s.codigoPrd,
                            decimales = s.decimales,
                            exFisica = exFisica,
                            nombreDep = s.nombreDep,
                            nombrePrd = s.nombrePrd,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroPrecio.Ficha> Reportes_MaestroPrecio(OOB.LibInventario.Reportes.MaestroPrecio.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroPrecio.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.MaestroPrecio.Filtro()
            {
                autoGrupo = filtro.autoGrupo,
                autoMarca = filtro.autoMarca,
                autoTasa = filtro.autoTasa,
                admDivisa = (DtoLibInventario.Reportes.enumerados.EnumAdministradorPorDivisa) filtro.admDivisa,
                autoDepartamento = filtro.autoDepartamento,
                categoria = (DtoLibInventario.Reportes.enumerados.EnumCategoria) filtro.categoria,
                origen = (DtoLibInventario.Reportes.enumerados.EnumOrigen) filtro.origen,
                precio = (DtoLibInventario.Reportes.enumerados.EnumPrecio) filtro.precio,
            };
            var r01 = MyData.Reportes_MaestroPrecio(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Reportes.MaestroPrecio.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.MaestroPrecio.Ficha()
                        {
                            codigoPrd = s.codigoPrd,
                            fechaUltCambioPrd = s.fechaUltCambioPrd,
                            isAdmDivisaPrd = (OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa) s.isAdmDivisaPrd,
                            modeloPrd = s.modeloPrd,
                            nombrePrd = s.nombrePrd,
                            departamento=s.departamento,
                            precioDivisaFull_1 = s.precioDivisaFull_1,
                            precioDivisaFull_2 = s.precioDivisaFull_2,
                            precioDivisaFull_3 = s.precioDivisaFull_3,
                            precioDivisaFull_4 = s.precioDivisaFull_4,
                            precioDivisaFull_5 = s.precioDivisaFull_5,
                            precioNeto_1 = s.precioNeto_1,
                            precioNeto_2 = s.precioNeto_2,
                            precioNeto_3 = s.precioNeto_3,
                            precioNeto_4 = s.precioNeto_4,
                            precioNeto_5 = s.precioNeto_5,
                            referenciaPrd = s.referenciaPrd,
                            tasaIvaPrd = s.tasaIvaPrd,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibInventario.Reportes.Kardex.Ficha> Reportes_Kardex(OOB.LibInventario.Reportes.Kardex.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibInventario.Reportes.Kardex.Ficha>();

            var filtroDto = new DtoLibInventario.Reportes.Kardex.Filtro()
            {
                autoDeposito = filtro.autoDeposito,
                autoProducto = filtro.autoProducto,
                desde = filtro.desde,
                hasta = filtro.hasta,
            };
            var r01 = MyData.Reportes_Kardex(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibInventario.Reportes.Kardex.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibInventario.Reportes.Kardex.Ficha()
                        {
                            codigoPrd = s.codigoPrd,
                            modeloPrd = s.modeloPrd,
                            nombrePrd = s.nombrePrd,
                            referenciaPrd = s.referenciaPrd,
                            cantidadUnd = s.cantidadUnd,
                            concepto = s.concepto,
                            decimalesPrd = s.decimalesPrd,
                            deposito = s.deposito,
                            documentoNro = s.documentoNro,
                            entidadMov = s.entidadMov,
                            existenciaInicial = s.existenciaInicial,
                            fechaMov = s.fechaMov,
                            horaMov = s.horaMov,
                            moduloMov = s.moduloMov,
                            siglasMov = s.siglasMov,
                            signoMov = s.signoMov,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

    }

}