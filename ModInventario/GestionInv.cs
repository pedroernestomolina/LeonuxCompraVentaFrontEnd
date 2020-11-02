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
        private Visor.CostoExistencia.Gestion _gestionVisorCostoExistencia;
        private Administrador.Gestion _gestionAdmMov;
        private Reportes.Filtros.Gestion _gestionReporteFiltros;


        public string Version 
        { 
            get 
            { 
                return "Ver. " + Application.ProductVersion; 
            } 
        }
        public string Host 
        { 
            get 
            { 
                return Sistema._Instancia + "/" + Sistema._BaseDatos; 
            } 
        }
        public string Usuario
        {
            get
            {
                var rt = "";
                rt = Sistema.UsuarioP.codigoUsu +
                    Environment.NewLine + Sistema.UsuarioP.nombreUsu +
                    Environment.NewLine + Sistema.UsuarioP.NombreGru;
                return rt;
            }
        }



        public GestionInv()
        {
            _gestionDepart = new Maestros.Departamentos.Gestion();
            _gestionGrupo = new Maestros.Grupos.Gestion();
            _gestionMarca = new Maestros.Marcas.Gestion();
            _gestionEmpaqueMedida = new Maestros.EmpaqueMedidas.Gestion();
            _gestionConcepto = new Maestros.Conceptos.Gestion();
            _gestionBusqueda = new Buscar.Gestion();
            _gestionMov = new Movimiento.Gestion();
            _gestionVisorExistencia = new Visor.Existencia.Gestion();
            _gestionVisorCostoEdad = new Visor.CostoEdad.Gestion();
            _gestionVisorTraslado = new Visor.Traslado.Gestion();
            _gestionVisorAjuste = new Visor.Ajuste.Gestion();
            _gestionVisorCostoExistencia = new Visor.CostoExistencia.Gestion();
            _gestionAdmMov = new Administrador.Gestion();
            _gestionReporteFiltros = new Reportes.Filtros.Gestion();
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
            var r00 = Sistema.MyData.Permiso_DefinirNivelMinimoMaximoInventario(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var _ajusteNivel = new Tool.AjusteNivelMinimoMaximoProducto.Gestion();
                _ajusteNivel.Inicia();
            }
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
            var r00 = Sistema.MyData.Permiso_MovimientoCargoInventario(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionMov = new Movimiento.Gestion();
                _gestionMov.setGestion(new Movimiento.Cargo.Gestion());
                _gestionMov.Inicia();
            }
        }

        public void MovimientoDesCargo()
        {
            var r00 = Sistema.MyData.Permiso_MovimientoDescargoInventario(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionMov = new Movimiento.Gestion();
                _gestionMov.setGestion(new Movimiento.Descargo.Gestion());
                _gestionMov.Inicia();
            }
        }

        public void MovimientoTraslado()
        {
            var r00 = Sistema.MyData.Permiso_MovimientoTrasladoInventario(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionMov = new Movimiento.Gestion();
                _gestionMov.setGestion(new Movimiento.Traslado.Gestion());
                _gestionMov.Inicia();
            }
        }

        public void TrasladoMercanciaEntreSucursalPorNivelMinimo()
        {
            var r00 = Sistema.MyData.Permiso_MovimientoTrasladoEntreSucursales_PorExistenciaDebajoDelMinimo(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionMov = new Movimiento.Gestion();
                _gestionMov.setGestion(new Movimiento.TrasladoEntreSucursal.Gestion());
                _gestionMov.Inicia2();
            }
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
            var r00 = Sistema.MyData.Permiso_MovimientoAjusteInventario(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionMov = new Movimiento.Gestion();
                _gestionMov.setGestion(new Movimiento.Ajuste.Gestion());
                _gestionMov.Inicia();
            }
        }

        public void AdministradorMovimiento()
        {
            var r00 = Sistema.MyData.Permiso_AdministradorMovimientoInventario(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionAdmMov.setGestion(new Administrador.Movimiento.Gestion());
                _gestionAdmMov.Inicia();
            }
        }

        public void VisorCostoExistencia()
        {
            _gestionVisorCostoExistencia = new Visor.CostoExistencia.Gestion ();
            _gestionVisorCostoExistencia.Inicia();
        }

        public void ReporteMaestroProductos()
        {
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.MaestroProducto.Filtros());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.ActivarFiltros_IsOK) 
            {
                var rp = new Reportes.Filtros.MaestroProducto.GestionRep();
                rp.setFiltros(_gestionReporteFiltros.DataFiltros);
                rp.Generar();
            }
        }

        public void ReporteMaestroInventario()
        {
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.MaestroInventario.Filtros());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.ActivarFiltros_IsOK)
            {
                var rp = new Reportes.Filtros.MaestroInventario.GestionRep();
                rp.setFiltros(_gestionReporteFiltros.DataFiltros);
                rp.Generar();
            }
        }

        public void GraficaTop30()
        {
            var gestion = new Graficas.Gestion();
            gestion.Inicia();
        }

        public void ReporteMaestroExistencia()
        {
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.MaestroExistencia.Filtros());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.ActivarFiltros_IsOK)
            {
                var rp = new Reportes.Filtros.MaestroExistencia.GestionRep();
                rp.setFiltros(_gestionReporteFiltros.DataFiltros);
                rp.Generar();
            }
        }

    }

}