﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.Valorizacion
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
            var filtro = new OOB.LibInventario.Reportes.Valorizacion.Filtro();
            if (dataFiltros != null)
            {
                filtro.hasta  = dataFiltros.Hasta;
                filtro.idDeposito = dataFiltros.AutoDeposito;
            };
            var r01 = Sistema.MyData.Reportes_Valorizacion(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var filt="AL: "+dataFiltros.Hasta.ToShortDateString();
            if (dataFiltros.AutoDeposito != "") 
            {
                filt += ", DEPOSITO: " + dataFiltros.NombreDeposito;
            };
            Imprimir(r01.Lista, filt);
        }

        public void Imprimir(List<OOB.LibInventario.Reportes.Valorizacion.Ficha> lista, string filtro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\Valorizacion.rdlc";
            var ds = new DS();

            foreach (var it in lista)
            {
                DataRow rt = ds.Tables["Valorizacion"].NewRow();
                rt["producto"] = it.nombre + Environment.NewLine + it.codigo;
                rt["departamento"] = it.departamento;
                rt["grupo"] = it.grupo;
                rt["existencia"] = it.cntUnd;
                rt["costoUnd"] = it.costoHist;
                rt["importe"] = (it.cntUnd*it.costoHist);
                ds.Tables["Valorizacion"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("Filtros", filtro));
            Rds.Add(new ReportDataSource("Valorizacion", ds.Tables["Valorizacion"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}