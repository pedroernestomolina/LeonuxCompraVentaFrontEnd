using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos
{

    public partial class Form1 : Form
    {


        private Sistema_ _controlador;


        public Form1()
        {
            InitializeComponent();
        }


        private void ActualizarJornadaOperadorUsuario()
        {
            L_JORNADA_ACTIVA.Text = "";
            L_JORNADA_FECHA.Text = "";
            L_OPERADOR_ESTATUS.Text = "";
            L_OPERADOR_USUARIO.Text = "";
            L_OPERADOR_CODIGO.Text = "";
            L_OPERADOR_FECHA.Text = "";
            L_USUARIO_CODIGO.Text = "";
            L_USUARIO_NOMBRE.Text = "";

            if (Sistema.MyJornada != null)
            {
                L_JORNADA_ACTIVA.Text = "ACTIVA";
                L_JORNADA_FECHA.Text = Sistema.MyJornada.FechaApertura.ToShortDateString();
            }

            if (Sistema.MyOperador != null)
            {
                L_OPERADOR_ESTATUS.Text = "ACTIVA";
                L_OPERADOR_CODIGO.Text = Sistema.MyOperador.CodigoUsuario;
                L_OPERADOR_USUARIO.Text = Sistema.MyOperador.Usuario;
                L_OPERADOR_FECHA.Text = Sistema.MyOperador.FechaApertura.ToShortDateString();
            }

            L_USUARIO_CODIGO.Text = Sistema.Usuario.Codigo;
            L_USUARIO_NOMBRE.Text = Sistema.Usuario.Descripcion;
        }

        private void BT_POS_Click(object sender, EventArgs e)
        {
            ModuloVenta();
        }

        private void ModuloVenta()
        {
            _controlador.ActivarPos();
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
        }

        private void Salida()
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            L_BD_INF.Text = _controlador.InformacionBD;
            ActualizarJornadaOperadorUsuario();
        }

        private void BT_ACTUALIZAR_DATA_Click(object sender, EventArgs e)
        {
            ActualizaDataDelServidor();
        }

        private void ActualizaDataDelServidor()
        {
            _controlador.ImportarDataDelServidor();
        }

        private void BT_CONFIGURACION_Click(object sender, EventArgs e)
        {
            ConfiguracionSistema();
        }

        private void ConfiguracionSistema()
        {
            _controlador.ConfiguracionActivar();
        }

        private void BT_ADM_DOC_Click(object sender, EventArgs e)
        {
            AdministradorDocumentos();
        }

        private void AdministradorDocumentos()
        {
            _controlador.AdministradorDocumentosActivar();
        }

        private void Fiscal()
        {
            _controlador.FiscalActivar();
        }

        private void MenuItem_Configuracion_Sistema_Click(object sender, EventArgs e)
        {
            ConfiguracionSistema();
        }

        private void MenuItem_Archivo_Salida_Click(object sender, EventArgs e)
        {
            Salida();
        }

        private void BT_CONTROL_FISCAL_Click(object sender, EventArgs e)
        {
            Fiscal();
        }

        private void BT_JORNADA_ABRIR_Click(object sender, EventArgs e)
        {
            AbrirJornada();
        }

        private void AbrirJornada()
        {
            _controlador.AbrirJornada();
            ActualizarJornadaOperadorUsuario();
        }

        private void BT_JORNADA_CERRAR_Click(object sender, EventArgs e)
        {
            CerrarJornada();
        }

        private void CerrarJornada()
        {
            _controlador.CerrarJornada();
            ActualizarJornadaOperadorUsuario();
        }

        private void BT_OPERADOR_ABRIR_Click(object sender, EventArgs e)
        {
            AbrirOperador();
        }

        private void AbrirOperador()
        {
            _controlador.AbrirOperador();
            ActualizarJornadaOperadorUsuario();
        }

        private void BT_OPERADOR_CERRAR_Click(object sender, EventArgs e)
        {
            CerrarOperador();
        }

        private void CerrarOperador()
        {
            _controlador.CerrarOperador();
            ActualizarJornadaOperadorUsuario();
        }

        private void BT_ENVIAR_SERVIDOR_Click(object sender, EventArgs e)
        {
            EniviarDataServidor();
        }

        private void EniviarDataServidor()
        {
            _controlador.EniviarDataAlServidor();
        }

        private void MenuItem_Herramientas_TestBD_Click(object sender, EventArgs e)
        {
            TestBD();
        }

        private void TestBD()
        {
            _controlador.TestBD();
        }

        public void setControlador(Sistema_ _ctr) 
        {
            _controlador = _ctr;
        }

        private void MenuItem_Configuracion_Permisos_Click(object sender, EventArgs e)
        {
            PermisosConfiguracion();
        }

        private void PermisosConfiguracion()
        {
            _controlador.ConfigurarPermisos();
        }

        private void MenuItem_Herramientas_Limpiar_BD_Local_Click(object sender, EventArgs e)
        {
            LimpiarBD_Local();
        }

        private void LimpiarBD_Local()
        {
            _controlador.InicializarBDLocal();
        }

    }

}