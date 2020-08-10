using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{
    
    public interface IReporte
    {

        OOB.ResultadoLista<OOB.LibVenta.PosOffline.Reporte.Pago.Detalle.Ficha> Reporte_Pago_Detalle(OOB.LibVenta.PosOffline.Reporte.Pago.Filtro filtro);
        OOB.ResultadoLista<OOB.LibVenta.PosOffline.Reporte.NCredito.Ficha> Reporte_NCredito(OOB.LibVenta.PosOffline.Reporte.NCredito.Filtro filtro);
        OOB.ResultadoLista<OOB.LibVenta.PosOffline.Reporte.Pago.Resumen.Ficha> Reporte_Pago_Resumen(OOB.LibVenta.PosOffline.Reporte.Pago.Filtro filtro);

    }

}