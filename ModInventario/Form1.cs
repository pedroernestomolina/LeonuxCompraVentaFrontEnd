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


        public Form1()
        {
            InitializeComponent();
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
            L_VERSION.Text = _controlador.Version;
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

    }

}