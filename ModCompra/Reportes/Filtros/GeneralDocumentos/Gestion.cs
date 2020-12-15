using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Reportes.Filtros.GeneralDocumentos
{
    
    public class Gestion : IReporte
    {

        private IFiltros filtros;
        private Reportes.Filtros.data filtrarPor;


        public IFiltros Filtros
        {
            get { return filtros;}
        }


        public Gestion()
        {
            filtros = new Filtros();
        }


        public void setDataFiltros(data filtros)
        {
            filtrarPor = filtros;
        }

        public void Generar()
        {
            if (filtrarPor.hasta < filtrarPor.desde) 
            {
                Helpers.Msg.Error("Fechas Incorrectas, Verifique Por Favor");
                return;
            }

            var filtro = new OOB.LibCompra.Reportes.GeneralDocumentos.Filtro()
            {
                desde = filtrarPor.desde,
                hasta = filtrarPor.hasta,
            };
            var xr1 = Sistema.MyData.Reportes_ComprasDocumento(filtro);
            if (xr1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(xr1.Mensaje);
                return;
            }
            Reporte(xr1.Lista);
        }

        private void Reporte(List<OOB.LibCompra.Reportes.GeneralDocumentos.Ficha> list)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\GeneralDocumentos.rdlc";
            var ds = new DS();
            foreach (var it in list.ToList().OrderBy(o => o.fecha).ToList())
            {
                DataRow rt = ds.Tables["GeneralDoc"].NewRow();
                rt["documentoNro"] = it.documento;
                ds.Tables["GeneralDoc"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            Rds.Add(new ReportDataSource("GeneralDoc", ds.Tables["GeneralDoc"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}