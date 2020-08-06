using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Precio.Ver
{

    public partial class VerFrm : Form
    {

        private Gestion _controlador;


        public VerFrm()
        {
            InitializeComponent();
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

        private void VerFrm_Load(object sender, EventArgs e)
        {
            Limpiar();
            Actualizar();
        }

        private void Actualizar()
        {
            L_ETQ_1.Text = _controlador.Precio1.etiqueta;
            L_EMP_1.Text = _controlador.Precio1.empaque;
            L_CONT_1.Text = _controlador.Precio1.contenido.ToString("n0");
            L_UT_1.Text = _controlador.Precio1.utilidadPorc.ToString("n2").Trim() + "%";
            L_PN_1.Text = _controlador.Precio1.PN.ToString("n2");
            L_PF_1.Text = _controlador.Precio1.PF.ToString("n2");
        }

        private void Limpiar()
        {
            L_ETQ_1.Text = "";
            L_CONT_1.Text = "";
            L_EMP_1.Text = "";
            L_UT_1.Text = "";
            L_PN_1.Text = "";
            L_PF_1.Text = "";
        }

        private void BT_MODO_PRECIO_Click(object sender, EventArgs e)
        {
            CambioModoPrecio();
        }

        private void CambioModoPrecio()
        {
            _controlador.CambioModoPrecio();
            Actualizar();
        }

    }

}