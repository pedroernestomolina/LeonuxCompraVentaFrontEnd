using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Documentos.Generar.Items
{
    
    public class Gestion
    {

        private decimal _mDivisa;
        private List<data> _ldata;
        private BindingList<data> _bl;
        private BindingSource _bs;


        public int CntItem { get { return _bl.Count; } }
        public decimal MontoNeto { get { return _bl.Sum(s => s.PImporte); } }
        public decimal MontoIva { get { return _bl.Sum(s => s.MIva); } }
        public decimal MontoTotal { get { return _bl.Sum(s => s.mTotal); } }
        public decimal MontoTotalDivisa { get { return MontoTotal / _mDivisa; } }
        public BindingSource ItemsSource { get { return _bs; } }
        public bool HayItemsEnBandeja { get { return CntItem > 0; } }


        public Gestion() 
        {
            _mDivisa = 0m;
            _ldata = new List<data>();
            _bl = new BindingList<data>(_ldata);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }

        public void Inicializa()
        {
            _mDivisa = 0m;
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }

        public void AgregarItem()
        {
            if (_bl.Count == 0)
            {
                _bl.Add(new data(1));
            }
            else
            {
                var id = _bl.Max(t => t.Id) + 1;
                _bl.Add(new data(id));
            }
        }

        public void setDivisa(decimal mont) 
        {
            _mDivisa = mont;
        }

        public void LimpiarItems()
        {
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }

        public void EliminarItem()
        {
            if (_bs.Current!=null)
            {
                var data = (data)_bs.Current;
                _bl.Remove(data);
                _bs.CurrencyManager.Refresh();
            }
        }

    }

}