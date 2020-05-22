using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Data
{

    public partial class DataProvider: DataProviderVenta.Infra.IData
    {

        public OOB.ResultadoEntidad<OOB.LibVenta.Permiso.Ficha> Permiso_Venta_DarDescuento_Item(string autoGrupoUsuario)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibVenta.Permiso.Ficha>();

            var r01 = MyData.PermisoVenta_DarDescuento_Item(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = new OOB.LibVenta.Permiso.Ficha();
            result.Entidad.IsHabilitado = r01.Entidad.IsHabilitado;
            result.Entidad.NivelSeguridad = (OOB.LibVenta.Permiso.Enumerados.EnumNivelSeguridad) r01.Entidad.NivelSeguridad;
            return result;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.Permiso.Ficha> Permiso_Venta_Eliminar_Item(string autoGrupoUsuario)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibVenta.Permiso.Ficha>();

            var r01 = MyData.PermisoVenta_Eliminar_Item(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = new OOB.LibVenta.Permiso.Ficha();
            result.Entidad.IsHabilitado = r01.Entidad.IsHabilitado;
            result.Entidad.NivelSeguridad = (OOB.LibVenta.Permiso.Enumerados.EnumNivelSeguridad)r01.Entidad.NivelSeguridad;
            return result;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.Permiso.Ficha> Permiso_Venta_PrecioLibre_Item(string autoGrupoUsuario)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibVenta.Permiso.Ficha>();

            var r01 = MyData.PermisoVenta_PrecioLibre_Item(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = new OOB.LibVenta.Permiso.Ficha();
            result.Entidad.IsHabilitado = r01.Entidad.IsHabilitado;
            result.Entidad.NivelSeguridad = (OOB.LibVenta.Permiso.Enumerados.EnumNivelSeguridad)r01.Entidad.NivelSeguridad;
            return result;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.Permiso.Ficha> Permiso_Venta_DescuentoGlobal(string autoGrupoUsuario)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibVenta.Permiso.Ficha>();

            var r01 = MyData.PermisoVenta_DescuentoGlobal(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = new OOB.LibVenta.Permiso.Ficha();
            result.Entidad.IsHabilitado = r01.Entidad.IsHabilitado;
            result.Entidad.NivelSeguridad = (OOB.LibVenta.Permiso.Enumerados.EnumNivelSeguridad)r01.Entidad.NivelSeguridad;
            return result;
        }

    }

}