using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Producto.Deposito.Asignar
{

    public partial class AsignarFrm : Form
    {

        private Gestion _controlador;


        public AsignarFrm()
        {
            InitializeComponent();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

    }

}