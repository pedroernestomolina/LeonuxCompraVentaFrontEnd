using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCajaBanco.Infra
{
    
    public interface IReporteMovimiento
    {

        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ArqueoCajaPos.Ficha > CajaBanco_ArqueoCajaPos(OOB.LibCajaBanco.Reporte.Movimiento.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenInventario.Ficha> Reporte_ResumenInventario(OOB.LibCajaBanco.Reporte.Movimiento.ResumenInventario.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVenta.Ficha> Reporte_ResumenVenta(OOB.LibCajaBanco.Reporte.Movimiento.ResumenVenta.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Habladores.Ficha> Reporte_Habladores(OOB.LibCajaBanco.Reporte.Habladores.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDetalle.Ficha> Reporte_ResumenVentaDetalle(OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDetalle.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorProducto.Ficha> Reporte_ResumenVentaPorProducto(OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorProducto.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaSucursal.Ficha> Reporte_ResumenVentaSucursal(OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaSucursal.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaProductoSucursal.Ficha> Reporte_ResumenVentaProductoSucursal(OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaProductoSucursal.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Ficha> Reporte_CobranzaDiaria(OOB.LibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Filtro filtro);

    }

}