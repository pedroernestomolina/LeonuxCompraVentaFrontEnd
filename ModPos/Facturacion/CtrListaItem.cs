using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion
{

    public class CtrListaItem
    {

        private CtrItem _ctrItem;
        private List<Item> _items;
        private BindingList<Item> _bItems;
        private BindingSource _bs;
        private Enumerados.EnumModoFuncion _modoFuncion; 


        public BindingSource Source { get { return _bs; } }
        public decimal SubTotal { get { return _ctrItem.SubTotal; } }


        public CtrListaItem(CtrItem ctr)
        {
            _ctrItem = ctr;
            _items = new List<Item>();
            _bItems = new BindingList<Item>(_items);
            _bs = new BindingSource();
            _bs.DataSource = _bItems;
        }

        public void EliminarItem()
        {
            if (_bs != null)
            {
                var item = (Item)_bs.Current;
                if (item != null)
                {
                    if (_modoFuncion == Enumerados.EnumModoFuncion.Facturacion) 
                    {
                        if (_ctrItem.EliminarItem(item.Id))
                        {
                            _bItems.Remove(item);
                        }
                    }
                    if (_modoFuncion == Enumerados.EnumModoFuncion.NotaCredito)
                    {
                        if (_ctrItem.EliminarItemNotaCredito(item.Id))
                        {
                            _bItems.Remove(item);
                        }
                    }
                }
            }
        }

        public void DevolerItem()
        {
            if (_bs != null)
            {
                var item = (Item)_bs.Current;
                if (item != null)
                {
                    if (item.EsPesado)
                    {
                        Helpers.Sonido.Error();
                        Helpers.Msg.Error("Opción No Permitida Para Item(s) Pesado, Verifique Por Favor");
                        return;
                    }
                    if (_modoFuncion == Enumerados.EnumModoFuncion.Facturacion)
                    {
                        if (item.Cantidad > 1)
                        {
                            if (_ctrItem.Restar(item.Id))
                            {
                                item.Cantidad -= 1;
                            };
                        }
                        else
                        {
                            if (_ctrItem.EliminarItem(item.Id))
                            {
                                _bItems.Remove(item);
                            }
                        }
                    }

                    if (_modoFuncion == Enumerados.EnumModoFuncion.NotaCredito)
                    {
                        if (item.Cantidad > 1)
                        {
                            if (_ctrItem.RestarNotaCredito(item.Id))
                            {
                                item.Cantidad -= 1;
                            };
                        }
                        else
                        {
                            if (_ctrItem.EliminarItemNotaCredito(item.Id))
                            {
                                _bItems.Remove(item);
                            }
                        }
                    }

                }
            }
        }

        public void Subir()
        {
            _bs.Position -= 1;
        }

        public void Bajar()
        {
            _bs.Position += 1;
        }

        Devolucion.DevolucionFrm frm;
        public void ActivarDevolucion(Enumerados.EnumModoFuncion modo= Enumerados.EnumModoFuncion.Facturacion) 
        {
            _modoFuncion = modo;
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new Devolucion.DevolucionFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            _bItems.Clear();
            foreach (var it in _ctrItem.Items) 
            {
                _bItems.Add(it);
            }
            return true;
        }

    }

}