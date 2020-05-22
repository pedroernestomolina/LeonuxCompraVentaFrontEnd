using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Data
{

    public partial class DataProvider: DataProviderVenta.Infra.IData
    {

        public OOB.ResultadoEntidad<decimal> FactorCambioDivisa()
        {
            var result = new OOB.ResultadoEntidad<decimal>();

            var r01 = MyData.FactorCambioDivisa();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = r01.Entidad;
            return result;
        }

        public OOB.ResultadoEntidad<decimal> FactorCambioDivisaParaRecibir()
        {
            var result = new OOB.ResultadoEntidad<decimal>();

            var r01 = MyData.FactorCambioDivisaParaRecibir ();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = r01.Entidad;
            return result;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.Sistema.Enumerados.enumPreferenciaBusquedaProducto> PreferenciaBusquedaProducto()
        {
            var result = new OOB.ResultadoEntidad<OOB.LibVenta.Sistema.Enumerados.enumPreferenciaBusquedaProducto>();

            var r01 = MyData.PreferenciaBusquedaProducto();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = (OOB.LibVenta.Sistema.Enumerados.enumPreferenciaBusquedaProducto) r01.Entidad;
            return result;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.Sistema.Enumerados.enumPreferenciaBusquedaCliente> PreferenciaBusquedaCliente()
        {
            var result = new OOB.ResultadoEntidad<OOB.LibVenta.Sistema.Enumerados.enumPreferenciaBusquedaCliente >();

            var r01 = MyData.PreferenciaBusquedaCliente();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = (OOB.LibVenta.Sistema.Enumerados.enumPreferenciaBusquedaCliente)r01.Entidad;
            return result;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.Sistema.Enumerados.enumMetodoCalculoUtilidad> MetodoCalculoUtilidad()
        {
            var result = new OOB.ResultadoEntidad<OOB.LibVenta.Sistema.Enumerados.enumMetodoCalculoUtilidad>();

            var r01 = MyData.MetodoCalculoUtilidad();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = (OOB.LibVenta.Sistema.Enumerados.enumMetodoCalculoUtilidad)r01.Entidad;
            return result;
        }

        public OOB.ResultadoEntidad<bool> HabilitarRupturaPorExistencia()
        {
            var result = new OOB.ResultadoEntidad<bool>();

            var r01 = MyData.HabilitarRupturaPorExistencia();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = (bool) r01.Entidad;
            return result;
        }

        public OOB.ResultadoEntidad<bool> HabilitarAlertaPorExistenciaEnNegativa()
        {
            var result = new OOB.ResultadoEntidad<bool>();

            var r01 = MyData.HabilitarAlertaPorExistenciaEnNegativa();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = (bool)r01.Entidad;
            return result;
        }

        public OOB.ResultadoEntidad<string> Clave_NivelMinimo()
        {
            var result = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.Clave_NivelMinimo();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = (string)r01.Entidad;
            return result;
        }

        public OOB.ResultadoEntidad<string> Clave_NivelMedio()
        {
            var result = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.Clave_NivelMedio ();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = (string)r01.Entidad;
            return result;
        }

        public OOB.ResultadoEntidad<string> Clave_NivelMaximo()
        {
            var result = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.Clave_NivelMaximo();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = (string)r01.Entidad;
            return result;
        }

    }

}