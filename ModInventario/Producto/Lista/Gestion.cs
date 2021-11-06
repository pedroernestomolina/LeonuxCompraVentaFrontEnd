using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Lista
{

    public class Gestion
    {

        private List<data> lst;
        private BindingSource bs;
        private bool _activarSeleccion;
        private bool _itemSeleccionadoIsOk;
        private data _itemSeleccionado;
        private string _autoItemSeleccionado;
        private string _descripcionItemSeleccionado;


        public string ItemsEncontrados { get { return string.Format("{0}", bs.Count); } }
        public BindingSource Source { get { return bs; } }
        public data ItemSeleccionado { get { return _itemSeleccionado; } }
        public event EventHandler ItemSeleccionadoOk;
        public bool ItemSeleccionadoIsOk { get { return _itemSeleccionadoIsOk; } }
        public string AutoItemSeleccionado { get { return _autoItemSeleccionado; } }
        public string DescripcionItemSeleccionado { get { return _descripcionItemSeleccionado; } }


        public Gestion()
        {
            _activarSeleccion = false;
            _itemSeleccionadoIsOk = false;
            _itemSeleccionado = null;
            _autoItemSeleccionado = "";
            _descripcionItemSeleccionado = "";

            lst = new List<data>();
            bs = new BindingSource();
            bs.DataSource = lst;
        }


        public void setLista(List<OOB.LibInventario.Producto.Data.Ficha> list)
        {
            lst.Clear();
            foreach (var rg in list.OrderBy(o=>o.DescripcionPrd).ToList())
            {
                lst.Add(new data(rg));
            }
            bs.CurrencyManager.Refresh();
        }

        ListaFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new ListaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        private void Limpiar()
        {
            _itemSeleccionado = null;
        }

        public void SeleccionarItem()
        {
            var it = (data)bs.Current;
            if (it != null)
            {
                if (_activarSeleccion) 
                {
                    _autoItemSeleccionado = it.Auto;
                    _descripcionItemSeleccionado = it.Producto;
                    _itemSeleccionadoIsOk = true;
                    frm.Cerrar();
                    return;
                }

                _itemSeleccionado = it;
                if (ItemSeleccionadoOk != null) 
                {
                    EventHandler hnd = ItemSeleccionadoOk;
                    hnd(this, null);
                }
            }
        }

        public void Cerrar()
        {
            frm.Close();
        }

        public void Inicializa()
        {
            _activarSeleccion = false;
            _itemSeleccionadoIsOk = false;
            _itemSeleccionado = null;
            _autoItemSeleccionado = "";
            _descripcionItemSeleccionado = "";
        }

        public void ActivarSeleccion(bool p)
        {
            _activarSeleccion = p;
        }

    }

}