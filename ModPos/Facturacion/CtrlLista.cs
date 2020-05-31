using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion
{

    public class CtrlLista
    {


        private BindingSource _bs;
        private BindingList<OOB.LibVenta.PosOffline.Producto.Ficha> _bProducto;
        public bool IsProductoSelected { get; set; }
        public OOB.LibVenta.PosOffline.Producto.Ficha ProductoSelected { get; set; }
        public BindingSource Source { get { return _bs; } }


        public CtrlLista()
        {
            _bProducto = new BindingList<OOB.LibVenta.PosOffline.Producto.Ficha>();
            _bs = new BindingSource();
            _bs.DataSource = _bProducto;
        }


        public void ListaPlu() 
        {
            IsProductoSelected = false;
            ProductoSelected = null;

            if (CargarDataPlu()) 
            {
                var frm = new ProductoLista.ListaPluFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarDataPlu()
        {
            var rt = true;

            var r01 = Sistema.MyData2.ProductoListaPlu();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            _bProducto.Clear();
            _bProducto.RaiseListChangedEvents = false;
            foreach (var dt in r01.Lista.OrderBy(o => o.NombrePrd))
            {
                _bProducto.Add(dt);
            }
            _bProducto.RaiseListChangedEvents = true;
            _bProducto.ResetBindings();

            return rt;
        }

        public void Subir() 
        {
            _bs.Position -= 1;
        }

        public void Bajar()
        {
            _bs.Position += 1;
        }

        public void Seleccionar() 
        {
            if (_bs != null)
            {
                if (_bs.Current != null)
                {
                    var prd = (OOB.LibVenta.PosOffline.Producto.Ficha)_bs.Current;
                    var r01 = Sistema.MyData2.Producto(prd.Auto);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    ProductoSelected = r01.Entidad;
                    IsProductoSelected  = true;
                }
            }
        }

        public void ListaOferta()
        {
            IsProductoSelected = false;
            ProductoSelected = null;

            if (CargarDataOferta())
            {
                var frm = new ProductoLista.ListaOfertaFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarDataOferta()
        {
            var rt = true;

            var r01 = Sistema.MyData2.ProductoListaOferta();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            _bProducto.Clear();
            _bProducto.RaiseListChangedEvents = false;
            foreach (var dt in r01.Lista.Where(w => w.IsOfertaActiva).OrderBy(o => o.NombrePrd))
            {
                _bProducto.Add(dt);
            }
            _bProducto.RaiseListChangedEvents = true;
            _bProducto.ResetBindings();

            return rt;
        }

        public void ListaFiltrada(string buscar) 
        {
            IsProductoSelected = false;
            ProductoSelected = null;

            if (CargarDataProducto(buscar))
            {
                var frm = new Facturacion.ProductoLista.ListaFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarDataProducto(string buscar)
        {
            var rt = true;

            var r01 = Sistema.MyData2.Producto_Lista(buscar);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            _bProducto.Clear();
            _bProducto.RaiseListChangedEvents = false;
            foreach (var dt in r01.Lista.OrderBy(o => o.NombrePrd))
            {
                _bProducto.Add(dt);
            }
            _bProducto.RaiseListChangedEvents = true;
            _bProducto.ResetBindings();

            return rt;
        }

    }

}