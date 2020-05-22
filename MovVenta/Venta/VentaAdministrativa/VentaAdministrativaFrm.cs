using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MovVenta.Venta.VentaAdministrativa
{

    public partial class VentaAdministrativaFrm : Form
    {

        private Venta Ficha { get; set; }
        private bool _habilitarRupturaPorExistencia;
        private bool _habilitarAlertaPorExistenciaEnNegativo;
        private OOB.LibVenta.Usuario.Ficha _usuario; 
        private OOB.LibVenta.Permiso.Ficha _darPermisoEliminarItem;
        private OOB.LibVenta.Permiso.Ficha _darPermisoDescuentoItem;
        private OOB.LibVenta.Permiso.Ficha _darPermisoPrecioLibre;
        private OOB.LibVenta.Permiso.Ficha _darPermisoDsctCargoGlobal;
        private CtrlCliente _ctrlCliente;
        private CtrlItems _ctrlItems;
        private CtrlTotales _ctrlTotales;


        public VentaAdministrativaFrm()
        {
            InitializeComponent();
            Ficha = new Venta();
            Ficha.AgregarOK+=Ficha_AgregarOK;
            _ctrlCliente = new CtrlCliente();
            _ctrlCliente.ClienteOK+=_ctrlCliente_ClienteOK;
            _ctrlItems = new CtrlItems();
            _ctrlItems.ItemOk+=_ctrlItems_ItemOk;
            _ctrlTotales = new CtrlTotales();
            _ctrlTotales.TotalesOK+=_ctrlTotales_TotalesOK;

            InicializarGridDetalle();
            InicializaControles();
        }

        private void Ficha_AgregarOK(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void _ctrlTotales_TotalesOK(object sender, VentaAdministrativa.Totalizar e)
        {
            ProcesarOk(e);
        }

        private void _ctrlCliente_ClienteOK(object sender, OOB.LibVenta.Cliente.Ficha e)
        {
            if (e != null)
            {
                var montoDoc=e.DocumentosPendientePorCobrar.Sum(sm=>sm.MontoPendiente);
                if (montoDoc >= e.LimitePorMonto) 
                {
                    Helpers.Msg.Error("CLIENTE SUPERA EL LIMITE EN MONTO DE DOCUMENTOS PENDIENTE");
                    return;
                }

                var cntDoc=e.DocumentosPendientePorCobrar.Count(ct=>ct.IsDocumentoFactura);
                if (cntDoc >= e.LimitePorDocumento) 
                {
                    Helpers.Msg.Error("CLIENTE SUPERA EL LIMITE EN CANTIDAD DE DOCUMENTOS PENDIENTE");
                    return;
                }

                if (e.TarifaPrecio == OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio.SinDefinir) 
                {
                    Helpers.Msg.Error("CLIENTE NO POSEE TARIFA DE PRECIO SELECCIONADA");
                    return;
                }
            }

            Ficha.Cliente = e;
            ActualizarCliente();
        }

        private void _ctrlItems_ItemOk(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void InicializarGridDetalle()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            DGV_DETALLE.AllowUserToAddRows = false;
            DGV_DETALLE.AutoGenerateColumns = false;
            DGV_DETALLE.AllowUserToResizeRows = false;
            DGV_DETALLE.AllowUserToResizeColumns = false;
            DGV_DETALLE.AllowUserToOrderColumns = false;
            DGV_DETALLE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_DETALLE.MultiSelect = false;
            DGV_DETALLE.ReadOnly = true;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "CodigoPrd";
            c1.HeaderText = "Código";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "NombrePrd";
            c2.HeaderText = "Descripcion";
            c2.Visible = true;
            c2.MinimumWidth = 120;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Cantidad";
            c3.Name = "Cantidad";
            c3.HeaderText = "Cant";
            c3.Visible = true;
            c3.Width = 80;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "EmpaqueVentaDescripcion";
            c4.HeaderText = "Empaque";
            c4.Visible = true;
            c4.Width = 80;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "EmpaqueVentaContenido";
            c5.HeaderText = "Cont";
            c5.Visible = true;
            c5.Width = 60;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "PrecioVenta";
            c6.HeaderText = "Precio";
            c6.Visible = true;
            c6.Width = 100;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";

            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "TasaIva";
            c7.HeaderText = "%Tasa";
            c7.Visible = true;
            c7.Width = 60;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "Importe";
            c8.HeaderText = "Total Neto";
            c8.Visible = true;
            c8.Width = 120;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f1;
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c8.DefaultCellStyle.Format = "n2";

            var c9 = new DataGridViewTextBoxColumn();
            c9.DataPropertyName = "EsPesado";
            c9.Name = "EsPesado";
            c9.Visible = false;

            DGV_DETALLE.Columns.Add(c1);
            DGV_DETALLE.Columns.Add(c2);
            DGV_DETALLE.Columns.Add(c3);
            DGV_DETALLE.Columns.Add(c4);
            DGV_DETALLE.Columns.Add(c5);
            DGV_DETALLE.Columns.Add(c6);
            DGV_DETALLE.Columns.Add(c7);
            DGV_DETALLE.Columns.Add(c8);
            DGV_DETALLE.Columns.Add(c9);
        }

        private void DGV_DETALLE_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGV_DETALLE.Columns[e.ColumnIndex].Name.Equals("EsPesado")) 
            {
                DataGridViewCell cell = this.DGV_DETALLE.Rows[e.RowIndex].Cells[3];
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

        private void DGV_DETALLE_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //foreach (DataGridViewRow row in DGV_DETALLE.Rows)
            //{
            //    row.DefaultCellStyle.Format = (bool)row.Cells["EsPesado"].Value ? "n3" : "n0";
            //}
        }

        private void TB_DIR_DESPACHO_Validated(object sender, EventArgs e)
        {
            Ficha.DireccionDespacho = TB_DIR_DESPACHO.Text.Trim();
        }

        private void TB_ORDEN_COMPRA_Validated(object sender, EventArgs e)
        {
            Ficha.OrdenCompraNro = TB_ORDEN_COMPRA.Text.Trim();
        }

        private void TB_PEDIDO_Validated(object sender, EventArgs e)
        {
            Ficha.PedidoNro = TB_PEDIDO.Text.Trim();
        }

        private void DTP_FECHA_PEDIDO_Validated(object sender, EventArgs e)
        {
            Ficha.FechaPedido = DTP_FECHA_PEDIDO.Value.Date;
        }

        private void TB_NOTAS_DOC_Validated(object sender, EventArgs e)
        {
            Ficha.NotasDocumento = TB_NOTAS_DOC.Text.Trim();
        }


        private void InicializaControles()
        {
            //
            CB_DEPOSITO.DisplayMember = "Nombre";
            CB_DEPOSITO.ValueMember = "Auto";
            CB_DEPOSITO.DataSource = Ficha.SourceDeposito;
            //
            CB_SUCURSAL.DisplayMember = "Nombre";
            CB_SUCURSAL.ValueMember = "Auto";
            CB_SUCURSAL.DataSource = Ficha.SourceSucursal;
            //
            CB_VENDEDOR.DisplayMember = "Nombre";
            CB_VENDEDOR.ValueMember= "Auto";
            CB_VENDEDOR.DataSource = Ficha.SourceVendedor;
            //
            CB_COBRADOR.DisplayMember = "Nombre";
            CB_COBRADOR.ValueMember= "Auto";
            CB_COBRADOR.DataSource = Ficha.SourceCobrador;
            //
            CB_TRANSPORTE.DisplayMember = "Nombre";
            CB_TRANSPORTE.ValueMember = "Auto";
            CB_TRANSPORTE.DataSource = Ficha.SourceTransporte;
            //
            CB_SERIE.DisplayMember = "Descripcion";
            CB_SERIE.ValueMember = "Auto";
            CB_SERIE.DataSource = Ficha.SourceSerie;
            //
            CB_MODO_IMPRESION.DataSource = Ficha.SourceModoImpresion;
            //
            string[] condicionPago = { "CONTADO", "CREDITO" };
            CB_CONDICION_PAGO.DataSource = condicionPago;
            CB_CONDICION_PAGO.Enabled = !Ficha.IsContado;
            TB_DIAS_CREDITO.Text = "0";
            TB_DIAS_CREDITO.Enabled = !Ficha.IsContado;
            L_TOTAL.Text = "0.0";
        }

        public bool CargarData()
        {
            var rt = true;

            if (!Ficha.CargarData())
            {
                return false;
            }

            //
            var r05 = Program.MyData.FechaServidor();
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }
            Ficha.FechaEmision = r05.Entidad;
            Ficha.FechaPedido = r05.Entidad;

            //
            var r06 = Program.MyData.FactorCambioDivisa();
            if (r06.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return false;
            }

            //
            var r07 = Program.MyData.FactorCambioDivisaParaRecibir();
            if (r07.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r07.Mensaje);
                return false;
            }
            Ficha.setFactorCambioParaRecibirDivisa(r07.Entidad);
            _ctrlItems.setFactorCambioParaRecibirDivisa(r07.Entidad);

            //
            var r08 = Program.MyData.HabilitarRupturaPorExistencia();
            if (r08.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r08.Mensaje);
                return false;
            }
            _habilitarRupturaPorExistencia = r08.Entidad;

            //
            var r09 = Program.MyData.HabilitarAlertaPorExistenciaEnNegativa();
            if (r09.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r09.Mensaje);
                return false;
            }
            _habilitarAlertaPorExistenciaEnNegativo  = r09.Entidad;

            //
            var r0A = Program.MyData.Permiso_Venta_DarDescuento_Item(_usuario.AutoGrupo);
            if (r0A.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0A.Mensaje);
                return false;
            }
            _darPermisoDescuentoItem = r0A.Entidad;

            //
            var r0B = Program.MyData.Permiso_Venta_Eliminar_Item(_usuario.AutoGrupo);
            if (r0B.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0B.Mensaje);
                return false;
            }
            _darPermisoEliminarItem = r0B.Entidad;

            //
            var r0C = Program.MyData.MovInventario_Concepto("0000000001");
            if (r0C.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0C.Mensaje);
                return false;
            }
            Ficha.setConceptoMovInv(r0C.Entidad);

            //
            var r0D = Program.MyData.Permiso_Venta_PrecioLibre_Item (_usuario.AutoGrupo);
            if (r0D.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0D.Mensaje);
                return false;
            }
            _darPermisoPrecioLibre = r0D.Entidad;

            //
            var r0e = Program.MyData.Permiso_Venta_DescuentoGlobal(_usuario.AutoGrupo);
            if (r0e.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0e.Mensaje);
                return false;
            }
            _darPermisoDsctCargoGlobal = r0e.Entidad;


            return rt;
        }

        private void BT_BUSCAR_CLIENTE_Click(object sender, EventArgs e)
        {
            _ctrlCliente.Buscar();
        }
  
        private void ActualizarCliente()
        {
            var indice = 0;
            Ficha.IsContado = true;
            Ficha.DiasCredito = 0;
            Ficha.TarifaPrecio = OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio.Tarifa_1;

            L_CLIENTE.Text = "";
            L_CLIENTE_CLASIFICACION.Text = "";
            L_CLIENTE_TARIFA_PRECIO.Text = "";
            CB_COBRADOR.SelectedIndex = -1;
            CB_VENDEDOR.SelectedIndex = -1;

            if (Ficha.Cliente != null) 
            {
                if (Ficha.Cliente.Categoria == OOB.LibVenta.Cliente.Enumerados.enumCategoria.Eventual)
                {
                    Ficha.TarifaPrecio = OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio.Tarifa_1;
                    Ficha.IsContado = true;
                    Ficha.DiasCredito = 0;
                    indice = 0;
                }
                else 
                {
                    Ficha.TarifaPrecio = Ficha.Cliente.TarifaPrecio;
                    if (Ficha.Cliente.IsCreditoHabilitado)
                    {
                        Ficha.IsContado = false;
                        Ficha.DiasCredito = Ficha.Cliente.DiasCredito;
                        indice = 1;
                    }
                    else 
                    {
                        Ficha.IsContado = true;
                        Ficha.DiasCredito = 0;
                        indice = 0;
                    }
                }
                L_CLIENTE.Text = Ficha.Cliente.Cliente;
                L_CLIENTE_CLASIFICACION.Text = Ficha.Cliente.CategoriaDescripcion;
                L_CLIENTE_TARIFA_PRECIO.Text = Ficha.TarifaPrecioDescripcion;
                CB_COBRADOR.SelectedValue = Ficha.Cliente.AutoCobrador;
                CB_VENDEDOR.SelectedValue = Ficha.Cliente.AutoVendedor;
            }
            CB_CONDICION_PAGO.SelectedIndex = indice;
            TB_DIAS_CREDITO.Text = Ficha.DiasCredito.ToString();
            CB_CONDICION_PAGO.Enabled = !Ficha.IsContado;
            TB_DIAS_CREDITO.Enabled = !Ficha.IsContado;
        }

        private void BT_LIMPIAR_CLIENTE_Click(object sender, EventArgs e)
        {
            LimpiarCliente();
        }

        private void CB_CONDICION_PAGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_CONDICION_PAGO.SelectedIndex == 1)
            {
                TB_DIAS_CREDITO.Text = Ficha.DiasCredito.ToString();
                Ficha.IsContado = false;
            }
            else 
            {
                TB_DIAS_CREDITO.Text = "0";
                Ficha.IsContado = true;
            }
        }

        private void VentaAdministrativaFrm_Load(object sender, EventArgs e)
        {
            Limpiar();
            DGV_DETALLE.DataSource = _ctrlItems.Source;
        }

        private void Limpiar()
        {
            LimpiarItems();
            LimpiarCliente();
            LimpiarFicha();
            L_FECHA_EMISION.Text = Ficha.FechaEmision.ToShortDateString();
            DTP_FECHA_PEDIDO.Value = Ficha.FechaEmision;
        }

        private void LimpiarItems()
        {
            _ctrlItems.Limpiar();
        }

        private void LimpiarFicha()
        {
            CB_DEPOSITO.SelectedIndex=0;
            CB_SUCURSAL.SelectedIndex=0;
            CB_TRANSPORTE.SelectedIndex=0;
            TB_DIR_DESPACHO.Text = "";
            TB_NOTAS_DOC.Text = "";
            TB_ORDEN_COMPRA.Text = "";
            TB_PEDIDO.Text = "";
            DTP_FECHA_PEDIDO.Value = DateTime.Now.Date;
            TB_DIAS_VALIDEZ.Text = "0";
            L_TOTAL.Text = "0.0";
            L_ITEMS.Text = "0";
        }

        private void LimpiarCliente()
        {
            _ctrlCliente.Limpiar();
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void TB_DIAS_CREDITO_Validated(object sender, EventArgs e)
        {
            var dias= int.Parse(TB_DIAS_CREDITO.Text);
            Ficha.DiasCredito = dias;
        }

        private void BT_CREAR_CLIENTE_Click(object sender, EventArgs e)
        {
            CrearClienteEventual();
        }

        private void CrearClienteEventual()
        {
            _ctrlCliente.CrearClienteEventual();
        }

        private void BT_BUSCAR_PRODUCTO_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void BuscarProducto()
        {
            if (Ficha.Cliente != null) 
            {
                _ctrlItems.setDepositoSeleccionado(Ficha.Deposito);
                _ctrlItems.setHabilitarAlertaPorExistenciaNegativa(_habilitarAlertaPorExistenciaEnNegativo);
                _ctrlItems.setHabilitarRupturaPorExistencia(_habilitarRupturaPorExistencia);
                _ctrlItems.setPermisoDarDescuento(_darPermisoDescuentoItem);
                _ctrlItems.setPermisoPrecioLibre (_darPermisoPrecioLibre);
                _ctrlItems.setTarifaPrecioSeleccionado(Ficha.TarifaPrecio);
                _ctrlItems.BuscarProducto();
            }
        }
                   
        private void Actualizar()
        {
            var habilitar = _ctrlItems.Renglones > 0 ? false : true;
            CB_DEPOSITO.Enabled = habilitar;
            BT_BUSCAR_CLIENTE.Enabled = habilitar;
            BT_CREAR_CLIENTE.Enabled = habilitar;
            BT_LIMPIAR_CLIENTE.Enabled = habilitar;  
            L_TOTAL.Text = _ctrlItems.SubTotal.ToString("N2");
            L_ITEMS.Text = _ctrlItems.Renglones.ToString("N0");
        }

        private void BT_ELIMINAR_ITEM_Click(object sender, EventArgs e)
        {
            EliminarItem();
        }

        private void EliminarItem()
        {
            if (_darPermisoEliminarItem.IsHabilitado)
            {
                if (_darPermisoEliminarItem.NivelSeguridad == OOB.LibVenta.Permiso.Enumerados.EnumNivelSeguridad.Niguna)
                {
                    _ctrlItems.EliminarItem();
                }
                else
                {
                    Helpers.Msg.Alerta("REQUIERE UNA CLAVE");
                }
            }
            else 
            {
                Helpers.Msg.Alerta("OPCION NO PERMITIDA");
            }
        }

        public void setUsuarioSistema(OOB.LibVenta.Usuario.Ficha ficha) 
        {
            _usuario = ficha;
            Ficha.Usuario = ficha;
        }

        private void BT_EDITAR_ITEM_Click(object sender, EventArgs e)
        {
           EditarItem();
        }

        private void EditarItem()
        {
            _ctrlItems.EditarItem();
        }

        private void BT_TOTALIZAR_Click(object sender, EventArgs e)
        {
            Totalizar();
        }

        private void Totalizar()
        {
            if (_ctrlItems.Renglones > 0 && _ctrlItems.SubTotal > 0) 
            {
                if (!Ficha.IsContado)
                {
                    if (_ctrlItems.SubTotal > Ficha.Cliente.SaldoDisponible)  
                    {
                        Helpers.Msg.Error("MONTO A FACTURAR SUPERA EL LIMITE PERMITIDO AL CLIENTE");
                        return;
                    }
                }
                _ctrlTotales.setSubTotal(_ctrlItems.SubTotal);
                _ctrlTotales.setIsContado(Ficha.IsContado);
                _ctrlTotales.setPermisoDsctoCargoGlobal(_darPermisoDsctCargoGlobal);
                _ctrlTotales.Totalizar();
            }
        }

        private void ProcesarOk(VentaAdministrativa.Totalizar e)
        {
            Ficha.setItems(_ctrlItems.ListaItems);
            Ficha.Procesar(e);
        }
    
    }

}