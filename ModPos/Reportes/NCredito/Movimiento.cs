using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Reportes.NCredito
{

    public class Movimiento
    {

        private List<OOB.LibVenta.PosOffline.Reporte.NCredito.Ficha> _lista;


        public Movimiento(List<OOB.LibVenta.PosOffline.Reporte.NCredito.Ficha > list)
        {
            _lista = list;
        }


        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\NcDetalle.rdlc";
            var ds = new DS();

            foreach (var rg in _lista)
            {
                DataRow p = ds.Tables["NCredito"].NewRow();
                p["documento"] = rg.documento;
                p["fechaHora"] = rg.hora + Environment.NewLine + rg.fecha.ToShortDateString();
                p["nombreRazonSocial"] = rg.ciRif + Environment.NewLine + rg.nombreRazaonSocial;
                p["aplica"] = rg.aplica;

                var _monto = rg.monto;
                if (rg.estatus == OOB.LibVenta.PosOffline.Reporte.NCredito.Enumerados.enumEstatus.Activo)
                {
                    p["estatus"] = "Activo";
                    p["monto"] = rg.monto;
                }
                else
                {
                    p["estatus"] = "ANULADO";
                    p["monto"] = 0.0m;
                }
                ds.Tables["NCredito"].Rows.Add(p);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            Rds.Add(new ReportDataSource("NCredito", ds.Tables["NCredito"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}