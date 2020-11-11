using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{

    public partial class DataProv: IData
    {

        public OOB.ResultadoLista<OOB.LibCompra.Proveedor.Data.Ficha> Proveedor_GetLista(OOB.LibCompra.Proveedor.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCompra.Proveedor.Data.Ficha>();

            var filtroDto = new DtoLibCompra.Proveedor.Lista.Filtro()
            {
                autoEstado = filtro.autoEstado,
                autoGrupo = filtro.autoGrupo,
                cadena = filtro.cadena,
                MetodoBusqueda = (DtoLibCompra.Proveedor.Enumerados.EnumMetodoBusqueda)filtro.MetodoBusqueda,
                estatus = (DtoLibCompra.Proveedor.Enumerados.EnumEstatus)filtro.estatus,
            };
            var r01 = MyData.Proveedor_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCompra.Proveedor.Data.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Proveedor.Data.Ficha();
                        var id = new OOB.LibCompra.Proveedor.Data.Identificacion()
                        {
                            auto = s.auto,
                            ciRif = s.ciRif,
                            codigo = s.codigo,
                            dirFiscal = s.dirFiscal,
                            estatus = (OOB.LibCompra.Proveedor.Enumerados.EnumEstatus)s.estatusPrv,
                            nombreContacto = s.nombreContacto,
                            nombreEstado = s.nombreEstado,
                            nombreGrupo = s.nombreGrupo,
                            nombreRazonSocial = s.nombreRazonSocial,
                            telefono = s.telefono,
                        };
                        nr.identidad = id;
                        return nr;
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Proveedor.Data.Ficha> Proveedor_GetFicha(string autoPrv)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Proveedor.Data.Ficha>();

            var r01 = MyData.Proveedor_GetFicha(autoPrv);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Proveedor.Data.Ficha();
            var id = new OOB.LibCompra.Proveedor.Data.Identificacion()
            {
                auto = s.autoId,
                autoEstado = s.autoEstado,
                autoGrupo = s.autoGrupo,
                ciRif = s.ciRif,
                codigo = s.codigo,
                dirFiscal = s.direccionFiscal,
                estatus = s.isActivo ? OOB.LibCompra.Proveedor.Enumerados.EnumEstatus.Activo : OOB.LibCompra.Proveedor.Enumerados.EnumEstatus.Inactivo,
                nombreContacto = s.nombreContacto,
                nombreEstado = s.nombreEstado,
                nombreGrupo = s.nombreGrupo,
                nombreRazonSocial = s.nombreRazonSocial,
                telefono = s.telefono,
            };
            nr.identidad = id;
            rt.Entidad = nr;

            return rt;
        }

    }

}