using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion.Cliente
{

    public partial class ListaFrm : Form
    {

        private BindingSource bs;
        private BindingList<OOB.LibVenta.PosOffline.Cliente.Ficha> bCliente;
        private bool _isClienteSelected;
        private OOB.LibVenta.PosOffline.Cliente.Ficha _clienteSelected;


        public bool IsClienteSelected { get { return _isClienteSelected; } }
        public OOB.LibVenta.PosOffline.Cliente.Ficha ClienteSelected { get { return _clienteSelected; } }


        public ListaFrm()
        {
            InitializeComponent();
            bCliente = new BindingList<OOB.LibVenta.PosOffline.Cliente.Ficha>();
            bs = new BindingSource();
            bs.DataSource = bCliente;

            _isClienteSelected = false;
            _clienteSelected = null;
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
            c0.DataPropertyName = "Id";
            c0.Name = "Id";
            c0.Visible = false;
            c0.Width = 10;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "CiRif";
            c1.HeaderText = "CI/Rif";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "NombreRazonSocial";
            c3.HeaderText = "Nombre/Razón Social";
            c3.Visible = true;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            DGV.Columns.Add(c0);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
        }

        public bool CargarData(string buscar)
        {
            var rt = true;

            var r01 = Sistema.MyData2.Cliente_Lista(buscar);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            bCliente.Clear();
            bCliente.RaiseListChangedEvents = false;
            foreach (var dt in r01.Lista.OrderBy(o => o.NombreRazonSocial))
            {
                bCliente.Add(dt);
            }
            bCliente.RaiseListChangedEvents = true;
            bCliente.ResetBindings();

            return rt;
        }

        private void ListaFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = bs;
            DGV.Focus();
            DGV.Refresh();
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                _clienteSelected= (OOB.LibVenta.PosOffline.Cliente.Ficha)bs.Current;
                _isClienteSelected = true;
                Salida();
            }
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
                        var id = (int)row.Cells[0].Value;
                        _clienteSelected= bCliente.FirstOrDefault(f => f.Id == id);
                        if (_clienteSelected != null)
                        {
                            _isClienteSelected= true;
                            Salida();
                        }
                    }
                }
            }
        }

        private void Salida()
        {
            this.Close();
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
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
                    _clienteSelected= (OOB.LibVenta.PosOffline.Cliente.Ficha)bs.Current;
                    _isClienteSelected= true;
                    Salida();
                }
            }
        }

    }

}