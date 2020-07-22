using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario
{

    public class GestionInv
    {


        private Movimiento.Traslado.EntreSucursalesPorExistenciaPorDebajoNivelMinimo.Gestion _gestionMovimiento;


        public string Version { get { return "Ver. " + Application.ProductVersion; } }


        public GestionInv()
        {
            _gestionMovimiento = new Movimiento.Traslado.EntreSucursalesPorExistenciaPorDebajoNivelMinimo.Gestion();
        }


        Form1 frm = null;
        public void Inicia() 
        {
            frm = new Form1();
            frm.setControlador(this);
            frm.ShowDialog();
        }

     
        public void TrasladoMercanciaEntreSucursalPorNivelMinimo()
        {
            _gestionMovimiento.Inicializar();
            _gestionMovimiento.TrasladoEntreSucursal_PorNivelMinimo();
        }


        public void Ajuste_DefinirNivelMinimoMaximo()
        {
            var _ajusteNivel = new Tool.AjusteNivelMinimoMaximoProducto.Gestion();
            _ajusteNivel.Inicia();
        }

    }

}