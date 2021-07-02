using System;
using System.Collections.Generic;
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


        public string Cliente { get { return ""; } }
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

    }

}