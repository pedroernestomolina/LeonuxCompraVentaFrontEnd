using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Principal
{

    public partial class PrincipalFrm : Form
    {
        
        private Gestion _controlador;
        private Timer timer;


        public PrincipalFrm()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var s = DateTime.Now;
            L_FECHA.Text = s.ToLongDateString();
            L_HORA.Text = s.ToLongTimeString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
            L_VERSION.Text = _controlador.Version;
            L_HOST.Text = _controlador.Host;
            L_USUARIO.Text = _controlador.Usuario;
            L_FECHA.Text = "";
            L_HORA.Text = "";
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

        private void TSM_ARCHIVO_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        public void setVisibilidadOff()
        {
            this.Visible = false;
        }

        public void setVisibilidadOn()
        {
            this.Visible = true;
        }

        private void MENU_DOCUMENTOS_ADMINISTRADOR_Click(object sender, EventArgs e)
        {
            AdministradorDoc();
        }

        private void AdministradorDoc()
        {
            _controlador.AdministradorDoc();
        }

    }

}