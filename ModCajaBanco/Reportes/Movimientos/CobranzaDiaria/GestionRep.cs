using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Movimientos.CobranzaDiaria
{
    
    public class GestionRep
    {

        private List<OOB.LibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Ficha> data;
        private string filtros;


        public GestionRep(List<OOB.LibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Ficha> list, string filt)
        {
            this.data = list;
            this.filtros = filt;
        }

        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Movimientos\CobranzaDiaria.rdlc";
            var ds = new dsMovimiento();
            foreach (var it in data)
            {
                DataRow r = ds.Tables["CobranzaDiaria"].NewRow();
                r["codSuc"] = it.codSuc;
                r["codEquipo"] = it.codEstacion;
                r["reciboNro"] = it.reciboNro;
                r["fechaHora"] = it.fecha.ToShortDateString()+", "+ it.hora;
                r["importe"] = it.importe;
                r["cliente"] = it.ciRif+Environment.NewLine+it.cliente;
                r["montoRecibido"] = it.montoRecibido;
                r["medioPago"] = it.medioPagoDesc;
                r["tipoDocumento"] = it.tipoDocumento;
                r["documentoNro"] = it.documentoNro;
                r["tipoOperacion"] = it.operacion;
                r["lote"] = it.loteNro;
                r["ref"] = it.refNro;
                ds.Tables["CobranzaDiaria"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("FILTRO", filtros));
            Rds.Add(new ReportDataSource("CobranzaDiaria", ds.Tables["CobranzaDiaria"]));

            var frp = new Reporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}