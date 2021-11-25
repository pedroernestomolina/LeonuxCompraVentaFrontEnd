using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Documentos.Generar.AgregarEditarItem
{

    public partial class AgregarEditarItemFrm : Form
    {

        private Gestion _controlador;


        public AgregarEditarItemFrm()
        {
            InitializeComponent();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void AgregarEditarItemFrm_Load(object sender, EventArgs e)
        {
            L_MODO.Text = _controlador.ModoFicha;
        }

    }

}