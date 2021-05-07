using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.SucursalDeposito
{

    public partial class SucDepFrm : Form
    {

        private Gestion _controlador;


        public SucDepFrm()
        {
            InitializeComponent();
            InicializarGrid();
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

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Nombre";
            c1.HeaderText = "Nombre/Sucursal";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Codigo";
            c2.HeaderText = "Cod/Suc";
            c2.Visible = true;
            c2.Width = 80;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "nombreGrupoSucursal";
            c3.HeaderText = "Grupo";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "nombreDepositoPrincipal";
            c4.HeaderText = "Deposito Principal";
            c4.Visible = true;
            c4.MinimumWidth = 160;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DGV.Columns.Add(c3);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c4);
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void SucDepFrm_Load(object sender, EventArgs e)
        {
            L_ITEMS.Text = _controlador.Items.ToString("n0");
            DGV.DataSource = _controlador.Source;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_EDITAR_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void Editar()
        {
            _controlador.EditarItem();
        }

        private void BT_ELIMINAR_Click(object sender, EventArgs e)
        {
            EliminarAsignacion();
        }

        private void EliminarAsignacion()
        {
            _controlador.EliminarAsignacion();
        }

    }

}