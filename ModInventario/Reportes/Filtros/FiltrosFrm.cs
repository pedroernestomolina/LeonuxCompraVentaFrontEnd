using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Reportes.Filtros
{

    public partial class FiltrosFrm : Form
    {

        private Gestion _controlador;


        public FiltrosFrm()
        {
            InitializeComponent();
            InicializarControles();
        }

        private void InicializarControles()
        {
            CB_DEPARTAMENTO.DisplayMember = "Nombre";
            CB_DEPARTAMENTO.ValueMember = "Auto";
            CB_DEPOSITO.DisplayMember = "Nombre";
            CB_DEPOSITO.ValueMember = "Auto";
            CB_ADMDIVISA.DisplayMember = "Descripcion";
            CB_ADMDIVISA.ValueMember = "Id";
            CB_SUCURSAL.DisplayMember = "Descripcion";
            CB_SUCURSAL.ValueMember = "Codigo";
            CB_CATEGORIA.DisplayMember = "Descripcion";
            CB_CATEGORIA.ValueMember = "Id";
            CB_ORIGEN.DisplayMember = "Descripcion";
            CB_ORIGEN.ValueMember = "Id";
            CB_IMPUESTO.DisplayMember = "Ficha";
            CB_IMPUESTO.ValueMember = "Auto";
            CB_ESTATUS.DisplayMember = "Descripcion";
            CB_ESTATUS.ValueMember = "Id";
            CB_GRUPO.DisplayMember = "Nombre";
            CB_GRUPO.ValueMember = "Auto";
            CB_MARCA.DisplayMember = "Nombre";
            CB_MARCA.ValueMember = "Auto";
        }

        private void FiltrosFrm_Load(object sender, EventArgs e)
        {
            TB_PRODUCTO.Text = "";
            CB_DEPARTAMENTO.DataSource = _controlador.SourceDepart;
            CB_DEPOSITO.DataSource = _controlador.SourceDeposito;
            CB_ADMDIVISA.DataSource = _controlador.SourceAdmDivisa;
            CB_SUCURSAL.DataSource = _controlador.SourceSucursal;
            CB_CATEGORIA.DataSource = _controlador.SourceCategoria;
            CB_ORIGEN.DataSource = _controlador.SourceOrigen;
            CB_IMPUESTO.DataSource = _controlador.SourceTasa;
            CB_ESTATUS.DataSource = _controlador.SourceEstatus;
            CB_MARCA.DataSource = _controlador.SourceMarca;
            CB_GRUPO.DataSource = _controlador.SourceGrupo;
            TB_PRODUCTO.Focus();

            TB_PRODUCTO.Enabled = _controlador.Filtros.ActivarProducto;
            BT_PRODUCTO_BUSCAR.Enabled = _controlador.Filtros.ActivarProducto;
            CB_DEPARTAMENTO.Enabled = _controlador.Filtros.ActivarDepartamento;
            CB_DEPOSITO.Enabled = _controlador.Filtros.ActivarDeposito;
            CB_ADMDIVISA.Enabled = _controlador.Filtros.ActivarAdmDivisa;
            CB_SUCURSAL.Enabled = _controlador.Filtros.ActivarSucursal;
            CB_IMPUESTO.Enabled = _controlador.Filtros.ActivarTasaIva;
            CB_ESTATUS.Enabled = _controlador.Filtros.ActivarEstatus;
            CB_ORIGEN.Enabled = _controlador.Filtros.ActivarOrigen;
            CB_CATEGORIA.Enabled = _controlador.Filtros.ActivarCategoria;
            CB_MARCA.Enabled = _controlador.Filtros.ActivarMarca;
            CB_GRUPO.Enabled = _controlador.Filtros.ActivarGrupo;
            DTP_DESDE.Enabled = _controlador.Filtros.ActivarDesde;
            DTP_HASTA.Enabled = _controlador.Filtros.ActivarHasta;
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void CB_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.AutoDepartamento = "";
            if (CB_DEPARTAMENTO.SelectedIndex != -1)
            {
                _controlador.AutoDepartamento = CB_DEPARTAMENTO.SelectedValue.ToString();
            }
        }

        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.AutoDeposito= "";
            if (CB_DEPOSITO.SelectedIndex != -1)
            {
                _controlador.AutoDeposito = CB_DEPOSITO.SelectedValue.ToString();
            }
        }

        private void CB_ADMDIVISA_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.IdAdmDivisa = "";
            if (CB_ADMDIVISA.SelectedIndex != -1)
            {
                _controlador.IdAdmDivisa = CB_ADMDIVISA.SelectedValue.ToString();
            }
        }

        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.CodigoSucursal= "";
            if (CB_SUCURSAL.SelectedIndex != -1)
            {
                _controlador.CodigoSucursal = CB_SUCURSAL.SelectedValue.ToString();
            }
        }

        private void CB_IMPUESTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.AutoTasa = "";
            if (CB_IMPUESTO.SelectedIndex != -1)
            {
                _controlador.AutoTasa = CB_IMPUESTO.SelectedValue.ToString();
            }
        }

        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.IdEstatus= "";
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.IdEstatus = CB_ESTATUS.SelectedValue.ToString();
            }
        }

        private void CB_CATEGORIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.IdCategoria= "";
            if (CB_CATEGORIA.SelectedIndex != -1)
            {
                _controlador.IdCategoria = CB_CATEGORIA.SelectedValue.ToString();
            }
        }

        private void CB_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.IdOrigen = "";
            if (CB_ORIGEN.SelectedIndex != -1)
            {
                _controlador.IdOrigen = CB_ORIGEN.SelectedValue.ToString();
            }
        }

        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.AutoGrupo = "";
            if (CB_GRUPO.SelectedIndex != -1)
            {
                _controlador.AutoGrupo = CB_GRUPO.SelectedValue.ToString();
            }
        }

        private void CB_MARCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.AutoMarca= "";
            if (CB_MARCA.SelectedIndex != -1)
            {
                _controlador.AutoMarca = CB_MARCA.SelectedValue.ToString();
            }
        }

        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            _controlador.Desde = DTP_DESDE.Value.Date;
        }

        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            _controlador.Hasta = DTP_HASTA.Value.Date;
        }

        private void BT_FILTRAR_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void Filtrar()
        {
            _controlador.ActivarFiltros();
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            _controlador.LimpiarFiltros();
            if (_controlador.LimpiarFiltros_IsOK)
            {
                TB_PRODUCTO.Text = "";
                CB_DEPARTAMENTO.SelectedIndex = -1;
                CB_DEPOSITO.SelectedIndex = -1;
                CB_ADMDIVISA.SelectedIndex = -1;
                CB_SUCURSAL.SelectedIndex = -1;
                CB_CATEGORIA.SelectedIndex = -1;
                CB_ORIGEN.SelectedIndex=-1;
                CB_IMPUESTO.SelectedIndex=-1;
                CB_ESTATUS.SelectedIndex=-1;
                CB_GRUPO.SelectedIndex = -1;
                CB_MARCA.SelectedIndex = -1;

                DTP_DESDE.Value = DateTime.Now.Date;
                DTP_HASTA.Value = DateTime.Now.Date;
            }
        }

        private void L_DEPARTAMENTO_Click(object sender, EventArgs e)
        {
            CB_DEPARTAMENTO.SelectedIndex = -1;
        }

        private void L_ADMDIVISA_Click(object sender, EventArgs e)
        {
            CB_ADMDIVISA.SelectedIndex = -1;
        }

        private void L_DEPOSITO_Click(object sender, EventArgs e)
        {
            CB_DEPOSITO.SelectedIndex = -1;
        }

        private void L_OFERTA_Click(object sender, EventArgs e)
        {
            CB_SUCURSAL.SelectedIndex = -1;
        }

        private void L_IMPUESTO_Click(object sender, EventArgs e)
        {
            CB_IMPUESTO.SelectedIndex = -1;
        }

        private void L_ESTATUS_Click(object sender, EventArgs e)
        {
            CB_ESTATUS.SelectedIndex = -1;
        }

        private void L_CATEGORIA_Click(object sender, EventArgs e)
        {
            CB_CATEGORIA.SelectedIndex = -1;
        }

        private void L_ORIGEN_Click(object sender, EventArgs e)
        {
            CB_ORIGEN.SelectedIndex = -1;
        }

        private void L_SUCURSAL_Click(object sender, EventArgs e)
        {
            CB_SUCURSAL.SelectedIndex = -1;
        }

        private void L_DESDE_Click(object sender, EventArgs e)
        {
            DTP_DESDE.Value = DateTime.Now.Date;
        }

        private void L_HASTA_Click(object sender, EventArgs e)
        {
            DTP_HASTA.Value = DateTime.Now.Date;
        }

        private void L_GRUPO_Click(object sender, EventArgs e)
        {
            CB_GRUPO.SelectedIndex = -1;
        }

        private void L_MARCA_Click(object sender, EventArgs e)
        {
            CB_MARCA.SelectedIndex = -1;
        }

        private void BT_PRODUCTO_BUSCAR_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void BuscarProducto()
        {
            _controlador.BuscarProducto();
            if (_controlador.ProductoIsOk)
            {
                TB_PRODUCTO.Text = _controlador.ProductoBuscar;
            }
            else
            {
                TB_PRODUCTO.Text = "";
            }
        }

        private void TB_PRODUCTO_Leave(object sender, EventArgs e)
        {
            _controlador.ProductoBuscar = TB_PRODUCTO.Text.Trim().ToUpper();
        }
     
    }

}