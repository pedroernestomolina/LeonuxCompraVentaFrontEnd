using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion
{

    public partial class PosVenta : Form
    {

        private Venta _venta;
        private Timer _hora;
        private BindingSource _bs;

     
        public PosVenta()
        {
            InitializeComponent();

            _hora = new Timer();
            _hora.Interval = 1000;
            _hora.Start();
            _hora.Tick+=_hora_Tick;

            InicializarGrid();
            Limpiar();
        }

        private void _venta_ProcesarOk(object sender, EventArgs e)
        {
            Limpiar();
            Actualizar();
        }

        private void _hora_Tick(object sender, EventArgs e)
        {
            L_HORA.Text = DateTime.Now.ToLongTimeString();
        }

        private void _ctrItem_PrdAcutalCambioOk(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        private void Limpiar()
        {
            L_IMPORTE.Text = "0.00";
            L_TOTAL_ITEMS.Text = "0";
            L_TOTAL_KILOS.Text = "0.00";
            L_TOTAL_RENGLONES.Text = "0";
            L_PRODUCTO.Text = "";
            L_PRD_NETO.Text = "0.00";
            L_PRD_TASA.Text = "Ex";
            L_PRD_IVA.Text = "0.00";
            L_PRD_CONT.Text = "1";
            L_CLIENTE.Text = "";
            L_MONTO_DIVISA.Text = "0.00";
            L_TOTAL_DIVISA.Text = "0.00";
        }

        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            DGV_DETALLE.AllowUserToAddRows = false;
            DGV_DETALLE.AllowUserToDeleteRows = false;
            DGV_DETALLE.AutoGenerateColumns = false;
            DGV_DETALLE.AllowUserToResizeRows = false;
            DGV_DETALLE.AllowUserToResizeColumns = false;
            DGV_DETALLE.AllowUserToOrderColumns = false;
            DGV_DETALLE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_DETALLE.MultiSelect = false;
            DGV_DETALLE.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "NombrePrd";
            c1.HeaderText = "Descripcion";
            c1.Visible = true;
            c1.MinimumWidth = 120;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Cantidad";
            c2.Name = "Cantidad";
            c2.HeaderText = "Cant";
            c2.Visible = true;
            c2.Width = 60;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Importe";
            c3.HeaderText = "Importe";
            c3.Visible = true;
            c3.Width = 120;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n2";

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "TasaIvaDesc";
            c4.HeaderText = "%Tasa";
            c4.Visible = true;
            c4.Width = 60;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            c4.DefaultCellStyle.Format = "n2";

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "Total";
            c5.HeaderText = "SubTotal";
            c5.Visible = true;
            c5.Width = 120;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var c6 = new DataGridViewCheckBoxColumn();
            c6.DataPropertyName = "EsPesado";
            c6.HeaderText = "Kg";
            c6.Name = "EsPesado";
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.Width = 30;

            DGV_DETALLE.Columns.Add(c1);
            DGV_DETALLE.Columns.Add(c2);
            DGV_DETALLE.Columns.Add(c3);
            DGV_DETALLE.Columns.Add(c4);
            DGV_DETALLE.Columns.Add(c5);
            DGV_DETALLE.Columns.Add(c6);
        }
    
        private void DGV_DETALLE_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGV_DETALLE.Columns[e.ColumnIndex].Name.Equals("EsPesado"))
            {
                DataGridViewCell cell = this.DGV_DETALLE.Rows[e.RowIndex].Cells[1];
                if ((bool)e.Value)
                {
                    cell.Style.Format = "n3";
                }
                else
                {
                    cell.Style.Format = "n0";
                }
            }
        }


        private void PosVenta_Load(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;

            DGV_DETALLE.DataSource = _venta.Items.Source;
            L_MONTO_DIVISA.Text = _venta.TasaCambio.ToString("n2");
            L_FECHA.Text = "Hoy : "+DateTime.Now.ToShortDateString();
            L_HORA.Text = "";
            L_USUARIO.Text = Sistema.Usuario.Usuario;
            L_ESTACION.Text = Environment.MachineName;

            ActualizarModo();

            Actualizar();
        }

        private void BT_CONSULTAR_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            _venta.Consultor();
            Actualizar();
        }

        private void ActivarBuscar()
        {
            TB_BUSCAR.Text = "";
            TB_BUSCAR.Focus();
        }

        private void TB_BUSCAR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) 
            {
                BuscarProducto();
                ActivarBuscar();
            }
        }

        private void BuscarProducto()
        {
            var buscar = TB_BUSCAR.Text.Trim().ToUpper();
            if (buscar != "")
            {
                _venta.BuscarProducto(buscar);
                Actualizar();
            }
        }

        private void ActualizarTotal()
        {
            L_IMPORTE.Text=_venta.Items.SubTotal.ToString("n2");
            L_TOTAL_ITEMS.Text = _venta.Items.CantItem.ToString("n0");
            L_TOTAL_KILOS.Text = _venta.Items.TotalPeso.ToString("n3");
            L_TOTAL_RENGLONES.Text = _venta.Items.Renglones.ToString("n0");
            L_TOTAL_DIVISA.Text = _venta.Items.TotalDivisa.ToString("n2");

            L_PRODUCTO.Text = _venta.Items.PrdActual.Nombre;
            L_PRD_NETO.Text = _venta.Items.PrdActual.PrecioNeto.ToString("n2");
            L_PRD_TASA.Text = _venta.Items.PrdActual.TasaIva;
            L_PRD_IVA.Text = _venta.Items.PrdActual.Iva.ToString("n2");
            L_PRD_CONT.Text = _venta.Items.PrdActual.Contenido.ToString("n0");
            DGV_DETALLE.Refresh();
        }

        private void BT_CLIENTE_Click(object sender, EventArgs e)
        {
            Cliente();
        }

        private void Cliente()
        {
            _venta.ClienteBuscar();
            ActualizarCliente();
            IrFoco();
        }

        private void ActualizarCliente()
        {
            L_CLIENTE.Text = "";
            L_CLIENTE.Text = _venta.Cliente.Ficha.Data;
        }

        private void TB_BUSCAR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==  (char)43 || e.KeyChar== (char)Keys.Oemplus )
            {
                if (TB_BUSCAR.Text == "")
                {
                    IncrementarItem();
                    e.Handled = true;
                }
            }
            if (e.KeyChar == (char)45 || e.KeyChar == (char)Keys.OemMinus)
            {
                if (TB_BUSCAR.Text == "")
                {
                    Restar();
                    e.Handled = true;
                }
            }
            if (e.KeyChar == (char)42)
            {
                if (TB_BUSCAR.Text == "")
                {
                    Multiplicar();
                    e.Handled = true;
                }
            }
        }

        private void BT_SUMAR_Click(object sender, EventArgs e)
        {
            IncrementarItem();
        }

        private void IncrementarItem()
        {
            _venta.IncrementarItem();
            Actualizar();
        }

        private void AnularVenta()
        {
            DGV_DETALLE.DataSource = null;
            _venta.AnularVenta();
            Actualizar();
            DGV_DETALLE.DataSource = _bs;
            ActualizarModo();
        }

        private void ActualizarModo() 
        {
            L_MODO_FUNCION.Text = "Facturación :)";
            L_MODO_FUNCION.ForeColor = Color.Yellow;

            if (_venta.ModoFuncion == Enumerados.EnumModoFuncion.NotaCredito)
            {
                L_MODO_FUNCION.Text = ":( Nt/Crédito";
                L_MODO_FUNCION.ForeColor = Color.Red;
            }
        }

        private void IrFoco()
        {
            TB_BUSCAR.Focus();
        }

        private void BT_MULTIPLICA_Click(object sender, EventArgs e)
        {
            Multiplicar();
        }

        private void Multiplicar()
        {
            _venta.Multiplicar();
            Actualizar();
        }

        private void BT_RESTAR_Click(object sender, EventArgs e)
        {
            Restar();
        }

        private void Restar()
        {
            _venta.Restar();
            Actualizar();
        }

        private void BT_TOTAL_Click(object sender, EventArgs e)
        {
            Totalizar();
        }
     
        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
        }

        private void Salida()
        {
            this.Close();
        }

        private void PosVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_venta.Items.SubTotal > 0) 
            {
                MessageBox.Show("HAY ITEMS EN PROCESO !!!","*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                e.Cancel = true;
            }
        }
    

        private void BT_CALCULADORA_Click(object sender, EventArgs e)
        {
            ActivarCalculadora();
        }

        private void ActivarCalculadora()
        {
            _venta.ActivarCalculador();
            Actualizar();
        }

        private void BT_LISTA_OFERTA_Click(object sender, EventArgs e)
        {
            ListaOferta();
        }

        private void ListaOferta()
        {
            _venta.ListaOferta();
            Actualizar();
        }

        private void BT_LISTA_PLU_Click(object sender, EventArgs e)
        {
            ListaPlu();
        }

        private void ListaPlu()
        {
            _venta.ListaPlu();
            Actualizar();
        }

        private void BT_DEVOLUCION_Click(object sender, EventArgs e)
        {
            DevolucionItem();
        }

        private void BT_ANULAR_Click(object sender, EventArgs e)
        {
            AnularVenta();
        }

        private void Totalizar()
        {
            DGV_DETALLE.DataSource = null;
            _venta.Procesar();
            if (_venta.DocumentoProcesadoIsOk) 
            {
                printDocument1.Print();
            }

            ActualizarModo();
            Actualizar();
            DGV_DETALLE.DataSource = _bs;
        }

        private void BT_PENDIENTE_Click(object sender, EventArgs e)
        {
            DejarCtaEnPendiente();
        }

        private void DejarCtaEnPendiente()
        {
            DGV_DETALLE.DataSource = null;
            _venta.DejarCtaPendiente();
            Actualizar();
            DGV_DETALLE.DataSource = _bs;
        }

        private void BT_ABRIR_PENDIENTE_Click(object sender, EventArgs e)
        {
            AbrirCtaEnPendiente();
        }

        private void AbrirCtaEnPendiente()
        {
            _venta.CtaPendiente();
            Actualizar();
        }

        private void DevolucionItem()
        {
            _venta.Devolucion();
            Actualizar();
        }

        private void DGV_DETALLE_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void PosVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) 
            {
                IrFoco();
            }
            if (e.KeyCode == Keys.F2)
            {
                Cliente();
            }
            if (e.KeyCode == Keys.F3)
            {
                Consultar();
            }
            if (e.KeyCode == Keys.F4)
            {
                DevolucionItem();
            }
            if (e.KeyCode == Keys.F5)
            {
                DejarCtaEnPendiente();
            }
            if (e.KeyCode == Keys.F6)
            {
                AbrirCtaEnPendiente();
            }
            if (e.KeyCode == Keys.Delete)
            {
                AnularVenta();
            }
            if (e.KeyCode == Keys.F10)
            {
                Totalizar();
            }
        }

        public void setVenta(Venta venta) 
        {
            _venta = venta;
            _bs = _venta.Items.Source;
            _bs.CurrentChanged+= _bs_CurrentChanged;
        }

        private void _bs_CurrentChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void Actualizar() 
        {
            ActualizarCliente();
            ActualizarTotal();
            IrFoco();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Cancel = false;
            _venta.Imprimir(e);
        }
   
    }

}