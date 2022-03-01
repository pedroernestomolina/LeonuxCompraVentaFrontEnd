using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema
{

    public partial class Form1 : Form
    {

        private Gestion _controlador;
        private Timer timer;


        public Form1()
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

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
            L_VERSION.Text = _controlador.Version;
            L_HOST.Text = _controlador.Host;
            L_USUARIO.Text = _controlador.Usuario;
            L_FECHA.Text = "";
            L_HORA.Text = "";
        }

        private void TSM_MAESTRO_SucursalGrupo_Click(object sender, EventArgs e)
        {
            SucursalGrupo();
        }

        private void SucursalGrupo()
        {
            _controlador.MaestroSucursalGrupo();
        }

        private void TSM_MAESTRO_Sucursal_Click(object sender, EventArgs e)
        {
            Sucursales();
        }

        private void Sucursales()
        {
            _controlador.MaestroSucursales();
        }

        private void TSM_MAESTRO_Deposito_Click(object sender, EventArgs e)
        {
            Depositos();
        }

        private void Depositos()
        {
            _controlador.MaestroDepositos();
        }

        private void TSM_AJUSTE_EtiquetarPrecios_Click(object sender, EventArgs e)
        {
            EtiquetarPrecios();
        }

        private void EtiquetarPrecios()
        {
            _controlador.EtiquetarPrecios();
        }

        private void TSM_AJUSTES_AsignarDepositoSucursal_Click(object sender, EventArgs e)
        {
            AsignarDepositoPrincipalASucursal();
        }

        private void AsignarDepositoPrincipalASucursal()
        {
            _controlador.AsignarDepositoPrincipalASucursal();
        }

        private void TSM_MAESTROS_UsuarioGrupo_Click(object sender, EventArgs e)
        {
            UsuarioGrupos();
        }

        private void UsuarioGrupos()
        {
            _controlador.MaestroUsuariosGrupo();
        }

        private void TSM_MAESTROS_Usuario_Click(object sender, EventArgs e)
        {
            Usuarios();
        }

        private void Usuarios()
        {
            _controlador.MaestroUsuarios();
        }

        private void TSM_SERVICIO_INICIALIZA_BD_Click(object sender, EventArgs e)
        {
            InicializarBD();
        }

        private void InicializarBD()
        {
            _controlador.InicializarBD();
        }

        private void TSM_SERVICIO_INICIALIZA_BD_SUCURSAL_Click(object sender, EventArgs e)
        {
            InicializarBD_Sucursal();
        }

        private void InicializarBD_Sucursal()
        {
            _controlador.InicializarBD_Sucursal();
        }

        private void Menu_Ajuste_TasaRecepciónDivisa_POS_Click(object sender, EventArgs e)
        {
            TasaRecepcionDivisaPos();
        }

        private void TasaRecepcionDivisaPos()
        {
            _controlador.TasaRecepcionDivisaPos();
        }

        private void Menu_Ajuste_TasaDivisa_Click(object sender, EventArgs e)
        {
            TasaDivisa();
        }

        private void TasaDivisa()
        {
            _controlador.TasaDivisa();
        }

        private void TSM_MAESTRO_VENDEDOR_Click(object sender, EventArgs e)
        {
            Vendedor();
        }

        private void Vendedor()
        {
            _controlador.Vendedor();
        }

        private void TSM_MAESTRO_COBRADOR_Click(object sender, EventArgs e)
        {
            Cobrador();
        }

        private void Cobrador()
        {
            _controlador.Cobrador();
        }

        private void TSM_MAESTRO_SERIES_FISCAL_Click(object sender, EventArgs e)
        {
            SeriesFiscal();
        }

        private void SeriesFiscal()
        {
            _controlador.SeriesFiscal();
        }

        private void Menu_Ajuste_ReconversionMonetaria_Click(object sender, EventArgs e)
        {
            ReconversionMonetaria();
        }

        private void ReconversionMonetaria()
        {
            _controlador.ReconversionMonetaria();
        }

        private void TSM_AJUSTE_Datos_Negocio_Click(object sender, EventArgs e)
        {
            DatosDelNegocio();
        }

        private void DatosDelNegocio()
        {
            _controlador.DatosDelNegocio();
        }

        private void TSM_CONF_MODULO_Click(object sender, EventArgs e)
        {
            ConfiguracionModulo();
        }
        private void ConfiguracionModulo()
        {
            _controlador.ConfiguracionModulo();
        }

    }

}