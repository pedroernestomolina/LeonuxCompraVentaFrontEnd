using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Reportes.Filtro
{

    public partial class FiltroFrm : Form
    {

        private Gestion _controlador;


        public FiltroFrm()
        {
            InitializeComponent();
            InicializaControles();
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }


        private void InicializaControles()
        {
            CB_SUCURSAL.DisplayMember = "Nombre";
            CB_SUCURSAL.ValueMember = "Auto";
            CB_ESTATUS.DisplayMember = "Descripcion";
            CB_ESTATUS.ValueMember = "Id";
        }

        private bool modoInicializar; 
        private void FiltrosFrm_Load(object sender, EventArgs e)
        {
            modoInicializar = true;
            L_ESTATUS.Enabled = _controlador.ActivarEstatus;
            CB_ESTATUS.DataSource = _controlador.SourceEstatus;
            CB_ESTATUS.Enabled = _controlador.ActivarEstatus;

            L_SUCURSAL.Enabled = _controlador.ActivarSucursal;
            CB_SUCURSAL.DataSource = _controlador.SourceSucursal;
            CB_SUCURSAL.Enabled = _controlador.ActivarSucursal;

            L_MES_ANO_RELACION.Enabled = _controlador.ActivarMesAnoRelacion;
            TB_MES_RELACION.Enabled = _controlador.ActivarMesAnoRelacion;
            TB_ANO_RELACION.Enabled = _controlador.ActivarMesAnoRelacion;

            L_DESDE.Enabled = _controlador.ActivarDesdeHasta;
            L_HASTA.Enabled = _controlador.ActivarDesdeHasta;
            DTP_DESDE.Enabled= _controlador.ActivarDesdeHasta;
            DTP_HASTA.Enabled = _controlador.ActivarDesdeHasta;

            L_CLIENTE.Enabled = _controlador.ActivarCliente;
            TB_CLIENTE.Enabled = _controlador.ActivarCliente;
            BT_CLIENTE_BUSCAR.Enabled = _controlador.ActivarCliente;

            L_TIPO_DOCUMENTO.Enabled = _controlador.ActivarTipoDocumento;
            CHB_FACTURA.Enabled = _controlador.ActivarTipoDocumento;
            CHB_NT_DEBITO.Enabled = _controlador.ActivarTipoDocumento;
            CHB_NT_CREDITO.Enabled = _controlador.ActivarTipoDocumento;
            CHB_NT_ENTREGA.Enabled = _controlador.ActivarTipoDocumento;

            LimpiarFiltros();
            modoInicializar = false;

            DTP_DESDE.Value = _controlador.FechaDesde;
            DTP_HASTA.Value = _controlador.FechaHasta;
            CB_SUCURSAL.SelectedValue = _controlador.IdSucursal;
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            LImpiarEstatus();
            LimpiarFechaDesde();
            LimpiarFechaHasta();
            LimpiarSucursal();
            LimpiarMesAnoRelacion();
            LimpiarTipoDocumento();
            LimpiarCliente();
        }

        private void L_SUCURSAL_Click(object sender, EventArgs e)
        {
            LimpiarSucursal();
        }

        private void LimpiarSucursal()
        {
            CB_SUCURSAL.SelectedIndex = -1;
        }

        private void L_ESTATUS_Click(object sender, EventArgs e)
        {
            LImpiarEstatus();
        }

        private void LImpiarEstatus()
        {
            CB_ESTATUS.SelectedIndex = -1;
        }

        private void L_DESDE_Click(object sender, EventArgs e)
        {
            LimpiarFechaDesde();
        }

        private void LimpiarFechaDesde()
        {
            if (_controlador.ActivarDesdeHasta) 
            {
                DTP_DESDE.Value = DateTime.Now.Date;
            }
        }

        private void L_HASTA_Click(object sender, EventArgs e)
        {
            LimpiarFechaHasta();
        }

        private void LimpiarFechaHasta()
        {
            if (_controlador.ActivarDesdeHasta)
            {
                DTP_HASTA.Value = DateTime.Now.Date;
            }
        }

        private void L_MES_ANO_RELACION_Click(object sender, EventArgs e)
        {
            LimpiarMesAnoRelacion();
        }

        private void LimpiarMesAnoRelacion()
        {
            if (_controlador.ActivarMesAnoRelacion) 
            {
                TB_MES_RELACION.Value = DateTime.Now.Month;
                TB_ANO_RELACION.Value = DateTime.Now.Year;
            }
        }

        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modoInicializar)
                return;

            _controlador.setSucursal("");
            if (CB_SUCURSAL.SelectedIndex != -1)
            {
                _controlador.setSucursal(CB_SUCURSAL.SelectedValue.ToString());
            }
        }

        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modoInicializar)
                return;

            _controlador.setEstatus("");
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.setEstatus(CB_ESTATUS.SelectedValue.ToString());
            }
        }

        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            if (modoInicializar)
                return;

            _controlador.setFechaDesde(DTP_DESDE.Value);
        }

        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            if (modoInicializar)
                return;

            _controlador.setFechaHasta(DTP_HASTA.Value);
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            _controlador.Salir();
            this.Close();
        }

        private void BT_FILTRAR_Click(object sender, EventArgs e)
        {
            _controlador.Filtrar();
            if (_controlador.IsOk)
            {
                Salir();
            }
        }

        private void TB_MES_RELACION_ValueChanged(object sender, EventArgs e)
        {
            if (modoInicializar)
                return;

            _controlador.setMesRelacion((int)TB_MES_RELACION.Value);
        }

        private void TB_ANO_RELACION_ValueChanged(object sender, EventArgs e)
        {
            if (modoInicializar)
                return;

            _controlador.setAnoRelacion((int)TB_ANO_RELACION.Value);
        }

        private void BT_CLIENTE_BUSCAR_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void BuscarCliente()
        {
            _controlador.BuscarCliente();
            if (_controlador.ClienteSeleccionadoIsOK)
            {
                TB_CLIENTE.Text = _controlador.NombreCliente;
            }
            else 
            {
                TB_CLIENTE.Text = "";
            }
        }

        private void FiltroFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_controlador.IsOk)
            {
                e.Cancel = true;
            }
        }

        private void L_TIPO_DOCUMENTO_Click(object sender, EventArgs e)
        {
            LimpiarTipoDocumento();
        }

        private void LimpiarTipoDocumento()
        {
            if (_controlador.ActivarTipoDocumento)
            {
                CHB_FACTURA.Checked = false;
                CHB_NT_DEBITO.Checked = false;
                CHB_NT_CREDITO.Checked = false;
                CHB_NT_ENTREGA.Checked = false;
            }
        }

        private void CHB_FACTURA_CheckedChanged(object sender, EventArgs e)
        {
            if (modoInicializar)
                return;

            _controlador.setTipoDocFactura(CHB_FACTURA.Checked);
        }

        private void CHB_NT_DEBITO_CheckedChanged(object sender, EventArgs e)
        {
            if (modoInicializar)
                return;

            _controlador.setTipoDocNtDebito(CHB_NT_DEBITO.Checked);
        }

        private void CHB_NT_CREDITO_CheckedChanged(object sender, EventArgs e)
        {
            if (modoInicializar)
                return;

            _controlador.setTipoDocNtCredito(CHB_NT_CREDITO.Checked);
        }

        private void CHB_NT_ENTREGA_CheckedChanged(object sender, EventArgs e)
        {
            if (modoInicializar)
                return;

            _controlador.setTipoDocNtEntrega(CHB_NT_ENTREGA.Checked);
        }

        private void TB_CLIENTE_Leave(object sender, EventArgs e)
        {
            _controlador.setCliente(TB_CLIENTE.Text);
        }

        private void L_CLIENTE_Click(object sender, EventArgs e)
        {
            LimpiarCliente();
        }

        private void LimpiarCliente()
        {
            _controlador.LimpiarCliente();
            TB_CLIENTE.Text = "";
        }

    }

}