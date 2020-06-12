using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Permisos
{

    public partial class PermisosFrm : Form
    {


        private CtrPermiso _controlador;


        public PermisosFrm()
        {
            InitializeComponent();
            InicializarGRid();
        }

        private void InicializarGRid()
        {
            var f = new Font("Serif", 9, FontStyle.Bold);
            var f1 = new Font("Serif", 11, FontStyle.Regular);

            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Descripcion";
            c1.HeaderText = "Función";
            c1.Visible = true;
            c1.MinimumWidth= 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.ReadOnly=true ;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Modulo";
            c2.HeaderText = "Módulo";
            c2.Visible = true;
            c2.Width = 60;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            c2.ReadOnly = true;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "ModuloDescripcion";
            c5.HeaderText = "Descripción";
            c5.Visible = true;
            c5.Width = 100;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            c5.ReadOnly = true;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "CodigoFuncion";
            c3.HeaderText = "Código Función";
            c3.Visible = true;
            c3.Width = 80;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            c3.ReadOnly = true;

            var c4 = new DataGridViewCheckBoxColumn();
            c4.DataPropertyName = "RequiereClave";
            c4.HeaderText = "Requiere Clave";
            c4.Visible = true;
            c4.Width = 80;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.ReadOnly = false;

            DGV.Columns.Add(c2);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
        }

        private void PermisosFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Source;
            DGV.Refresh();
        }

        public void setControlador(CtrPermiso ctr)
        {
            _controlador = ctr;
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            GuardarCambios();
        }

        private void GuardarCambios()
        {
            if (_controlador.GuardarCambios())
            {
                Salir();
            }
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

    }

}