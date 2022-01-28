using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.PrecioMayor
{
    
    public class Gestion
    {


        private string _autoPrd;
        private string _tarifa;
        private string _producto;
        private bool _precioSeleccionadoIsOk;
        private string _tarifaSeleccionada;
        private OOB.Producto.Entidad.Ficha _ficha;
        private List<data> _precios;
        private BindingSource _source; 


        public string Producto { get { return _producto; } }
        public OOB.Producto.Entidad.Ficha Ficha { get { return _ficha; } }
        public bool PrecioSeleccionadoIsOk { get { return _precioSeleccionadoIsOk; } }
        public string TarifaSeleccionada { get { return _tarifaSeleccionada; } }
        public BindingSource Source { get { return _source; } }
        public string AutoProducto { get { return _autoPrd; } }
        

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
                            var p1 = new precio("1", _ficha.empaque_1, _ficha.contenido_1, _ficha.pneto_1, _ficha.decimales_1);
                            _precios.Add(new data("1", "DETAL", p1));
                            break;
                        case "2":
                            var p2 = new precio("2", _ficha.empaque_2, _ficha.contenido_2, _ficha.pneto_2, _ficha.decimales_2);
                            _precios.Add(new data("2", "DETAL", p2));
                            break;
                        case "3":
                            var p3 = new precio("3", _ficha.empaque_3, _ficha.contenido_3, _ficha.pneto_3, _ficha.decimales_3);
                            _precios.Add(new data("3", "DETAL", p3));
                            break;
                        case "4":
                            var p4 = new precio("4", _ficha.empaque_4, _ficha.contenido_4, _ficha.pneto_4, _ficha.decimales_4);
                            _precios.Add(new data("4", "DETAL", p4));
                            break;
                        case "5":
                            var p5 = new precio("5", _ficha.empaque_5, _ficha.contenido_5, _ficha.pneto_5, _ficha.decimales_5);
                            _precios.Add(new data("5", "DETAL", p5));
                            break;
                        default:
                            var p11 = new precio("1", _ficha.empaque_1, _ficha.contenido_1, _ficha.pneto_1, _ficha.decimales_1);
                            _precios.Add(new data("1", "DETAL", p11));
                            break;
                    }
                    var pM1 = new precio("6", _ficha.empaqueMay_1, _ficha.contenidoMay_1, _ficha.pnetoMay_1, _ficha.decimalesMay_1);
                    if (pM1.Habilitado)
                    {
                        _precios.Add(new data("6", "MAYOR 1", pM1));
                    }
                    var pM2 = new precio("6", _ficha.empaqueMay_2, _ficha.contenidoMay_2, _ficha.pnetoMay_2, _ficha.decimalesMay_2);
                    if (pM2.Habilitado)
                    {
                        _precios.Add(new data("7", "MAYOR 2", pM2));
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

            var r01 = Sistema.MyData.Producto_GetFichaById(_autoPrd);
            if (r01.Result ==  OOB.Resultado.Enumerados.EnumResult.isError)
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