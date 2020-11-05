using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario
{

    public partial class Form1 : Form
    {


        private GestionInv _controlador;
        private Timer timer;


        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick +=timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var s = DateTime.Now;
            L_FECHA.Text = s.ToLongDateString();
            L_HORA.Text = s.ToLongTimeString();
        }

        private void BT_TRASLADO_MERC_SUCURSAL_NIVEL_MINIMO_Click(object sender, EventArgs e)
        {
            TrasladoMercanciaEntreSucursalPorNivelMinimo();
        }

        private void TrasladoMercanciaEntreSucursalPorNivelMinimo()
        {
            _controlador.TrasladoMercanciaEntreSucursalPorNivelMinimo();
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

        public void setControlador(GestionInv ctr) 
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

        private void TSM_MOVIMIENTO_TRASLADOMERCANCIAPOREXISTENCIADEBAJOMINIMO_Click(object sender, EventArgs e)
        {
            Movimientos_TrasladoEntreSucursal_PorExistenca_DebajoMinimo();
        }

        private void Movimientos_TrasladoEntreSucursal_PorExistenca_DebajoMinimo()
        {
            _controlador.TrasladoMercanciaEntreSucursalPorNivelMinimo();
        }

        private void TSM_ARCHIVO_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void TSM_AJUSTE_DefinirNivelMinimoMaximo_Click(object sender, EventArgs e)
        {
            Ajuste_DefinirNivelMinimoMaximo();
        }

        private void Ajuste_DefinirNivelMinimoMaximo()
        {
            VisibilidadOff();
            _controlador.Ajuste_DefinirNivelMinimoMaximo();
            VisibilidadOn();
        }

        private void VisibilidadOn()
        {
            this.Visible = true;
        }

        private void VisibilidadOff()
        {
            this.Visible = false;
        }

        private void TSM_MAESTROS_Departamentos_Click(object sender, EventArgs e)
        {
            MaestroDepartamentos();
        }

        private void MaestroDepartamentos()
        {
            _controlador.MaestroDepartamentos();
        }

        private void TSM_MAESTRO_Grupo_Click(object sender, EventArgs e)
        {
            MaestroGrupo();
        }

        private void MaestroGrupo()
        {
            _controlador.MaestroGrupo();
        }

        private void TSM_MAESTRO_Marcas_Click(object sender, EventArgs e)
        {
            MaestroMarca();
        }

        private void MaestroMarca()
        {
            _controlador.MaestroMarca();
        }

        private void TSM_MAESTRO_EmpaquesMedida_Click(object sender, EventArgs e)
        {
            MaestroEmpaquesMedida();
        }

        private void MaestroEmpaquesMedida()
        {
            _controlador.MaestroEmpaquesMedida();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controlador.BuscarProducto();
        }

        private void TSM_MAESTROS_Conceptos_Click(object sender, EventArgs e)
        {
            MaestroConcepto();
        }

        private void MaestroConcepto()
        {
            _controlador.MaestroConcepto();
        }

        private void TSM_Movimiento_Control_Cargo_Click(object sender, EventArgs e)
        {
            MovimientoCargo();
        }

        private void MovimientoCargo()
        {
            _controlador.MovimientoCargo();
        }

        private void TSM_Movimiento_Control_DesCargo_Click(object sender, EventArgs e)
        {
            MovimientoDesCargo();
        }

        private void MovimientoDesCargo()
        {
            _controlador.MovimientoDesCargo();
        }

        private void TSM_Movimiento_Control_Traslado_Click(object sender, EventArgs e)
        {
            MovimientoTraslado();
        }

        private void MovimientoTraslado()
        {
            _controlador.MovimientoTraslado();
        }

        private void TSM_VISOR_EXISTENCIA_Click(object sender, EventArgs e)
        {
            VisorExistencia();
        }

        private void VisorExistencia()
        {
            _controlador.VisorExistencia();
        }

        private void TSM_VISOR_COSTOEDAD_Click(object sender, EventArgs e)
        {
            VisorCostoEdad();
        }

        private void VisorCostoEdad()
        {
            _controlador.VisorCostoEdad(); 
        }

        private void TSM_VISOR_TRASLADO_Click(object sender, EventArgs e)
        {
            VisorTraslados();
        }

        private void VisorTraslados()
        {
            _controlador.VisorTraslados();
        }

        private void TSM_VISOR_AJUSTE_Click(object sender, EventArgs e)
        {
            VisorAjuste();
        }

        private void VisorAjuste()
        {
            _controlador.VisorAjuste();
        }

        private void TSM_AJUSTE_MOVIMIENTO_Click(object sender, EventArgs e)
        {
            MovimientoAjuste();
        }

        private void MovimientoAjuste()
        {
            _controlador.MovimientoAjuste();
        }

        private void TSM_MOVIMIENTO_ADMINISTRADOR_Click(object sender, EventArgs e)
        {
            AdministradorMovimiento();
        }

        private void AdministradorMovimiento()
        {
            _controlador.AdministradorMovimiento();
        }

        private void TSM_VISOR_COSTO_EXISTENCIA_Click(object sender, EventArgs e)
        {
            VisorCostoExistencia();
        }

        private void VisorCostoExistencia()
        {
            _controlador.VisorCostoExistencia();
        }

        private void TSM_REPORTE_MAESTRO_PRODUCTO_Click(object sender, EventArgs e)
        {
            ReporteMaestroProductos();
        }

        private void ReporteMaestroProductos()
        {
            _controlador.ReporteMaestroProductos();
        }

        private void TSM_REPORTE_MAESTRO_INVENTARIO_Click(object sender, EventArgs e)
        {
            ReporteMaestroInventario();
        }

        private void ReporteMaestroInventario()
        {
            _controlador.ReporteMaestroInventario();
        }

        private void TSM_GRAFICA_TOP_30_Click(object sender, EventArgs e)
        {
            GraficaTop30();
        }

        private void GraficaTop30()
        {
            _controlador.GraficaTop30();
        }

        private void TSM_REPORTE_MAESTRO_EXISTENCIA_Click(object sender, EventArgs e)
        {
            ReporteMaestroExistencia();
        }

        private void ReporteMaestroExistencia()
        {
            _controlador.ReporteMaestroExistencia();
        }

        private void TSM_REPORTE_MAESTRO_PRECIO_Click(object sender, EventArgs e)
        {
            ReporteMaestroPrecio();
        }

        private void ReporteMaestroPrecio()
        {
            _controlador.ReporteMaestroPrecio();
        }

        private void TSM_REPORTE_KARDEX_Click(object sender, EventArgs e)
        {
            Kardex();
        }

        private void Kardex()
        {
            _controlador.Kardex();
        }

    }

}