using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Existencia.Ver
{
    
    public class Gestion
    {


        private List<data> _data;
        private BindingSource _bs;
        private string _autoPrd;
        private string _decimales;
        private string _empaque;
        private int _empaqueContenido;
        private string _empaqueDes;


        public BindingSource Source { get { return _bs; } }
        public decimal ExFisica { get { return _data.Sum(s => s.ExFisica); } }
        public decimal ExReserva { get { return _data.Sum(s => s.ExReserva); } }
        public decimal ExDisponible { get { return _data.Sum(s => s.ExDisponible); } }
        public string EmpaqueDes { get { return _empaqueDes; } }
        public string Formato 
        {
            get 
            { 
                var r="n";
                r+=_decimales;
                return r;
            } 
        }


        public Gestion()
        {
            _autoPrd = "";
            _empaque = "";
            _empaqueContenido = 1;

            _data = new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _data;
        }


        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                var frm = new VerFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private void Limpiar()
        {
            _empaque = "";
            _empaqueContenido = 1;
            _data.Clear();
        }

        public void setFicha(string autoprd)
        {
            _autoPrd = autoprd;
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Producto_GetExistencia(_autoPrd);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _decimales = r01.Entidad.decimales;
            _empaque = r01.Entidad.empaque;
            _empaqueContenido = r01.Entidad.empaqueContenido;

            foreach (var it in r01.Entidad.depositos.OrderBy(o=>o.nombre).ToList()) 
            {
                var nr = new data(it);
                _data.Add(nr);
            }
            _bs.CurrencyManager.Refresh();

            return rt;
        }

        public void setCompra()
        {
            _empaqueDes = _empaque.Trim().ToUpper() + " (" + _empaqueContenido.ToString().Trim() + ")"; 
            foreach (var it in _data) 
            {
                it.setContenido(_empaqueContenido);
            }
        }

        public void setUnidad()
        {
            _empaqueDes = "UNIDAD (1)";
            foreach (var it in _data)
            {
                it.setContenido(1);
            }
        }

    }

}