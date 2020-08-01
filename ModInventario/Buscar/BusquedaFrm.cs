using System;
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


            DGV.Columns.Add(c2);
            DGV.Columns.Add(c1);
        }


        private void BusquedaFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Source;
            L_ITEMS.Text = _controlador.Items.ToString("n0");
            L_PRODUCTO.Text = "";
            L_DEPARTAMENTO.Text = "";
            L_GRUPO .Text = "";
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
        }

        private void RB_BUSCAR_POR_NOMBRE_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_BUSCAR_POR_NOMBRE.Checked)
            {
                _controlador.MetodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Nombre;
            }
        }

        private void RB_BUSCAR_POR_REF_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_BUSCAR_POR_REF.Checked)
            {
                _controlador.MetodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Referencia;
            }
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            RealizarBusqueda();
        }

        private void RealizarBusqueda()
        {
            _controlador.RealizarBusqueda();
            L_ITEMS.Text = _controlador.Items.ToString("n0");
            TB_CADENA.Text = _controlador.Cadena;
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
        }

        private void LimpiarEtiquetas()
        {
            L_PRODUCTO.Text = "";
            L_DEPARTAMENTO.Text = "";
            L_GRUPO.Text = "";
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
            L_ITEMS.Text = _controlador.Items.ToString("n0");
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
            _controlador.SeleccionarItem();
            if (_controlador.HayItemSeleccionado) 
            {
                Salir();
            }
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            Close();
        }

    }

}