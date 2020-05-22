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


        private bool _permitirBusquedaPorDescripcion;
        private Enumerados.EnumModoOperacionPos _modoOperacionPos;
        private bool _activarRepesaje;
        private decimal _limiteRepesajeInf ;
        private decimal _limiteRepesajeSup ;
        private decimal _montoDivisa;
        private CtrItem _ctrItem;
        private CtrCliente _ctrCliente;
        private Timer _hora;
        private Venta _venta;
        private OOB.LibVenta.PosOffline.Configuracion.Vendedor.Ficha _vendedor;
        private OOB.LibVenta.PosOffline.Configuracion.Deposito.Ficha _deposito;

     
        public PosVenta()
        {
            InitializeComponent();

            _venta = new Venta();
            _venta.ProcesarOk+=_venta_ProcesarOk;
            _ctrItem = new CtrItem();
            _ctrItem.PrdAcutalCambioOk+=_ctrItem_PrdAcutalCambioOk;
            _ctrCliente = new CtrCliente();
            _vendedor = null;
            _deposito = null;

            _hora = new Timer();
            _hora.Interval = 1000;
            _hora.Start();
            _hora.Tick+=_hora_Tick;

            Helpers.FormatoPreEmpaque formato = new Helpers.FormatoPreEmpaque();
            Helpers.BuscarProducto.setFormatoPreEmpaque(formato);
            InicializarGrid();
            Limpiar();
        }

        private void _venta_ProcesarOk(object sender, EventArgs e)
        {
            _ctrCliente.Limpiar();
            _ctrItem.Limpiar(false);
            ActualizarCliente();
            ActualizarTotal();
            IrFoco();
            Limpiar();
        }

        private void _hora_Tick(object sender, EventArgs e)
        {
            L_HORA.Text = DateTime.Now.ToLongTimeString();
        }

        public bool CargarData() 
        {
            var rt = true;

            _permitirBusquedaPorDescripcion = false;
            _modoOperacionPos = Enumerados.EnumModoOperacionPos.Detal;
            _montoDivisa = 0.0m;
            _activarRepesaje = false;
            _limiteRepesajeInf = 0.0m;
            _limiteRepesajeSup = 0.0m;

            var r01 = Sistema.MyData2.Item_Cargar();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            if (r01.Lista.Count > 0)
            {
                _ctrItem.CargarLista(r01.Lista);
            }

            var r02 = Sistema.MyData2.Fiscal_Tasas();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            _venta.setFiscal(r02.Entidad);

            var r03 = Sistema.MyData2.Configuracion_FactorCambio();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            _montoDivisa = r03.Entidad;
            _ctrItem.setMontoDivisa(_montoDivisa);

            var r04 = Sistema.MyData2.Configuracion_Repesaje();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }
            _activarRepesaje = r04.Entidad.IsActivo;
            _limiteRepesajeInf = r04.Entidad.LimiteValidoInferior;
            _limiteRepesajeSup = r04.Entidad.LimiteValidoSuperior;
            _ctrItem.setRepesaje(_activarRepesaje, _limiteRepesajeInf, _limiteRepesajeSup);

            var r05 = Sistema.MyData2.Configuracion_Serie();
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }
            _venta.SerieFactura = r05.Entidad.ParaFactura;
            _venta.SerieNotaCredito = r05.Entidad.ParaNotaCredito;
            _venta.SerieNotaDebito = r05.Entidad.ParaNotaDebito;

            var r06 = Sistema.MyData2.Configuracion_Sucursal();
            if (r06.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return false;
            }
            _venta.CodigoSucursal = r06.Entidad.Codigo;

            var r07 = Sistema.MyData2.Configuracion_ModoPos ();
            if (r07.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r07.Mensaje);
                return false;
            }
            switch(r07.Entidad.Modo)
            {
                case OOB.LibVenta.PosOffline.Configuracion.Enumerados.EnumModoPos.Detal:
                    _modoOperacionPos = Enumerados.EnumModoOperacionPos.Detal;
                    break;
                case OOB.LibVenta.PosOffline.Configuracion.Enumerados.EnumModoPos.Mayor:
                    _modoOperacionPos = Enumerados.EnumModoOperacionPos.Mayor;
                    break;
            }

            var r08 = Sistema.MyData2.Configuracion_Deposito();
            if (r08.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r08.Mensaje);
                return false;
            }
            _venta.setDeposito(r08.Entidad);

            var r09 = Sistema.MyData2.Configuracion_Vendedor();
            if (r09.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r09.Mensaje);
                return false;
            }
            _venta.setVendedor(r09.Entidad);

            var r0a = Sistema.MyData2.Configuracion_ActivarBusquedaPorDescripcion();
            if (r0a.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0a.Mensaje);
                return false;
            }
            _permitirBusquedaPorDescripcion = r0a.Entidad;

            var r0b = Sistema.MyData2.Configuracion_Cobrador ();
            if (r0b.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0b.Mensaje);
                return false;
            }
            _venta.setCobrador(r0b.Entidad);

            var r0c = Sistema.MyData2.Configuracion_Transporte();
            if (r0c.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0c.Mensaje);
                return false;
            }
            _venta.setTransporte(r0c.Entidad);

            var r0d = Sistema.MyData2.Configuracion_MedioCobro();
            if (r0d.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0d.Mensaje);
                return false;
            }
            _venta.setMedioCobro(r0d.Entidad);

            var r0e = Sistema.MyData2.Permiso_ManejoPos();
            if (r0e.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0e.Mensaje);
                return false;
            }
            _venta.setPermiso(r0e.Entidad);

            return rt;
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
            c3.Width = 100;
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
            L_MONTO_DIVISA.Text = _montoDivisa.ToString("n2");
            L_FECHA.Text = "Hoy : "+DateTime.Now.ToShortDateString();
            L_HORA.Text = "";
            L_USUARIO.Text = Sistema.Usuario.Usuario;
            L_ESTACION.Text = Environment.MachineName;
            ActualizarCliente();
            ActualizarTotal();

            DGV_DETALLE.DataSource = _ctrItem.Source;

            IrFoco();
        }

        private void BT_CONSULTAR_Click(object sender, EventArgs e)
        {
            Consultar();
            IrFoco();
        }

        Consultor.ConsultorFrm frmConsultor;
        private void Consultar()
        {
            if (frmConsultor == null) 
            {
                frmConsultor = new Consultor.ConsultorFrm();
            }
            frmConsultor.ShowDialog();
            ActivarBuscar();
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
                var rt = Helpers.BuscarProducto.ActivarBusqueda(buscar, _permitirBusquedaPorDescripcion);
                if (rt)
                {
                    _ctrItem.RegistraItem(Helpers.BuscarProducto.Producto, Helpers.BuscarProducto.Peso);
                    ActualizarTotal();
                }
                else 
                {
                    Helpers.Msg.Error("Producto No Encontrado");
                    return;
                }
            }
        }

        private void ActualizarTotal()
        {
            L_IMPORTE.Text=_ctrItem.SubTotal.ToString("n2");
            L_TOTAL_ITEMS.Text = _ctrItem.CantItem.ToString("n0");
            L_TOTAL_KILOS.Text = _ctrItem.TotalPeso.ToString("n3");
            L_TOTAL_RENGLONES.Text = _ctrItem.Renglones.ToString("n0");
            L_TOTAL_DIVISA.Text = _ctrItem.TotalDivisa.ToString("n2");

            L_PRODUCTO.Text = _ctrItem.PrdActual.Nombre;
            L_PRD_NETO.Text = _ctrItem.PrdActual.PrecioNeto.ToString("n2");
            L_PRD_TASA.Text =  _ctrItem.PrdActual.TasaIva;
            L_PRD_IVA.Text = _ctrItem.PrdActual.Iva.ToString("n2");
            L_PRD_CONT.Text = _ctrItem.PrdActual.Contenido.ToString("n0");
            DGV_DETALLE.Refresh();
        }

        private void BT_CLIENTE_Click(object sender, EventArgs e)
        {
            Cliente();
            IrFoco();
        }

        private void Cliente()
        {
            _ctrCliente.Buscar();
            ActualizarCliente();
        }

        private void ActualizarCliente()
        {
            L_CLIENTE.Text = "";
            if (_ctrCliente.Cliente != null)
            {
                L_CLIENTE.Text = _ctrCliente.Cliente.Data;
            }
        }

        private void TB_BUSCAR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==  (char)43 || e.KeyChar== (char)Keys.Oemplus )
            {
                if (TB_BUSCAR.Text == "")
                {
                    IncrementarItem(1);
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
            IncrementarItem(1);
            IrFoco();
        }

        private void IncrementarItem(int p)
        {
            _ctrItem.IncrementarItem(p);
        }

        private void AnularVenta()
        {
            var msg = MessageBox.Show("Anular Venta ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes) 
            {
                _ctrCliente.Limpiar();
                _ctrItem.Limpiar();
                ActualizarCliente();
                ActualizarTotal();
            }
            IrFoco();
        }

        private void IrFoco()
        {
            TB_BUSCAR.Focus();
        }

        private void BT_MULTIPLICA_Click(object sender, EventArgs e)
        {
            Multiplicar();
            IrFoco();
        }

        private void Multiplicar()
        {
            _ctrItem.Multiplicar();
        }

        private void BT_RESTAR_Click(object sender, EventArgs e)
        {
            Restar();
            IrFoco();
        }

        private void Restar()
        {
            DGV_DETALLE.DataSource = null;
            _ctrItem.Restar();
            DGV_DETALLE.DataSource = _ctrItem.Source;
            DGV_DETALLE.Refresh();
        }

        private void BT_TOTAL_Click(object sender, EventArgs e)
        {
            Totalizar();
            IrFoco();
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
            if (_ctrItem.SubTotal > 0) 
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
            Helpers.Utilitis.Calculadora();
            IrFoco();
        }

        private void BT_LISTA_OFERTA_Click(object sender, EventArgs e)
        {
            ListaOferta();
            IrFoco();
        }

        private void ListaOferta()
        {
            var frm = new ProductoLista.ListaOfertaFrm ();
            if (frm.CargarData())
            {
                frm.ShowDialog();
            }
        }

        private void BT_LISTA_PLU_Click(object sender, EventArgs e)
        {
            ListaPlu();
            IrFoco();
        }

        private void ListaPlu()
        {
            var frm = new ProductoLista.ListaPluFrm();
            if (frm.CargarData()) 
            {
                frm.ShowDialog();
                if (frm.IsProductoSelected) 
                {
                    _ctrItem.RegistraItem(frm.ProductoSelected , 0 );
                    ActualizarTotal();
                }
            }
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
            _venta.setUsuario(Sistema.Usuario);
            _venta.setCliente(_ctrCliente);
            _venta.setItem(_ctrItem);
            _venta.Procesar();
        }

        private void BT_PENDIENTE_Click(object sender, EventArgs e)
        {
            DejarCtaEnPendiente();
        }

        private void DejarCtaEnPendiente()
        {
            var result = _ctrItem.DejarCtaEnPendiente(_ctrCliente.Cliente);
            if (result)
            {
                _ctrCliente.Limpiar();
                _ctrItem.Limpiar();
                ActualizarCliente();
                ActualizarTotal();
            }
            IrFoco();
        }

        private void BT_ABRIR_PENDIENTE_Click(object sender, EventArgs e)
        {
            AbrirCtaEnPendiente();
        }

        private void AbrirCtaEnPendiente()
        {
            var result = _ctrItem.AbrirCtaEnPendiente(_ctrCliente);
            if (result)
            {
                ActualizarCliente();
                ActualizarTotal();
            }
            IrFoco();
        }

        private void DevolucionItem()
        {
            _ctrItem.ActivarDevolucion();
            ActualizarTotal();
            IrFoco();
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
    
    }

}