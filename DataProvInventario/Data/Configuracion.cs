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

        public OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda> Configuracion_PreferenciaBusqueda()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda>();

            var r01 = MyData.Configuracion_PreferenciaBusqueda();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda) s;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad> Configuracion_MetodoCalculoUtilidad()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad>();

            var r01 = MyData.Configuracion_MetodoCalculoUtilidad();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad)s;

            return rt;
        }

        public OOB.ResultadoEntidad<decimal> Configuracion_TasaCambioActual()
        {
            var rt = new OOB.ResultadoEntidad<decimal>();

            var r01 = MyData.Configuracion_TasaCambioActual();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = s;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta> Configuracion_ForzarRedondeoPrecioVenta()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta>();

            var r01 = MyData.Configuracion_ForzarRedondeoPrecioVenta();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibInventario.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta)s;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio> Configuracion_PreferenciaRegistroPrecio()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio>();

            var r01 = MyData.Configuracion_PreferenciaRegistroPrecio();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio)s;

            return rt;
        }

    }

}