using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Maestros
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
            if (_controlador.GridVisualizarIs == Enumerados.Maestro.SERIEFISCAL)
            {
                DGV.Columns["CODIGO"].Visible = false;
                DGV.Columns["CIRIF"].Visible = false;
                DGV.Columns["NOMBRE"].Visible = false;
                DGV.Columns["SERIE"].Visible = true;
                DGV.Columns["CONTROL"].Visible = true;
                DGV.Columns["CORRELATIVO"].Visible = true;
                DGV.Columns["ESTATUS"].Visible = true;
            }
            else if (_controlador.GridVisualizarIs== Enumerados.Maestro.VENDEDOR)
            {
                DGV.Columns["CODIGO"].Visible = true;
                DGV.Columns["CIRIF"].Visible = true;
                DGV.Columns["NOMBRE"].Visible = true;
                DGV.Columns["SERIE"].Visible = false;
                DGV.Columns["CONTROL"].Visible = false;
                DGV.Columns["CORRELATIVO"].Visible = false;
                DGV.Columns["ESTATUS"].Visible = true;
            }
            else
            {
                DGV.Columns["CODIGO"].Visible = true;
                DGV.Columns["CIRIF"].Visible = true;
                DGV.Columns["NOMBRE"].Visible = true;
                DGV.Columns["SERIE"].Visible = false;
                DGV.Columns["CONTROL"].Visible = false;
                DGV.Columns["CORRELATIVO"].Visible = false;
                DGV.Columns["ESTATUS"].Visible = true;
            }

            DGV.DataSource = _controlador.Source;
            ActualizarData();
        }

        private void ActualizarData()
        {
            L_TITULO.Text = _controlador.MaestroTitulo;
            L_ITEMS.Text = _controlador.CntItem.ToString("n0");
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
            c1.DataPropertyName = "Codigo";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Name = "CODIGO";

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "ciRif";
            c2.HeaderText = "CI/RIF";
            c2.Visible = true;
            c2.Width = 120;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.Name = "CIRIF";

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Nombre";
            c3.HeaderText = "Nombre";
            c3.Visible = true;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.MinimumWidth = 180;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c3.Name = "NOMBRE";

            var c11 = new DataGridViewTextBoxColumn();
            c11.DataPropertyName = "Serie";
            c11.HeaderText = "Serie";
            c11.Visible = true;
            c11.Width = 120;
            c11.HeaderCell.Style.Font = f;
            c11.DefaultCellStyle.Font = f1;
            c11.Name = "SERIE";

            var c22 = new DataGridViewTextBoxColumn();
            c22.DataPropertyName = "Control";
            c22.HeaderText = "Control";
            c22.Visible = true;
            c22.Width = 120;
            c22.HeaderCell.Style.Font = f;
            c22.DefaultCellStyle.Font = f1;
            c22.Name = "CONTROL";

            var c33 = new DataGridViewTextBoxColumn();
            c33.DataPropertyName = "Correlativo";
            c33.HeaderText = "Correlativo";
            c33.Visible = true;
            c33.HeaderCell.Style.Font = f;
            c33.DefaultCellStyle.Font = f1;
            c33.DefaultCellStyle.Alignment= DataGridViewContentAlignment.MiddleRight;
            c33.Width = 100;
            c33.Name = "CORRELATIVO";

            var c44 = new DataGridViewTextBoxColumn();
            c44.DataPropertyName = "Estatus";
            c44.HeaderText = "Estatus";
            c44.Visible = true;
            c44.HeaderCell.Style.Font = f;
            c44.DefaultCellStyle.Font = f1;
            c44.MinimumWidth = 100;
            c44.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c44.Name = "ESTATUS";

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);

            DGV.Columns.Add(c11);
            DGV.Columns.Add(c22);
            DGV.Columns.Add(c33);
            DGV.Columns.Add(c44);
        }

        private void BT_AGREGAR_Click(object sender, EventArgs e)
        {
            AgregarFicha();
        }

        private void AgregarFicha()
        {
            _controlador.AgregarFicha();
            ActualizarData();
        }

        private void BT_EDITAR_Click(object sender, EventArgs e)
        {
            EditarFicha();
        }

        private void EditarFicha()
        {
            _controlador.EditarFicha();
            ActualizarData();
        }

        private void BT_ESTATUS_Click(object sender, EventArgs e)
        {
            CambiarEstatus();
        }

        private void CambiarEstatus()
        {
            _controlador.CambiarEstatus();
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if (row.Cells["Estatus"].Value.ToString() == "Inactivo")
                {
                    row.Cells["Estatus"].Style.BackColor = Color.Red;
                    row.Cells["Estatus"].Style.ForeColor = Color.White;
                }
            }
        }

    }

}