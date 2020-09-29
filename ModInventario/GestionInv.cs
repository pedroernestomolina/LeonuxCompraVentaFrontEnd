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
        private Movimiento.Gestion _gestionMov;
        private Visor.Existencia.Gestion _gestionVisorExistencia;
        private Visor.CostoEdad.Gestion _gestionVisorCostoEdad;
        private Visor.Traslado.Gestion _gestionVisorTraslado;
        private Visor.Ajuste.Gestion _gestionVisorAjuste;


        public string Version { get { return "Ver. " + Application.ProductVersion; } }
        public string Host { get { return Sistema._Instancia + "/" + Sistema._BaseDatos; } }


        public GestionInv()
        {
            _gestionDepart = new Maestros.Departamentos.Gestion();
            _gestionGrupo = new Maestros.Grupos.Gestion();
            _gestionMarca = new Maestros.Marcas.Gestion();
            _gestionEmpaqueMedida = new Maestros.EmpaqueMedidas.Gestion();
            _gestionConcepto = new Maestros.Conceptos.Gestion();
            _gestionBusqueda = new Buscar.Gestion();
            _gestionMovimiento = new Movimiento.Traslado.EntreSucursalesPorExistenciaPorDebajoNivelMinimo.Gestion();
            _gestionMov = new Movimiento.Gestion();
            _gestionVisorExistencia = new Visor.Existencia.Gestion();
            _gestionVisorCostoEdad = new Visor.CostoEdad.Gestion();
            _gestionVisorTraslado = new Visor.Traslado.Gestion();
            _gestionVisorAjuste = new Visor.Ajuste.Gestion();
        }


        Form1 frm = null;
        public void Inicia() 
        {
            if (frm == null) 
            {
                frm = new Form1();
                frm.setControlador(this);
            }
            frm.ShowDialog();
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

        public void MovimientoCargo()
        {
            _gestionMov = new Movimiento.Gestion();
            _gestionMov.setGestion(new Movimiento.Cargo.Gestion());
            _gestionMov.Inicia();
        }

        public void MovimientoDesCargo()
        {
            _gestionMov = new Movimiento.Gestion();
            _gestionMov.setGestion(new Movimiento.Descargo.Gestion());
            _gestionMov.Inicia();
        }

        public void MovimientoTraslado()
        {
            _gestionMov = new Movimiento.Gestion();
            _gestionMov.setGestion(new Movimiento.Traslado.Gestion());
            _gestionMov.Inicia();
        }

        public void TrasladoMercanciaEntreSucursalPorNivelMinimo()
        {
            //_gestionMovimiento.Inicializar();
            //_gestionMovimiento.TrasladoEntreSucursal_PorNivelMinimo();
            _gestionMov = new Movimiento.Gestion();
            _gestionMov.setGestion(new Movimiento.TrasladoEntreSucursal.Gestion());
            _gestionMov.Inicia2();
        }

        public void VisorExistencia()
        {
            _gestionVisorExistencia = new Visor.Existencia.Gestion();
            _gestionVisorExistencia.Inicia();
        }

        public  void VisorCostoEdad()
        {
            _gestionVisorCostoEdad = new Visor.CostoEdad.Gestion();
            _gestionVisorCostoEdad.Inicia();
        }

        public void VisorTraslados()
        {
            _gestionVisorTraslado = new Visor.Traslado.Gestion();
            _gestionVisorTraslado.Inicia();
        }

        public void VisorAjuste()
        {
            _gestionVisorAjuste= new Visor.Ajuste.Gestion();
            _gestionVisorAjuste.Inicia();
        }

        public void MovimientoAjuste()
        {
            _gestionMov = new Movimiento.Gestion();
            _gestionMov.setGestion(new Movimiento.Ajuste.Gestion());
            _gestionMov.Inicia();
        }

    }

}