using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.ControlAcceso
{
    public partial class ControlAccesoFrm : Form
    {

        private Gestion _controlador;


        public ControlAccesoFrm()
        {
            InitializeComponent();
            InicializaGrid();
        }

        private void InicializaGrid()
        {
            IniGridCliente();
            IniGridProveedor();
            IniGridInventario();
            IniGridCompra();
            IniGridVenta();
            IniGridSistema();
        }

        private void IniGridSistema()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            DG_SIST.AllowUserToAddRows = false;
            DG_SIST.AllowUserToDeleteRows = false;
            DG_SIST.AutoGenerateColumns = false;
            DG_SIST.AllowUserToResizeRows = false;
            DG_SIST.AllowUserToResizeColumns = false;
            DG_SIST.AllowUserToOrderColumns = false;
            DG_SIST.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DG_SIST.MultiSelect = false;
            DG_SIST.ReadOnly = false;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Funcion";
            c1.HeaderText = "Función";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c1.ReadOnly = true;

            var c2 = new DataGridViewCheckBoxColumn();
            c2.DataPropertyName = "Estatus";
            c2.HeaderText = "Estatus";
            c2.Visible = true;
            c2.Width = 80;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.ReadOnly = false;

            var c3 = new DataGridViewComboBoxColumn();
            c3.DataPropertyName = "Seguridad";
            c3.HeaderText = "Seguridad";
            c3.Visible = true;
            c3.Width = 120;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.ReadOnly = false;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "SeguridadValor";
            c4.Visible = false;
            c4.Width = 10;

            DG_SIST.Columns.Add(c1);
            DG_SIST.Columns.Add(c2);
            DG_SIST.Columns.Add(c3);
            DG_SIST.Columns.Add(c4);
        }

        private void IniGridVenta()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            DG_VENTA.AllowUserToAddRows = false;
            DG_VENTA.AllowUserToDeleteRows = false;
            DG_VENTA.AutoGenerateColumns = false;
            DG_VENTA.AllowUserToResizeRows = false;
            DG_VENTA.AllowUserToResizeColumns = false;
            DG_VENTA.AllowUserToOrderColumns = false;
            DG_VENTA.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DG_VENTA.MultiSelect = false;
            DG_VENTA.ReadOnly = false;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Funcion";
            c1.HeaderText = "Función";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c1.ReadOnly = true;

            var c2 = new DataGridViewCheckBoxColumn();
            c2.DataPropertyName = "Estatus";
            c2.HeaderText = "Estatus";
            c2.Visible = true;
            c2.Width = 80;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.ReadOnly = false;

            var c3 = new DataGridViewComboBoxColumn();
            c3.DataPropertyName = "Seguridad";
            c3.HeaderText = "Seguridad";
            c3.Visible = true;
            c3.Width = 120;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.ReadOnly = false;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "SeguridadValor";
            c4.Visible = false;
            c4.Width = 10;

            DG_VENTA.Columns.Add(c1);
            DG_VENTA.Columns.Add(c2);
            DG_VENTA.Columns.Add(c3);
            DG_VENTA.Columns.Add(c4);
        }

        private void IniGridCompra()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            DG_COMPRA.AllowUserToAddRows = false;
            DG_COMPRA.AllowUserToDeleteRows = false;
            DG_COMPRA.AutoGenerateColumns = false;
            DG_COMPRA.AllowUserToResizeRows = false;
            DG_COMPRA.AllowUserToResizeColumns = false;
            DG_COMPRA.AllowUserToOrderColumns = false;
            DG_COMPRA.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DG_COMPRA.MultiSelect = false;
            DG_COMPRA.ReadOnly = false;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Funcion";
            c1.HeaderText = "Función";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c1.ReadOnly = true;

            var c2 = new DataGridViewCheckBoxColumn();
            c2.DataPropertyName = "Estatus";
            c2.HeaderText = "Estatus";
            c2.Visible = true;
            c2.Width = 80;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.ReadOnly = false;

            var c3 = new DataGridViewComboBoxColumn();
            c3.DataPropertyName = "Seguridad";
            c3.HeaderText = "Seguridad";
            c3.Visible = true;
            c3.Width = 120;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.ReadOnly = false;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "SeguridadValor";
            c4.Visible = false;
            c4.Width = 10;

            DG_COMPRA.Columns.Add(c1);
            DG_COMPRA.Columns.Add(c2);
            DG_COMPRA.Columns.Add(c3);
            DG_COMPRA.Columns.Add(c4);
        }

        private void IniGridInventario()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            DG_INV.AllowUserToAddRows = false;
            DG_INV.AllowUserToDeleteRows = false;
            DG_INV.AutoGenerateColumns = false;
            DG_INV.AllowUserToResizeRows = false;
            DG_INV.AllowUserToResizeColumns = false;
            DG_INV.AllowUserToOrderColumns = false;
            DG_INV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DG_INV.MultiSelect = false;
            DG_INV.ReadOnly = false;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Funcion";
            c1.HeaderText = "Función";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c1.ReadOnly = true;

            var c2 = new DataGridViewCheckBoxColumn();
            c2.DataPropertyName = "Estatus";
            c2.HeaderText = "Estatus";
            c2.Visible = true;
            c2.Width = 80;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.ReadOnly = false;

            var c3 = new DataGridViewComboBoxColumn();
            c3.DataPropertyName = "Seguridad";
            c3.HeaderText = "Seguridad";
            c3.Visible = true;
            c3.Width = 120;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.ReadOnly = false;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "SeguridadValor";
            c4.Visible = false;
            c4.Width = 10;

            DG_INV.Columns.Add(c1);
            DG_INV.Columns.Add(c2);
            DG_INV.Columns.Add(c3);
            DG_INV.Columns.Add(c4);
        }

        private void IniGridProveedor()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            DG_PROV.AllowUserToAddRows = false;
            DG_PROV.AllowUserToDeleteRows = false;
            DG_PROV.AutoGenerateColumns = false;
            DG_PROV.AllowUserToResizeRows = false;
            DG_PROV.AllowUserToResizeColumns = false;
            DG_PROV.AllowUserToOrderColumns = false;
            DG_PROV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DG_PROV.MultiSelect = false;
            DG_PROV.ReadOnly = false;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Funcion";
            c1.HeaderText = "Función";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c1.ReadOnly = true;

            var c2 = new DataGridViewCheckBoxColumn();
            c2.DataPropertyName = "Estatus";
            c2.HeaderText = "Estatus";
            c2.Visible = true;
            c2.Width = 80;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.ReadOnly = false;

            var c3 = new DataGridViewComboBoxColumn();
            c3.DataPropertyName = "Seguridad";
            c3.HeaderText = "Seguridad";
            c3.Visible = true;
            c3.Width = 120;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.ReadOnly = false;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "SeguridadValor";
            c4.Visible = false;
            c4.Width = 10;

            DG_PROV.Columns.Add(c1);
            DG_PROV.Columns.Add(c2);
            DG_PROV.Columns.Add(c3);
            DG_PROV.Columns.Add(c4);
        }

        private void IniGridCliente()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            DG_CLIENTE.AllowUserToAddRows = false;
            DG_CLIENTE.AllowUserToDeleteRows = false;
            DG_CLIENTE.AutoGenerateColumns = false;
            DG_CLIENTE.AllowUserToResizeRows = false;
            DG_CLIENTE.AllowUserToResizeColumns = false;
            DG_CLIENTE.AllowUserToOrderColumns = false;
            DG_CLIENTE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DG_CLIENTE.MultiSelect = false;
            DG_CLIENTE.ReadOnly = false;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Funcion";
            c1.HeaderText = "Función";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c1.ReadOnly = true;

            var c2 = new DataGridViewCheckBoxColumn();
            c2.DataPropertyName = "Estatus";
            c2.HeaderText = "Estatus";
            c2.Visible = true;
            c2.Width = 80;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.ReadOnly = false;

            var c3 = new DataGridViewComboBoxColumn();
            c3.DataPropertyName = "Seguridad";
            c3.HeaderText = "Seguridad";
            c3.Visible = true;
            c3.Width = 120;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.ReadOnly = false;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "SeguridadValor";
            c4.Visible = false;
            c4.Width = 10;

            DG_CLIENTE.Columns.Add(c1);
            DG_CLIENTE.Columns.Add(c2);
            DG_CLIENTE.Columns.Add(c3);
            DG_CLIENTE.Columns.Add(c4);
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void ControlAccesoFrm_Load(object sender, EventArgs e)
        {
            L_GRUPO.Text = _controlador.Grupo;
            DG_CLIENTE.DataSource = _controlador.ClienteSource;
        }

        private void ClienteCargarData()
        {
            foreach(DataGridViewRow row in DG_CLIENTE.Rows)
            {
                DataGridViewComboBoxCell cb = (row.Cells[2] as DataGridViewComboBoxCell);
                cb.Items.Clear();
                cb.Items.Add("Ninguna");
                cb.Items.Add("Minima");
                cb.Items.Add("Media");
                cb.Items.Add("Maxima");
                cb.Value = row.Cells[3].Value.ToString();
            }
        }

        private void ProveedorCargarData()
        {
            DG_PROV.DataSource = _controlador.ProveedorSource;
            foreach (DataGridViewRow row in DG_PROV.Rows)
            {
                DataGridViewComboBoxCell cb = (row.Cells[2] as DataGridViewComboBoxCell);
                cb.Items.Clear();
                cb.Items.Add("Ninguna");
                cb.Items.Add("Minima");
                cb.Items.Add("Media");
                cb.Items.Add("Maxima");
                cb.Value = row.Cells[3].Value.ToString();
            }
        }

        private void InventarioCargarData()
        {
            DG_INV.DataSource = _controlador.InventarioSource;
            foreach (DataGridViewRow row in DG_INV.Rows)
            {
                DataGridViewComboBoxCell cb = (row.Cells[2] as DataGridViewComboBoxCell);
                cb.Items.Clear();
                cb.Items.Add("Ninguna");
                cb.Items.Add("Minima");
                cb.Items.Add("Media");
                cb.Items.Add("Maxima");
                cb.Value = row.Cells[3].Value.ToString();
            }
        }

        private void CompraCargarData()
        {
            DG_COMPRA.DataSource = _controlador.CompraSource;
            foreach (DataGridViewRow row in DG_COMPRA.Rows)
            {
                DataGridViewComboBoxCell cb = (row.Cells[2] as DataGridViewComboBoxCell);
                cb.Items.Clear();
                cb.Items.Add("Ninguna");
                cb.Items.Add("Minima");
                cb.Items.Add("Media");
                cb.Items.Add("Maxima");
                cb.Value = row.Cells[3].Value.ToString();
            }
        }

        private void VentaCargarData()
        {
            DG_VENTA.DataSource = _controlador.VentaSource;
            foreach (DataGridViewRow row in DG_VENTA.Rows)
            {
                DataGridViewComboBoxCell cb = (row.Cells[2] as DataGridViewComboBoxCell);
                cb.Items.Clear();
                cb.Items.Add("Ninguna");
                cb.Items.Add("Minima");
                cb.Items.Add("Media");
                cb.Items.Add("Maxima");
                cb.Value = row.Cells[3].Value.ToString();
            }
        }

        private void SistemaCargarData()
        {
            DG_SIST.DataSource = _controlador.SistemaSource;
            foreach (DataGridViewRow row in DG_SIST.Rows)
            {
                DataGridViewComboBoxCell cb = (row.Cells[2] as DataGridViewComboBoxCell);
                cb.Items.Clear();
                cb.Items.Add("Ninguna");
                cb.Items.Add("Minima");
                cb.Items.Add("Media");
                cb.Items.Add("Maxima");
                cb.Value = row.Cells[3].Value.ToString();
            }
        }

        private void ControlAccesoFrm_Shown(object sender, EventArgs e)
        {
            ClienteCargarData();
            ProveedorCargarData();
            InventarioCargarData();
            CompraCargarData();
            VentaCargarData();
            SistemaCargarData();
        }

        private void BT_ACTUALIZAR_Click(object sender, EventArgs e)
        {
            ActualizarData();
        }

        private void ActualizarData()
        {
            _controlador.ActualizarData();
            if (_controlador.ActualizarIsOk) 
            {
                Salir();
            }
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            AbandonarCambios();
        }

        private void AbandonarCambios()
        {
            _controlador.AbandonarCambios();
            if (_controlador.AbandonarIsOk)
                Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void ControlAccesoFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_controlador.AbandonarIsOk || _controlador.ActualizarIsOk)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                ClienteCargarData();
            else if (tabControl1.SelectedIndex == 1)
                ProveedorCargarData();
            else if (tabControl1.SelectedIndex == 2)
                InventarioCargarData();
            else if (tabControl1.SelectedIndex == 3)
                CompraCargarData();
            else if (tabControl1.SelectedIndex == 4)
                VentaCargarData();
            else if (tabControl1.SelectedIndex == 5)
                SistemaCargarData();
        }

    }

}