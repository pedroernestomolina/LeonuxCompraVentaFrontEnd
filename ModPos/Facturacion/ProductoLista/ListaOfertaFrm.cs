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

    public partial class ListaOfertaFrm : Form
    {
        
        private BindingSource bs;
        private BindingList<OOB.LibVenta.PosOffline.Producto.Ficha> bProducto;


        public ListaOfertaFrm()
        {
            InitializeComponent();
            bProducto = new BindingList<OOB.LibVenta.PosOffline.Producto.Ficha>();
            bs = new BindingSource();
            bs.DataSource = bProducto;
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

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "CodigoPrd";
            c1.HeaderText = "Código";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "CodigoPlu";
            c2.HeaderText = "Plu";
            c2.Visible = true;
            c2.Width = 80;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

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

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "PrecioRegular";
            c5.HeaderText = "P/Regular";
            c5.Visible = true;
            c5.Width = 100;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.DefaultCellStyle.Format = "n2";

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "OfertaPrecio";
            c6.HeaderText = "P/Oferta";
            c6.Visible = true;
            c6.Width = 100;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c6.DefaultCellStyle.Format = "n2";

            DGV.Columns.Add(c1);
            //DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c6);
        }

        private void DGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DGV.Rows)
            {
                row.DefaultCellStyle.ForeColor = !(bool)row.Cells["IsActivo"].Value ? Color.Red : Color.Black;
            }
        }

        public bool CargarData() 
        {
            var rt = true;

            var r01 = Sistema.MyData2.ProductoListaOferta();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            bProducto.Clear();
            bProducto.RaiseListChangedEvents = false;
            foreach (var dt in r01.Lista.Where(w=>w.IsOfertaActiva).OrderBy(o=>o.NombrePrd))
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

        private void ListaOfertaFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = bs;
            DGV.Focus();
            DGV.Refresh();
        }

    }

}