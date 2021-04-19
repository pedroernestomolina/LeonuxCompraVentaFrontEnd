using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Devolucion
{
    
    public class Gestion
    {

        private BindingList<Item.data> _bl;
        private BindingSource _bs;
        private bool _fichaCambio;


        public bool FichaCambioIsOk { get { return _fichaCambio; } }
        public decimal MontoSubTotal { get { return _bl.Sum(f => f.MontoTotal()); } }
        public BindingSource DataSource { get { return _bs; } }


        public Gestion()
        {
            _fichaCambio = false;
            _bl = new BindingList<Item.data>();
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializa()
        {
            _fichaCambio = false;
        }

        DevolucionFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new DevolucionFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;
            return rt;
        }

        public void SubirItem()
        {
            _bs.Position -= 1;
        }

        public void BajarItem()
        {
            _bs.Position += 1;
        }

        public void setData(System.ComponentModel.BindingList<Item.data> bl)
        {
            _bl.Clear();
            foreach (var it in bl) 
            {
                _bl.Add(it);
            }
            _bs.CurrencyManager.Refresh();
        }

        public void EliminarItem()
        {
            if (_bs.Current != null)
            {
                eliminar();
            }
        }

        private void eliminar()
        {
            var it = (Item.data)_bs.Current;
            var ficha = new OOB.Venta.Item.Eliminar.Ficha()
            {
                idOperador = it.Ficha.idOperador,
                idItem = it.Ficha.id,
                autoProducto = it.Ficha.autoProducto,
                autoDeposito = it.Ficha.autoDeposito,
                cantUndBloq = it.TotalUnd,
            };
            var r01 = Sistema.MyData.Venta_Item_Eliminar(ficha);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _fichaCambio = true;
            _bl.Remove(it);
            Helpers.Sonido.SonidoOk();
        }

        public void DevolerItem()
        {
            if (_bs.Current != null)
            {
                var it = (Item.data)_bs.Current;
                if (it.EsPesado) 
                {
                    Helpers.Msg.Error("PRODUCTO PESADO DEBE SER ELIMINADO POR COMPLETO");
                    return;
                }

                if (it.Cantidad == 1)
                {
                    eliminar();
                }
                else 
                {
                    var ficha = new OOB.Venta.Item.ActualizarCantidad.Disminuir.Ficha()
                    {
                        idOperador = it.Ficha.idOperador,
                        idItem = it.Ficha.id,
                        autoProducto = it.Ficha.autoProducto,
                        autoDeposito = it.Ficha.autoDeposito,
                        cantUndBloq = it.ContenidoEmp,
                        cantidad = 1,
                    };
                    var r01 = Sistema.MyData.Venta_Item_ActualizarCantidad_Disminuir(ficha);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    it.setDisminuyeCantidad(1);
                    _fichaCambio = true;
                    Helpers.Sonido.SonidoOk();
                }
                _bs.CurrencyManager.Refresh();
            }
        }

    }

}