﻿using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{

    public partial class DataProv: IData
    {

        public OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor> Configuracion_PreferenciaBusquedaProveedor()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor>();

            var r01 = MyData.Configuracion_PreferenciaBusquedaProveedor();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor)s;

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

        public OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProducto> Configuracion_PreferenciaBusquedaProducto()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProducto>();

            var r01 = MyData.Configuracion_PreferenciaBusquedaProducto();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProducto)s;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad> Configuracion_MetodoCalculoUtilidad()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad>();

            var r01 = MyData.Configuracion_MetodoCalculoUtilidad();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad)s;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta> Configuracion_ForzarRedondeoPrecioVenta()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta>();

            var r01 = MyData.Configuracion_ForzarRedondeoPrecioVenta();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibCompra.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta)s;

            return rt;
        }

    }

}