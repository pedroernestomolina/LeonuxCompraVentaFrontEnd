using DataProvSistema.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Data
{

    public partial class DataProv: IData
    {

        public OOB.ResultadoLista<OOB.LibSistema.SucursalGrupo.Ficha> SucursalGrupo_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.SucursalGrupo.Ficha>();

            var r01 = MyData.SucursalGrupo_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibSistema.SucursalGrupo.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.SucursalGrupo.Ficha()
                        {
                            auto = s.auto,
                            nombre = s.nombre,
                            precioId = s.precioId,
                            precioDescripcion = s.precioDescripcion,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.SucursalGrupo.Ficha> SucursalGrupo_GetFicha(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.SucursalGrupo.Ficha>();

            var r01 = MyData.SucursalGrupo_GetFicha (auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.SucursalGrupo.Ficha()
            {
                auto = s.auto,
                nombre = s.nombre,
                precioId = s.precioId,
                precioDescripcion = s.precioDescripcion,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoAuto SucursalGrupo_Agregar(OOB.LibSistema.SucursalGrupo.Agregar ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibSistema.GrupoSucursal.Agregar()
            {
                nombre = ficha.nombre,
                precioId = ficha.precioId,
            };
            var r01 = MyData.SucursalGrupo_Agregar (fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            rt.Auto = r01.Auto;

            return rt;
        }

        public OOB.Resultado SucursalGrupo_Editar(OOB.LibSistema.SucursalGrupo.Editar ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.GrupoSucursal.Editar()
            {
                auto = ficha.auto,
                precioId = ficha.precioId,
                nombre = ficha.nombre,
            };
            var r01 = MyData.SucursalGrupo_Editar (fichaDTO);
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