using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.Kardex
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
            var filtro = new OOB.LibInventario.Reportes.Kardex.Filtro();
            if (dataFiltros != null)
            {
                filtro.autoDeposito = dataFiltros.AutoDeposito;
                filtro.autoProducto = dataFiltros.AutoProducto;
                filtro.desde = dataFiltros.Desde;
                filtro.hasta= dataFiltros.Hasta;
            }
            var r01 = Sistema.MyData.Reportes_Kardex (filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var filt = "DESDE: "+dataFiltros.Desde.ToShortDateString()+", HASTA: "+dataFiltros.Hasta.ToShortDateString();
            if (dataFiltros.AutoDeposito!="")
                filt += ", DEPOSITO: "+dataFiltros.NombreDeposito;

            Imprimir(r01.Lista,filt);
        }


        public void Imprimir(List<OOB.LibInventario.Reportes.Kardex.Ficha> lista, string filt)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\Kardex.rdlc";
            var ds = new DS();

            var grupos = lista.GroupBy(g => g.nombrePrd).OrderBy(o=>o.Key).ToList();
            foreach (var g in grupos)
            {
                var saldo = 0.0m;
                saldo = lista.FirstOrDefault(f => f.nombrePrd == g.Key).existenciaInicial;
                //foreach (var it in lista.Where(w => w.nombrePrd == g.Key).OrderBy(o=>o.moduloMov).ThenBy(o=>o.fechaMov).ToList())
                foreach (var it in lista.Where(w => w.nombrePrd == g.Key).OrderBy(o => o.fechaMov).ThenBy(o=>o.ordenPrioridad).ToList())
                {
                    DataRow rt = ds.Tables["Kardex"].NewRow();
                    rt["nombre"] = it.nombrePrd.Trim()+Environment.NewLine+it.codigoPrd;
                    rt["fechaHora"] = it.fechaMov.ToShortDateString() + ", " + it.horaMov;
                    rt["modulo"] = it.moduloMov;
                    rt["siglas"] = it.siglasMov;
                    rt["documento"] = it.documentoNro;
                    rt["deposito"] = it.deposito;
                    rt["concepto"] = it.concepto;
                    rt["cantidadUnd"] = it.cantidadUnd;
                    rt["entidadMov"] = it.entidadMov;
                    rt["saldoIni"] = saldo;

                    if (it.signoMov == -1)
                    {
                        saldo -= it.cantidadUnd;
                        rt["entrada"] = 0.0m;
                        rt["salida"] = it.cantidadUnd;
                        rt["saldo"] = saldo;
                    }
                    else 
                    {
                        saldo += it.cantidadUnd;
                        rt["entrada"] = it.cantidadUnd ;
                        rt["salida"] = 0.0m;
                        rt["saldo"] = saldo;
                    }
                    ds.Tables["Kardex"].Rows.Add(rt);
                }
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("FILTROS", filt));
            Rds.Add(new ReportDataSource("Kardex", ds.Tables["Kardex"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}