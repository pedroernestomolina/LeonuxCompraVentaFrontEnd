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


        public string ItemsEncontrados { get { return string.Format("{0}", bs.Count); } }
        public BindingSource Source { get { return bs; } }
        public data ItemSeleccionado { get; set; }
        public event EventHandler ItemSeleccionadoOk;


        public Gestion()
        {
            ItemSeleccionado = null;
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
            ItemSeleccionado = null;
        }

        public void SeleccionarItem()
        {
            var it = (data)bs.Current;
            if (it != null)
            {
                ItemSeleccionado = it;
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

    }

}