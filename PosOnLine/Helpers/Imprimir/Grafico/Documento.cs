using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Helpers.Imprimir.Grafico
{

    public class Documento: IDocumento
    {

        private data _ds;


        public void ImprimirDoc()
        {
            Imprimir();
        }

        public void ImprimirCopiaDoc()
        {
            Imprimir();
        }

        private void Imprimir()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Helpers\Imprimir\Grafico\Documento.rdlc";
            var ds = new ds();

            //NEGOCIO
            DataRow N = ds.Tables["DatosNegocio"].NewRow();
            N["Nombre"] = _ds.negocio.Nombre;
            ds.Tables["DatosNegocio"].Rows.Add(N);

            //ENCABEZADO
            DataRow E = ds.Tables["Encabezado"].NewRow();
            E["NombreCli"] = _ds.encabezado.NombreCli;
            E["DireccionCli"] = _ds.encabezado.DireccionCli;
            E["CiRifCli"] = _ds.encabezado.CiRifCli;
            E["CodigoCli"] = _ds.encabezado.CodigoCli;
            E["DocNombre"] = _ds.encabezado.DocumentoNombre;
            E["DocNro"] = _ds.encabezado.DocumentoNro;
            E["DocFecha"] = _ds.encabezado.DocumentoFecha;
            ds.Tables["Encabezado"].Rows.Add(E);

            //ITEMS
            foreach (var rg in _ds.item)
            {
                DataRow p = ds.Tables["Item"].NewRow();
                p["NombrePrd"] = rg.NombrePrd;
                ds.Tables["Item"].Rows.Add(p);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            Rds.Add(new ReportDataSource("DatosNegocio", ds.Tables["DatosNegocio"]));
            Rds.Add(new ReportDataSource("Encabezado", ds.Tables["Encabezado"]));
            Rds.Add(new ReportDataSource("Item", ds.Tables["Item"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }


        public void setData(data ds)
        {
            _ds = ds;
        }

    }

}
