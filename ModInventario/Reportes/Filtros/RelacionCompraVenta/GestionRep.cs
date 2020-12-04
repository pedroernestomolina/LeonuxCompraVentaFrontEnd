using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Filtros.RelacionCompraVenta
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
            var filtro = new OOB.LibInventario.Reportes.CompraVentaAlmacen.Filtro();
            if (dataFiltros != null)
            {
                filtro.autoProducto = dataFiltros.AutoProducto;
            }
            var r01 = Sistema.MyData.Reportes_CompraVentaAlmacen(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var filt = "";
            Imprimir(r01.Entidad, filt);
        }


        public void Imprimir(OOB.LibInventario.Reportes.CompraVentaAlmacen.Ficha ficha, string filt)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\RelacionCompraVenta.rdlc";
            var ds = new DS();

            var diferencia = 0.0m;
            DataRow rt = ds.Tables["RelCompraVentaAlm"].NewRow();
            rt["producto"] = ficha.prdCodigo + Environment.NewLine + ficha.prdNombre;
            rt["exActual"] = ficha.exUnd;
            rt["empaque"] = ficha.empaque+"/"+ficha.contenido.ToString();
            rt["costoDivisaUnd"] = ficha.costoDivisaUnd;
            ds.Tables["RelCompraVentaAlm"].Rows.Add(rt);

            var cUnd = 0.0m;
            foreach (var it in ficha.compras.ToList())
            {
                DataRow xrt = ds.Tables["RelCompraVentaAlmDet"].NewRow();
                xrt["tipo"] = "COMPRA";
                xrt["documento"] = it.documento ;
                xrt["fecha"] = it.fecha;
                xrt["cnt"] = it.cnt;
                xrt["empaque"] = it.empaque;
                xrt["contenido"] = it.contenido;
                xrt["cntUnd"] = it.cntUnd;
                xrt["costoPrecioDivisa"] = it.costoDivisaUnd;
                xrt["montoDivisa"] = it.costoDivisaUnd*it.cntUnd*it.signoDoc;
                xrt["factor"] = it.factor;
                ds.Tables["RelCompraVentaAlmDet"].Rows.Add(xrt);
                cUnd += it.cntUnd;
            }

            var mp = 0.0m;
            var vcnt = ficha.ventas.Sum(s => s.cnt);
            if (vcnt>0)
                mp=ficha.ventas.Sum(s => s.montoVentaDivisa) / vcnt ;
            DataRow xrt2 = ds.Tables["RelCompraVentaAlmDet"].NewRow();
            xrt2["tipo"] = "VENTA";
            xrt2["empaque"] = "UNIDAD";
            xrt2["contenido"] = 1;
            xrt2["cntUnd"] = vcnt ;
            xrt2["costoPrecioDivisa"] = mp;
            xrt2["montoDivisa"] = ficha.ventas.Sum(s=>s.montoVentaDivisa);
            ds.Tables["RelCompraVentaAlmDet"].Rows.Add(xrt2);
            diferencia = ficha.exUnd - (cUnd - vcnt);

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("DIFERENCIA", diferencia.ToString("n2")));
            Rds.Add(new ReportDataSource("RelCompraVentaAlm", ds.Tables["RelCompraVentaAlm"]));
            Rds.Add(new ReportDataSource("RelCompraVentaAlmDet", ds.Tables["RelCompraVentaAlmDet"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}