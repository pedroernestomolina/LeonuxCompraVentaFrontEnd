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

        public OOB.ResultadoLista<OOB.LibSistema.Sucursal.Ficha> Sucursal_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.Sucursal.Ficha>();

            var r01 = MyData.Sucursal_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibSistema.Sucursal.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.Sucursal.Ficha()
                        {
                            auto = s.auto,
                            nombre = s.nombre,
                            codigo = s.codigo,
                            precioId = "",
                            autoDepositoPrincipal = "",
                            autoGrupoSucursal = "",
                            codigoDepositoPrincipal = "",
                            nombreDepositoPrincipal = s.deposito,
                            nombreGrupoSucursal = s.grupo,
                            estatusFactMayor = s.estatusFactMayor,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Sucursal.Ficha> Sucursal_GetFicha(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Sucursal.Ficha>();

            var r01 = MyData.Sucursal_GetFicha(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Sucursal.Ficha()
            {
                auto = s.auto,
                nombre = s.nombre,
                codigo = s.codigo,
                autoDepositoPrincipal = s.autoDepositoPrincipal,
                autoGrupoSucursal = s.autoGrupoSucursal,
                codigoDepositoPrincipal = s.codigoDepositoPrincipal,
                nombreDepositoPrincipal = s.nombreDepositoPrincipal,
                nombreGrupoSucursal = s.nombreGrupoSucursal,
                precioId = s.precioId,
                estatusFactMayor = s.estatusFacturarMayor,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoAuto Sucursal_Agregar(OOB.LibSistema.Sucursal.Agregar ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibSistema.Sucursal.Agregar()
            {
                autoGrupo = ficha.autoGrupo,
                nombre = ficha.nombre,
                codigo = ficha.codigo,
                estatusFactMayor = ficha.estatusFactMayor,
            };
            var r01 = MyData.Sucursal_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            rt.Auto = r01.Auto;

            return rt;
        }

        public OOB.Resultado Sucursal_Editar(OOB.LibSistema.Sucursal.Editar ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Sucursal.Editar()
            {
                auto = ficha.auto,
                autoGrupo = ficha.autoGrupo,
                nombre = ficha.nombre,
                codigo = ficha.codigo,
                estatusFactMayor = ficha.estatusFactMayor,
            };
            var r01 = MyData.Sucursal_Editar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Sucursal_AsignarDepositoPrincipal(OOB.LibSistema.Sucursal.AsignarDepositoPrincipal ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Sucursal.AsignarDepositoPrincipal()
            {
                auto = ficha.auto,
                autoDepositoPrincipal=ficha.autoDepositoPrincipal,
            };
            var r01 = MyData.Sucursal_AsignarDepositoPrincipal(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Sucursal_QuitarDepositoPrincipal(string autoSuc)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Sucursal_QuitarDepositoPrincipal (autoSuc);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoEntidad<int> Sucursal_GeneraCodigoAutomatico()
        {
            var rt = new OOB.ResultadoEntidad<int>();

            var r01 = MyData.Sucursal_GeneraCodigoAutomatico();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }

    }

}