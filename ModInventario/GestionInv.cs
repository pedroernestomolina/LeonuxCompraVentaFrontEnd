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
        private Maestros.Departamentos.Gestion _gestionDepart;
        private Maestros.Grupos.Gestion _gestionGrupo;
        private Maestros.EmpaqueMedidas.Gestion _gestionEmpaqueMedida;
        private Maestros.Marcas.Gestion _gestionMarca;
        private Maestros.Conceptos.Gestion _gestionConcepto;
        private Buscar.Gestion _gestionBusqueda;


        public string Version { get { return "Ver. " + Application.ProductVersion; } }


        public GestionInv()
        {
            _gestionDepart = new Maestros.Departamentos.Gestion();
            _gestionGrupo = new Maestros.Grupos.Gestion();
            _gestionMarca = new Maestros.Marcas.Gestion();
            _gestionEmpaqueMedida = new Maestros.EmpaqueMedidas.Gestion();
            _gestionConcepto = new Maestros.Conceptos.Gestion();
            _gestionBusqueda = new Buscar.Gestion();
            _gestionMovimiento = new Movimiento.Traslado.EntreSucursalesPorExistenciaPorDebajoNivelMinimo.Gestion();
        }


        Form1 frm = null;
        public void Inicia() 
        {
            frm = new Form1();
            frm.setControlador(this);
            Application.Run(frm);

            //frm = new Form1();
            //frm.setControlador(this);
            //frm.ShowDialog();
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

        public void MaestroDepartamentos()
        {
            _gestionDepart.Inicia();
        }

        public void MaestroGrupo()
        {
            _gestionGrupo.Inicia();
        }

        public void MaestroMarca()
        {
            _gestionMarca.Inicia();
        }

        public void MaestroEmpaquesMedida()
        {
            _gestionEmpaqueMedida.Inicia();
        }

        public void BuscarProducto()
        {
            _gestionBusqueda.Inicia();
            if (_gestionBusqueda.HayItemSeleccionado)
            {
                MessageBox.Show(_gestionBusqueda.Item.Producto);
            }
        }

        public void MaestroConcepto()
        {
            _gestionConcepto.Inicia();
        }

    }

}