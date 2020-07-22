using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Reportes.Documentos
{

    public class MovimientoTraslado
    {

        public class Detalle 
        {
            public string codigo { get; set; }
            public string descripcion { get; set; }
            public decimal cantidad { get; set; }
            public int signo { get; set; }
            public decimal costoUnd { get; set; }
            public decimal importe { get; set; }
        }

        public class Movimiento 
        {
            public string documentoNro { get; set; }
            public DateTime fecha { get; set; }
            public string tipoDocumento { get; set; }
            public string concepto { get; set; }
            public string codigoConcepto { get; set; }
            public string depositoOrigen { get; set; }
            public string codigoDepositoOrigen { get; set; }
            public string depositoDestino { get; set; }
            public string codigoDepositoDestino { get; set; }
            public string notas { get; set; }
            public string hora { get; set; }
            public string estacion { get; set; }
            public string autorizadoPor { get; set; }
            public decimal total { get; set; }
            public string usuario { get; set; }
            public string usuarioCodigo { get; set; }
            public List<Detalle> detalles { get; set; }
        }



        private Movimiento _ficha;
        private OOB.LibInventario.Movimiento.Ver.Ficha xficha;


        public MovimientoTraslado(Movimiento ficha)
        {
            _ficha = ficha;
        }


        public void Generar() 
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Documentos\MovTraslado.rdlc";
            var ds = new dsDocumento();

            DataRow rt = ds.Tables["Movimiento"].NewRow();
            rt["documentoNro"] = _ficha.documentoNro;
            rt["fecha"] = _ficha.fecha;
            rt["autorizadoPor"] = _ficha.autorizadoPor;
            rt["notas"] = _ficha.notas;
            rt["depOrigen"] = _ficha.codigoDepositoOrigen+"/"+_ficha.depositoOrigen ;
            rt["depDestino"] = _ficha.codigoDepositoDestino+"/"+_ficha.depositoDestino ;
            rt["tipoMovimiento"] = _ficha.tipoDocumento ;
            rt["concepto"] = _ficha.codigoConcepto+ "/" + _ficha.concepto ;
            rt["usuario"] = _ficha.usuarioCodigo + "/" + _ficha.usuario;
            rt["equipo"] = _ficha.estacion ;
            ds.Tables["Movimiento"].Rows.Add(rt);

            foreach (var it in _ficha.detalles.ToList())
            {
                DataRow r = ds.Tables["MovimientoDetalle"].NewRow();
                r["codigo"] = it.codigo;
                r["descripcion"] = it.descripcion;
                r["cantidad"] = it.cantidad;
                r["signo"] = it.signo;
                r["costo"] = it.costoUnd;
                r["importe"] = it.importe;
                ds.Tables["MovimientoDetalle"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            Rds.Add(new ReportDataSource("Movimiento", ds.Tables["Movimiento"]));
            Rds.Add(new ReportDataSource("MovimientoDetalle", ds.Tables["MovimientoDetalle"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}