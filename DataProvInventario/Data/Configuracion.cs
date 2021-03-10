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

        public OOB.ResultadoEntidad<int> Configuracion_CostoEdadProducto()
        {
            var rt = new OOB.ResultadoEntidad<int>();

            var r01 = MyData.Configuracion_CostoEdadProducto ();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }


        public OOB.Resultado Configuracion_SetCostoEdadProducto(OOB.LibInventario.Configuracion.CostoEdad.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Configuracion.CostoEdad.Editar.Ficha()
            {
                Edad = ficha.Edad,
            };
            var r01 = MyData.Configuracion_SetCostoEdadProducto(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Configuracion_SetRedondeoPrecioVenta(OOB.LibInventario.Configuracion.RedondeoPrecio.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Configuracion.RedondeoPrecio.Editar.Ficha()
            {
                Redondeo = ficha.Redondeo,
            };
            var r01 = MyData.Configuracion_SetRedondeoPrecioVenta(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Configuracion_SetPreferenciaRegistroPrecio(OOB.LibInventario.Configuracion.PreferenciaPrecio.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Configuracion.PreferenciaPrecio.Editar.Ficha()
            {
                Preferencia = ficha.Preferencia,
            };
            var r01 = MyData.Configuracion_SetPreferenciaRegistroPrecio(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Configuracion_SetMetodoCalculoUtilidad(OOB.LibInventario.Configuracion.MetodoCalculoUtilidad.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Configuracion.MetodoCalculoUtilidad.Editar.Ficha()
            {
                Metodo = ficha.Metodo,
            };
            var r01 = MyData.Configuracion_SetMetodoCalculoUtilidad(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Configuracion_SetBusquedaPredeterminada(OOB.LibInventario.Configuracion.BusquedaPredeterminada.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibInventario.Configuracion.BusquedaPredeterminada.Editar.Ficha()
            {
                Busqueda = ficha.Busqueda,
            };
            var r01 = MyData.Configuracion_SetBusquedaPredeterminada(fichaDTO);
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