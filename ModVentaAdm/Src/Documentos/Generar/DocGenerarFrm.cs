using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Documentos.Generar
{

    public partial class DocGenerarFrm : Form
    {


        private Gestion _controlador;


        public DocGenerarFrm()
        {
            InitializeComponent();
            InicializaGridItems();
        }

        private void InicializaGridItems()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);
            var f2 = new Font("Serif", 10, FontStyle.Bold);

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
            c1.Width = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "DescripcionPrd";
            c2.HeaderText = "Descripcion";
            c2.Visible = true;
            c2.MinimumWidth = 220;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Cant";
            c3.HeaderText = "Cant";
            c3.Visible = true;
            c3.Width = 60;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Format = "n2";
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "PNeto";
            c4.HeaderText = "P/Neto";
            c4.Visible = true;
            c4.Width = 90;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Format = "n2";
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Dscto";
            c5.HeaderText = "Dsctos";
            c5.Visible = true;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";
            c5.Width = 90;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "PImporte";
            c6.HeaderText = "P/Importe";
            c6.Visible = true;
            c6.Width = 90;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Format = "n2";
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "TasaIvaDesc";
            c7.HeaderText = "Iva%";
            c7.Visible = true;
            c7.Width = 60;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Format = "n2";
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "Empaque";
            c8.HeaderText = "Empaque";
            c8.Visible = true;
            c8.Width = 100;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c8);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c6);
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void DocGenerarFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.ItemsSource;
            L_TIPO_DOCUMENTO.Text = _controlador.TipoDocumento;
            ActualizarVistaCliente();
            ActualizaVistaTotales();

            switch (_controlador.TipoDocumento) 
            {
                case "FACTURA":
                    P_DOCUMENTO.BackColor = Color.DarkGreen;
                    L_TIPO_DOCUMENTO.ForeColor = Color.White;
                    break;

                case "PRESUPUESTO":
                    P_DOCUMENTO.BackColor = Color.Yellow;
                    L_TIPO_DOCUMENTO.ForeColor = Color.Black;
                    break;

                case "PEDIDO":
                    P_DOCUMENTO.BackColor = Color.Blue;
                    L_TIPO_DOCUMENTO.ForeColor = Color.White;
                    break;
            }
        }

        private void ActualizaVistaTotales()
        {
            L_MONTO.Text = _controlador.Monto;
            L_MONTO_DIVISA.Text = _controlador.MontoDivisa;
            L_MONTO_NETO.Text = _controlador.MontoNeto;
            L_MONTO_IVA.Text = _controlador.MontoIva;
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Abandonar();
        }

        private void Abandonar()
        {
            _controlador.AbandonarDoc();
            if (_controlador.AbandonarDocIsOk) 
            {
                Salida();
            }
        }

        private void Salida()
        {
            this.Close();
        }

        private void DocGenerarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.AbandonarDocIsOk)
            {
                e.Cancel = false;
            }
        }

        private void BT_NUEVO_DOC_Click(object sender, EventArgs e)
        {
            NuevoDocumento();
        }

        private void NuevoDocumento()
        {
            _controlador.NuevoDocumento();
            ActualizarVistaCliente();
        }

        private void ActualizarVistaCliente()
        {
            L_RIF_CLIENTE.Text = _controlador.RifCliente;
            L_CODIGO_CLIENTE.Text = _controlador.CodigoCliente;
            L_CLIENTE.Text = _controlador.Cliente;
        }

        private void BT_DATOS_DOCUMENTO_EDITAR_Click(object sender, EventArgs e)
        {
            EditarDatosDocumento();
        }

        private void EditarDatosDocumento()
        {
            _controlador.EditarDatosDocumento();
            ActualizarVistaCliente();
        }

        private void BT_DATOS_DOCUMENTO_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarDatosDocumento();
        }

        private void LimpiarDatosDocumento()
        {
            _controlador.LimpiarDatosDocumento();
            ActualizarVistaCliente();
        }

        private void BT_VISUALIZAR_CLIENTE_Click(object sender, EventArgs e)
        {
            VisualizarCliente();
        }

        private void VisualizarCliente()
        {
            _controlador.VisualizarCliente();
        }

        private void BT_VISUALIZAR_CLIENTE_DOC_Click(object sender, EventArgs e)
        {
            VisualizarClenteDoc();
        }

        private void VisualizarClenteDoc()
        {
            _controlador.VisualizarClenteDoc();
        }

        private void BT_VISUALIZAR_CLIENTE_ARTICULOS_Click(object sender, EventArgs e)
        {
            VisualizarClienteArticulos();
        }

        private void VisualizarClienteArticulos()
        {
            _controlador.VisualizarClienteArticulos();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _controlador.AgregarItem();
            ActualizaVistaTotales();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _controlador.LimpiarItems();
            ActualizaVistaTotales();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _controlador.EliminarItem();
            ActualizaVistaTotales();
        }

    }

}