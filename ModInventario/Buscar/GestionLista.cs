using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ModInventario.Buscar
{

    public class GestionLista
    {

        public event EventHandler CambioItemActual;


        private List<OOB.LibInventario.Producto.Data.Ficha> lLista;
        private BindingList<OOB.LibInventario.Producto.Data.Ficha> blLista;
        private BindingSource bsLista;
        private OOB.LibInventario.Producto.Data.Ficha _item;


        public BindingSource Source { get { return bsLista; } }
        public int Items { get { return bsLista.Count; } }
        public OOB.LibInventario.Producto.Data.Ficha Item { get { return _item; } }


        public GestionLista()
        {
            lLista = new List<OOB.LibInventario.Producto.Data.Ficha>();
            blLista = new BindingList<OOB.LibInventario.Producto.Data.Ficha>(lLista);
            bsLista = new BindingSource();
            bsLista.CurrentChanged +=bsLista_CurrentChanged;
            bsLista.DataSource = blLista;
        }

        private void bsLista_CurrentChanged(object sender, EventArgs e)
        {
            _item = (OOB.LibInventario.Producto.Data.Ficha)  bsLista.Current;
            if (_item != null) 
            {
                EventHandler hnd = CambioItemActual;
                if (hnd != null)
                {
                    hnd(this, null);
                }
            }
        }

        public void setLista(List<OOB.LibInventario.Producto.Data.Ficha> list)
        {
            blLista.Clear();
            blLista.RaiseListChangedEvents = false;
            foreach (var it in list.OrderBy(o=>o.identidad.descripcion).ToList())
            {
                blLista.Add(it);
            }
            blLista.RaiseListChangedEvents = true;
            blLista.ResetBindings();
            bsLista.CurrencyManager.Refresh();
        }

        public OOB.LibInventario.Producto.Data.Ficha SeleccionarItem()
        {
            var it= (OOB.LibInventario.Producto.Data.Ficha) bsLista.Current;
            return it;
        }

        public void Limpiar()
        {
            blLista.Clear();
            bsLista.CurrencyManager.Refresh();
        }

    }

}