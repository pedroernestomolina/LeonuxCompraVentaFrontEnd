using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.MaestroInventario
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
            var sFiltro = "";
            var filtro = new OOB.LibInventario.Reportes.MaestroInventario.Filtro();
            if (dataFiltros != null)
            {
                if (dataFiltros.IdAdmDivisa != "")
                {
                    sFiltro += "Por Divisa=";
                    var rt = OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa.Si;
                    if (dataFiltros.IdAdmDivisa == "No")
                    {
                        rt = OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa.No;
                        sFiltro += "NO, ";
                    }
                    else 
                        sFiltro += "SI, ";
                    filtro.admDivisa = rt;
                }
                if (dataFiltros.IdEstatus != "")
                {
                    filtro.estatus = (OOB.LibInventario.Reportes.enumerados.EnumEstatus)int.Parse(dataFiltros.IdEstatus);
                    sFiltro += "Por Estatus= "+filtro.estatus.ToString()+", ";
                }
                filtro.autoDepartamento = dataFiltros.AutoDepartamento;
                filtro.autoDeposito= dataFiltros.AutoDeposito;

                if (filtro.autoDeposito != "")
                    sFiltro += "Por Deposito= "+dataFiltros.NombreDeposito+", ";
                if (filtro.autoDepartamento != "")
                    sFiltro += "Por Departamento= " + dataFiltros.NombreDepartamento + ", ";
            }
            var r01 = Sistema.MyData.Reportes_MaestroInventario (filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Imprimir(r01.Lista, sFiltro);
        }

        public void Imprimir(List<OOB.LibInventario.Reportes.MaestroInventario.Ficha> lista, string sFiltro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\MaestroInventario.rdlc";
            var ds = new DS();

            foreach (var it in lista.ToList().OrderBy(o => o.departamento).OrderBy(o => o.nombrePrd).ToList())
            {
                var existencia = 0.0m;
                if (it.existencia.HasValue)
                    existencia= it.existencia.Value;
                var costoUnd = it.costoUnd;
                var costoDivisaUnd = 0.0m;
                var admDivisa = "No";
                var importe = 0.0m;
                var importeDivisa = 0.0m;
                if (it.admDivisa == OOB.LibInventario.Reportes.enumerados.EnumAdministradorPorDivisa.Si) 
                {
                    admDivisa = "Si";
                    costoDivisaUnd = it.costoDivisaUnd;
                    costoUnd = 0.0m;
                }
                importe = costoUnd * existencia;
                importeDivisa = costoDivisaUnd * existencia;


                DataRow rt = ds.Tables["MaestroInventario"].NewRow();
                rt["codigo"] = it.codigoPrd;
                rt["nombre"] = it.nombrePrd;
                rt["modelo"] = it.modeloPrd;
                rt["referencia"] = it.referenciaPrd;
                rt["departamento"] = it.departamento;
                rt["existencia"] = existencia.ToString("n"+it.decimales);
                rt["costoUnd"] = costoUnd.ToString("n2");
                rt["costoDivisaUnd"] = costoDivisaUnd.ToString("n2");
                rt["importe"] = importe;
                rt["importeDivisa"] = importeDivisa;
                rt["admDivisa"] = admDivisa;

                if (existencia!=0.0m)
                    ds.Tables["MaestroInventario"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("FILTROS", sFiltro));
            Rds.Add(new ReportDataSource("MaestroInventario", ds.Tables["MaestroInventario"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}