﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Existencia.Ver
{

    public partial class VerFrm : Form
    {


        private Gestion _controlador;


        public VerFrm()
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
            c1.DataPropertyName = "CodigoDep";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 80;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "NombreDep";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.MinimumWidth = 120;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "ExFisica";
            c3.HeaderText = "Ex/Fisica";
            c3.Visible = true;
            c3.Width = 90;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n2";

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "ExReserva";
            c4.HeaderText = "Ex/Reserv";
            c4.Visible = true;
            c4.Width = 90;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = "n2";

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "ExDisponible";
            c5.HeaderText = "Ex/Disponib";
            c5.Visible = true;
            c5.Width = 90;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";


            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
        }

        private void VerFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Source;
            RB_UNIDAD.Checked = true;
            Actualizar();
        }

        private void RB_UNIDAD_CheckedChanged(object sender, EventArgs e)
        {
            SeleccionUidad();
        }

        private void SeleccionUidad()
        {
            _controlador.setUnidad();
            Actualizar();
        }

        private void Actualizar()
        {
            var nr = _controlador.Formato;
            L_EMPAQUE.Text = _controlador.EmpaqueDes;
            L_FISICA.Text = _controlador.ExFisica.ToString(nr);
            L_RESERVA.Text = _controlador.ExReserva.ToString(nr);
            L_DISPONIBLE.Text = _controlador.ExDisponible.ToString(nr);
            DGV.Refresh();
        }

        private void RB_COMPRA_CheckedChanged(object sender, EventArgs e)
        {
            SeleccionCompra();
        }

        private void SeleccionCompra()
        {
            _controlador.setCompra();
            Actualizar();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }
      
    }

}
