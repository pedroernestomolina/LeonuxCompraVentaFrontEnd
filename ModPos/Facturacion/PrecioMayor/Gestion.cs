using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion.PrecioMayor
{
    
    public class Gestion
    {


        private string _autoPrd;
        private string _tarifa;
        private string _producto;
        private bool _precioSeleccionadoIsOk;
        private string _tarifaSeleccionada;
        private OOB.LibVenta.PosOffline.Producto.Ficha _ficha;
        private List<data> _precios;
        private BindingSource _source; 


        public string Producto { get { return _producto; } }
        public OOB.LibVenta.PosOffline.Producto.Ficha Ficha { get { return _ficha; } }
        public bool PrecioSeleccionadoIsOk { get { return _precioSeleccionadoIsOk; } }
        public string TarifaSeleccionada { get { return _tarifaSeleccionada; } }
        public BindingSource Source { get { return _source; } }
        

        public Gestion()
        {
            _autoPrd = "";
            _tarifa = "";
            _precios = new List<data>();
            _source = new BindingSource();
            _source.DataSource = _precios;
        }


        public void Inicializa() 
        {
            _producto = "";
            _tarifaSeleccionada = "";
            _precioSeleccionadoIsOk = false;
            _precios.Clear();
        }

        PrecioMayorFrm frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (_ficha.PreciosMayorHabilitado)
                {
                    switch (_tarifa) 
                    {
                        case "1":
                            _precios.Add(new data("1", "DETAL", _ficha.Precio_1));
                            break;
                        case "2":
                            _precios.Add(new data("2", "DETAL", _ficha.Precio_2));
                            break;
                        case "3":
                            _precios.Add(new data("3", "DETAL", _ficha.Precio_3));
                            break;
                        case "4":
                            _precios.Add(new data("4", "DETAL", _ficha.Precio_4));
                            break;
                        case "5":
                            _precios.Add(new data("5", "DETAL", _ficha.Precio_5));
                            break;
                    }
                    if (_ficha.PrecioMay_1.Habilitado) 
                    {
                        _precios.Add(new data("6", "MAYOR 1", _ficha.PrecioMay_1));
                    }
                    if (_ficha.PrecioMay_2.Habilitado)
                    {
                        _precios.Add(new data("7", "MAYOR 2", _ficha.PrecioMay_2));
                    }
                    _source.CurrencyManager.Refresh();

                    if (frm == null)
                    {
                        frm = new PrecioMayorFrm();
                        frm.setControlador(this);
                    }
                    frm.ShowDialog();
                }
                else 
                {
                    _tarifaSeleccionada = _tarifa;
                    _precioSeleccionadoIsOk = true;
                }
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData2.Producto(_autoPrd);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _producto = r01.Entidad.NombrePrd;
            _ficha = r01.Entidad;

            return rt;
        }

        public void setAutoProducto(string autoPrd)
        {
            _autoPrd = autoPrd;
        }

        public void setTarifaPrecio(string tarifa) 
        {
            _tarifa = tarifa;
        }

        public void ItemSeleccionado()
        {
            if (_source.Current != null) 
            {
                var _item = (data)_source.Current;
                _tarifaSeleccionada = _item.ID;
                _precioSeleccionadoIsOk = true;
            }
        }

    }

}