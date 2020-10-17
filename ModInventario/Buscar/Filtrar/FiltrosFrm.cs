using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Buscar.Filtrar
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
            CB_GRUPO.DisplayMember = "Nombre";
            CB_GRUPO.ValueMember = "Auto";
            CB_MARCA.DisplayMember = "Nombre";
            CB_MARCA.ValueMember = "Auto";
            CB_DEPOSITO.DisplayMember = "Nombre";
            CB_DEPOSITO.ValueMember = "Auto";
            CB_CATEGORIA.DisplayMember = "Descripcion";
            CB_CATEGORIA.ValueMember = "Id";
            CB_ORIGEN.DisplayMember = "Descripcion";
            CB_ORIGEN.ValueMember = "Id";
            CB_IMPUESTO.DisplayMember= "Ficha";
            CB_IMPUESTO.ValueMember = "Auto";
            CB_ESTATUS.DisplayMember = "Descripcion";
            CB_ESTATUS.ValueMember = "Id";
            CB_ADMDIVISA.DisplayMember = "Descripcion";
            CB_ADMDIVISA.ValueMember = "Id";
            CB_PESADO.DisplayMember = "Descripcion";
            CB_PESADO.ValueMember = "Id";
            CB_OFERTA.DisplayMember = "Descripcion";
            CB_OFERTA.ValueMember = "Id";
        }

        private void FiltrosFrm_Load(object sender, EventArgs e)
        {
            TB_PROVEEDOR.Text = "";
            CB_DEPARTAMENTO.DataSource = _controlador.SourceDepart;
            CB_GRUPO.DataSource = _controlador.SourceGrupo;
            CB_MARCA.DataSource = _controlador.SourceMarca;
            CB_DEPOSITO .DataSource = _controlador.SourceDeposito;
            CB_CATEGORIA.DataSource = _controlador.SourceCategoria;
            CB_ORIGEN.DataSource = _controlador.SourceOrigen;
            CB_IMPUESTO .DataSource = _controlador.SourceTasa;
            CB_ESTATUS.DataSource = _controlador.SourceEstatus ;
            CB_ADMDIVISA.DataSource = _controlador.SourceAdmDivisa;
            CB_PESADO.DataSource = _controlador.SourcePesado;
            CB_OFERTA.DataSource = _controlador.SourceOferta;
            CB_ESTATUS.SelectedValue = _controlador.IdEstatus;
            CB_EXISTENCIA.SelectedIndex = -1;
            CB_CATALOGO.SelectedIndex = -1;
            TB_PROVEEDOR.Focus();
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
            _controlador.AutoMarca = "";
            if (CB_MARCA.SelectedIndex != -1)
            {
                _controlador.AutoMarca = CB_MARCA.SelectedValue.ToString();
            }
        }

        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.AutoDeposito = "";
            if (CB_DEPOSITO.SelectedIndex != -1)
            {
                _controlador.AutoDeposito= CB_DEPOSITO.SelectedValue.ToString();
            }
        }

        private void CB_CATEGORIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.IdCategoria = "";
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
            _controlador.IdEstatus = "";
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.IdEstatus = CB_ESTATUS.SelectedValue.ToString();
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

        private void CB_PESADO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.IdPesado = "";
            if (CB_PESADO.SelectedIndex != -1)
            {
                _controlador.IdPesado = CB_PESADO.SelectedValue.ToString();
            }
        }

        private void CB_CATALOGO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.IdCatalogo = "";
            if (CB_CATALOGO.SelectedIndex != -1)
            {
                _controlador.IdCatalogo = CB_CATALOGO.SelectedItem.ToString();
            }
        }

        private void CB_OFERTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.IdOferta = "";
            if (CB_OFERTA.SelectedIndex != -1)
            {
                _controlador.IdOferta = CB_OFERTA.SelectedValue.ToString();
            }
        }

        private void CB_EXISTENCIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.IdExistencia = "";
            if (CB_EXISTENCIA.SelectedIndex != -1)
            {
                _controlador.IdExistencia = CB_EXISTENCIA.SelectedIndex.ToString();
            }
        }

        private void BT_FILTRAR_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void Filtrar()
        {
            _controlador.Filtrar();
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            _controlador.Salir();
            Salir();
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarSelecciones();
        }

        private void LimpiarSelecciones()
        {
            _controlador.LimpiarSelecciones();
            if (_controlador.IsLimpiarOK) 
            {
                TB_PROVEEDOR.Text = "";
                CB_DEPARTAMENTO.SelectedIndex = -1;
                CB_GRUPO.SelectedIndex = -1;
                CB_MARCA.SelectedIndex = -1;
                CB_DEPOSITO.SelectedIndex = -1;
                CB_CATEGORIA.SelectedIndex = -1;
                CB_ORIGEN.SelectedIndex = -1;
                CB_IMPUESTO.SelectedIndex = -1;
                CB_ESTATUS.SelectedIndex = -1;
                CB_ADMDIVISA.SelectedIndex = -1;
                CB_PESADO.SelectedIndex = -1;
                CB_OFERTA.SelectedIndex = -1;
                CB_EXISTENCIA.SelectedIndex = -1;
                CB_CATALOGO.SelectedIndex = -1;
            }
        }

        private void L_DEPARTAMENTO_Click(object sender, EventArgs e)
        {
            CB_DEPARTAMENTO.SelectedIndex = -1;
        }

        private void L_GRUPO_Click(object sender, EventArgs e)
        {
            CB_GRUPO.SelectedIndex = -1;
        }

        private void L_PESADO_Click(object sender, EventArgs e)
        {
            CB_PESADO.SelectedIndex = -1;
        }

        private void L_ADMDIVISA_Click(object sender, EventArgs e)
        {
            CB_ADMDIVISA.SelectedIndex = -1;
        }

        private void L_ESTATUS_Click(object sender, EventArgs e)
        {
            CB_ESTATUS.SelectedIndex = -1;
        }

        private void L_IMPUESTO_Click(object sender, EventArgs e)
        {
            CB_IMPUESTO.SelectedIndex = -1;
        }

        private void L_ORIGEN_Click(object sender, EventArgs e)
        {
            CB_ORIGEN.SelectedIndex = -1;
        }

        private void L_CATEGORIA_Click(object sender, EventArgs e)
        {
            CB_CATEGORIA.SelectedIndex = -1;
        }

        private void L_DEPOSITO_Click(object sender, EventArgs e)
        {
            CB_DEPOSITO.SelectedIndex = -1;
        }

        private void L_MARCA_Click(object sender, EventArgs e)
        {
            CB_MARCA.SelectedIndex = -1;
        }

        private void L_OFERTA_Click(object sender, EventArgs e)
        {
            CB_OFERTA.SelectedIndex = -1;
        }

        private void L_EXISTENCIA_Click(object sender, EventArgs e)
        {
            CB_EXISTENCIA.SelectedIndex = -1;
        }

        private void L_CATALOGO_Click(object sender, EventArgs e)
        {
            CB_CATALOGO.SelectedIndex = -1;
        }

        private void BT_PROVEED_BUSCAR_Click(object sender, EventArgs e)
        {
            BuscarProveedor();
        }

        private void BuscarProveedor()
        {
            _controlador.BuscarProveedor();
            TB_PROVEEDOR.Text = _controlador.NombreProveedor;
        }

             
    }

}