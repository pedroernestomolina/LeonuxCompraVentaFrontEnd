using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Proveedor.Administrador
{

    public class GestionLista
    {

        public event EventHandler ItemChanged;


        private List<OOB.LibCompra.Proveedor.Data.Ficha> _lst;
        private BindingList<OOB.LibCompra.Proveedor.Data.Ficha> _bl;
        private BindingSource _bs;
        private OOB.LibCompra.Proveedor.Data.Ficha _item;


        public BindingSource Source { get { return _bs; } }
        public int Items { get { return _bs.Count; } }
        public OOB.LibCompra.Proveedor.Data.Ficha Item { get { return _item; } }
        public string Proveedor 
        { 
            get 
            {
                var rt = "";
                if (Item != null) 
                {
                    rt = Item.ciRif + Environment.NewLine + Item.nombreRazonSocial;
                }
                return rt;
            } 
        }


        public GestionLista()
        {
            _item = null;
            _lst = new List<OOB.LibCompra.Proveedor.Data.Ficha>();
            _bl = new BindingList<OOB.LibCompra.Proveedor.Data.Ficha >(_lst);
            _bs = new BindingSource();
            _bs.CurrentChanged +=_bs_CurrentChanged;   
            _bs.DataSource = _bl;
        }

        private void _bs_CurrentChanged(object sender, EventArgs e)
        {
            _item = (OOB.LibCompra.Proveedor.Data.Ficha)_bs.Current;
            if (_item != null)
            {
                EventHandler hnd = ItemChanged;
                if (hnd != null)
                {
                    hnd(this, null);
                }
            }
        }

        public void setLista(List<OOB.LibCompra.Proveedor.Data.Ficha> list)
        {
            _item = null;
            _lst.Clear();
            _lst.AddRange(list.OrderBy(o => o.nombreRazonSocial).ToList());
            _bs.CurrencyManager.Refresh();
        }

        public void LimpiarLista()
        {
            _item = null;
            _lst.Clear();
            _bs.CurrencyManager.Refresh();
        }

        public void AgregarFicha(OOB.LibCompra.Proveedor.Data.Ficha ficha)
        {
            _lst.Add(ficha);
            _bs.CurrencyManager.Refresh();
        }

        public void EliminarItem(string autoId)
        {
            var it = _lst.FirstOrDefault(f => f.autoId == autoId);
            if (it != null) 
            {
                _lst.Remove(it);
                _bs.CurrencyManager.Refresh();
            }
        }

    }

}