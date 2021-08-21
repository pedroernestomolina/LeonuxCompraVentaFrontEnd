using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Maestros
{
    
    public class GestionLista
    {

        private List<dataLista> _list;
        private BindingList<dataLista> _bl;
        private BindingSource _bs;
        private dataLista _itemActual;


        public BindingSource Source { get { return _bs; } }
        public int CntItem { get { return _bs.Count; } }
        public dataLista ItemActual { get { return _itemActual; } }


        public GestionLista()
        {
            _itemActual = null;
            _list= new List<dataLista>();
            _bl= new BindingList<dataLista>(_list);
            _bs = new BindingSource();
            _bs.CurrentChanged +=_bs_CurrentChanged;
            _bs.DataSource = _bl;
        }

        private void _bs_CurrentChanged(object sender, EventArgs e)
        {
            if (_bs.Current != null)
                _itemActual = (dataLista)_bs.Current;
        }


        public void setLista(List<OOB.LibSistema.Vendedor.Entidad.Ficha> lista)
        {
            _bl.Clear();
            foreach (var it in lista.OrderBy(o => o.nombre).ToList())
            {
                _bl.Add(new dataLista(it));
            }
        }

        public void setLista(List<OOB.LibSistema.Cobrador.Entidad.Ficha> list)
        {
            _bl.Clear();
            foreach (var it in list.OrderBy(o => o.nombre).ToList())
            {
                _bl.Add(new dataLista(it));
            }
        }

        public void setLista(List<OOB.LibSistema.SerieFiscal.Entidad.Ficha> list)
        {
            _bl.Clear();
            foreach (var it in list.OrderBy(o => o.serie).ToList())
            {
                _bl.Add(new dataLista(it));
            }
        }

        public void Inicializa()
        {
            _itemActual = null;
            _bl.Clear();
        }

        public void AgregarItem(OOB.LibSistema.Vendedor.Entidad.Ficha ficha)
        {
            _bl.Add(new dataLista(ficha));
            _bs.CurrencyManager.Refresh();
        }

        public void ActualizarItem(OOB.LibSistema.Vendedor.Entidad.Ficha ficha)
        {
            var it = _bl.FirstOrDefault(f => f.id == ficha.id);
            var idx = _bl.IndexOf(it);
            _bl.Remove(it);
            _bl.Insert(idx, new dataLista(ficha));
            _bs.CurrencyManager.Refresh();
        }

        public void AgregarItem(OOB.LibSistema.Cobrador.Entidad.Ficha ficha)
        {
            _bl.Add(new dataLista(ficha));
            _bs.CurrencyManager.Refresh();
        }

        public void ActualizarItem(OOB.LibSistema.Cobrador.Entidad.Ficha ficha)
        {
            var it = _bl.FirstOrDefault(f => f.id == ficha.id);
            var idx = _bl.IndexOf(it);
            _bl.Remove(it);
            _bl.Insert(idx, new dataLista(ficha));
            _bs.CurrencyManager.Refresh();
        }

        public void AgregarItem(OOB.LibSistema.SerieFiscal.Entidad.Ficha ficha)
        {
            _bl.Add(new dataLista(ficha));
            _bs.CurrencyManager.Refresh();
        }

        public void ActualizarItem(OOB.LibSistema.SerieFiscal.Entidad.Ficha ficha)
        {
            var it = _bl.FirstOrDefault(f => f.id == ficha.id);
            var idx = _bl.IndexOf(it);
            _bl.Remove(it);
            _bl.Insert(idx, new dataLista(ficha));
            _bs.CurrencyManager.Refresh();
        }

    }

}