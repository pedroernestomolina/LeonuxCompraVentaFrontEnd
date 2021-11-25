﻿using System;
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
            IrFoco();
            DGV.DataSource = _controlador.ItemsSource;
            L_TIPO_DOCUMENTO.Text = _controlador.TipoDocumento;
            ActualizarVistaCliente();
            ActualizaVistaTotales();
            ActualizaBusquedaProducto();
            ActualizarDatosDoc();

            switch (_controlador.TipoDocumento) 
            {
                case "FACTURA":
                    P_DOCUMENTO.BackColor = Color.DarkGreen;
                    L_TIPO_DOCUMENTO.ForeColor = Color.White;
                    break;

                case "PRESUPUESTO":
                    P_DOCUMENTO.BackColor = Color.FromArgb(255, 255, 128);
                    L_TIPO_DOCUMENTO.ForeColor = Color.Black;
                    break;

                case "PEDIDO":
                    P_DOCUMENTO.BackColor = Color.Blue;
                    L_TIPO_DOCUMENTO.ForeColor = Color.White;
                    break;
            }
        }

        private void ActualizarDatosDoc()
        {
            L_DATOS_DOC_FECHA.Text = _controlador.DatosDoc_Fecha;
            L_DATOS_DOC_COND_PAGO.Text = _controlador.DatosDoc_CondPago;
            L_DATOS_DOC_DEPOSITO.Text = _controlador.DatosDoc_Deposito;
            L_DATOS_DOC_FECHA_VENCE.Text = _controlador.DatosDoc_FechaVence;
            L_DATOS_DOC_ORD_COMPRA.Text = _controlador.DatosDoc_OrdenCompra;
            L_DATOS_DOC_PEDIDO.Text = _controlador.DatosDoc_Pedido;
            L_DATOS_DOC_SERIE.Text = _controlador.DatosDoc_Serie;
            L_DATOS_DOC_SUCURSAL.Text = _controlador.DatosDoc_Sucursal;
        }

        private void ActualizaBusquedaProducto()
        {
            switch(_controlador.PrefBusqProducto)
            {
                case enumerados.BusqPrd.Codigo:
                    R_CODIGO.Checked = true;
                    break;
                case enumerados.BusqPrd.Nombre:
                    R_DESCRIPCION.Checked = true;
                    break;
                case enumerados.BusqPrd.Referencia:
                    R_REFERENCIA.Checked = true;
                    break;
            }
        }

        private void ActualizaVistaTotales()
        {
            L_CNT_ITEM.Text = _controlador.CntItem;
            L_TASA_DIVISA.Text = _controlador.TasaDivisa.ToString("n2");
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
            IrFoco();
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
            ActualizarDatosDoc();
            IrFoco();
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
            ActualizarDatosDoc();
            IrFoco();
        }

        private void BT_DATOS_DOCUMENTO_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarDatosDocumento();
        }

        private void LimpiarDatosDocumento()
        {
            _controlador.LimpiarDatosDocumento();
            ActualizarVistaCliente();
            ActualizarDatosDoc();
            IrFoco();
        }

        private void BT_VISUALIZAR_CLIENTE_Click(object sender, EventArgs e)
        {
            VisualizarCliente();
        }

        private void VisualizarCliente()
        {
            _controlador.VisualizarCliente();
            IrFoco();
        }

        private void BT_VISUALIZAR_CLIENTE_DOC_Click(object sender, EventArgs e)
        {
            VisualizarClenteDoc();
        }

        private void VisualizarClenteDoc()
        {
            _controlador.VisualizarClenteDoc();
            IrFoco();
        }

        private void BT_VISUALIZAR_CLIENTE_ARTICULOS_Click(object sender, EventArgs e)
        {
            VisualizarClienteArticulos();
        }

        private void VisualizarClienteArticulos()
        {
            _controlador.VisualizarClienteArticulos();
            IrFoco();
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

        private void TB_CADENA_BUSQ_PRODUCTO_Leave(object sender, EventArgs e)
        {
            _controlador.setCadenaBusqProducto(TB_CADENA_BUSQ_PRODUCTO.Text.Trim());
        }

        private void BT_BUSQ_PRODUCTO_Click(object sender, EventArgs e)
        {
            BusqProducto();
        }

        private void BusqProducto()
        {
            _controlador.BusqProducto();
            ActualizaVistaTotales();
            TB_CADENA_BUSQ_PRODUCTO.Text = "";
            IrFoco();
        }

        private void R_CODIGO_CheckedChanged(object sender, EventArgs e)
        {
            ActivarBusPorCodigo();
        }

        private void ActivarBusPorCodigo()
        {
            _controlador.ActivarBusPorCodigo();
            IrFoco();
        }

        private void IrFoco()
        {
            TB_CADENA_BUSQ_PRODUCTO.Focus();
        }

        private void R_DESCRIPCION_CheckedChanged(object sender, EventArgs e)
        {
            ActivarBusPorDescripcion();
        }

        private void ActivarBusPorDescripcion()
        {
            _controlador.ActivarBusPorDescripcion();
            IrFoco();
        }

        private void R_REFERENCIA_CheckedChanged(object sender, EventArgs e)
        {
            ActivarBusPorReferencia();
        }

        private void ActivarBusPorReferencia()
        {
            _controlador.ActivarBusPorReferencia();
            IrFoco();
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

    }

}