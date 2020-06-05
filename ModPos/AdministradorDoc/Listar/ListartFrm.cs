using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.AdministradorDoc.Listar
{

    public partial class ListartFrm : Form
    {


        private Administrador _controlador;


        public ListartFrm()
        {
            InitializeComponent();
            InicializarGRid();
        }

        private void InicializarGRid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 9, FontStyle.Regular);

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
            c1.DataPropertyName = "FechaHora";
            c1.HeaderText = "Fecha/Hora";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Documento";
            c2.HeaderText = "Documento";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "TipoDocumentoDesc";
            c7.HeaderText = "Tipo";
            c7.Visible = true;
            c7.Width = 100;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Renglones";
            c6.HeaderText = "# Reng";
            c6.Visible = true;
            c6.Width = 60;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n0";

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "CiRif";
            c3.HeaderText = "CiRif";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "NombreRazonSocial";
            c4.HeaderText = "Nombre / Razón Social";
            c4.Visible = true;
            c4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c4.MinimumWidth = 180;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Monto";
            c5.HeaderText = "Importe";
            c5.Visible = true;
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";
        
            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "IsActivo";
            c8.Name = "IsActivo";
            c8.Visible = false;
            c8.Width = 10;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c8);
        }

        private void ListartFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Source;
            DGV.Refresh();
        }

        private void IrFocoPrincipal()
        {
            DGV.Focus();
        }

        private void BT_SUBIR_Click(object sender, EventArgs e)
        {
            SubirItem();
        }

        private void SubirItem()
        {
            _controlador.Subir();
        }

        private void BT_BAJAR_Click(object sender, EventArgs e)
        {
            BajarItem();
        }

        private void BajarItem()
        {
            _controlador.Bajar();
        }

        private void BT_ANULAR_Click(object sender, EventArgs e)
        {
            AnularDocumento();
        }

        private void AnularDocumento()
        {
            _controlador.AnularDocumento();
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_NOTA_CREDITO_Click(object sender, EventArgs e)
        {
            NotaCredito();
        }

        private void NotaCredito()
        {
            if (_controlador.NotaCredito()) 
            {
                Salir();
            }
        }

        private void BT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            ImprimirDocumento();
        }

        private void ImprimirDocumento()
        {
            _controlador.ReImprimirDocumento();
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                row.DefaultCellStyle.ForeColor = !(bool)row.Cells["IsActivo"].Value ? Color.Red : Color.Black;
            }
        }

        public void setControlador(Administrador ctr) 
        {
            _controlador = ctr;
        }

    }

}