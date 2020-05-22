using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MovVenta.Cliente.BuscarFrm
{

    public partial class BuscarFrm : Form
    {

        public event EventHandler<Buscar.ClienteSelected> ClienteOK;
        private BindingSource bs;
        private BindingList<OOB.LibVenta.Cliente.Ficha> bCliente;
        private OOB.LibVenta.Cliente.Enumerados.enumPreferenciaBusqueda PreferenciaBusqueda;


        public BuscarFrm()
        {
            InitializeComponent();

            bCliente = new BindingList<OOB.LibVenta.Cliente.Ficha>();
            bs = new BindingSource();
            bs.DataSource = bCliente;

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
            c1.DataPropertyName = "Codigo";
            c1.HeaderText = "Código";
            c1.Visible = true;
            c1.Width = 120;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "CiRif";
            c2.HeaderText = "CI/Rif";
            c2.Visible = true;
            c2.Width = 120;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Nombre";
            c3.HeaderText = "Nombre/RazonSocial";
            c3.Visible = true;
            c3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;

            var c4 = new DataGridViewTextBoxColumn();
            c4.Name="IsActivo";
            c4.DataPropertyName = "IsActivo";
            c4.Visible = false;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                EventHandler<Buscar.ClienteSelected> handler =ClienteOK;
                if (handler != null) 
                {
                    var item = (OOB.LibVenta.Cliente.Ficha) bs.Current;
                    var ficha = new Buscar.ClienteSelected()
                    {
                        AutoCliente = item.Auto,
                        IsActivo = item.IsActivo,
                    };
                    handler(this,ficha);
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

            var r01 = Program.MyData.PreferenciaBusquedaCliente();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            switch(r01.Entidad)
            {
                case OOB.LibVenta.Sistema.Enumerados.enumPreferenciaBusquedaCliente.Nombre:
                    PreferenciaBusqueda = OOB.LibVenta.Cliente.Enumerados.enumPreferenciaBusqueda.Nombre;
                    RB_NOMBRE.Checked = true;
                    break;
                case OOB.LibVenta.Sistema.Enumerados.enumPreferenciaBusquedaCliente.CiRif:
                    PreferenciaBusqueda = OOB.LibVenta.Cliente.Enumerados.enumPreferenciaBusqueda.CiRif;
                    RB_CIRIF.Checked = true;
                    break;
                case OOB.LibVenta.Sistema.Enumerados.enumPreferenciaBusquedaCliente.Codigo:
                    PreferenciaBusqueda = OOB.LibVenta.Cliente.Enumerados.enumPreferenciaBusqueda.Codigo;
                    RB_CODIGO.Checked = true;
                    break;
            }

            return rt;
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            DGV.DataSource = bs;
            LimpiarData();
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            var filtro = new OOB.LibVenta.Cliente.Filtro();
            filtro.cadena = TB_CADENA.Text.Trim();
            filtro.preferenciaBusqueda= PreferenciaBusqueda;
            var r01= Program.MyData.ClienteLista(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            };

            bCliente.Clear();
            List<OOB.LibVenta.Cliente.Ficha> lista =null;
            switch (PreferenciaBusqueda) 
            {
                case OOB.LibVenta.Cliente.Enumerados.enumPreferenciaBusqueda.Nombre:
                    lista = r01.Lista.OrderBy(o => o.Nombre).ToList();
                    break;
                case OOB.LibVenta.Cliente.Enumerados.enumPreferenciaBusqueda.Codigo:
                    lista = r01.Lista.OrderBy(o => o.Codigo).ToList();
                    break;
                case OOB.LibVenta.Cliente.Enumerados.enumPreferenciaBusqueda.CiRif:
                    lista = r01.Lista.OrderBy(o => o.CiRif).ToList();
                    break;
            }
 
            bCliente.RaiseListChangedEvents=false;
            foreach (var dt in lista) 
            {
                bCliente.Add(dt);
            }
            bCliente.RaiseListChangedEvents=true;
            bCliente.ResetBindings();

            TB_CADENA.Text = "";
            DGV.Focus();
        }

        private void RB_NOMBRE_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_NOMBRE.Checked)
                PreferenciaBusqueda = OOB.LibVenta.Cliente.Enumerados.enumPreferenciaBusqueda.Nombre;
        }

        private void RB_CIRIF_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_CIRIF.Checked)
                PreferenciaBusqueda = OOB.LibVenta.Cliente.Enumerados.enumPreferenciaBusqueda.CiRif;

        }

        private void RB_CODIGO_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_CODIGO.Checked)
                PreferenciaBusqueda = OOB.LibVenta.Cliente.Enumerados.enumPreferenciaBusqueda.Codigo;
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarData();
        }

        private void LimpiarData()
        {
            bCliente.Clear();
            TB_CADENA.Text = "";
            TB_CADENA.Focus();
        }

        private void BT_INFORMACION_Click(object sender, EventArgs e)
        {
            if (bs.Current != null) 
            {
                var item = (OOB.LibVenta.Cliente.Ficha) bs.Current;
                BuscarFicha(item.Auto);
            }
        }

        private void BuscarFicha(string p)
        {
            var r01 = Program.MyData.ClienteFicha(p);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            VerFicha(r01.Entidad);
        }

        private void VerFicha(OOB.LibVenta.Cliente.Ficha ficha)
        {
        }

    }

}