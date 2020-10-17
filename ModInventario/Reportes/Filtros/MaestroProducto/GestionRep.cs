using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.MaestroProducto
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
            var filtro = new OOB.LibInventario.Reportes.MaestroProducto.Filtro();
            if (dataFiltros!=null)
            {
                if (dataFiltros.IdAdmDivisa != "") 
                {
                    var rt= OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa.Si;
                    if (dataFiltros.IdAdmDivisa=="No")
                        rt= OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa.No;
                    filtro.admDivisa = rt; 
                }
                if (dataFiltros.IdOrigen != "")
                {
                    filtro.origen = (OOB.LibInventario.Reportes.enumerados.EnumOrigen)int.Parse(dataFiltros.IdOrigen);
                }
                if (dataFiltros.IdCategoria != "")
                {
                    filtro.categoria = (OOB.LibInventario.Reportes.enumerados.EnumCategoria)int.Parse(dataFiltros.IdCategoria);
                }
                if (dataFiltros.IdEstatus != "")
                {
                    filtro.estatus = (OOB.LibInventario.Reportes.enumerados.EnumEstatus)int.Parse(dataFiltros.IdEstatus);
                }
                filtro.autoDepartamento = dataFiltros.AutoDepartamento;
                filtro.autoTasa = dataFiltros.AutoTasa;
            }
            var r01 = Sistema.MyData.Reportes_MaestroProducto(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Imprimir(r01.Lista);
        }


        public void Imprimir(List<OOB.LibInventario.Reportes.MaestroProducto.Ficha> lista)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\MaestroProductos.rdlc";
            var ds = new DS();

  //public string codigoPrd { get; set; }
  //      public string nombrePrd { get; set; }
  //      public string referenciaPrd { get; set; }
  //      public string modeloPrd { get; set; }
  //      public int contenidoPrd { get; set; }
  //      public string departamento { get; set; }
  //      public string empaque { get; set; }
  //      public decimal tasaIva { get; set; }
  //      public enumerados.EnumAdministradorPorDivisa admDivisa { get; set; }
  //      public enumerados.EnumEstatus estatus { get; set; }
  //      public enumerados.EnumCategoria categoria { get; set; }
  //      public enumerados.EnumOrigen origen { get; set; }

            foreach (var it in lista.ToList().OrderBy(o=>o.departamento).OrderBy(o=>o.nombrePrd).ToList())
            {
                DataRow rt = ds.Tables["MaestroProducto"].NewRow();
                rt["codigo"] = it.codigoPrd;
                rt["nombre"] = it.nombrePrd;
                rt["modelo"] = it.modeloPrd;
                rt["referencia"] = it.referenciaPrd;
                rt["departamento"] = it.departamento;
                rt["empaque"] = it.empaque.Trim()+" ("+it.contenidoPrd.ToString("n0")+")";
                rt["tasa"] = it.tasaIva.ToString("n2")+"%";
                rt["admDivisa"] = it.admDivisa.ToString();
                rt["origen"] = it.origen.ToString();
                rt["categoria"] = it.categoria.ToString();
                ds.Tables["MaestroProducto"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            Rds.Add(new ReportDataSource("MaestroProducto", ds.Tables["MaestroProducto"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}