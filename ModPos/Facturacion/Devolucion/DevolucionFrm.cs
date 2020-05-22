using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion.Devolucion
{

    public partial class DevolucionFrm : Form
    {

        private CtrItem _ctrItem;
        private List<Item> _items;
        private BindingList<Item> _bItems;
        private BindingSource _bs;


        public DevolucionFrm(CtrItem ctrItem)
        {
            _ctrItem = ctrItem;
            _items = new List<Item>(_ctrItem.Items);
            _bItems = new BindingList<Item>(_items);
            _bs = new BindingSource();
            _bs.DataSource = _bItems;

            InitializeComponent();
            InicializarGrid();
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


        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void DevolucionFrm_Load(object sender, EventArgs e)
        {
            DGV_DETALLE.DataSource = _bs;
            L_SUBTOTAL.Text = _ctrItem.SubTotal.ToString("n2");
            irFocoPrincipal();
        }

        private void irFocoPrincipal()
        {
            DGV_DETALLE.Focus();
        }

        private void BT_ELIMINAR_Click(object sender, EventArgs e)
        {
            EliminarItem();
        }

        private void EliminarItem()
        {
            if (_bs != null) 
            {
                var item = (Item)_bs.Current;
                if (item != null)
                {
                    if (_ctrItem.EliminarItem(item.Id)) 
                    {
                        _bItems.Remove(item);
                    }
                }
            }
            ActualizarSubTotal();
        }

        private void ActualizarSubTotal()
        {
            L_SUBTOTAL.Text = _ctrItem.SubTotal.ToString("n2");
            DGV_DETALLE.Refresh();
        }

        private void BT_DEVOLVER_Click(object sender, EventArgs e)
        {
            if (_bs != null)
            {
                var item = (Item)_bs.Current;
                if (item != null)
                {
                    if (item.EsPesado)
                    {
                        Helpers.Msg.Error("Opción No Permitida Para Item(s) Pesado, Verifique Por Favor");
                        return;
                    }
                    if (item.Cantidad > 1)
                    {
                        if (_ctrItem.Restar(item.Id)) 
                        {
                            item.Cantidad -= 1;
                        };
                    }
                    else 
                    {
                        if (_ctrItem.EliminarItem(item.Id)) 
                        {
                            _bItems.Remove(item);
                        }
                    }
                }
            }
            ActualizarSubTotal();
        }

    }

}