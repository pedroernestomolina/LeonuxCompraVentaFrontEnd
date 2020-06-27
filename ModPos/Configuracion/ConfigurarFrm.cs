using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Configuracion
{

    public partial class ConfigurarFrm : Form
    {


        public configurar _controlador {get;set;}


        public ConfigurarFrm()
        {
            InitializeComponent();
        }


        private void Inicializar() 
        {
            CB_DEPOSITO.DisplayMember = "Nombre";
            CB_DEPOSITO.ValueMember = "Auto";
            CB_DEPOSITO.DataSource =  _controlador._bs_Deposito;

            CB_COBRADOR.DisplayMember = "Nombre";
            CB_COBRADOR.ValueMember = "Auto";
            CB_COBRADOR.DataSource = _controlador._bs_Cobrador;

            CB_VENDEDOR.DisplayMember = "Nombre";
            CB_VENDEDOR.ValueMember = "Auto";
            CB_VENDEDOR.DataSource = _controlador._bs_Vendedor;

            CB_TRANSPORTE.DisplayMember = "Nombre";
            CB_TRANSPORTE.ValueMember = "Auto";
            CB_TRANSPORTE.DataSource = _controlador._bs_Transporte;

            CB_TRANSPORTE.DisplayMember = "Nombre";
            CB_TRANSPORTE.ValueMember = "Auto";
            CB_TRANSPORTE.DataSource = _controlador._bs_Transporte;

            CB_FACTURA.DisplayMember = "Nombre";
            CB_FACTURA.ValueMember = "Auto";
            CB_FACTURA.DataSource = _controlador._bs_SerieFactura;

            CB_NOTA_CREDITO.DisplayMember = "Nombre";
            CB_NOTA_CREDITO.ValueMember = "Auto";
            CB_NOTA_CREDITO.DataSource = _controlador._bs_SerieNotaCredito;

            CB_NOTA_DEBITO.DisplayMember = "Nombre";
            CB_NOTA_DEBITO.ValueMember = "Auto";
            CB_NOTA_DEBITO.DataSource = _controlador._bs_SerieNotaDebito;

            CB_NOTA_ENTREGA.DisplayMember = "Nombre";
            CB_NOTA_ENTREGA.ValueMember = "Auto";
            CB_NOTA_ENTREGA.DataSource = _controlador._bs_SerieNotaEntrega;

            CB_MEDIO_EFECTIVO.DisplayMember = "Nombre";
            CB_MEDIO_EFECTIVO.ValueMember = "Auto";
            CB_MEDIO_EFECTIVO.DataSource = _controlador._bs_MedioEfectivo;

            CB_MEDIO_DIVISA.DisplayMember = "Nombre";
            CB_MEDIO_DIVISA.ValueMember = "Auto";
            CB_MEDIO_DIVISA.DataSource = _controlador._bs_MedioDivisa;

            CB_MEDIO_ELECTRONICO.DisplayMember = "Nombre";
            CB_MEDIO_ELECTRONICO.ValueMember = "Auto";
            CB_MEDIO_ELECTRONICO.DataSource = _controlador._bs_MedioElectronico;

            CB_MEDIO_OTRO.DisplayMember = "Nombre";
            CB_MEDIO_OTRO.ValueMember = "Auto";
            CB_MEDIO_OTRO.DataSource = _controlador._bs_MedioOtro;

            CB_MOV_VENTA.DisplayMember = "Nombre";
            CB_MOV_VENTA.ValueMember = "Auto";
            CB_MOV_VENTA.DataSource = _controlador._bs_MovVenta;

            CB_MOV_DEV_VENTA.DisplayMember = "Nombre";
            CB_MOV_DEV_VENTA.ValueMember = "Auto";
            CB_MOV_DEV_VENTA.DataSource = _controlador._bs_MovDevVenta;

            CB_MOV_SALIDA.DisplayMember = "Nombre";
            CB_MOV_SALIDA.ValueMember = "Auto";
            CB_MOV_SALIDA.DataSource = _controlador._bs_MovSalida;

            TB_CODIGO_SUCURSAL.Text = "";
            ND_LIMITE_INFERIOR.Text = "0,0";
            ND_LIMITE_SUPERIOR.Text = "0,0";
            TB_TARIFA.Text = "";
            CHB_ETIQUETAR_PRECIO_NEGOCIO.Checked = false;
            CHB_REPESAJE.Checked = false;
            CHB_ACTIVAR_BUSQUEDA_POR_DESCRIPCION.Checked =false;
        }


        private void ConfigurarFrm_Load(object sender, EventArgs e)
        {
            Inicializar();

            CB_MEDIO_EFECTIVO.SelectedValue = _controlador.CnfActual.AutoMedioEfectivo;
            CB_MEDIO_DIVISA.SelectedValue = _controlador.CnfActual.AutoMedioDivisa;
            CB_MEDIO_ELECTRONICO.SelectedValue = _controlador.CnfActual.AutoMedioElectronico;
            CB_MEDIO_OTRO.SelectedValue = _controlador.CnfActual.AutoMedioOtro;

            CB_DEPOSITO.SelectedValue = _controlador.CnfActual.AutoDeposito;
            CB_TRANSPORTE.SelectedValue = _controlador.CnfActual.AutoTransporte;
            CB_COBRADOR.SelectedValue = _controlador.CnfActual.AutoCobrador;
            CB_VENDEDOR.SelectedValue = _controlador.CnfActual.AutoVendedor;

            CB_FACTURA.SelectedValue = _controlador.CnfActual.SerieFactura;
            CB_NOTA_CREDITO.SelectedValue = _controlador.CnfActual.SerieNotaCredito;
            CB_NOTA_DEBITO.SelectedValue = _controlador.CnfActual.SerieNotaDebito;
            CB_NOTA_ENTREGA.SelectedValue = _controlador.CnfActual.SerieNotaEntrega;

            CB_MOV_VENTA.SelectedValue = _controlador.CnfActual.AutoMovConceptoVenta;
            CB_MOV_DEV_VENTA.SelectedValue = _controlador.CnfActual.AutoMovConceptoDevVenta;
            CB_MOV_SALIDA.SelectedValue = _controlador.CnfActual.AutoMovConceptoSalida;

            TB_CODIGO_SUCURSAL.Text = _controlador.CnfActual.CodigoSucursal;
            TB_TARIFA.Text = _controlador.CnfActual.TarifaPrecio;
            ND_LIMITE_INFERIOR.Text = _controlador.CnfActual.LimiteInferiorRepesaje.ToString("n3");
            ND_LIMITE_SUPERIOR.Text = _controlador.CnfActual.LimiteSuperiorRepesaje.ToString("n3");
            CHB_REPESAJE.Checked = _controlador.CnfActual.ActivarRepesaje;
            CHB_ACTIVAR_BUSQUEDA_POR_DESCRIPCION.Checked = _controlador.CnfActual.ActivarBusquedaPorDescripcion;
            CHB_REPESAJE.Checked = _controlador.CnfActual.ActivarRepesaje;
            CB_CLAVE.SelectedIndex = _controlador.CnfActual.ClavePos - 1;
            CHB_ETIQUETAR_PRECIO_NEGOCIO.Checked = _controlador.CnfActual.EtiquetarPrecioPorTipoNegocio;
            TB_ID_EQUIPO.Text = _controlador.CnfActual.EquipoNumero;

            ND_LIMITE_INFERIOR.Enabled = _controlador.CnfActual.ActivarRepesaje;
            ND_LIMITE_SUPERIOR.Enabled = _controlador.CnfActual.ActivarRepesaje;
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            GuardarCambios();
        }

        public void GuardarCambios()
        {
            _controlador.CnfNueva.LimInfRepesaje = decimal.Parse(ND_LIMITE_INFERIOR.Text);
            _controlador.CnfNueva.LimSupRepesaje = decimal.Parse(ND_LIMITE_SUPERIOR.Text);
            _controlador.CnfNueva.IdEquipo = TB_ID_EQUIPO.Text.Trim().ToUpper();  
            if (_controlador.Guardar())
            {
                Salir();
            }
        }

        private void CHB_REPESAJE_CheckedChanged(object sender, EventArgs e)
        {
            ND_LIMITE_INFERIOR.Enabled = CHB_REPESAJE.Checked;
            ND_LIMITE_SUPERIOR.Enabled = CHB_REPESAJE.Checked;
            _controlador.CnfNueva.ActivarRepesaje = CHB_REPESAJE.Checked;
        }

        public void setControlador(configurar ctr)
        {
            _controlador = ctr;
        }

        private void CB_MEDIO_EFECTIVO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.CnfNueva.aMedioEfectivo = CB_MEDIO_EFECTIVO.SelectedValue.ToString();
        }

        private void CB_MEDIO_DIVISA_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.CnfNueva.aMedioDivisa = CB_MEDIO_DIVISA.SelectedValue.ToString();
        }

        private void CB_MEDIO_ELECTRONICO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.CnfNueva.aMedioElectronico = CB_MEDIO_ELECTRONICO.SelectedValue.ToString();
        }

        private void CB_MEDIO_OTRO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.CnfNueva.aMedioOtro = CB_MEDIO_OTRO.SelectedValue.ToString();
        }

        private void CB_COBRADOR_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.CnfNueva.aCobrador = CB_COBRADOR.SelectedValue.ToString();
        }

        private void CB_VENDEDOR_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.CnfNueva.aVendedor = CB_VENDEDOR.SelectedValue.ToString();
        }

        private void CB_TRANSPORTE_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.CnfNueva.aTransporte = CB_TRANSPORTE.SelectedValue.ToString();
        }

        private void CB_MOV_VENTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.CnfNueva.aMovVenta = CB_MOV_VENTA.SelectedValue.ToString();
        }

        private void CB_MOV_DEV_VENTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.CnfNueva.aMovDevVenta = CB_MOV_DEV_VENTA.SelectedValue.ToString();
        }

        private void CB_MOV_SALIDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.CnfNueva.aMovSalida = CB_MOV_SALIDA.SelectedValue.ToString();
        }

        private void CB_FACTURA_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.CnfNueva.aSerieFactura = CB_FACTURA.SelectedValue.ToString();
        }

        private void CB_NOTA_CREDITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.CnfNueva.aSerieNCredito = CB_NOTA_CREDITO.SelectedValue.ToString();
        }

        private void CB_NOTA_DEBITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.CnfNueva.aSerieNDebito = CB_NOTA_DEBITO.SelectedValue.ToString();
        }

        private void CB_NOTA_ENTREGA_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.CnfNueva.aSerieNEntrega = CB_NOTA_ENTREGA.SelectedValue.ToString();
        }

        private void CHB_ACTIVAR_BUSQUEDA_POR_DESCRIPCION_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.CnfNueva.ActivarBusqPorDescripcion = CHB_ACTIVAR_BUSQUEDA_POR_DESCRIPCION.Checked; 
        }

        private void CB_CLAVE_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.CnfNueva.indClave = CB_CLAVE.SelectedIndex ; 
        }

        private void TB_ID_EQUIPO_TextChanged(object sender, EventArgs e)
        {
            _controlador.CnfNueva.IdEquipo = TB_ID_EQUIPO.Text;  
        }

    }

}