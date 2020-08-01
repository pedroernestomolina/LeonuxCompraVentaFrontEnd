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
            CB_CATEGORIA.DisplayMember = "Descripcion";
            CB_CATEGORIA.ValueMember = "Id";
            CB_ORIGEN.DisplayMember = "Descripcion";
            CB_ORIGEN.ValueMember = "Id";
            CB_IMPUESTO.DisplayMember= "Ficha";
            CB_IMPUESTO.ValueMember = "Auto";
        }

        private void FiltrosFrm_Load(object sender, EventArgs e)
        {
            CB_DEPARTAMENTO.DataSource = _controlador.SourceDepart;
            CB_GRUPO.DataSource = _controlador.SourceGrupo;
            CB_CATEGORIA.DataSource = _controlador.SourceCategoria;
            CB_ORIGEN.DataSource = _controlador.SourceOrigen;
            CB_IMPUESTO .DataSource = _controlador.SourceTasa;
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void CB_DEPARTAMENTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_DEPARTAMENTO.SelectedIndex != -1)
            {
                _controlador.AutoDepartamento = CB_DEPARTAMENTO.SelectedValue.ToString();
            }
        }

        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_GRUPO.SelectedIndex != -1) 
            {
                _controlador.AutoGrupo = CB_GRUPO.SelectedValue.ToString();
            }
        }

        private void CB_CATEGORIA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_CATEGORIA.SelectedIndex != -1) 
            {
                _controlador.IdCategoria = CB_CATEGORIA.SelectedValue.ToString();
            }
        }

        private void CB_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_ORIGEN.SelectedIndex != -1)
            {
                _controlador.IdOrigen = CB_ORIGEN.SelectedValue.ToString();
            }
        }

        private void CB_IMPUESTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_IMPUESTO.SelectedIndex != -1)
            {
                _controlador.AutoTasa = CB_IMPUESTO.SelectedValue.ToString();
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
                CB_DEPARTAMENTO.SelectedIndex = -1;
                CB_GRUPO.SelectedIndex = -1;
                CB_CATEGORIA.SelectedIndex = -1;
                CB_ORIGEN.SelectedIndex = -1;
                CB_IMPUESTO.SelectedIndex = -1;
            }
        }

    }

}