using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Movimiento.Traslado.EntreSucursalesPorExistenciaPorDebajoNivelMinimo
{

    public partial class MovimientoFrm : Form
    {

        private Gestion _controlador { get; set; }


        public MovimientoFrm()
        {
            InitializeComponent();
        }

        private void MovimientoFrm_Load(object sender, EventArgs e)
        {
            Inicializar();
            DGV.DataSource =  _controlador.ItemSource;
            ActualizarTotales();
        }

        private void ActualizarTotales()
        {
            L_ITEMS.Text = _controlador.Items.ToString("n0");
            L_TOTAL.Text = _controlador.Total.ToString("n2");
        }

        private void Inicializar()
        {
            InicializarGrid();

            CB_SUC_ORIGEN.DisplayMember = "Nombre";
            CB_SUC_ORIGEN.ValueMember = "Auto";
            CB_SUC_ORIGEN.DataSource = _controlador._bsSucOrigen;

            CB_SUC_DESTINO.DisplayMember = "Nombre";
            CB_SUC_DESTINO.ValueMember = "Auto";
            CB_SUC_DESTINO.DataSource = _controlador._bsSucDestino ;
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
            c2.DataPropertyName = "NombrePrd";
            c2.HeaderText = "Nombre";
            c2.Visible = true;
            c2.MinimumWidth = 120;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Cantidad";
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
            c4.Width = 80;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Costo";
            c5.HeaderText = "Costo sin Iva";
            c5.Visible = true;
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Importe";
            c6.HeaderText = "Total";
            c6.Visible = true;
            c6.Width = 120;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_CARGAR_DATA_Click(object sender, EventArgs e)
        {
            BuscarProductosPorDebajoNivel();
            DGV.Refresh();
            ActualizarTotales();
        }

        private void BuscarProductosPorDebajoNivel()
        {
            _controlador.BuscarProductosPorDebajoNivel();
        }

        private void CB_SUC_DESTINO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador._autoSucDestino = CB_SUC_DESTINO.SelectedValue.ToString();
        }

        private void CB_SUC_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador._autoSucOrigen = CB_SUC_ORIGEN.SelectedValue.ToString();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            if (_controlador.Salida()) 
            {
                this.Close();
            }
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            AceptarMovimiento();
        }

        private void AceptarMovimiento()
        {
            _controlador.ProcesarMovimiento();
            if (_controlador.IsMovimientoOk) 
            {
                this.Close();
            }
        }

        private void TB_DESCRIPCION_TextChanged(object sender, EventArgs e)
        {
            _controlador._descripcionMov = TB_DESCRIPCION.Text;
        }

        private void TB_AUTORIZADO_TextChanged(object sender, EventArgs e)
        {
            _controlador._autorizadoPor= TB_AUTORIZADO.Text;
        }

        private void DTP_FECHA_ValueChanged(object sender, EventArgs e)
        {
            _controlador._fechaMov = DTP_FECHA.Value;
        }

    }

}