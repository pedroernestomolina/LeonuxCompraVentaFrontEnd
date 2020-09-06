﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Buscar
{

    public partial class BusquedaFrm : Form
    {


        private Gestion _controlador;


        public BusquedaFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }

        private void InicializarGrid()
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
            c1.DataPropertyName = "DescripcionPrd";
            c1.HeaderText = "Nombre";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.MinimumWidth = 180;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "CodigoPrd";
            c2.HeaderText = "Codigo";
            c2.Visible = true;
            c2.Width = 120;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.Name = "VEstatus";
            c3.HeaderText = "*";
            c3.Visible = true;
            c3.Width = 20;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.BackColor = Color.Green;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Estatus";
            c4.Name = "Estatus";
            c4.Visible = false;
            c4.Width = 0;

            DGV.Columns.Add(c2);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
        }


        private void BusquedaFrm_Load(object sender, EventArgs e)
        {
            TB_CADENA.Text = "";
            DGV.DataSource = _controlador.Source;
            L_ITEMS.Text = _controlador.Items.ToString("n0");
            LimpiarEtiquetas();
            TB_CADENA.Focus();
            switch (_controlador.MetodoBusqueda) 
            {
                case OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Codigo:
                    RB_BUSCAR_POR_CODIGO.Checked = true;
                    break;
                case OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Nombre:
                    RB_BUSCAR_POR_NOMBRE.Checked = true;
                    break;
                case OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Referencia:
                    RB_BUSCAR_POR_REF.Checked = true;
                    break;
            }
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                var xcolor = Color.Green;
                if (row.Cells["Estatus"].Value.ToString() == "Suspendido")
                    xcolor= Color.Orange;
                if (row.Cells["Estatus"].Value.ToString() == "Inactivo")
                    xcolor = Color.Red;

                row.Cells["VEstatus"].Style.BackColor = xcolor;    
            }
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void RB_BUSCAR_POR_CODIGO_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_BUSCAR_POR_CODIGO.Checked)
            {
                _controlador.MetodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Codigo;
            }
            TB_CADENA.Focus();
        }

        private void RB_BUSCAR_POR_NOMBRE_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_BUSCAR_POR_NOMBRE.Checked)
            {
                _controlador.MetodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Nombre;
            }
            TB_CADENA.Focus();
        }

        private void RB_BUSCAR_POR_REF_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_BUSCAR_POR_REF.Checked)
            {
                _controlador.MetodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Referencia;
            }
            TB_CADENA.Focus();
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            RealizarBusqueda();
        }

        private void RealizarBusqueda()
        {
            _controlador.RealizarBusqueda();
            ActualizarBusqueda();
            DGV.Focus();
        }

        private void TB_CADENA_TextChanged(object sender, EventArgs e)
        {
            _controlador.Cadena = TB_CADENA.Text;
        }


        public void ActualizarItem()
        {
            if (_controlador.Item==null)
            {
                LimpiarEtiquetas();
                return;
            }

            L_PRODUCTO.Text = _controlador.Item.Producto;
            L_DEPARTAMENTO.Text = _controlador.Item.Departamento;
            L_GRUPO.Text = _controlador.Item.Grupo;
            L_MARCA.Text = _controlador.Item.Marca;
            L_REFERENCIA.Text = _controlador.Item.Referencia;
            L_IMPUESTO.Text = _controlador.Item.Impuesto;
            L_EMPAQUE.Text = _controlador.Item.Empaque;

            L_CATEGORIA.Text = _controlador.Item.Categoria;
            L_ORIGEN.Text = _controlador.Item.Origen;
            L_ESTATUS.Text = _controlador.Item.Estatus;
            L_DIVISA.Text = _controlador.Item.Divisa;
            L_OFERTA.Text = _controlador.Item.EstatusOferta;

            L_PESADO.Text = _controlador.Item.Pesado;
            L_FECHA_ALTA.Text = _controlador.Item.FechaAlta.ToShortDateString();
            L_FECHA_ACT.Text= _controlador.Item.FechaUltimaActualizacion;
        }

        private void LimpiarEtiquetas()
        {
            L_PRODUCTO.Text = "";
            L_DEPARTAMENTO.Text = "";
            L_GRUPO.Text = "";
            L_MARCA.Text = "";
            L_REFERENCIA.Text = "";
            L_IMPUESTO.Text = "";
            L_EMPAQUE.Text = "";
            L_CATEGORIA.Text = "";
            L_ORIGEN.Text = "";
            L_ESTATUS.Text = "";
            L_DIVISA.Text = "";
            L_PESADO.Text = "";
            L_OFERTA.Text = "";
            L_FECHA_ALTA.Text="";
            L_FECHA_ACT.Text = "";
        }

        private void BT_FILTRAR_Click(object sender, EventArgs e)
        {
            FiltrarBusqueda();
        }

        private void FiltrarBusqueda()
        {
            BT_BUSCAR.Enabled = false;
            _controlador.FiltrarBusqueda();
            BT_BUSCAR.Enabled = true;
            ActualizarBusqueda();
            DGV.Focus();
        }

        private void ActualizarBusqueda()
        {
            L_ITEMS.Text = _controlador.Items.ToString("n0");
            TB_CADENA.Text = _controlador.Cadena;
            TB_CADENA.Focus();
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                SeleccionarItem();
            }
        }

        private void SeleccionarItem()
        {
            //_controlador.SeleccionarItem();
            //if (_controlador.HayItemSeleccionado) 
            //{
            //    Salir();
            //}
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            Close();
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_VER_EXISTENCIA_Click(object sender, EventArgs e)
        {
            VerExistencia();
        }

        private void VerExistencia()
        {
            _controlador.VerExistencia();
            TB_CADENA.Focus();
        }

        private void BT_PRECIO_Click(object sender, EventArgs e)
        {
            VerPrecios();
        }

        private void VerPrecios()
        {
            _controlador.VerPrecios();
            TB_CADENA.Focus();
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            _controlador.Limpiar();
            L_ITEMS.Text = _controlador.Items.ToString("n0");
            TB_CADENA.Focus();
        }

        private void BT_PRECIO_EDITAR_Click(object sender, EventArgs e)
        {
            EditarPrecio();
        }

        private void EditarPrecio()
        {
            _controlador.EditarPrecio();
            TB_CADENA.Focus();
        }

        private void BT_PRECIO_HISTORICO_Click(object sender, EventArgs e)
        {
            HistoricoPrecio();
        }

        private void HistoricoPrecio()
        {
            _controlador.HistoricoPrecio();
            TB_CADENA.Focus();
        }

        private void BT_HISTORICO_COSTO_Click(object sender, EventArgs e)
        {
            HistoricoCosto();
        }

        private void HistoricoCosto()
        {
            _controlador.HistoricoCosto();
            TB_CADENA.Focus();
        }

        private void BT_COSTO_Click(object sender, EventArgs e)
        {
            VerCosto();
        }

        private void VerCosto()
        {
            _controlador.VerCosto();
            TB_CADENA.Focus();
        }

        private void BT_EDITAR_COSTO_Click(object sender, EventArgs e)
        {
            EditarCosto();
        }

        private void EditarCosto()
        {
            _controlador.EditarCosto();
            TB_CADENA.Focus();
        }

        private void BT_GENERAR_QR_Click(object sender, EventArgs e)
        {
            GenerarQR();
        }

        private void GenerarQR()
        {
            _controlador.GenerarQR();
            TB_CADENA.Focus();
        }

        private void BusquedaFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) 
            {
                TB_CADENA.Focus();
            }
        }

        private void BT_ASIGNAR_DEPOSITO_Click(object sender, EventArgs e)
        {
            AsignarDeposito();
        }

        private void AsignarDeposito()
        {
            _controlador.AsignarDeposito();
            TB_CADENA.Focus();
        }

        private void BT_MOV_KARDEX_Click(object sender, EventArgs e)
        {
            MovKardex();
        }

        private void MovKardex()
        {
            _controlador.MovKardex(); 
            TB_CADENA.Focus();
        }

        private void BT_EDITAR_FICHA_Click(object sender, EventArgs e)
        {
            EditarFicha();
        }

        private void EditarFicha()
        {
            _controlador.EditarFicha();
            TB_CADENA.Focus();
        }

        private void BT_AGREGAR_FICHA_Click(object sender, EventArgs e)
        {
            AgregarFicha();
        }

        private void AgregarFicha()
        {
            _controlador.AgregarFicha();
            TB_CADENA.Focus();
            L_ITEMS.Text = _controlador.Items.ToString("n0");
        }

        private void TB_CAMBIO_ESTATUS_Click(object sender, EventArgs e)
        {
            CambioEstatus();
        }

        private void CambioEstatus()
        {
            _controlador.CambioEstatus();
        }
      
    }

}