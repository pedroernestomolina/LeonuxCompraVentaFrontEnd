﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Proveedor.Administrador
{

    public partial class AdmFrm : Form
    {


        private Gestion _controlador;


        public AdmFrm()
        {
            InitializeComponent();
            InicializarDGV();
        }

        private void InicializarDGV()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);

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
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 100;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "CiRif";
            c2.HeaderText = "CiRif";
            c2.Visible = true;
            c2.Width = 110;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "NombreRazonSocial";
            c3.HeaderText = "Nombre/Razón Social";
            c3.Visible = true;
            c3.MinimumWidth = 220;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            _controlador.ActivarBusqueda();
            ActualizarData();
            ActualizarDataProveedor();
        }

        private void ActualizarData()
        {
            TB_CADENA.Text = "";
            L_ITEMS.Text = _controlador.cntItem.ToString("n0");
            switch (_controlador.MetodoBusqueda)
            {
                case Enumerados.enumMetodoBusqueda.PorCodigo:
                    RB_BUSCAR_POR_CODIGO.Checked = true;
                    break;
                case Enumerados.enumMetodoBusqueda.PorNombre:
                    RB_BUSCAR_POR_NOMBRE.Checked = true;
                    break;
                case Enumerados.enumMetodoBusqueda.PorRif:
                    RB_BUSCAR_POR_RIF.Checked = true;
                    break;
            }
        }

        private void AdmFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Source;
            ActualizarData();
            L_PROVEEDOR.Text = _controlador.Proveedor;
        }

        private void TB_CADENA_Leave(object sender, EventArgs e)
        {
            _controlador.setCadena(TB_CADENA.Text);
        }

        private void RB_BUSCAR_POR_CODIGO_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setMetodoPorCodigo();
            GoInicio();
        }

        private void RB_BUSCAR_POR_NOMBRE_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setMetodoPorNombre();
            GoInicio();
        }

        private void RB_BUSCAR_POR_RIF_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setMetodoPorCiRif();
            GoInicio();
        }

        public void ActualizarDataProveedor()
        {
            L_PROVEEDOR.Text = _controlador.Proveedor;
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarBusqueda();
            ActualizarData();
            ActualizarDataProveedor();
            GoInicio();
        }

        private void GoInicio()
        {
            TB_CADENA.Focus();
        }

        private void LimpiarBusqueda()
        {
            _controlador.LimpiarBusqueda();
        }

        private void AdmFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                GoInicio();
            }
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_AGREGAR_FICHA_Click(object sender, EventArgs e)
        {
            AgregarFicha();
        }

        private void AgregarFicha()
        {
            _controlador.AgregarFicha();
            ActualizarData();
            ActualizarDataProveedor();
        }

        private void BT_EDITAR_FICHA_Click(object sender, EventArgs e)
        {
            EditarFicha();
        }

        private void EditarFicha()
        {
            _controlador.EditarFicha();
        }

        private void BT_ARTICULOS_COMPRA_Click(object sender, EventArgs e)
        {
            CompraArticulos();
        }

        private void CompraArticulos()
        {
            _controlador.CompraArticulos();
        }

        private void BT_DOCUMENTOS_Click(object sender, EventArgs e)
        {
            Documentos();
        }

        private void Documentos()
        {
            _controlador.Documentos();
        }
      
    }

}