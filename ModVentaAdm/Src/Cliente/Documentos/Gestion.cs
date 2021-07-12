using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Cliente.Documentos
{
    
    public class Gestion
    {


        private string _autoCli;
        private OOB.Maestro.Cliente.Entidad.Ficha _cliente;
        private BindingSource _bs;
        private Filtro _filtro;
        private List<data> _ldata;


        public string Cliente { get { return _cliente.ciRif+Environment.NewLine+_cliente.razonSocial; } }
        public BindingSource Source { get { return _bs; } }
        public DateTime Desde { get { return _filtro.desde; } }
        public DateTime Hasta { get { return _filtro.hasta; } }


        public Gestion()
        {
            _autoCli = "";
            _filtro = new Filtro();
            _ldata= new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _ldata;
        }


        public void Inicializa()
        {
            _autoCli = "";
            _filtro.Limpiar();
            _ldata.Clear();
        }

        public void setCliente(Administrador.data Item)
        {
            _autoCli = Item.Id;
        }

        DocumentosFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new DocumentosFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Cliente_GetFicha (_autoCli);
            if (r01.Result ==  OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _cliente = r01.Entidad;
            _filtro.setCliente(_cliente.id);

            return rt;
        }

        public void setDesde(DateTime fecha)
        {
            _filtro.setDesde(fecha);
        }

        public void setHasta(DateTime fecha)
        {
            _filtro.setHasta(fecha);
        }

        public void Buscar()
        {
            if (_filtro.IsOk()) 
            {
                var filtroOOB = new OOB.Maestro.Cliente.Documento.Filtro()
                {
                    desde = _filtro.desde,
                    hasta = _filtro.hasta,
                    autoCliente = _filtro.autoCliente,
                };
                var r01 = Sistema.MyData.Cliente_Documentos_GetLista(filtroOOB);
                if (r01.Result ==  OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _ldata.Clear();
                foreach(var it in r01.ListaD)
                {
                    var nr = new data(it);
                    _ldata.Add(nr);
                }
                _bs.CurrencyManager.Refresh();
            }
        }

        public void Limpiar()
        {
            _filtro.Limpiar();
            _filtro.setCliente(_cliente.id);
            _ldata.Clear();
            _bs.CurrencyManager.Refresh();
        }

        public void Imprimir()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"ReportesCliente\Documento.rdlc";
            var ds = new ReportesCliente.DS_CLI();

            foreach (var it in _ldata.ToList())
            {
                DataRow rt = ds.Tables["Documento"].NewRow();
                rt["fecha"] = it.Fecha.Date;
                rt["tipo"] = it.Tipo;
                rt["serie"] = it.Serie;
                rt["documento"] = it.Documento;
                rt["importeDivisa"] = it.ImporteDivisa;
                ds.Tables["Documento"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("Documento", ds.Tables["Documento"]));

            var frp = new Reportes.ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}