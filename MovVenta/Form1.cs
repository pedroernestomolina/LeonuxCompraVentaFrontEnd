using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MovVenta
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
        }

        private void Salida()
        {
            Close();
        }

        private void BT_VENTA_Click(object sender, EventArgs e)
        {
            VentaAdministrativa();
        }

        private void VentaAdministrativa()
        {
            var usuario = new OOB.LibVenta.Usuario.Ficha();
            usuario.Auto = "0000000032";
            usuario.AutoGrupo = "0000000001";
            usuario.Codigo = "KARI";
            usuario.CodigoGrupo = "ADMINISTRADOR";
            usuario.Descripcion = "KARI";
            usuario.DescripcionGrupo = "ADMINISTRADOR";

            var frm = new Venta.VentaAdministrativa.VentaAdministrativaFrm();
            frm.setUsuarioSistema(usuario);
            if (frm.CargarData()) 
            {
                frm.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }

}