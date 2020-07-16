using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario
{

    public partial class Form1 : Form
    {


        private GestionInv _controlador;


        public Form1()
        {
            InitializeComponent();
        }

        private void BT_TRASLADO_MERC_SUCURSAL_NIVEL_MINIMO_Click(object sender, EventArgs e)
        {
            TrasladoMercanciaEntreSucursalPorNivelMinimo();
        }

        private void TrasladoMercanciaEntreSucursalPorNivelMinimo()
        {
            _controlador.TrasladoMercanciaEntreSucursalPorNivelMinimo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void setControlador(GestionInv ctr) 
        {
            _controlador = ctr;
        }

    }
}
