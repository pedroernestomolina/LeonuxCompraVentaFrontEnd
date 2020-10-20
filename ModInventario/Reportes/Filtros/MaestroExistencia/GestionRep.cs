using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.MaestroExistencia
{

    public class GestionRep
    {

        private data dataFiltros;


        public GestionRep()
        {
        }


        public void setFiltros(data data)
        {
            dataFiltros = data;
        }

        public void Generar()
        {
            var filtro = new OOB.LibInventario.Reportes.MaestroExistencia.Filtro();
            if (dataFiltros != null)
            {
                filtro.autoDepartamento = dataFiltros.AutoDepartamento;
                filtro.autoDeposito = dataFiltros.AutoDeposito;
            }
            var r01 = Sistema.MyData.Reportes_MaestroExistencia(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Imprimir(r01.Lista);
        }

        public void Imprimir(List<OOB.LibInventario.Reportes.MaestroExistencia.Ficha> lista)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\MaestroExistencia.rdlc";
            var ds = new DS();

            foreach (var it in lista.ToList().OrderBy(o => o.nombrePrd).ToList())
            {
                DataRow rt = ds.Tables["MaestroExistencia"].NewRow();
                rt["nombrePrd"] = it.nombrePrd + Environment.NewLine + it.codigoPrd; 
                rt["nombreDep"] = it.codigoDep+", "+it.nombreDep;
                rt["existencia"] = it.exFisica;

                if (it.exFisica != 0.0m)
                    ds.Tables["MaestroExistencia"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            Rds.Add(new ReportDataSource("MaestroExistencia", ds.Tables["MaestroExistencia"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}