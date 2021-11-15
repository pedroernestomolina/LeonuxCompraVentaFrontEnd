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

        private Maestros.Gestion _gestionMaestro;
        private Buscar.Gestion _gestionBusqueda;
        private Movimiento.Gestion _gestionMov;
        private Visor.Existencia.Gestion _gestionVisorExistencia;
        private Visor.CostoEdad.Gestion _gestionVisorCostoEdad;
        private Visor.Traslado.Gestion _gestionVisorTraslado;
        private Visor.Ajuste.Gestion _gestionVisorAjuste;
        private Visor.CostoExistencia.Gestion _gestionVisorCostoExistencia;
        private Visor.Precio.Gestion _gestionVisorPrecio;
        private Administrador.Gestion _gestionAdmMov;
        private Reportes.Filtros.Gestion _gestionReporteFiltros;
        private Configuracion.CostoEdad.Gestion _gestionConfCostoEdad;
        private Configuracion.RedondeoPrecio.Gestion _gestionConfRedondeoPrecio;
        private Configuracion.RegistroPrecio.Gestion _gestionConfRegistroPrecio;
        private Configuracion.BusquedaPredeterminada.Gestion _gestionConfBusquedaPred;
        private Configuracion.MetodoCalculoUtilidad.Gestion _gestionConfMetodoCalUtilidad;
        private Auditoria.Visualizar.Gestion _gestionAuditoria;


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
            _gestionMaestro = new Maestros.Gestion();
            _gestionBusqueda = new Buscar.Gestion();
            _gestionMov = new Movimiento.Gestion();
            _gestionVisorExistencia = new Visor.Existencia.Gestion();
            _gestionVisorCostoEdad = new Visor.CostoEdad.Gestion();
            _gestionVisorTraslado = new Visor.Traslado.Gestion();
            _gestionVisorAjuste = new Visor.Ajuste.Gestion();
            _gestionVisorCostoExistencia = new Visor.CostoExistencia.Gestion();
            _gestionVisorPrecio = new Visor.Precio.Gestion();
            _gestionAdmMov = new Administrador.Gestion();
            _gestionReporteFiltros = new Reportes.Filtros.Gestion();
            _gestionConfCostoEdad = new Configuracion.CostoEdad.Gestion();
            _gestionConfRedondeoPrecio = new Configuracion.RedondeoPrecio.Gestion();
            _gestionConfRegistroPrecio = new Configuracion.RegistroPrecio.Gestion();
            _gestionConfBusquedaPred = new Configuracion.BusquedaPredeterminada.Gestion();
            _gestionConfMetodoCalUtilidad = new Configuracion.MetodoCalculoUtilidad.Gestion();
            _gestionAuditoria = new Auditoria.Visualizar.Gestion();
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
            _gestionMaestro.setGestion(new Maestros.Departamento.Gestion());
            _gestionMaestro.Inicia();
        }

        public void MaestroGrupo()
        {
            _gestionMaestro.setGestion(new Maestros.Grupo.Gestion());
            _gestionMaestro.Inicia();
        }

        public void MaestroMarca()
        {
            _gestionMaestro.setGestion(new Maestros.Marca.Gestion());
            _gestionMaestro.Inicia();
        }

        public void MaestroEmpaquesMedida()
        {
            _gestionMaestro.setGestion(new Maestros.EmpaqueMedida.Gestion());
            _gestionMaestro.Inicia();
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
            _gestionMaestro.setGestion(new Maestros.Concepto.Gestion());
            _gestionMaestro.Inicia();
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
                _gestionMov.Inicializa();
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
                _gestionAdmMov.setGestionAuditoria(_gestionAuditoria);
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

        public void ReporteMaestroPrecio()
        {
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.MaestroPrecio.Filtros());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.ActivarFiltros_IsOK)
            {
                var rp = new Reportes.Filtros.MaestroPrecio.GestionRep();
                rp.setFiltros(_gestionReporteFiltros.DataFiltros);
                rp.Generar();
            }
        }

        public void Kardex()
        {
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.Kardex.Filtros());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.ActivarFiltros_IsOK)
            {
                if (_gestionReporteFiltros.Hasta >= _gestionReporteFiltros.Desde)
                {
                    var rp = new Reportes.Filtros.Kardex.GestionRep();
                    rp.setFiltros(_gestionReporteFiltros.DataFiltros);
                    rp.Generar();
                }
                else
                    Helpers.Msg.Error("Parametros Incorrectos, Verifique Por Favor");
            }
        }

        public void ReporteRelacionCompraVenta()
        {
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.RelacionCompraVenta.Filtros());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.ActivarFiltros_IsOK)
            {
                if (_gestionReporteFiltros.ProductoIsOk)
                {
                    var rp = new Reportes.Filtros.RelacionCompraVenta.GestionRep();
                    rp.setFiltros(_gestionReporteFiltros.DataFiltros);
                    rp.Generar();
                }
                else
                    Helpers.Msg.Error("Parametros Incorrectos, Verifique Por Favor");
            }
        }

        public void ReporteMaestroDepositoResumen()
        {
            var rp = new Reportes.Filtros.DepositoResumen.GestionRep();
            rp.Generar();
        }

        public void MaestroNivelMinimo()
        {
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.NivelMInimo.Filtro());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.ActivarFiltros_IsOK)
            {
                var rp = new Reportes.Filtros.NivelMInimo.GestionRep();
                rp.setFiltros(_gestionReporteFiltros.DataFiltros);
                rp.Generar();
            }
        }

        public void Conf_CostoEdadProducto()
        {
            var r00 = Sistema.MyData.Permiso_ConfiguracionSistema(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionConfCostoEdad.Inicializa();
                _gestionConfCostoEdad.Inicia();
            }
        }

        public void Conf_RedondeoPreciosVenta()
        {
            var r00 = Sistema.MyData.Permiso_ConfiguracionSistema(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionConfRedondeoPrecio.Inicializa();
                _gestionConfRedondeoPrecio.Inicia();
            }
        }

        public void Conf_RegistroPrecio()
        {
            var r00 = Sistema.MyData.Permiso_ConfiguracionSistema(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionConfRegistroPrecio.Inicializa();
                _gestionConfRegistroPrecio.Inicia();
            }
        }

        public void Conf_BusquedaPredeterminada()
        {
            var r00 = Sistema.MyData.Permiso_ConfiguracionSistema(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionConfBusquedaPred.Inicializa();
                _gestionConfBusquedaPred.Inicia();
            }
        }

        public void Conf_MetodoCalcUtilidad()
        {
            var r00 = Sistema.MyData.Permiso_ConfiguracionSistema(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionConfMetodoCalUtilidad.Inicializa();
                _gestionConfMetodoCalUtilidad.Inicia();
            }
        }

        public void ReporteValorizacionInventario()
        {
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.Valorizacion.Filtros());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.ActivarFiltros_IsOK)
            {
                var rp = new Reportes.Filtros.Valorizacion.GestionRep();
                rp.setFiltros(_gestionReporteFiltros.DataFiltros);
                rp.Generar();
            }
        }

        public void TrasladoPorDevolucion()
        {
            var r00 = Sistema.MyData.Permiso_MovimientoTrasladoPorDevolucion(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var _gestion = new Movimiento.TrasladoDevolucion.Gestion();
                _gestion.setConcepto("0000000034");

                _gestionMov = new Movimiento.Gestion();
                _gestionMov.setGestion(_gestion);
                _gestionMov.setHabilitarConcepto(false);
                _gestionMov.Inicia();
            }
        }

        public void VisorPrecios()
        {
            _gestionVisorPrecio.Inicializa();
            _gestionVisorPrecio.Inicia();
        }

        public void Kardex_Resumen_Mov()
        {
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.Kardex.Filtros());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.ActivarFiltros_IsOK)
            {
                if (_gestionReporteFiltros.DataFiltros.AutoProducto=="")
                {
                    Helpers.Msg.Error("Parametro [ PRODUCTO ] Incorrectos, Verifique Por Favor");
                    return;
                }

                if (_gestionReporteFiltros.Hasta >= _gestionReporteFiltros.Desde)
                {
                    var rp = new Reportes.Filtros.KardexResumen.GestionRep();
                    rp.setFiltros(_gestionReporteFiltros.DataFiltros);
                    rp.Generar();
                }
                else
                    Helpers.Msg.Error("Parametros Incorrectos, Verifique Por Favor");
            }
        }

    }

}