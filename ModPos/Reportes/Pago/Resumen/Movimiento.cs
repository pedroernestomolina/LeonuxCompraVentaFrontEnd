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

        private List<OOB.LibVenta.PosOffline.Reporte.Pago.Resumen.Ficha> _lista;


        public Movimiento(List<OOB.LibVenta.PosOffline.Reporte.Pago.Resumen.Ficha > list)
        {
            _lista = list;
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
            foreach (var rg in lista.OrderBy(o=>o.key.codigo).ToList())
            {
                xd += 1;
                foreach (var dt in rg.list) 
                {
                    DataRow p = ds.Tables["Pago"].NewRow();
                    p["id1"] = xd.ToString();
                    p["tasa"] = dt.tasa;
                    p["lote"] = dt.lote;
                    p["montoRecibido"] = rg.list.Sum(r => r.montoRecibido * r.tasa);
                    p["codigoMedioPago"] = dt.codigo + "/ " + dt.descripcion;
                    p["importe"] = rg.list.Sum(r=>r.montoRecibido);
                    ds.Tables["Pago"].Rows.Add(p);
                }
            }

            //foreach (var rg in _lista)
            //{
            //    xd+=1;
            //    DataRow p = ds.Tables["Pago"].NewRow();
            //    p["id1"]=xd.ToString();
            //    p["montoRecibido"] = rg.montoRecibido;
            //    p["codigoMedioPago"] = rg.codigo + "/ " + rg.descripcion;
            //    p["tasa"] = rg.tasa;
            //    p["lote"] = rg.lote;
            //    ds.Tables["Pago"].Rows.Add(p);
            //}

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            Rds.Add(new ReportDataSource("Pago", ds.Tables["Pago"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}
