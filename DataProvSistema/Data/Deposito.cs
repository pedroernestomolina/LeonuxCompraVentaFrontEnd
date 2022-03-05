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

        public OOB.ResultadoLista<OOB.LibSistema.Deposito.Ficha> Deposito_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.Deposito.Ficha>();

            var r01 = MyData.Deposito_GetLista ();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibSistema.Deposito.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.Deposito.Ficha()
                        {
                            auto = s.auto,
                            codigo = s.codigo,
                            nombre = s.nombre,
                            estatus=s.estatusDep,
                            autoSucursal = "",
                            codigoSucursal = s.codigoSucursal,
                            sucursal = s.sucursal,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibSistema.Deposito.Ficha> Deposito_GetFicha(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Deposito.Ficha>();

            var r01 = MyData.Deposito_GetFicha(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Deposito.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
                autoSucursal = s.autoSucursal,
                codigoSucursal = s.codigoSucursal,
                sucursal = s.sucursal,
            };
            rt.Entidad= nr;

            return rt;
        }
        public OOB.ResultadoAuto Deposito_Agregar(OOB.LibSistema.Deposito.Agregar ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibSistema.Deposito.Agregar()
            {
                autoSucursal = ficha.autoSucursal,
                codigo = ficha.codigo,
                codigoSucursal = ficha.codigoSucursal,
                nombre = ficha.nombre,
            };
            var r01 = MyData.Deposito_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            rt.Auto = r01.Auto;

            return rt;
        }
        public OOB.Resultado Deposito_Editar(OOB.LibSistema.Deposito.Editar ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Deposito.Editar()
            {
                auto = ficha.auto,
                autoSucursal = ficha.autoSucursal,
                codigo = ficha.codigo,
                codigoSucursal = ficha.codigoSucursal,
                nombre = ficha.nombre,
            };
            var r01 = MyData.Deposito_Editar (fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.ResultadoEntidad<int> Deposito_GeneraCodigoAutomatico()
        {
            var rt = new OOB.ResultadoEntidad<int> ();

            var r01 = MyData.Deposito_GeneraCodigoAutomatico();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }
        public OOB.Resultado Deposito_Activar(string idDep)
        {
            var rt = new OOB.Resultado();
            
            var r01 = MyData.Deposito_Activar(idDep);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }
        public OOB.Resultado Deposito_Inactivar(string idDep)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Deposito_Inactivar(idDep);
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