using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco
{

    public partial class Form1 : Form
    {

        private Gestion _controlador;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            L_VERSION.Text = _controlador.Version;
            L_HOST.Text = _controlador.Host;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void TSM_REPORTES_ArqueoCajaPos_Click(object sender, EventArgs e)
        {
            ArqueoCajaPos();
        }

        private void ArqueoCajaPos()
        {
            _controlador.ArqueoCajaPos();
        }

    }

}