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
            var filt = "";
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
                if (dataFiltros.AutoDepartamento != "") 
                {
                    filt += "DEPARTAMENTO: " + dataFiltros.NombreDepartamento;
                    filtro.autoDepartamento = dataFiltros.AutoDepartamento;
                }
                if (dataFiltros.AutoGrupo != "")
                {
                    filt += "GRUPO: " + dataFiltros.NombreDepartamento;
                    filtro.autoGrupo = dataFiltros.AutoGrupo;
                }
                if (dataFiltros.AutoDeposito != "")
                {
                    filt += "DEPOSITO: " + dataFiltros.NombreDeposito;
                    filtro.autoDeposito = dataFiltros.AutoDeposito;
                }
                filtro.autoTasa = dataFiltros.AutoTasa;
            }
            var r01 = Sistema.MyData.Reportes_MaestroProducto(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Imprimir(r01.Lista, filt);
        }


        public void Imprimir(List<OOB.LibInventario.Reportes.MaestroProducto.Ficha> lista, string filtros)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\MaestroProductos.rdlc";
            var ds = new DS();
            foreach (var it in lista.ToList().OrderBy(o=>o.departamento).ThenBy(o=>o.nombrePrd).ToList())
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
                rt["grupo"] = it.grupo;
                ds.Tables["MaestroProducto"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("FILTROS", filtros));
            Rds.Add(new ReportDataSource("MaestroProducto", ds.Tables["MaestroProducto"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}