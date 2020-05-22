using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.ClaveSeguridad
{

    public partial class SeguridadFrm : Form
    {


        public string Clave { get; set; }


        public SeguridadFrm()
        {
            InitializeComponent();
        }

        private void SeguridadFrm_Load(object sender, EventArgs e)
        {
            TB_CLAVE.Text = "";
            TB_CLAVE.Focus();
            Clave = "";
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Clave = TB_CLAVE.Text.Trim().ToUpper();
            Close();
        }

    }

}