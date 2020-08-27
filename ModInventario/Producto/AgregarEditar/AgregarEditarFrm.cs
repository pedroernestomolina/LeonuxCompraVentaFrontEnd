using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.AgregarEditar
{

    public partial class AgregarEditarFrm : Form
    {


        private Gestion _controlador;


        public AgregarEditarFrm()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            CB_DEPARTAMENTO.DisplayMember = "Nombre";
            CB_DEPARTAMENTO.ValueMember = "auto";

            CB_GRUPO.DisplayMember = "Nombre";
            CB_GRUPO.ValueMember = "auto";

            CB_MARCA.DisplayMember = "Nombre";
            CB_MARCA.ValueMember = "auto";

            CB_IMPUESTO.DisplayMember = "TasaImpuesto";
            CB_IMPUESTO.ValueMember = "auto";

            CB_ORIGEN.DisplayMember = "Descripcion";
            CB_ORIGEN.ValueMember = "id";

            CB_EMPAQUE_COMPRA.DisplayMember = "Nombre";
            CB_EMPAQUE_COMPRA.ValueMember = "auto";

            CB_DIVISA.DisplayMember = "Descripcion";
            CB_DIVISA.ValueMember = "id";

            CB_CATEGORIA.DisplayMember = "Descripcion";
            CB_CATEGORIA.ValueMember = "id";

            CB_CLASIFICACION_ABC.DisplayMember = "Descripcion";
            CB_CLASIFICACION_ABC.ValueMember = "id";
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
        }

        bool inicializarData = false;
        private void AgregarEditarFrm_Load(object sender, EventArgs e)
        {
            inicializarData = true;
            CB_DEPARTAMENTO.DataSource = _controlador.Departamentos;
            CB_GRUPO.DataSource = _controlador.Grupos;
            CB_MARCA.DataSource = _controlador.Marcas;
            CB_IMPUESTO.DataSource = _controlador.Impuesto;
            CB_ORIGEN.DataSource = _controlador.Origen;
            CB_EMPAQUE_COMPRA.DataSource = _controlador.EmpCompra;
            CB_DIVISA.DataSource = _controlador.Divisa;
            CB_CATEGORIA.DataSource = _controlador.Categoria;
            CB_CLASIFICACION_ABC.DataSource = _controlador.Clasificacion;

            TB_CODIGO.Text = _controlador.CodigoProducto;
            TB_DESCRIPCION.Text = _controlador.DescripcionProducto;
            TB_NOMBRE.Text = _controlador.NombreProducto;
            TB_MODELO.Text = _controlador.ModeloProducto;
            TB_REFERENCIA.Text = _controlador.ReferenciaProducto;
            TB_CONTENIDO.Text = _controlador.ContEmpProducto.ToString();

            CB_DEPARTAMENTO.SelectedValue = _controlador.AutoDepartamento;
            CB_GRUPO.SelectedValue = _controlador.AutoGrupo;
            CB_MARCA.SelectedValue = _controlador.AutoMarca;
            CB_IMPUESTO.SelectedValue = _controlador.AutoImpuesto;
            CB_ORIGEN.SelectedValue = _controlador.IdOrigen;
            CB_CATEGORIA.SelectedValue = _controlador.IdCategoria;
            CB_CLASIFICACION_ABC.SelectedValue = _controlador.IdClasificacionAbc;
            CB_DIVISA.SelectedValue = _controlador.IdDivisa;
            CB_EMPAQUE_COMPRA.SelectedValue = _controlador.AutoEmpCompra;
            inicializarData = false;
        }

        private void AgregarEditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_controlador.IsCerrarHabilitado;
            _controlador.InicializarIsCerrarHabilitado();
        }


        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_CODIGO_Leave(object sender, EventArgs e)
        {
            TB_CODIGO.Text = TB_CODIGO.Text.Trim().ToUpper();
            _controlador.CodigoProducto = TB_CODIGO.Text;
        }

        private void TB_DESCRIPCION_Leave(object sender, EventArgs e)
        {
            TB_DESCRIPCION.Text = TB_DESCRIPCION.Text.Trim().ToUpper();
            _controlador.DescripcionProducto = TB_DESCRIPCION.Text;
        }

        private void TB_NOMBRE_Leave(object sender, EventArgs e)
        {
            TB_NOMBRE.Text = TB_NOMBRE.Text.Trim().ToUpper();
            _controlador.NombreProducto = TB_NOMBRE.Text;
        }

        private void CB_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.AutoDepartamento = "";
            if (CB_DEPARTAMENTO.SelectedIndex != -1)
            {
                _controlador.AutoDepartamento = CB_DEPARTAMENTO.SelectedValue.ToString();
            }
        }

        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.AutoGrupo = "";
            if (CB_GRUPO.SelectedIndex != -1)
            {
                _controlador.AutoGrupo = CB_GRUPO.SelectedValue.ToString();
            }
        }

        private void CB_MARCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.AutoMarca = "";
            if (CB_MARCA.SelectedIndex != -1)
            {
                _controlador.AutoMarca = CB_MARCA.SelectedValue.ToString();
            }
        }

        private void CB_IMPUESTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.AutoImpuesto = "";
            if (CB_IMPUESTO.SelectedIndex != -1)
            {
                _controlador.AutoImpuesto = CB_IMPUESTO.SelectedValue.ToString();
            }
        }

        private void CB_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.IdOrigen = "";
            if (CB_ORIGEN.SelectedIndex != -1)
            {
                _controlador.IdOrigen = CB_ORIGEN.SelectedValue.ToString();
            }
        }

        private void CB_CATEGORIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.IdCategoria = "";
            if (CB_CATEGORIA.SelectedIndex != -1)
            {
                _controlador.IdCategoria = CB_CATEGORIA.SelectedValue.ToString();
            }
        }

        private void CB_CLASIFICACION_ABC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.IdClasificacionAbc = "";
            if (CB_CLASIFICACION_ABC.SelectedIndex != -1)
            {
                _controlador.IdClasificacionAbc = CB_CLASIFICACION_ABC.SelectedValue.ToString();
            }
        }

        private void CB_DIVISA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.IdDivisa = "";
            if (CB_DIVISA.SelectedIndex != -1)
            {
                _controlador.IdDivisa = CB_DIVISA.SelectedValue.ToString();
            }
        }

        private void CB_EMPAQUE_COMPRA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inicializarData) return;
            _controlador.AutoEmpCompra = "";
            if (CB_EMPAQUE_COMPRA.SelectedIndex != -1)
            {
                _controlador.AutoEmpCompra = CB_EMPAQUE_COMPRA.SelectedValue.ToString();
            }
        }

        private void TB_MODELO_Leave(object sender, EventArgs e)
        {
            TB_MODELO.Text = TB_MODELO.Text.Trim().ToUpper();
            _controlador.ModeloProducto = TB_MODELO.Text;
        }

        private void TB_REFERENCIA_Leave(object sender, EventArgs e)
        {
            TB_REFERENCIA.Text = TB_REFERENCIA.Text.Trim().ToUpper();
            _controlador.ReferenciaProducto = TB_REFERENCIA.Text;
        }

        private void TB_CONTENIDO_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = int.Parse(TB_CONTENIDO.Text) <= 0;
        }

        private void TB_CONTENIDO_Leave(object sender, EventArgs e)
        {
            _controlador.ContEmpProducto = int.Parse(TB_CONTENIDO.Text);  
        }

    }

}