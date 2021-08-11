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


        public BindingSource Source { get { return _bs; } }
        public int CntItem { get { return _bs.Count; } }


        public GestionLista()
        {
            _list= new List<dataLista>();
            _bl= new BindingList<dataLista>(_list);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
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


        public void AgregarItem()
        {
            //_gestionAgregarEditar.Agregar();
            //if (_gestionAgregarEditar.IsAgregarEditarOk)
            //{
            //    CargarData();
            //}
        }

        public void EditarItem()
        {
            //var it = (OOB.LibSistema.Sucursal.Ficha)bsLista.Current;
            //if (it != null)
            //{
            //    _gestionAgregarEditar.Editar(it);
            //    if (_gestionAgregarEditar.IsAgregarEditarOk)
            //    {
            //        CargarData();
            //    }
            //}
        }

        public void Inicializa()
        {
            _bl.Clear();
        }

    }

}