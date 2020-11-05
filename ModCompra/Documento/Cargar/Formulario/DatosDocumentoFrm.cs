using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Formulario
{

    public partial class DatosDocumentoFrm : Form
    {

        private Controlador.GestionDocumento _controlador;


        public DatosDocumentoFrm()
        {
            InitializeComponent();
            InicializarComboBox();

        }

        private void InicializarComboBox()
        {
            CB_SUCURSAL.ValueMember = "codigo";
            CB_SUCURSAL.DisplayMember = "nombre";

            CB_DEPOSITO.ValueMember = "auto";
            CB_DEPOSITO.DisplayMember = "nombre";
        }

        public void setControlador(Controlador.GestionDocumento ctr)
        {
            _controlador = ctr;
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void Aceptar()
        {
            salirIsOk = false;
            _controlador.Aceptar();
            if (_controlador.IsAceptarOk)
                Salir();
        }

        private void TB_DOCUMENTO_NRO_Leave(object sender, EventArgs e)
        {
            _controlador.DocumentoNro = TB_DOCUMENTO_NRO.Text.Trim().ToUpper();
        }

        private void DTP_FECHA_EIMSION_ValueChanged(object sender, EventArgs e)
        {
            _controlador.FechaEmision = DTP_FECHA_EIMSION.Value.Date;
            ActualizarFechaVencimiento();
        }

        private void ActualizarFechaVencimiento()
        {
            L_FECHA_VENCIMIENTO.Text = _controlador.FechaVencimiento.ToShortDateString();
        }

        private void TB_DIAS_CREDITO_ValueChanged(object sender, EventArgs e)
        {
            _controlador.DiasCredito = (int) TB_DIAS_CREDITO.Value;
            ActualizarFechaVencimiento();
        }

        private void TB_NOTAS_Leave(object sender, EventArgs e)
        {
            _controlador.Notas = TB_NOTAS.Text.Trim();
        }

        private void TB_CONTROL_NRO_Leave(object sender, EventArgs e)
        {
            _controlador.ControlNro = TB_CONTROL_NRO.Text.Trim().ToUpper(); 
        }

        private void TB_ORDEN_COMPRA_Leave(object sender, EventArgs e)
        {
            _controlador.OrdenCompraNro = TB_ORDEN_COMPRA.Text.Trim().ToUpper();
        }

        private void TB_FACTOR_DIVISA_Leave(object sender, EventArgs e)
        {
            _controlador.FactorDivisa = decimal.Parse(TB_FACTOR_DIVISA.Text);
        }

        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.IdSucursal = "";
            if (CB_SUCURSAL.SelectedIndex!=-1)
                _controlador.IdSucursal = (string)CB_SUCURSAL.SelectedValue;
        }

        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.IdDeposito = "";
            if (CB_DEPOSITO.SelectedIndex != -1)
                _controlador.IdDeposito= (string)CB_DEPOSITO.SelectedValue;
        }


        private void DatosDocumentoFrm_Load(object sender, EventArgs e)
        {
            L_RIF.Text = _controlador.RifProveedor;
            L_RAZON_SOCIAL.Text = _controlador.RazonSocialProveedor;
            L_DIRECCION_FISCAL.Text=_controlador.DireccionProveedor;

            DTP_FECHA_EIMSION.Value = _controlador.FechaEmision;
            TB_DOCUMENTO_NRO.Text = _controlador.DocumentoNro;
            TB_CONTROL_NRO.Text = _controlador.ControlNro;
            TB_DIAS_CREDITO.Value = _controlador.DiasCredito;
            TB_ORDEN_COMPRA.Text = _controlador.OrdenCompraNro;
            TB_FACTOR_DIVISA.Text = _controlador.FactorDivisa.ToString();
            TB_NOTAS.Text = _controlador.Notas;
            L_FECHA_VENCIMIENTO.Text = _controlador.FechaVencimiento.ToShortDateString();
            L_ANO_RELACION.Text = _controlador.AnoRelacion;
            L_MES_RELACION.Text = _controlador.MesRelacion;

            CB_SUCURSAL.DataSource = _controlador.SucursalSource;
            CB_DEPOSITO.DataSource = _controlador.DepositoSource;
            CB_SUCURSAL.SelectedIndex=-1;
            CB_DEPOSITO.SelectedIndex=-1;

            switch (_controlador.PreferenciaBusquedaProveedor) 
            {
                case Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda.Codigo:
                    RB_BUSCAR_POR_CODIGO.Checked = true;
                    break;
                case Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda.CiRif:
                    RB_BUSCAR_POR_RIF.Checked = true;
                    break;
                case Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda.Nombre:
                    RB_BUSCAR_POR_NOMBRE.Checked = true;
                    break;
            }
        }

        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        bool salirIsOk;
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            salirIsOk = false;
            var msg = MessageBox.Show("Abandonar Ficha ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            { 
                salirIsOk=true;
                Salir();
            }
        }

        private void Salir()
        {
            this.Close();
        }

        private void DatosDocumentoFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_controlador.IsAceptarOk || salirIsOk)
                e.Cancel = false;
            else 
            {
                e.Cancel = true;
            }
        }

    }

}