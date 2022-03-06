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

        private Helpers.Seguridad _seguridad;
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
        private Configuracion.CostoEdad.Gestion _gestionConfCostoEdad;
        private Configuracion.RedondeoPrecio.Gestion _gestionConfRedondeoPrecio;
        private Configuracion.RegistroPrecio.Gestion _gestionConfRegistroPrecio;
        private Configuracion.BusquedaPredeterminada.Gestion _gestionConfBusquedaPred;
        private Configuracion.MetodoCalculoUtilidad.Gestion _gestionConfMetodoCalUtilidad;
        private Auditoria.Visualizar.Gestion _gestionAuditoria;
        private Configuracion.DepositoPreDeterminado.Gestion _gConfDepPredeterminado;


        //
        private Buscar.IListaSeleccion _gListaSelProv;
        private Buscar.INotificarSeleccion _gListaSelPrd;
        private FiltrosGen.IOpcion _gfiltroMarca;
        private FiltrosGen.IOpcion _gfiltroConcepto;
        private FiltrosGen.IOpcion _gfiltroEstatus;
        private FiltrosGen.IOpcion _gfiltroDepOrigen;
        private FiltrosGen.IOpcion _gfiltroDepDestino;
        private FiltrosGen.IBuscar _gFiltroBusPrd;
        private FiltrosGen.IBuscar _gFiltroBusProv;
        private FiltrosGen.IOpcion _gfiltroSucursal;
        private FiltrosGen.IOpcion _gfiltroTipoDoc;
        private FiltrosGen.IOpcion _gfiltroCategoria;
        private FiltrosGen.IOpcion _gfiltroOrigen;
        private FiltrosGen.IOpcion _gfiltroTasaIva;
        private FiltrosGen.IOpcion _gfiltroDivisa;
        private FiltrosGen.IOpcion _gfiltroPesado;
        private FiltrosGen.IOpcion _gfiltroOferta;
        private FiltrosGen.IOpcion _gfiltroExistencia;
        private FiltrosGen.IOpcion _gfiltroCatalogo;
        private FiltrosGen.IOpcion _gfiltroPrecioMay;
        private FiltrosGen.IOpcion _gfiltroDepart;
        private FiltrosGen.IOpcion _gfiltroGrupo;
        private FiltrosGen.IFecha _gfiltroDesde;
        private FiltrosGen.IFecha _gfiltroHasta;
        private FiltrosGen.IAdmDoc _gFiltroAdmDoc;
        private FiltrosGen.IAdmProducto _gFiltroAdmProducto;
        private FiltrosGen.IAdmSelecciona _gAdmSelPrd;
        private Administrador.IGestion _gAdmDoc;
        private IGestionRep _gestionReporteFiltros;
        private MovimientoInv.IMov _gMovAjusteInvCero;
        private MovimientoInv.AjusteInvCero.IItem _gItemAjusteInvCero; 
        private MovimientoInv.IGestionMov _gestionMovInv;
        //
        private SeguridadSist.ISeguridad _gSecurity;
        private SeguridadSist.Usuario.IModoUsuario _gSecurityModoUsuario;
        private SeguridadSist.NivelAcceso.IModoNivelAcceso _gSecurityNivelAcceso;


        public string Version { get { return "Ver. " + Application.ProductVersion; } }
        public string Host { get { return Sistema._Instancia + "/" + Sistema._BaseDatos; } }
        public string Usuario
        {
            get 
            { 
                var rt = ""; 
                rt = Sistema.UsuarioP.codigoUsu + Environment.NewLine + Sistema.UsuarioP.nombreUsu + Environment.NewLine + Sistema.UsuarioP.NombreGru; 
                return rt; 
            }
        }


        public GestionInv()
        {
            _gSecurity= new SeguridadSist.Gestion();
            _gSecurityModoUsuario = new SeguridadSist.Usuario.Gestion();
            _gSecurityNivelAcceso= new SeguridadSist.NivelAcceso.Gestion();
            //
            _gListaSelProv = new Proveedor.ListaSel.Gestion();
            _gListaSelPrd = new Producto.ListaSel.Gestion();
            _gfiltroMarca= new FiltrosGen.Opcion.Gestion();
            _gfiltroConcepto = new FiltrosGen.Opcion.Gestion();
            _gfiltroEstatus = new FiltrosGen.Opcion.Gestion();
            _gfiltroDepOrigen= new FiltrosGen.Opcion.Gestion();
            _gfiltroDepDestino = new FiltrosGen.Opcion.Gestion();
            _gFiltroBusPrd= new FiltrosGen.BuscarProducto.Gestion(_gListaSelPrd);
            _gFiltroBusProv = new FiltrosGen.BuscarProveedor.Gestion(_gListaSelProv);
            _gfiltroSucursal= new FiltrosGen.Opcion.Gestion();
            _gfiltroTipoDoc= new FiltrosGen.Opcion.Gestion();
            _gfiltroDesde = new FiltrosGen.Fecha.Gestion();
            _gfiltroHasta= new FiltrosGen.Fecha.Gestion();
            _gfiltroCategoria = new FiltrosGen.Opcion.Gestion();
            _gfiltroOrigen = new FiltrosGen.Opcion.Gestion();
            _gfiltroTasaIva= new FiltrosGen.Opcion.Gestion();
            _gfiltroEstatus= new FiltrosGen.Opcion.Gestion();
            _gfiltroDivisa= new FiltrosGen.Opcion.Gestion();
            _gfiltroPesado= new FiltrosGen.Opcion.Gestion();
            _gfiltroOferta= new FiltrosGen.Opcion.Gestion();
            _gfiltroExistencia= new FiltrosGen.Opcion.Gestion();
            _gfiltroCatalogo= new FiltrosGen.Opcion.Gestion();
            _gfiltroPrecioMay = new FiltrosGen.Opcion.Gestion();
            _gfiltroDepart= new FiltrosGen.Opcion.Gestion();
            _gfiltroGrupo= new FiltrosGen.Opcion.Gestion();
            _gFiltroAdmDoc = new FiltrosGen.AdmDoc.Gestion(_gfiltroConcepto, _gfiltroEstatus, _gfiltroDepOrigen,
                            _gfiltroDepDestino, _gFiltroBusPrd, _gfiltroSucursal, _gfiltroTipoDoc, 
                            _gfiltroDesde, _gfiltroHasta);
            _gFiltroAdmProducto = new FiltrosGen.AdmProducto.Gestion(_gfiltroMarca, _gFiltroBusProv, _gfiltroDepOrigen,
                            _gfiltroCategoria, _gfiltroOrigen, _gfiltroTasaIva, _gfiltroEstatus, _gfiltroDivisa, _gfiltroPesado,
                            _gfiltroOferta, _gfiltroExistencia, _gfiltroCatalogo, _gfiltroPrecioMay, _gfiltroDepart, _gfiltroGrupo);
            _gAdmDoc = new Administrador.Movimiento.Gestion(_gFiltroAdmDoc);
            _gAdmSelPrd = new FiltrosGen.AdmSelecciona.Gestion(_gFiltroAdmProducto, _gListaSelPrd);
            _gestionReporteFiltros = new FiltrosGen.Reportes.Gestion(_gFiltroBusPrd, _gfiltroDepOrigen, _gfiltroMarca,
                _gfiltroSucursal, _gfiltroDepart, _gfiltroDivisa, _gfiltroCategoria, _gfiltroTasaIva, _gfiltroEstatus,
                _gfiltroOrigen, _gfiltroGrupo, _gfiltroDesde, _gfiltroHasta);
            //
            _gItemAjusteInvCero = new MovimientoInv.AjusteInvCero.GestionItem();
            _gMovAjusteInvCero = new MovimientoInv.AjusteInvCero.Gestion(
                _gfiltroSucursal, 
                _gfiltroConcepto, 
                _gfiltroDepOrigen, 
                _gItemAjusteInvCero,
                _gSecurity);
            _gestionMovInv = new MovimientoInv.GestionMov();
            //
            _seguridad = new Helpers.Seguridad(_gSecurityNivelAcceso, _gSecurity);
 

            _gestionMaestro = new Maestros.Gestion();
            _gestionBusqueda = new Buscar.Gestion(_gFiltroAdmProducto);
            _gestionMov = new Movimiento.Gestion(_gAdmSelPrd);
            _gestionVisorExistencia = new Visor.Existencia.Gestion();
            _gestionVisorCostoEdad = new Visor.CostoEdad.Gestion();
            _gestionVisorTraslado = new Visor.Traslado.Gestion();
            _gestionVisorAjuste = new Visor.Ajuste.Gestion();
            _gestionVisorCostoExistencia = new Visor.CostoExistencia.Gestion();
            _gestionVisorPrecio = new Visor.Precio.Gestion();
            _gestionAdmMov = new Administrador.Gestion();


            _gestionConfCostoEdad = new Configuracion.CostoEdad.Gestion();
            _gestionConfRedondeoPrecio = new Configuracion.RedondeoPrecio.Gestion();
            _gestionConfRegistroPrecio = new Configuracion.RegistroPrecio.Gestion();
            _gestionConfBusquedaPred = new Configuracion.BusquedaPredeterminada.Gestion();
            _gestionConfMetodoCalUtilidad = new Configuracion.MetodoCalculoUtilidad.Gestion();
            _gestionAuditoria = new Auditoria.Visualizar.Gestion();
            _gConfDepPredeterminado = new Configuracion.DepositoPreDeterminado.Gestion();
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
            if (_seguridad.Verificar(r00.Entidad))
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
            _gestionBusqueda.Inicializa();
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

            if (_seguridad.Verificar(r00.Entidad))
            {
                var ctr = new Movimiento.Cargo.Gestion();
                ctr.Inicializa();

                _gestionMov.Inicializa();
                _gestionMov.setGestion(ctr);
                _gestionMov.Inicia();
                _gestionMov.Finaliza();
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

            if (_seguridad.Verificar(r00.Entidad))
            {
                var ctr = new Movimiento.Descargo.Gestion();
                ctr.Inicializa();

                _gestionMov.Inicializa();
                _gestionMov.setGestion(ctr);
                _gestionMov.Inicia();
                _gestionMov.Finaliza();
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
            if (_seguridad.Verificar(r00.Entidad))
            {
                var ctr = new Movimiento.Traslado.Gestion();
                ctr.Inicializa();

                _gestionMov.Inicializa();
                _gestionMov.setGestion(ctr);
                _gestionMov.Inicia();
                _gestionMov.Finaliza();
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

            if (_seguridad.Verificar(r00.Entidad))
            {
                var ctr = new Movimiento.TrasladoEntreSucursal.Gestion(_gAdmSelPrd);
                ctr.Inicializa();

                _gestionMov.Inicializa();
                _gestionMov.setGestion(ctr);
                _gestionMov.Inicia2();
                _gestionMov.Finaliza();
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
            if (_seguridad.Verificar(r00.Entidad))
            {
                var ctr = new Movimiento.Ajuste.Gestion();
                ctr.Inicializa();

                _gestionMov.Inicializa();
                _gestionMov.setGestion(ctr);
                _gestionMov.Inicia();
                _gestionMov.Finaliza();
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

            if (_seguridad.Verificar(r00.Entidad))
            {
                _gAdmDoc.Inicializa();
                _gestionAdmMov.setGestion(_gAdmDoc);
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
            _gestionReporteFiltros.Inicializa();
            _gestionReporteFiltros.setValidarData(false);
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.MaestroProducto.Filtros());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.FiltrosIsOK) 
            {
                var rp = new Reportes.Filtros.MaestroProducto.GestionRep();
                rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                rp.Generar();
            }
        }

        public void ReporteMaestroInventario()
        {
            _gestionReporteFiltros.Inicializa();
            _gestionReporteFiltros.setValidarData(false);
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.MaestroInventario.Filtros());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.FiltrosIsOK)
            {
                var rp = new Reportes.Filtros.MaestroInventario.GestionRep();
                rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
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
            _gestionReporteFiltros.Inicializa();
            _gestionReporteFiltros.setValidarData(false);
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.MaestroExistencia.Filtros());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.FiltrosIsOK)
            {
                var rp = new Reportes.Filtros.MaestroExistencia.GestionRep();
                rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                rp.Generar();
            }
        }

        public void ReporteMaestroPrecio()
        {
            _gestionReporteFiltros.Inicializa();
            _gestionReporteFiltros.setValidarData(false);
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.MaestroPrecio.Filtros());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.FiltrosIsOK)
            {
                var rp = new Reportes.Filtros.MaestroPrecio.GestionRep();
                rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                rp.Generar();
            }
        }

        public void Kardex()
        {
            _gestionReporteFiltros.Inicializa();
            _gestionReporteFiltros.setValidarData(true);
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.Kardex.Filtros());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.FiltrosIsOK)
            {
                var rp = new Reportes.Filtros.Kardex.GestionRep();
                rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                rp.Generar();
            }
        }

        public void ReporteRelacionCompraVenta()
        {
            _gestionReporteFiltros.Inicializa();
            _gestionReporteFiltros.setValidarData(false);
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.RelacionCompraVenta.Filtros());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.FiltrosIsOK)
            {
                if (_gestionReporteFiltros.dataFiltrar.Producto ==null)
                {
                    Helpers.Msg.Error("Parametros Incorrectos, Verifique Por Favor");
                    return;
                }
                var rp = new Reportes.Filtros.RelacionCompraVenta.GestionRep();
                rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                rp.Generar();
            }
        }

        public void ReporteMaestroDepositoResumen()
        {
            var rp = new Reportes.Filtros.DepositoResumen.GestionRep();
            rp.Generar();
        }

        public void MaestroNivelMinimo()
        {
            _gestionReporteFiltros.Inicializa();
            _gestionReporteFiltros.setValidarData(false);
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.NivelMInimo.Filtro());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.FiltrosIsOK)
            {
                var rp = new Reportes.Filtros.NivelMInimo.GestionRep();
                rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
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
            if (_seguridad.Verificar(r00.Entidad))
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
            if (_seguridad.Verificar(r00.Entidad))
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
            if (_seguridad.Verificar(r00.Entidad))
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
            if (_seguridad.Verificar(r00.Entidad))
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
            if (_seguridad.Verificar(r00.Entidad))
            {
                _gestionConfMetodoCalUtilidad.Inicializa();
                _gestionConfMetodoCalUtilidad.Inicia();
            }
        }

        public void ReporteValorizacionInventario()
        {
            _gestionReporteFiltros.Inicializa();
            _gestionReporteFiltros.setValidarData(true);
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.Valorizacion.Filtros());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.FiltrosIsOK)
            {
                if (_gestionReporteFiltros.dataFiltrar.Deposito== null)
                {
                    Helpers.Msg.Error("Parametro [ DEPOSITO ] Incorrectos, Verifique Por Favor");
                    return;
                }

                var rp = new Reportes.Filtros.Valorizacion.GestionRep();
                rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
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
            if (_seguridad.Verificar(r00.Entidad))
            {
                var ctr= new Movimiento.TrasladoDevolucion.Gestion();
                ctr.Inicializa();
                ctr.setConcepto("0000000034");

                _gestionMov.Inicializa();
                _gestionMov.setGestion(ctr);
                _gestionMov.setHabilitarConcepto(false);
                _gestionMov.Inicia();
                _gestionMov.Finaliza();
            }
        }

        public void VisorPrecios()
        {
            _gestionVisorPrecio.Inicializa();
            _gestionVisorPrecio.Inicia();
        }

        public void Kardex_Resumen_Mov()
        {
            _gestionReporteFiltros.Inicializa();
            _gestionReporteFiltros.setValidarData(true);
            _gestionReporteFiltros.setGestion(new Reportes.Filtros.Kardex.Filtros());
            _gestionReporteFiltros.Inicia();
            if (_gestionReporteFiltros.FiltrosIsOK)
            {
                if (_gestionReporteFiltros.dataFiltrar.Producto==null)
                {
                    Helpers.Msg.Error("Parametro [ PRODUCTO ] Incorrectos, Verifique Por Favor");
                    return;
                }
                var rp = new Reportes.Filtros.KardexResumen.GestionRep();
                rp.setFiltros(_gestionReporteFiltros.dataFiltrar);
                rp.Generar();
            }
        }

        public void Conf_DepositosPreDeterminadosRegistrar()
        {
            var r00 = Sistema.MyData.Permiso_ConfiguracionSistema(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (_seguridad.Verificar(r00.Entidad))
            {
                _gConfDepPredeterminado.Inicializa();
                _gConfDepPredeterminado.Inicia();
            }
        }

        public void AjusteInvCero()
        {
            var r00 = Sistema.MyData.Permiso_MovimientoAjusteInventarioCero(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (_seguridad.Verificar(r00.Entidad))
            {
                // POR USUARIO
                _gSecurityModoUsuario.Inicializa();
                _gSecurityModoUsuario.setUsuarioValidar(SeguridadSist.Usuario.enumerados.enumTipo.Administrador);

                //
                _gMovAjusteInvCero.Inicializa();
                _gMovAjusteInvCero.setModoSeguridad(_gSecurityModoUsuario);

                _gestionMovInv.Inicializa();
                _gestionMovInv.setGestion(_gMovAjusteInvCero);
                _gestionMovInv.Inicia();
                _gestionMovInv.Finaliza();
            }
        }

    }

}