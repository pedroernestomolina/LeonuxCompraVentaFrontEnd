using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Tool.AjusteNivelMinimoMaximoProducto
{

    public class GestionLista
    {

        private GestionAjuste _gestionAjuste;
        private List<data> _data;
        private BindingList<data> _bldata;
        private BindingSource _bs;


        public BindingSource Source { get { return _bs; } }
        public List<data> Lista { get { return _data; } }


        public GestionLista()
        {
            _gestionAjuste = new GestionAjuste();
            _data = new List<data>();
            _bldata=new BindingList<data>(_data);
            _bs = new BindingSource();
            _bs.DataSource = _bldata;
        }


        public void setLista(List<OOB.LibInventario.Tool.AjusteNivelMinimoMaximoProducto.Capturar.Ficha> list)
        {
            _bldata.Clear();
            foreach (var it in list.OrderBy(o=>o.nombreProducto).ToList()) 
            {
                var nr = new data(it);
                _bldata.Add(nr);
            }
        }

        public void Limpiar()
        {
            _bldata.Clear();
        }

        public void AjustarMinimoMaximo()
        {
            if (_bs.Current != null) 
            {
                var it =(data) _bs.Current;
                _gestionAjuste.Inicia(it);
                if (_gestionAjuste.AjusteIsOk) 
                {
                    it.setMinimo(_gestionAjuste.Minimo);
                    it.setMaximo(_gestionAjuste.Maximo);
                }
            }
        }

    }

}