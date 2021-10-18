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

        public OOB.ResultadoEntidad<OOB.LibSistema.Negocio.Entidad.Ficha> Negocio_GetEntidad_ByAuto(string autoEmpresa)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Negocio.Entidad.Ficha>();

            var r01 = MyData.Negocio_GetEntidad_ByAuto(autoEmpresa);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Negocio.Entidad.Ficha()
            {
                auto = s.auto,
                ciudad = s.ciudad,
                codPostal = s.codPostal,
                codSucursal = s.codSucursal,
                contacto = s.contacto,
                direccion = s.direccion,
                email = s.email,
                estado = s.estado,
                fax = s.fax,
                nombre = s.nombre,
                pais = s.pais,
                rif = s.rif,
                sucursal = s.sucursal,
                telefono = s.telefono,
                webSite = s.webSite,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.Resultado Negocio_EditarFicha(OOB.LibSistema.Negocio.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Negocio.Editar.Ficha()
            {
                auto = ficha.auto,
                ciudad = ficha.ciudad,
                codPostal = ficha.codPostal,
                contacto = ficha.contacto,
                direccion = ficha.direccion,
                email = ficha.email,
                estado = ficha.estado,
                fax = ficha.fax,
                nombre = ficha.nombre,
                pais = ficha.pais,
                rif = ficha.rif,
                telefono = ficha.telefono,
                webSite = ficha.webSite,
            };
            var r01 = MyData.Negocio_EditarFicha(fichaDTO);
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