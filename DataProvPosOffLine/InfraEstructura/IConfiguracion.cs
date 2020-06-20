using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{

    public interface IConfiguracion
    {

        OOB.ResultadoEntidad<decimal> Configuracion_FactorCambio();
        OOB.ResultadoEntidad<string> Configuracion_TarifaPrecio();
        OOB.ResultadoEntidad<bool > Configuracion_EtiquetarPrecioPorTipoNegocio();

        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.ModoPos.Ficha> Configuracion_ModoPos();
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Repesaje.Ficha> Configuracion_Repesaje();
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Serie.Ficha> Configuracion_Serie();
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Sucursal.Ficha> Configuracion_Sucursal();
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Vendedor.Ficha> Configuracion_Vendedor();
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Deposito.Ficha> Configuracion_Deposito();
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Cobrador.Ficha> Configuracion_Cobrador();
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Transporte.Ficha> Configuracion_Transporte();
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.MedioCobro.Ficha> Configuracion_MedioCobro();
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.MovConceptoInv.Ficha> Configuracion_MovConceptoInv();

        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.ClaveAcceso.Ficha> Configuracion_ClavePos();
        OOB.ResultadoEntidad<bool> Configuracion_ActivarBusquedaPorDescripcion();
        OOB.Resultado Configuracion_GuardarCambio(OOB.LibVenta.PosOffline.Configuracion.Guardar.Ficha ficha);
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Configuracion.Actual.Ficha> Configuracion_ActualCargar();

    }

}