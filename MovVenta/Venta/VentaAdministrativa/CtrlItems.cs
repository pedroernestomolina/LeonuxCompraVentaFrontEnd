using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MovVenta.Venta.VentaAdministrativa
{

    public class CtrlItems
    {

        public event EventHandler ItemOk;


        private List<Detalle> Items; 
        private BindingSource bsDetalle;
        private BindingList<Detalle> blDetalle;
        private bool _habilitarRupturaPorExistencia;
        private bool _habilitarAlertaPorExistenciaEnNegativo;
        private OOB.LibVenta.Permiso.Ficha _darPermisoDescuentoItem;
        private OOB.LibVenta.Permiso.Ficha _darPermisoPrecioLibre; 
        private OOB.LibVenta.Deposito.Ficha _depositoSeleccionado;
        private OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio _tarifaPrecioSeleccionado;
        private decimal _factorCambioParaRecibirDivisa;


        public BindingSource Source 
        {
            get 
            {
                return bsDetalle;
            }
        }

        public int Renglones
        {
            get
            {
                var rt = 0;
                rt = Items.Count();
                return rt;
            }
        }

        public decimal SubTotal
        {
            get
            {
                return Items.Sum(s => s.Total);
            }
        }

        public List<Detalle> ListaItems 
        {
            get { return Items; }
        }


        public CtrlItems()
        {
            Items = new List<Detalle>();
            blDetalle = new BindingList<Detalle>(Items);
            bsDetalle = new BindingSource();
            bsDetalle.DataSource = blDetalle;
        }


        public void Limpiar() 
        {
            blDetalle.Clear();
            Notificar();
        }

        private Producto.Buscar.BuscarFrm frmProducto = null;
        public void BuscarProducto()
        {
            if (frmProducto == null)
            {
                frmProducto = new Producto.Buscar.BuscarFrm();
                frmProducto.ProductoOK += frmProducto_ProductoOK;
            }
            if (frmProducto.CargarData())
            {
                frmProducto.ShowDialog();
            }
        }

        public void EliminarItem()
        {
            var dt = (Detalle)bsDetalle.Current;
            if (dt != null)
            {
                blDetalle.Remove(dt);
                Notificar();
            }
        }

        public void EditarItem() 
        {
            var dt = (Detalle)bsDetalle.Current;
            if (dt != null)
            {
                frmDetalle.setItemEditar(dt);
                frmDetalle.ShowDialog();
            }
        }

        VentaDetalleAdmFrm frmDetalle = null;
        private void frmProducto_ProductoOK(object sender, Producto.Buscar.ProductoSelected e)
        {
            if (!e.IsActivo)
            {
                Helpers.Msg.Error("PRODUCTO SELECCIONADO EN ESTADO INACTIVO");
                return;
            }

            frmProducto.Hide();

            if (frmDetalle == null)
            {
                frmDetalle = new VentaDetalleAdmFrm();
                frmDetalle.ItemOK += frmDetalle_ItemOK;
                frmDetalle.ItemEditarOK += frmDetalle_ItemEditarOK;
            }
            frmDetalle.Generar();
            frmDetalle.setDepositoSeleccionado(_depositoSeleccionado);
            frmDetalle.setTariafaPrecioSeleccionado(_tarifaPrecioSeleccionado);
            frmDetalle.setAutoProductoSeleccionado(e.AutoProducto);
            if (frmDetalle.CargarData())
            {
                frmDetalle.setPermisoDarDescuento(_darPermisoDescuentoItem);
                frmDetalle.setPermisoPrecioLibre(_darPermisoPrecioLibre);
                frmDetalle.setHabilitarRupturaPorExistencia(_habilitarRupturaPorExistencia);
                frmDetalle.setHabilitarAlertaPorExistenciaNegativa(_habilitarAlertaPorExistenciaEnNegativo);
                frmDetalle.ShowDialog();
            }

            frmProducto.Close();
        }

        private void frmDetalle_ItemOK(object sender, Detalle e)
        {
            blDetalle.Add(e);
            Notificar();
        }

        private void frmDetalle_ItemEditarOK(object sender, Detalle e)
        {
            var dt = (Detalle)bsDetalle.Current;
            blDetalle.Remove(dt);
            blDetalle.Add(e);
            Notificar();
        }

        private void Notificar()
        {
            EventHandler handler = ItemOk;
            if (handler != null)
            {
                handler(this, null);
            }
        }

        public void setDepositoSeleccionado(OOB.LibVenta.Deposito.Ficha deposito)
        {
            _depositoSeleccionado = deposito;
        }

        public void setPermisoDarDescuento(OOB.LibVenta.Permiso.Ficha darPermisoDescuentoItem)
        {
            _darPermisoDescuentoItem = darPermisoDescuentoItem;
        }

        public void setPermisoPrecioLibre (OOB.LibVenta.Permiso.Ficha permiso )
        {
            _darPermisoPrecioLibre = permiso;
        }

        public void setHabilitarRupturaPorExistencia(bool habilitarRupturaPorExistencia)
        {
            _habilitarRupturaPorExistencia = habilitarRupturaPorExistencia;
        }

        public void setHabilitarAlertaPorExistenciaNegativa(bool habilitarAlertaPorExistenciaEnNegativo)
        {
            _habilitarAlertaPorExistenciaEnNegativo = habilitarAlertaPorExistenciaEnNegativo;
        }

        public void setTarifaPrecioSeleccionado(OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio tarifaPrecioSeleccionado)
        {
            _tarifaPrecioSeleccionado = tarifaPrecioSeleccionado;
        }

        public void setFactorCambioParaRecibirDivisa(decimal factor)
        {
            _factorCambioParaRecibirDivisa = factor;
        }

    }

}