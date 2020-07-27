using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.SucursalDeposito
{

    public partial class AsignarFrm : Form
    {

        private GestionAjustar _controlador;


        public AsignarFrm()
        {
            InitializeComponent();
        }


        public void setControlador(GestionAjustar ctr)
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

        private void AsignarFrm_Load(object sender, EventArgs e)
        {
            CB_DEPOSITO.DisplayMember = "nombre";
            CB_DEPOSITO.ValueMember = "auto";
            CB_DEPOSITO.DataSource = _controlador.DepositoSource;
            CB_DEPOSITO.SelectedValue = _controlador.AutoDeposito;

            L_SUCURSAL.Text = _controlador.Sucursal;
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.IsAjusteOk) 
            {
                Salir();
            }
        }

        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.AutoDeposito = CB_DEPOSITO.SelectedValue.ToString();
        }

    }

}