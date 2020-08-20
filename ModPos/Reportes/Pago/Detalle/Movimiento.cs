using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Reportes.Pago.Detalle
{

    public class Movimiento
    {


        private List<OOB.LibVenta.PosOffline.Reporte.Pago.Detalle.Ficha> _lista;


        public Movimiento(List<OOB.LibVenta.PosOffline.Reporte.Pago.Detalle.Ficha> list)
        {
            _lista = list;
        }


        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\PagoDetalle.rdlc";
            var ds = new DS();
            var xid = 0;
            var montoTotal = 0.0m;
            var cambioDarTotal = 0.0m;
            var ncreditoTotal = 0.0m;

            foreach (var rg in _lista.OrderBy(o=>o.id).ToList()) 
            {
                xid += 1;
                if (rg.estatus == OOB.LibVenta.PosOffline.Reporte.Pago.Enumerados.enumEstatus.Activo && 
                    rg.tipoDoc== OOB.LibVenta.PosOffline.Reporte.Pago.Enumerados.enumTipoDocumento.Factura) 
                {
                    montoTotal += rg.monto;
                    cambioDarTotal += rg.cambioDar;
                }
                if (rg.estatus == OOB.LibVenta.PosOffline.Reporte.Pago.Enumerados.enumEstatus.Activo && 
                    rg.tipoDoc== OOB.LibVenta.PosOffline.Reporte.Pago.Enumerados.enumTipoDocumento.NotaCredito) 
                {
                    ncreditoTotal += rg.monto;
                }

                foreach (var pg in rg.pagos.ToList())
                {
                    DataRow p = ds.Tables["Pago"].NewRow();
                    p["id1"] = xid.ToString().Trim().PadLeft(4,'0');
                    p["documento"] = rg.documento;
                    p["fechaHora"] = rg.hora+Environment.NewLine+ rg.fecha.ToShortDateString();
                    p["nombreRazonSocial"] = rg.ciRif+Environment.NewLine+rg.nombreRazaonSocial;
                    p["dirFiscal"] = rg.dirFiscal;
                    p["telefono"] = rg.telefono;
                    p["cambioDar"] = rg.cambioDar;

                    var _monto = rg.monto;
                    var _montoRecibido= pg.montoRecibido;
                    var _medioPago = pg.codigo + "/ " + pg.descripcion;
                    var _importe = pg.montoRecibido*pg.tasa;
                    var _tasa = "";

                    if (pg.tasa > 1) 
                    {
                        _tasa = pg.tasa.ToString("n2");
                    }

                    if (rg.estatus == OOB.LibVenta.PosOffline.Reporte.Pago.Enumerados.enumEstatus.Activo)
                    {
                        p["estatus"] = "Activo";
                        p["monto"] = rg.monto;
                        p["montoRecibido"] = pg.montoRecibido;
                        p["codigoMedioPago"] = pg.codigo + "/ " + pg.descripcion;
                        p["tasa"] = _tasa;
                        p["importe"] = _importe;
                    }
                    else
                    {
                        p["estatus"] = "ANULADO";
                        p["monto"] = 0.0m;
                        p["montoRecibido"] = 0.0m;
                        p["codigoMedioPago"] = "";
                        p["tasa"] = "";
                        p["importe"] = 0.0m;
                    }
                    ds.Tables["Pago"].Rows.Add(p);
                    if (rg.estatus == OOB.LibVenta.PosOffline.Reporte.Pago.Enumerados.enumEstatus.Anulado) 
                    {
                        break;
                    }
                }
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("montoTotal", montoTotal.ToString("n2")));
            pmt.Add(new ReportParameter("cambioDarTotal", cambioDarTotal.ToString("n2")));
            pmt.Add(new ReportParameter("ncreditoTotal", ncreditoTotal.ToString("n2")));
            Rds.Add(new ReportDataSource("Pago", ds.Tables["Pago"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}