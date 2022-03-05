using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.ControlAcceso.Sist
{
    
    public class Gestion
    {

        private List<item> _lista;
        private BindingList<item> _bl;
        private BindingSource _bs;


        public BindingSource Source { get { return _bs; } }


        public Gestion() 
        {
            _lista = new List<item>();
            _bl = new BindingList<item>(_lista);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void setLista(List<OOB.LibSistema.ControlAcceso.Data.Ficha> list)
        {
            foreach(var it in list.OrderBy(o=>o.fCodigo).ToList())
            {
                var nr = new item()
                {
                    codFuncion = it.fCodigo,
                    funcion = it.fNombre,
                    estatus = it.estatus == "1" ? true : false,
                    seguridadValor=it.seguridad,
                };
                _bl.Add(nr);
            }
        }

        public void Inicializa()
        {
            _bl.Clear();
        }

        public List<item> ListaAcceso()
        {
            return _bl.ToList();
        }

    }

}