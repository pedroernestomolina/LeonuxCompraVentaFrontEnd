using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Formulario
{

    public partial class DocumentoFrm : Form
    {


        private Controlador.Gestion _controlador;


        public DocumentoFrm()
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
            c1.DataPropertyName = "CodigoPrd";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "DescripcionPrd";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.MinimumWidth = 180;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Cnt";
            c3.HeaderText = "Cant";
            c3.Visible = true;
            c3.Width = 80;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Empaque";
            c4.HeaderText = "Empaque";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.Width = 100;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Costo";
            c5.HeaderText = "Costo Bs";
            c5.Visible = true;
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var c5b = new DataGridViewTextBoxColumn();
            c5b.DataPropertyName = "Costo";
            c5b.HeaderText = "Costo $";
            c5b.Visible = true;
            c5b.Width = 120;
            c5b.HeaderCell.Style.Font = f;
            c5b.DefaultCellStyle.Font = f1;
            c5b.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5b.DefaultCellStyle.Format = "n2";

            var c6 = new DataGridViewTextBoxColumn();
            c6.HeaderText = "Dscto";
            c6.Visible = true;
            c6.Width = 120;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "Iva";
            c7.HeaderText = "Iva";
            c7.Visible = true;
            c7.Width = 60;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c7.DefaultCellStyle.Format = "n2";

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "Importe";
            c8.HeaderText = "Importe";
            c8.Visible = true;
            c8.Width = 120;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c8.DefaultCellStyle.Format = "n2";

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c5b);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c8);
        }

        private void DocumentoFrm_Load(object sender, EventArgs e)
        {
            Inicializar_1();
            DGV.Columns[0].Frozen = true;
            DGV.Columns[1].Frozen = true;
            DGV.Columns[2].Frozen = true;
            DGV.DataSource = _controlador.ItemSource;
        }

        private void Inicializar_1()
        {
            L_TITULO_DOCUMENTO.Text = _controlador.TituloDocumento;
            switch (_controlador.MetodoBusquedaProducto) 
            {
                case Controlador.GestionProductoBuscar.metodoBusqueda.Codigo:
                    RB_BUSCAR_POR_CODIGO.Checked = true;
                    ActivarBusquedaProductoPorCodigo();
                    break;
                case Controlador.GestionProductoBuscar.metodoBusqueda.Nombre:
                    RB_BUSCAR_POR_NOMBRE.Checked = true;
                    ActivarBusquedaProductoPorNombre();
                    break;
                case Controlador.GestionProductoBuscar.metodoBusqueda.Referencia:
                    RB_BUSCAR_POR_REFERENCIA.Checked = true;
                    ActivarBusquedaProductoPorReferencia();
                    break;
            }
            ActualizarDatosDocumento();
            ActualizarDatosTotales();
        }

        private void ActualizarDatosTotales()
        {
            L_TOTAL.Text = _controlador.Total.ToString("n2");
            L_IVA.Text = _controlador.MontoIva.ToString("n2");
            L_DIVISA.Text = _controlador.MontoDivisa.ToString("n2");
            L_ITEMS.Text = _controlador.Items.ToString("n0");
        }

        public void setControlador(Controlador.Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_NUEVO_Click(object sender, EventArgs e)
        {
            NuevoDocumento();
        }

        private void NuevoDocumento()
        {
            _controlador.NuevoDocumento();
            ActualizarDatosDocumento();
            if (_controlador.DatosDocumentoIsOk)
                IniciarBusqueda();
        }

        private void ActualizarDatosDocumento()
        {
            L_PROVEEDOR.Text = _controlador.Proveedor;
            L_FECHA_EMISION.Text = _controlador.FechaEmision.ToShortDateString();
            L_DOCUMENTO.Text = _controlador.DocumentoNro;
            L_CONTROL_NRO.Text = _controlador.ControlNro;
            L_FECHA_VENC.Text = _controlador.FechaVencimiento.ToShortDateString();
            L_FACTOR_DIVISA.Text = _controlador.FactorDivisa.ToString("n2");
            L_DEPOSITO.Text = _controlador.Deposito;
            L_SUCURSAL.Text = _controlador.Sucursal;
        }

        private void BT_EDITAR_ITEM_Click(object sender, EventArgs e)
        {
            EditarItem();
        }

        private void EditarItem()
        {
            _controlador.EditarItem();
        }

        private void BT_ELIMINAR_ITEM_Click(object sender, EventArgs e)
        {
            EliminarItem();
        }

        private void EliminarItem()
        {
            _controlador.EliminarItem();
        }

        private void BT_LIMPIAR_ITEMS_Click(object sender, EventArgs e)
        {
            LimpiarItems();
        }

        private void LimpiarItems()
        {
            _controlador.LimpiarItems();
        }

        private void BT_BUSCAR_PRODUCTO_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void BuscarProducto()
        {
            _controlador.BuscarProducto();
            IniciarBusqueda();
        }

        private void IniciarBusqueda()
        {
            TB_CADENA_BUSQ.Text = "";
            TB_CADENA_BUSQ.Focus();
        }

        private void RB_BUSCAR_POR_CODIGO_CheckedChanged(object sender, EventArgs e)
        {
            ActivarBusquedaProductoPorCodigo();
        }

        private void ActivarBusquedaProductoPorCodigo()
        {
            _controlador.ActivarBusquedaProductoPorCodigo();
            IniciarBusqueda();
        }

        private void RB_BUSCAR_POR_NOMBRE_CheckedChanged(object sender, EventArgs e)
        {
            ActivarBusquedaProductoPorNombre();
        }

        private void ActivarBusquedaProductoPorNombre()
        {
            _controlador.ActivarBusquedaProductoPorNombre();
            IniciarBusqueda();
        }

        private void RB_BUSCAR_POR_REFERENCIA_CheckedChanged(object sender, EventArgs e)
        {
            ActivarBusquedaProductoPorReferencia();
        }

        private void ActivarBusquedaProductoPorReferencia()
        {
            _controlador.ActivarBusquedaProductoPorReferencia();
            IniciarBusqueda();
        }

        private void TB_CADENA_BUSQ_Leave(object sender, EventArgs e)
        {
            _controlador.CadenaPrdBuscar=TB_CADENA_BUSQ.Text.Trim().ToUpper();
        }

        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

    }

}