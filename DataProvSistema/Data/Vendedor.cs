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

        public OOB.ResultadoLista<OOB.LibSistema.Vendedor.Entidad.Ficha> Vendedor_GetLista(OOB.LibSistema.Vendedor.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.Vendedor.Entidad.Ficha>();

            var filtroDto = new DtoLibSistema.Vendedor.Lista.Filtro();
            var r01 = MyData.Vendedor_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibSistema.Vendedor.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.Vendedor.Entidad.Ficha()
                        {
                            id= s.id,
                            codigo = s.codigo,
                            nombre = s.nombre,
                            ciRif=s.ciRif,
                            estatus=s.estatus,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Vendedor.Entidad.Ficha> Vendedor_GetFicha_ById(string id)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Vendedor.Entidad.Ficha>();

            var r01 = MyData.Vendedor_GetFicha_ById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Vendedor.Entidad.Ficha()
            {
                advertencia = s.advertencia,
                ciRif = s.ciRif,
                codigo = s.codigo,
                contacto = s.contacto,
                direccion = s.direccion,
                email = s.email,
                estatus = s.estatus,
                fechaAlta = s.fechaAlta,
                fechaBaja = s.fechaBaja,
                id = s.id,
                memo = s.memo,
                nombre = s.nombre,
                telefono = s.telefono,
                webSite = s.webSite,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoAuto Vendedor_AgregarFicha(OOB.LibSistema.Vendedor.Agregar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibSistema.Vendedor.Agregar.Ficha()
            {
                advertencia = ficha.advertencia,
                ciRif = ficha.ciRif,
                codigo = ficha.codigo,
                contacto = ficha.contacto,
                direccion = ficha.direccion,
                email = ficha.email,
                memo = ficha.memo,
                nombre = ficha.nombre,
                telefono = ficha.telefono,
                webSite = ficha.webSite,
            };
            var r01 = MyData.Vendedor_AgregarFicha(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }

        public OOB.Resultado Vendedor_EditarFicha(OOB.LibSistema.Vendedor.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Vendedor.Editar.Ficha()
            {
                id = ficha.id,
                advertencia = ficha.advertencia,
                ciRif = ficha.ciRif,
                codigo = ficha.codigo,
                contacto = ficha.contacto,
                direccion = ficha.direccion,
                email = ficha.email,
                memo = ficha.memo,
                nombre = ficha.nombre,
                telefono = ficha.telefono,
                webSite = ficha.webSite,
            };
            var r01 = MyData.Vendedor_EditarFicha(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Vendedor_Activar(OOB.LibSistema.Vendedor.ActivarInactivar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Vendedor.ActivarInactivar.Ficha()
            {
                id=ficha.id
            };
            var r01 = MyData.Vendedor_Activar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Vendedor_Inactivar(OOB.LibSistema.Vendedor.ActivarInactivar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Vendedor.ActivarInactivar.Ficha()
            {
                id = ficha.id
            };
            var r01 = MyData.Vendedor_Inactivar(fichaDTO);
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