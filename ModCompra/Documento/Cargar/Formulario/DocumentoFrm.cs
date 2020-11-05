using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Formulario
{

    public partial class DocumentoFrm : Form
    {


        private Controlador.Gestion _controlador;


        public DocumentoFrm()
        {
            InitializeComponent();
        }

        private void DocumentoFrm_Load(object sender, EventArgs e)
        {
            Inicializar_1();
        }

        private void Inicializar_1()
        {
            L_TITULO_DOCUMENTO.Text = _controlador.TituloDocumento;
        }

        public void setControlador(Controlador.Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_NUEVO_Click(object sender, EventArgs e)
        {
            NuevoDocumento();
        }

        private void NuevoDocumento()
        {
            _controlador.NuevoDocumento();
        }

    }

}