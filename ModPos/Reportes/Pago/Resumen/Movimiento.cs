using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Reportes.Pago.Resumen
{
    
    public class Movimiento
    {

        private decimal _montoNCredito;
        private decimal _montoCambioDar;
        private List<OOB.LibVenta.PosOffline.Reporte.Pago.Resumen.Detalle> _lista;


        public Movimiento(OOB.LibVenta.PosOffline.Reporte.Pago.Resumen.Ficha ficha)
        {
            _montoNCredito = ficha.MontoNCredito;
            _montoCambioDar = ficha.MontoCambioDar;
            _lista = ficha.Detalle;
        }


        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\PagoResumen.rdlc";
            var ds = new DS();

            var lista = _lista.
                GroupBy(g => new { g.codigo, g.lote, g.tasa }).
                Select(gr => new { key = gr.Key, cnt = gr.Count(), list = gr.ToList() }).
                ToList();

            var xd = 0;
            var timporte = 0.0m;
            foreach (var rg in lista.OrderBy(o => o.key.codigo).ToList())
            {
                xd += 1;
                timporte += rg.list.Sum(r => r.montoRecibido * r.tasa);
                var imp = rg.list.Sum(r => r.montoRecibido * r.tasa);
                var cmb = rg.list.Sum(r => r.importe);

                foreach (var dt in rg.list)
                {
                    var _tasa = "";
                    var _cntDivisa = "";
                    if (dt.tasa > 1)
                    {
                        _tasa = dt.tasa.ToString("n2");
                        _cntDivisa = rg.list.Sum(r => r.montoRecibido).ToString("n0");
                    }

                    DataRow p = ds.Tables["PagoResumen"].NewRow();
                    p["id"] = xd.ToString();
                    p["medio"] = dt.codigo + "/ " + dt.descripcion;
                    p["tasa"] = _tasa;
                    p["lote"] = dt.lote;
                    p["cntDivisa"] = _cntDivisa;
                    p["cntMov"] = rg.list.Count().ToString("n0");
                    p["importe"] = rg.list.Sum(r => r.montoRecibido * r.tasa);

                    ds.Tables["PagoResumen"].Rows.Add(p);
                }
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("tImporte", timporte.ToString("n2")));
            pmt.Add(new ReportParameter("tCambio", _montoCambioDar.ToString("n2")));
            pmt.Add(new ReportParameter("tNCredito", _montoNCredito.ToString("n2")));
            Rds.Add(new ReportDataSource("PagoResumen", ds.Tables["PagoResumen"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}
