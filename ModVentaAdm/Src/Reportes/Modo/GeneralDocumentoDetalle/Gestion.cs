﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Reportes.Modo.GeneralDocumentoDetalle
{
    
    public class Gestion: IGestion
    {

        private Reportes.Filtro.IFiltro _filtro;


        public Reportes.Filtro.IFiltro Filtros { get { return _filtro; } }


        public Gestion()
        {
            _filtro = new Filtro();
        }


        public void Generar(Reportes.Filtro.data data)
        {
            var filtro = new OOB.Reportes.GeneralDocumentoDetalle.Filtro();
            if (data.Sucursal!=null)
            {
                filtro.codigoSucursal = data.Sucursal.codigo;
            }
            if (data.Desde.HasValue)
            {
                filtro.desdeFecha = data.Desde.Value;
            }
            if (data.Hasta.HasValue)
            {
                filtro.hastaFecha = data.Hasta.Value;
            }
            if (data.TipoDocFactura.HasValue)
            {
                filtro.tipoDocFactura = data.TipoDocFactura.Value;
            }
            if (data.TipoDocNtDebito.HasValue)
            {
                filtro.tipoDocNtDebito = data.TipoDocNtDebito.Value;
            }
            if (data.TipoDocNtCredito.HasValue)
            {
                filtro.tipoDocNtCredito = data.TipoDocNtCredito.Value;
            }
            if (data.TipoDocNtEntrega.HasValue)
            {
                filtro.tipoDocNtEntrega = data.TipoDocNtEntrega.Value;
            }
            var r01 = Sistema.MyData.Reportes_GeneralDocumentoDetalle(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            Imprimir(r01.ListaD);
        }

        private void Imprimir(List<OOB.Reportes.GeneralDocumentoDetalle.Ficha> list)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\GeneralDocumentoDet.rdlc";
            var ds = new DS();

            foreach (var it in list.ToList())
            {
                DataRow rt = ds.Tables["GeneralDocumentoDet"].NewRow();
                rt["fechaHora"] = it.fecha.ToShortDateString() + ", " + it.hora;
                rt["documentoNro"] = it.documento;
                rt["documentoNombre"] = it.documentoNombre;
                //rt["usuarioEstacion"] = it.usuarioCodigo.Trim() + "(" + it.usuarioNombre.Trim() + "), " + Environment.NewLine + it.CajaEstacion;
                rt["renglones"] = it.renglones.ToString("n0");
                rt["total"] = it.total * it.signo;
                rt["nombrePrd"] = it.nombreProducto;
                rt["cantidad"] = it.cantidadUnd.ToString("n2");
                rt["precio"] = it.precioUnd;
                rt["totalRenglon"] = it.totalRenglon * it.signo;
                rt["sucursal"] = it.sucNombre+Environment.NewLine+it.sucCodigo;
                rt["estacion"] = it.estacion;
                ds.Tables["GeneralDocumentoDet"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("GeneralDocumentoDet", ds.Tables["GeneralDocumentoDet"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}