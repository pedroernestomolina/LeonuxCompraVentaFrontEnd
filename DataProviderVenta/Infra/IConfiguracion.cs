using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Infra
{

    public interface IConfiguracion
    {

        OOB.ResultadoEntidad<string> Clave_NivelMinimo();
        OOB.ResultadoEntidad<string> Clave_NivelMedio();
        OOB.ResultadoEntidad<string> Clave_NivelMaximo();

        OOB.ResultadoEntidad<decimal> FactorCambioDivisa();
        OOB.ResultadoEntidad<decimal> FactorCambioDivisaParaRecibir();
        OOB.ResultadoEntidad<OOB.LibVenta.Sistema.Enumerados.enumPreferenciaBusquedaProducto> PreferenciaBusquedaProducto();
        OOB.ResultadoEntidad<OOB.LibVenta.Sistema.Enumerados.enumPreferenciaBusquedaCliente> PreferenciaBusquedaCliente();
        OOB.ResultadoEntidad<OOB.LibVenta.Sistema.Enumerados.enumMetodoCalculoUtilidad> MetodoCalculoUtilidad();
        OOB.ResultadoEntidad<bool> HabilitarRupturaPorExistencia();
        OOB.ResultadoEntidad<bool> HabilitarAlertaPorExistenciaEnNegativa(); 

    }

}