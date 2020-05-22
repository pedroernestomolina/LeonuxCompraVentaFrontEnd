using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MovVenta.Venta.VentaAdministrativa
{

    public partial class VentaDetalleAdmFrm : Form
    {

        public event EventHandler<Detalle> ItemOK;
        public event EventHandler<Detalle> ItemEditarOK;


        private Detalle _detalle;
        private string _autoProductoSeleccionado;
        private OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio _tarifaPrecioSeleccionado;
        private OOB.LibVenta.Deposito.Ficha _depositoSeleccionado; 
        private bool _habilitarAlertaPorExistenciaNegativa;
        private OOB.LibVenta.Permiso.Ficha _permisoDarDescuento;
        private OOB.LibVenta.Permiso.Ficha _permisoPrecioLibre;
        private bool _modoEditar;


        public VentaDetalleAdmFrm()
        {
            InitializeComponent();
            _habilitarAlertaPorExistenciaNegativa = true;
            _permisoDarDescuento = new OOB.LibVenta.Permiso.Ficha();
            _permisoPrecioLibre = new OOB.LibVenta.Permiso.Ficha();
            _modoEditar = false;
        }


        public void Generar() 
        {
            _detalle = new Detalle();
            _modoEditar = false;
        }

        public bool CargarData() 
        {
            var rt = true;
            var idPrecio = "";
            switch (_tarifaPrecioSeleccionado)
            {
                case OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio.Tarifa_1:
                    idPrecio = "1";
                    break;
                case OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio.Tarifa_2:
                    idPrecio = "2";
                    break;
                case OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio.Tarifa_3:
                    idPrecio = "3";
                    break;
                case OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio.Tarifa_4:
                    idPrecio = "4";
                    break;
            }
            
            var r01 = Program.MyData.Existencia(_autoProductoSeleccionado, _depositoSeleccionado.Auto);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _detalle.Existencia = new Existencia(r01.Entidad);

            var r02 = Program.MyData.Precio(_autoProductoSeleccionado, idPrecio);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            _detalle.Precio=new Precio(r02.Entidad);
            if (r02.Entidad.PrecioNeto == 0.0m) 
            {
                Helpers.Msg.Error("PRODUCTO NO POSEE PRECIO DEFINIDO PARA LA TARIFA # "+idPrecio.ToString());
                return false;
            }

            var r03 = Program.MyData.Producto(_autoProductoSeleccionado);
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            _detalle.Producto = r03.Entidad;
            _detalle.Precio.SetTasaImpuesto(r03.Entidad.TasaImpuesto);
            _detalle.Precio.SetCostoUnd(r03.Entidad.CostoUnidad);

            return rt;
        }

        private void VentaDetalleAdmFrm_Load(object sender, EventArgs e)
        {
            TB_DSCTO.Enabled = _permisoDarDescuento.IsHabilitado;
            Limpiar();
        }

        private void Limpiar()
        {
            TB_CANTIDAD.Text = _detalle.Existencia.CantUndDespachar.ToString("0.00");
            TB_PRECIO.Text = _detalle.Precio.PrecioNeto.ToString("0.00");
            TB_DSCTO.Text = _detalle.Precio.DescuentoItemPorcentaje.ToString("0.00");
            TB_IMPORTE.Text = _detalle.Importe.ToString("0.00");
            TB_NOTAS.Text = _detalle.Notas;
        }

        private void TB_CANTIDAD_Validated(object sender, EventArgs e)
        {
            _detalle.Existencia.setCantUndDespachar(decimal.Parse(TB_CANTIDAD.Text));
            ActuailizarImporte();
        }

        private void TB_CANTIDAD_Validating(object sender, CancelEventArgs e)
        {
            if (_detalle.Existencia.VerificarExistencia(decimal.Parse(TB_CANTIDAD.Text)))
            {
                e.Cancel = false;
            }
            else 
            {
                e.Cancel = true;
            }
        }

        private void TB_PRECIO_Validating(object sender, CancelEventArgs e)
        {
            if (_detalle.Precio.VerificarPrecio(decimal.Parse(TB_PRECIO.Text)))
            {
                e.Cancel = false;
                if (_permisoPrecioLibre.NivelSeguridad == OOB.LibVenta.Permiso.Enumerados.EnumNivelSeguridad.Niguna)
                {
                    e.Cancel = false;
                }
                else
                {
                    Helpers.Msg.Alerta("NECESITAS CLAVE PARA ACTIVAR OPCION");
                    e.Cancel = true;
                }
            }
            else 
            {
                e.Cancel = true;
            }
        }

        private void TB_PRECIO_Validated(object sender, EventArgs e)
        {
            _detalle.Precio.SetPrecio(decimal.Parse(TB_PRECIO.Text));
            ActuailizarImporte();
        }

        private void TB_DSCTO_Validating(object sender, CancelEventArgs e)
        {
            if (_detalle.Precio.VerificarDscto(decimal.Parse(TB_DSCTO.Text)))
            {
                if (_permisoDarDescuento.NivelSeguridad == OOB.LibVenta.Permiso.Enumerados.EnumNivelSeguridad.Niguna)
                {
                    e.Cancel = false;
                }
                else
                {
                    Helpers.Msg.Alerta("NECESITAS CLAVE PARA ACTIVAR OPCION");
                    e.Cancel = true;
                }
            }
            else 
            {
                e.Cancel = true;
            }
        }

        private void TB_DSCTO_Validated(object sender, EventArgs e)
        {
            _detalle.Precio.SetDescuentoItem(decimal.Parse(TB_DSCTO.Text));
            ActuailizarImporte();
        }

        private void TB_NOTAS_Validated(object sender, EventArgs e)
        {
            _detalle.Notas = TB_NOTAS.Text;
        }

        private void ActuailizarImporte()
        {
            TB_IMPORTE.Text = _detalle.Importe.ToString("0.00");
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            if (_detalle.Importe > 0) 
            {
                if (_habilitarAlertaPorExistenciaNegativa) 
                {
                    if (_detalle.Existencia.VerificarExistenciaNegativa)
                    {
                        var rt= MessageBox.Show("Cantidad A Despachar SobrePasa La Existencia Del Producto\n Procesar Item ?", 
                            "*** ALERTA ***",  MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (rt == System.Windows.Forms.DialogResult.No)
                            return;
                    }  
                }

                if (!_modoEditar)
                {
                    EventHandler<Detalle> handler = ItemOK;
                    if (handler != null)
                    {
                        handler(this, _detalle);
                    }
                }
                else 
                {
                    EventHandler<Detalle> handler = ItemEditarOK ;
                    if (handler != null)
                    {
                        handler(this, _detalle);
                    }
                }
                Close();
            }
        }

        public void setHabilitarRupturaPorExistencia(bool modo)
        {
            _detalle.setHabilitarRupturaPorExistencia(modo);
        }

        public void setHabilitarAlertaPorExistenciaNegativa(bool modo) 
        {
            _habilitarAlertaPorExistenciaNegativa = modo;
        }

        public void setDepositoSeleccionado(OOB.LibVenta.Deposito.Ficha ficha)
        {
            _depositoSeleccionado = ficha;
        }
        
        public void setTariafaPrecioSeleccionado(OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio  tarifa)
        {
            _tarifaPrecioSeleccionado = tarifa;
        }

        public void setAutoProductoSeleccionado(string autoPrd)
        {
            _autoProductoSeleccionado = autoPrd; 
        }

        public void setPermisoDarDescuento(OOB.LibVenta.Permiso.Ficha permiso)
        {
            _permisoDarDescuento = permiso;
            TB_DSCTO.Enabled = permiso.IsHabilitado;
        }

        public void setPermisoPrecioLibre (OOB.LibVenta.Permiso.Ficha permiso)
        {
            _permisoPrecioLibre = permiso;
            TB_PRECIO.Enabled = permiso.IsHabilitado;
        }

        public void setItemEditar(Detalle dt) 
        {
            _detalle = dt;
            _modoEditar = true;
        }

    }

}