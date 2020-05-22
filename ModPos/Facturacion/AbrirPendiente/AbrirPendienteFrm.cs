using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion.AbrirPendiente
{

    public partial class AbrirPendienteFrm : Form
    {

        private List<OOB.LibVenta.PosOffline.Pendiente.Ficha> _items;
        private BindingList<OOB.LibVenta.PosOffline.Pendiente.Ficha> _bItems;
        private BindingSource _bs;
        private bool _abrirCtaOk;
        private int _idCliente; 


        public bool AbrirCtaOk 
        {
            get 
            {
                return _abrirCtaOk;
            }
        }

        public int IdCliente
        {
            get
            {
                return _idCliente;
            }
        }


        public AbrirPendienteFrm()
        {
            InitializeComponent();

            _abrirCtaOk = false;
            _idCliente = -1;
            _items = new List<OOB.LibVenta.PosOffline.Pendiente.Ficha>();
            _bItems = new BindingList<OOB.LibVenta.PosOffline.Pendiente.Ficha>(_items);
            _bs = new BindingSource();
            _bs.CurrentChanged += _bs_CurrentChanged;
            _bs.DataSource = _bItems;

            InicializarGrid();
        }

        private void _bs_CurrentChanged(object sender, EventArgs e)
        {
        }

        public bool CargarData() 
        {
            var rt = true;

            var r01 = Sistema.MyData2.Pendiente_Lista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            _bItems.Clear();
            foreach (var rg in r01.Lista.OrderByDescending(o=>o.Id)) 
            {
                _bItems.Add(rg);
            }

            return rt;
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

            var c0 = new DataGridViewTextBoxColumn();
            c0.DataPropertyName = "Id";
            c0.Name = "Id";
            c0.Visible = false;
            c0.Width = 10;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Fecha";
            c1.HeaderText = "Fecha";
            c1.Visible = true;
            c1.Width = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Cliente";
            c2.HeaderText = "Cliente";
            c2.Visible = true;
            c2.MinimumWidth = 120;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Monto";
            c3.HeaderText = "Importe";
            c3.Visible = true;
            c3.Width = 120;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n2";

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Renglones";
            c4.HeaderText = "Renglon";
            c4.Visible = true;
            c4.Width = 60;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format = "n0";

            DGV.Columns.Add(c0);
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
        }

        private void AbrirPendienteFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _bs;
            DGV.Refresh();
            IrFoco();
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_ABRIR_Click(object sender, EventArgs e)
        {
            AbrirCta();
        }

        private void AbrirCta()
        {
            var it = (OOB.LibVenta.PosOffline.Pendiente.Ficha)_bs.Current;
            if (it != null) 
            {
                Abrir(it);
            }
        }
     
        private void Abrir(OOB.LibVenta.PosOffline.Pendiente.Ficha it) 
        {
            var msg = MessageBox.Show("Abrir Cuenta Pendiente ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var r01 = Sistema.MyData2.Pendiente_AbrirCta(it.Id);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _idCliente = it.IdCliente;
                _abrirCtaOk = true;
                this.Close();
            }
        }

        private void IrFoco() 
        {
            DGV.Focus();
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (DGV.CurrentRow != null)
            {
                if (DGV.CurrentRow.Index > -1)
                {
                    var row = DGV.CurrentRow;
                    var id = (int)row.Cells[0].Value;
                    var item = _bItems.FirstOrDefault(f => f.Id == id);
                    if (item != null)
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            Abrir(item);
                        }
                        if (e.KeyCode == Keys.Delete) 
                        {
                            Eliminar(item);
                        }
                    }
                }
            }
        }

        private void BT_ELIMINAR_Click(object sender, EventArgs e)
        {
            EliminarCta();
        }

        private void EliminarCta()
        {
            var it = (OOB.LibVenta.PosOffline.Pendiente.Ficha)_bs.Current;
            if (it != null)
            {
                Eliminar(it);
            }
        }

        private void Eliminar(OOB.LibVenta.PosOffline.Pendiente.Ficha it)
        {
            var msg = MessageBox.Show("Eliminar Cuenta Pendiente ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var r01 = Sistema.MyData2.Pendiente_EliminarCta(it.Id);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _bItems.Remove(it);
            }
        }

    }

}