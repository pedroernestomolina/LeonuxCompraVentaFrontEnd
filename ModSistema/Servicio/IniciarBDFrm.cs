using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Servicio
{

    public partial class IniciarBDFrm : Form
    {

        private Gestion _controlador;


        public IniciarBDFrm()
        {
            InitializeComponent();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
        }

        private void IniciarBDFrm_Load(object sender, EventArgs e)
        {
            ND_EQUIPO.Value = 1;
            ND_SUCURSAL.Value = 1;
            P_DATA.Enabled = _controlador.HabilitarEntrada;
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
     
        private void Salir()
        {
            this.Close();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void ND_SUCURSAL_ValueChanged(object sender, EventArgs e)
        {
            //_controlador.Sucursal =  ND_SUCURSAL.Value.ToString().Trim().PadLeft(2,'0');
            _controlador.setSucursal(ND_SUCURSAL.Value);
        }

        private void ND_EQUIPO_ValueChanged(object sender, EventArgs e)
        {
            _controlador.Equipo = ND_EQUIPO.Value.ToString().Trim().PadLeft(2, '0');
        }

    }

}