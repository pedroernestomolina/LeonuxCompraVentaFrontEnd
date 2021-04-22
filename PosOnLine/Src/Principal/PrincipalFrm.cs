using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Principal
{

    public partial class PrincipalFrm : Form
    {


        private Gestion _controlador;


        public PrincipalFrm()
        {
            InitializeComponent();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void PrincipalFrm_Load(object sender, EventArgs e)
        {
        }

        private void BT_ABRIR_POS_Click(object sender, EventArgs e)
        {
            AbrirPos();
        }

        private void AbrirPos()
        {
            _controlador.AbrirPos();
        }

        private void BT_CERRAR_POS_Click(object sender, EventArgs e)
        {
            CerrarPos();
        }

        private void CerrarPos()
        {
            _controlador.CerrarPos();
        }

        public void setVisibilidad(bool p)
        {
            this.Visible = p;
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_ADM_DOCUMENTOS_Click(object sender, EventArgs e)
        {
            AdmDocumentos();
        }

        private void AdmDocumentos()
        {
            _controlador.AdmDocumentos();
        }

    }

}