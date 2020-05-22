using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MovVenta.Producto.Buscar
{

    public partial class BuscarFrm : Form
    {

        public event EventHandler<Buscar.ProductoSelected> ProductoOK;
        private BindingSource bs;
        private BindingList<OOB.LibVenta.Inventario.Producto.Ficha> bProducto;
        private OOB.LibVenta.Inventario.Enumerados.enumPreferenciaBusqueda PreferenciaBusqueda;


        public BuscarFrm()
        {
            InitializeComponent();

            bProducto = new BindingList<OOB.LibVenta.Inventario.Producto.Ficha>();
            bs = new BindingSource();
            bs.DataSource = bProducto;
            RB_NOMBRE.Checked = true;

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

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                EventHandler<Buscar.ProductoSelected> handler = ProductoOK;
                if (handler != null)
                {
                    var item = (OOB.LibVenta.Inventario.Producto.Ficha)bs.Current;
                    var ficha = new Buscar.ProductoSelected()
                    {
                        AutoProducto = item.Auto,
                        IsActivo = item.IsActivo,
                    };
                    handler(this, ficha);
                }
            }
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

            var r01 = Program.MyData.PreferenciaBusquedaProducto();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            switch (r01.Entidad)
            {
                case OOB.LibVenta.Sistema.Enumerados.enumPreferenciaBusquedaProducto.Nombre:
                    PreferenciaBusqueda = OOB.LibVenta.Inventario.Enumerados.enumPreferenciaBusqueda.Nombre;
                    RB_NOMBRE.Checked = true;
                    break;
                case OOB.LibVenta.Sistema.Enumerados.enumPreferenciaBusquedaProducto.Codigo:
                    PreferenciaBusqueda = OOB.LibVenta.Inventario.Enumerados.enumPreferenciaBusqueda.Codigo ;
                    RB_CODIGO.Checked = true;
                    break;
                case OOB.LibVenta.Sistema.Enumerados.enumPreferenciaBusquedaProducto.Referencia:
                    PreferenciaBusqueda = OOB.LibVenta.Inventario.Enumerados.enumPreferenciaBusqueda.Referencia;
                    RB_REFERENCIA.Checked = true;
                    break;
            }

            return rt;
        }


        private void BuscarFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = bs;
            LimpiarData();
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarData();
        }

        private void LimpiarData()
        {
            bProducto.Clear();
            TB_CADENA.Text = "";
            TB_CADENA.Focus();
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            var filtro = new OOB.LibVenta.Inventario.Producto.Filtro();
            filtro.cadena = TB_CADENA.Text.Trim();
            filtro.preferenciaBusqueda = PreferenciaBusqueda;
            var r01 = Program.MyData.ProductoLista(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            };

            bProducto.Clear();
            List<OOB.LibVenta.Inventario.Producto.Ficha> lista = null;
            switch (PreferenciaBusqueda)
            {
                case OOB.LibVenta.Inventario.Enumerados.enumPreferenciaBusqueda.Nombre:
                    lista = r01.Lista.OrderBy(o => o.NombrePrd).ToList();
                    break;
                case OOB.LibVenta.Inventario.Enumerados.enumPreferenciaBusqueda.Codigo:
                    lista = r01.Lista.OrderBy(o => o.CodigoPrd).ToList();
                    break;
                case OOB.LibVenta.Inventario.Enumerados.enumPreferenciaBusqueda.Referencia:
                    lista = r01.Lista.OrderBy(o => o.Referencia).ToList();
                    break;
            }

            bProducto.RaiseListChangedEvents = false;
            foreach (var dt in lista)
            {
                bProducto.Add(dt);
            }
            bProducto.RaiseListChangedEvents = true;
            bProducto.ResetBindings();

            TB_CADENA.Text = "";
            DGV.Focus();
        }

        private void BT_INFORMACION_Click(object sender, EventArgs e)
        {
            if (bs.Current != null)
            {
                var item = (OOB.LibVenta.Inventario.Producto.Ficha)bs.Current;
                BuscarFicha(item.Auto);
            }
        }

        private void BuscarFicha(string p)
        {
            var r01 = Program.MyData.ProductoDetalle(p);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            VerFicha(r01.Entidad);
        }

        private void VerFicha(OOB.LibVenta.Inventario.Producto.Ficha ficha)
        {
        }

        private void RB_CODIGO_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_CODIGO.Checked)
                PreferenciaBusqueda = OOB.LibVenta.Inventario.Enumerados.enumPreferenciaBusqueda.Codigo;
        }

        private void RB_NOMBRE_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_NOMBRE.Checked)
                PreferenciaBusqueda = OOB.LibVenta.Inventario.Enumerados.enumPreferenciaBusqueda.Nombre;
        }

        private void RB_REFERENCIA_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_REFERENCIA.Checked)
                PreferenciaBusqueda = OOB.LibVenta.Inventario.Enumerados.enumPreferenciaBusqueda.Referencia;
        }

    }

}