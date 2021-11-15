using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Usuario

{
    public partial class MaestroFrm : Form
    {

        private Gestion _controlador;


        public MaestroFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void TSM_ARCHIVO_Salir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void MaestroFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Source;
            L_ITEMS.Text = _controlador.Items.ToString("n0");
        }

        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;
            DGV.ReadOnly = true;

            var c0 = new DataGridViewTextBoxColumn();
            c0.DataPropertyName = "Codigo";
            c0.HeaderText = "Codigo";
            c0.Visible = true;
            c0.HeaderCell.Style.Font = f;
            c0.DefaultCellStyle.Font = f1;
            c0.MinimumWidth = 80;
            c0.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Nombre";
            c1.HeaderText = "Nombre";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 120;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Apellido";
            c2.HeaderText = "Apellido";
            c2.Visible = true;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.Width = 120;

            DGV.Columns.Add(c0);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
        }

        private void BT_AGREGAR_Click(object sender, EventArgs e)
        {
            AgregarItem();
        }

        private void AgregarItem()
        {
            _controlador.AgregarItem();
            L_ITEMS.Text = _controlador.Items.ToString("n0");
        }

        private void BT_EDITAR_Click(object sender, EventArgs e)
        {
            EditarItem();
        }

        private void EditarItem()
        {
            _controlador.EditarItem();
            L_ITEMS.Text = _controlador.Items.ToString("n0");
        }

        public void setActualizarItem()
        {
            L_GRUPO.Text = _controlador.ItemActual.grupo;
            L_FECHA_ALTA.Text = _controlador.ItemActual.fechaAlta;
            L_FECHA_BAJA.Text = "";
            L_FECHA_SESION.Text = "";
            P_ESTATUS.BackColor = Color.Green;
            L_ESTATUS.Text = "ACTIVO";
            L_ESTATUS.ForeColor = Color.White;
            L_FECHA_BAJA.Text = _controlador.ItemActual.fechaBaja;
            L_FECHA_SESION.Text = _controlador.ItemActual.fechaUltSesion;
            if (_controlador.ItemActual.estatus == OOB.LibSistema.Usuario.Enumerados.EnumModo.Inactivo) 
            {
                P_ESTATUS.BackColor = Color.Red;
                L_ESTATUS.Text = "INACTIVO";
                L_ESTATUS.ForeColor = Color.Yellow;
            }
        }

        private void BT_ACTIVAR_INACTIVAR_Click(object sender, EventArgs e)
        {
            ActivarInactivar();
        }

        private void ActivarInactivar()
        {
            _controlador.ActivarInactivar();
        }

        private void BT_ELIMINAR_Click(object sender, EventArgs e)
        {
            EliminarItem();
        }

        private void EliminarItem()
        {
            _controlador.EliminarItem();
        }

    }

}