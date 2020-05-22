using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion.ProductoLista
{

    public partial class ListaFrm : Form
    {

        private BindingSource bs;
        private BindingList<OOB.LibVenta.PosOffline.Producto.Ficha> bProducto;
        private bool _isProductoSelected;
        private OOB.LibVenta.PosOffline.Producto.Ficha _productoSelected;


        public bool IsProductoSelected { get { return _isProductoSelected; } }
        public OOB.LibVenta.PosOffline.Producto.Ficha ProductoSelected { get { return _productoSelected; } }


        public ListaFrm()
        {
            InitializeComponent();
            bProducto = new BindingList<OOB.LibVenta.PosOffline.Producto.Ficha>();
            bs = new BindingSource();
            bs.DataSource = bProducto;

            _isProductoSelected = false;
            _productoSelected = null;
            InicializarDGV();
        }

        private void InicializarDGV()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            DGV.AllowUserToAddRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;
            DGV.ReadOnly = true;

            var c0 = new DataGridViewTextBoxColumn();
            c0.DataPropertyName = "Auto";
            c0.Name = "Auto";
            c0.Visible = false;
            c0.Width = 10;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "CodigoPrd";
            c1.HeaderText = "Código";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "NombrePrd";
            c3.HeaderText = "Nombre";
            c3.Visible = true;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.Name = "IsActivo";
            c4.DataPropertyName = "IsActivo";
            c4.Visible = false;

            DGV.Columns.Add(c0);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                row.DefaultCellStyle.ForeColor = !(bool)row.Cells["IsActivo"].Value ? Color.Red : Color.Black;
            }
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                _productoSelected = (OOB.LibVenta.PosOffline.Producto.Ficha)bs.Current;
                _isProductoSelected = true;
                Salida();
            }
        }


        public bool CargarData(string buscar) 
        {
            var rt = true;

            var r01 = Sistema.MyData2.Producto_Lista(buscar);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            bProducto.Clear();
            bProducto.RaiseListChangedEvents = false;
            foreach (var dt in r01.Lista.OrderBy(o=>o.NombrePrd))
            {
                bProducto.Add(dt);
            }
            bProducto.RaiseListChangedEvents = true;
            bProducto.ResetBindings();

            return rt;
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
        }

        private void Salida()
        {
            this.Close();
        }

        private void ListaFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = bs;
            DGV.Focus();
            DGV.Refresh();
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (DGV.CurrentRow != null)
                {
                    if (DGV.CurrentRow.Index > -1)
                    {
                        var row = DGV.CurrentRow;
                        var auto = (string)row.Cells[0].Value;
                        _productoSelected = bProducto.FirstOrDefault(f => f.Auto == auto);
                        if (_productoSelected != null)
                        {
                            _isProductoSelected = true;
                            Salida();
                        }
                    }
                }
            }
        }

        private void BT_SUBIR_Click(object sender, EventArgs e)
        {
            SubirItem();
        }

        private void SubirItem()
        {
            bs.Position = bs.Position - 1;
        }

        private void BT_BAJAR_Click(object sender, EventArgs e)
        {
            BajarItem();
        }

        private void BajarItem()
        {
            bs.Position = bs.Position + 1;
        }

        private void BT_ENTER_Click(object sender, EventArgs e)
        {
            SeleccionarItem();
        }

        private void SeleccionarItem()
        {
            if (bs != null)
            {
                if (bs.Current != null) 
                {
                    _productoSelected = (OOB.LibVenta.PosOffline.Producto.Ficha)bs.Current;
                    _isProductoSelected = true;
                    Salida();
                }
            }
        }
    
    }

}