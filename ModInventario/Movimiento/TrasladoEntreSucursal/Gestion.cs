using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Movimiento.TrasladoEntreSucursal
{
    
    public class Gestion: IGestion
    {

        private Producto.Busqueda.Gestion _gestionBusquedaPrd;
        private Producto.Lista.Gestion _gestionListaPrd;
        private Producto.Deposito.Listar.Gestion _gestionExistencia;
        private Analisis.General.Gestion _gestionAnalisisGeneral;
        private Analisis.Detallado.Gestion _gestionAnalisisDetallado;
        private Analisis.Existencia.Gestion _gestionAnalisisExistencia;
        private List<OOB.LibInventario.Concepto.Ficha> lConcepto;
        private List<OOB.LibInventario.Sucursal.Ficha> lSucOrigen;
        private List<OOB.LibInventario.Sucursal.Ficha> lSucDestino;
        private List<OOB.LibInventario.Departamento.Ficha> lDepartamento;
        private BindingSource bsConcepto;
        private BindingSource bsSucOrigen;
        private BindingSource bsSucDestino;
        private BindingSource bsDepartamento;
        private Movimiento.data miData;
        private GestionDetalle _gestionDetalle;
        private decimal tasaCambio;
        private bool isCerrarOk;
        private OOB.LibInventario.Sucursal.Ficha sucOrigen;
        private OOB.LibInventario.Sucursal.Ficha sucDestino;
        private OOB.LibInventario.Departamento.Ficha _departamento;


        public bool IsCerrarOk { get { return isCerrarOk; } }
        public string TipoMovimiento { get {return "TRASLADO";} }
        public decimal MontoMovimiento { get { return _gestionDetalle.MontoMovimiento; } }
        public string ItemsMovimiento  { get { return _gestionDetalle.ItemsMovimiento; } }
        public bool Habilitar_DepDestino { get { return true; } }
        public bool VisualizarColumnaTipoMovimiento { get { return false; } }
        public BindingSource ConceptoSource { get { return bsConcepto; } }
        public BindingSource SucursalSource { get { return null; } }
        public BindingSource DepOrigenSource { get { return bsSucOrigen; } }
        public BindingSource DepDestinoSource { get { return bsSucDestino; } }
        public BindingSource DepartamentoSource { get { return bsDepartamento; } }
        public string IdSucursal { get { return miData.IdSucursal; } set { miData.IdSucursal = value; } }
        public string IdConcepto { get { return miData.IdConcepto; } set { miData.IdConcepto = value; } }
        public string IdDepOrigen
        { 
            get { return miData.IdDepOrigen; } 
            set { miData.IdDepOrigen = value;  }
        } 
        public string IdDepDestino 
        { 
            get { return miData.IdDepDestino; }
            set { miData.IdDepDestino = value; }
        }
        public string AutorizadoPor { get { return miData.AutorizadoPor; } set { miData.AutorizadoPor = value; } }
        public string Motivo { get { return miData.Motivo; } set { miData.Motivo = value; } }
        public DateTime FechaMov { get { return miData.Fecha; } set { miData.Fecha = value; } }
        public OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda MetodoBusqueda { get { return _gestionBusquedaPrd.Metodo; } set { _gestionBusquedaPrd.Metodo = value; } }
        public string CadenaBusqueda { get { return _gestionBusquedaPrd.CadenaBusqueda; } set { _gestionBusquedaPrd.CadenaBusqueda = value; } }
        public bool CargarDetallesIsOk { get; set; }
        

        public Gestion()
        {
            _gestionDetalle = new GestionDetalle();
            _gestionBusquedaPrd = new Producto.Busqueda.Gestion();
            _gestionListaPrd = new Producto.Lista.Gestion();
            _gestionListaPrd.ItemSeleccionadoOk+=_gestionListaPrd_ItemSeleccionadoOk;
            _gestionExistencia = new Producto.Deposito.Listar.Gestion();
            _gestionAnalisisGeneral = new Analisis.General.Gestion();
            _gestionAnalisisGeneral.ItemSeleccionado+=_gestionAnalisisGeneral_ItemSeleccionado;
            _gestionAnalisisDetallado = new Analisis.Detallado.Gestion();
            _gestionAnalisisExistencia = new Analisis.Existencia.Gestion();
            miData = new Movimiento.data();

            lConcepto = new List<OOB.LibInventario.Concepto.Ficha>();
            lSucOrigen = new List<OOB.LibInventario.Sucursal.Ficha>();
            lSucDestino = new List<OOB.LibInventario.Sucursal.Ficha>();
            lDepartamento = new List<OOB.LibInventario.Departamento.Ficha>();
            bsConcepto = new BindingSource();
            bsSucOrigen = new BindingSource();
            bsSucDestino = new BindingSource();
            bsDepartamento = new BindingSource();
            bsConcepto.DataSource = lConcepto;
            bsSucOrigen.DataSource = lSucOrigen;
            bsSucDestino.DataSource = lSucDestino;
            bsDepartamento.DataSource = lDepartamento;
        }

        private void _gestionAnalisisGeneral_ItemSeleccionado(object sender, EventArgs e)
        {
            var item = _gestionAnalisisGeneral.Item;
            _gestionDetalle.AgregarItem(item, sucOrigen.autoDepositoPrincipal);
        }

        private void _gestionListaPrd_ItemSeleccionadoOk(object sender, EventArgs e)
        {
            if (_gestionListaPrd.ItemSeleccionado.Estatus == OOB.LibInventario.Producto.Enumerados.EnumEstatus.Inactivo)
            {
                Helpers.Msg.Error("PRODUCTO EN ESTADO INACTIVO");
                return;
            }
            else
            {
                if (sucOrigen==null)
                {
                    Helpers.Msg.Error("DEPOSITO [ ORIGEN ] NO DEFINIDO");
                    return;
                }
                _gestionDetalle.AgregarItem(_gestionListaPrd.ItemSeleccionado.FichaPrd, sucOrigen.autoDepositoPrincipal);
            }
        }


        MovimientoFrm frm;
        public void Inicia()
        {
            Limpiar();
            _gestionBusquedaPrd.Inicia();
            if (CargarData())
            {
                frm = new MovimientoFrm();
                frm.setControlador(this);
                frm.Show();
            }
        }

        public bool CargarData()
        {
            var rt = true;

            var rt1 = Sistema.MyData.Sucursal_GetLista();
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return false;
            }
            var rt2 = Sistema.MyData.Concepto_GetLista() ;
            if (rt2.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt2.Mensaje);
                return false;
            }
            var rt4 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (rt4.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt4.Mensaje);
                return false;
            }
            var rt5 = Sistema.MyData.Departamento_GetLista();
            if (rt5.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt5.Mensaje);
                return false;
            }

            tasaCambio = rt4.Entidad;
            _gestionDetalle.setTasaCambio(tasaCambio);

            lConcepto.Clear();
            lConcepto.AddRange(rt2.Lista.OrderBy(o=>o.nombre).ToList());
            bsConcepto.CurrencyManager.Refresh();

            lSucOrigen.Clear();
            lSucOrigen.AddRange(rt1.Lista.OrderBy(o=>o.nombre).ToList());
            bsSucOrigen.CurrencyManager.Refresh();

            lSucDestino.Clear();
            lSucDestino.AddRange(rt1.Lista.OrderBy(o=>o.nombre).ToList());
            bsSucDestino.CurrencyManager.Refresh();

            lDepartamento.Clear();
            lDepartamento.AddRange(rt5.Lista.OrderBy(o => o.nombre).ToList());
            bsDepartamento.CurrencyManager.Refresh();

            return rt;
        }

        public void Limpiar()
        {
            CargarDetallesIsOk = false;
            isCerrarOk = false;
            miData.Limpiar();
            _gestionDetalle.Limpiar();
            _departamento = null;
        }

        public bool LimpiarVistaIsOk()
        {
            var rt = true;

            var msg = MessageBox.Show("Limpiar Cambios Realizados ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.No) { return false; }

            Limpiar();

            return rt;
        }

        public void BuscarProducto()
        {
            _gestionBusquedaPrd.Buscar();
            if (_gestionBusquedaPrd.IsOk)
            {
                _gestionListaPrd.setLista(_gestionBusquedaPrd.Resultado);
                _gestionListaPrd.Inicia();
            }
        }

        public void EliminarItem()
        {
            _gestionDetalle.EliminarItem();
        }

        public void EditarItem()
        {
            _gestionDetalle.EditarItem(IdDepOrigen);
        }

        public void Procesar()
        {
            miData.detalle = _gestionDetalle.Detalle;
            IdConcepto = "0000000008";
            if (miData.Verificar())
            {
                if (IdDepOrigen == "")
                {
                    Helpers.Msg.Error("[ Sucursal Origen ] No Seleccionada");
                    return;
                }
                if (IdDepDestino== "")
                {
                    Helpers.Msg.Error("[ Sucursal Destino ] No Seleccionada");
                    return;
                }

                var msg = MessageBox.Show("Procesar Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.No)
                    return;

                if (!RegistrarDocumento()) 
                {
                    return;
                }

                Helpers.Msg.AgregarOk();
                isCerrarOk = true;
            }
        }

        private bool RegistrarDocumento()
        {
            var concepto = lConcepto.FirstOrDefault(m => m.auto == miData.IdConcepto);
            var ficha = new OOB.LibInventario.Movimiento.Traslado.Insertar.Ficha()
            {
                autoConcepto = miData.IdConcepto,
                autoDepositoDestino = sucDestino.autoDepositoPrincipal,
                autoDepositoOrigen = sucOrigen.autoDepositoPrincipal,
                autoRemision = "",
                autorizado = miData.AutorizadoPor,
                autoUsuario = Sistema.UsuarioP.autoUsu,
                cierreFtp = "",
                codConcepto = concepto.codigo,
                codDepositoDestino = sucDestino.codigoDepositoPrincipal,
                codDepositoOrigen = sucOrigen.codigoDepositoPrincipal,
                codigoSucursal = sucOrigen.codigo,
                codUsuario = Sistema.UsuarioP.codigoUsu,
                desConcepto = concepto.nombre,
                desDepositoDestino = sucDestino.nombreDepositoPrincipal,
                desDepositoOrigen = sucOrigen.nombreDepositoPrincipal,
                documentoNombre = "TRANSFERENCIA",
                estacion = Environment.MachineName,
                estatusAnulado = "0",
                estatusCierreContable = "0",
                nota = miData.Motivo,
                renglones = _gestionDetalle.TotalItems,
                situacion = "Procesado",
                tipo = "03",
                total = MontoMovimiento,
                usuario = Sistema.UsuarioP.nombreUsu,
                factorCambio = tasaCambio,
                montoDivisa = Math.Round(MontoMovimiento / tasaCambio, 2, MidpointRounding.AwayFromZero),
            };

            var detalles = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaDetalle()
                {
                    autoDepartamento = s.FichaPrd.identidad.autoDepartamento,
                    autoGrupo = s.FichaPrd.identidad.autoGrupo,
                    autoProducto = s.FichaPrd.AutoId,
                    cantidad = s.Cantidad,
                    cantidadBono = 0,
                    cantidadUnd = s.CantidadUnd,
                    categoria = s.FichaPrd.Categoria,
                    codigoProducto = s.FichaPrd.CodigoPrd,
                    contEmpaque = s.FichaPrd.identidad.contenidoCompra,
                    costoCompra = s.CostoMonedaLocal,
                    costoUnd = s.CostoUndMonedaLocal,
                    decimales = s.FichaPrd.Decimales,
                    empaque = s.FichaPrd.identidad.empaqueCompra,
                    estatusAnulado = "0",
                    estatusUnidad = s.TipoEmpaqueSeleccionado == enumerados.enumTipoEmpaque.PorUnidad ? "1" : "0",
                    nombreProducto = s.DescripcionPrd,
                    signo = 1,
                    tipo = "03",
                    total = s.ImporteMonedaLocal,
                };
                return rg;
            }).ToList();
            ficha.detalles = detalles;

            var lDep = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaPrdDeposito()
                {
                    autoDepositoOrigen = sucOrigen.autoDepositoPrincipal,
                    nombreProducto = s.DescripcionPrd,
                    autoDepositoDestino = sucDestino.autoDepositoPrincipal,
                    autoProducto = s.FichaPrd.AutoId,
                    cantidadUnd = s.CantidadUnd,
                };
                return rg;
            }).ToList();
            ficha.prdDeposito = lDep;

            var lKardexS = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaKardex()
                {
                    autoConcepto = concepto.auto,
                    autoDeposito = sucOrigen.autoDepositoPrincipal ,
                    autoProducto = s.FichaPrd.AutoId,
                    cantidad = s.Cantidad,
                    cantidadBono = 0.0m,
                    cantidadUnd = s.CantidadUnd,
                    codigoMov = "03",
                    codigoConcepto = concepto.codigo,
                    codigoDeposito = sucOrigen.codigoDepositoPrincipal,
                    codigoSucursal = sucOrigen.codigo,
                    costoUnd = s.CostoUndMonedaLocal,
                    entidad = "",
                    estatusAnulado = "0",
                    modulo = "Inventario",
                    nombreConcepto = concepto.nombre,
                    nombreDeposito = sucOrigen.nombreDepositoPrincipal ,
                    nota = "",
                    precioUnd = 0.0m,
                    siglasMov = "TRA",
                    signoMov = -1,
                    total = s.ImporteMonedaLocal,
                };
                return rg;
            }).ToList();

            var lKardexE = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaKardex()
                {
                    autoConcepto = concepto.auto,
                    autoDeposito = sucDestino.autoDepositoPrincipal ,
                    autoProducto = s.FichaPrd.AutoId,
                    cantidad = s.Cantidad,
                    cantidadBono = 0.0m,
                    cantidadUnd = s.CantidadUnd,
                    codigoMov = "03",
                    codigoConcepto = concepto.codigo,
                    codigoDeposito = sucDestino.codigoDepositoPrincipal ,
                    codigoSucursal = sucOrigen.codigo,
                    costoUnd = s.CostoUndMonedaLocal,
                    entidad = "",
                    estatusAnulado = "0",
                    modulo = "Inventario",
                    nombreConcepto = concepto.nombre,
                    nombreDeposito = sucDestino.nombreDepositoPrincipal ,
                    nota = "",
                    precioUnd = 0.0m,
                    siglasMov = "TRA",
                    signoMov = 1,
                    total = s.ImporteMonedaLocal,
                };
                return rg;
            }).ToList();
            ficha.movKardex = lKardexS.Union(lKardexE).ToList();

            var r01 = Sistema.MyData.Producto_Movimiento_Traslado_Insertar(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            Helpers.VisualizarDocumento.CargarVisualizarDocumento(r01.Auto);

            return true;
        }

        public bool AbandonarDocumento()
        {
            var msg = MessageBox.Show("Abandonar Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            return (msg == DialogResult.Yes);
        }

        public enumerados.enumTipoMovimiento EnumTipoMovimiento
        {
            get { return  enumerados.enumTipoMovimiento.Traslado; }
        }

        public void BuscarData()
        {
            CargarDetallesIsOk = false;
            if (_gestionDetalle.TotalItems > 0)
                return;
            if (sucOrigen == null)
            {
                Helpers.Msg.Error("FALTA POR SELECCIONAR [ Sucursal Origen ]");
                return;
            }
            if (sucDestino== null)
            {
                Helpers.Msg.Error("FALTA POR SELECCIONAR [ Sucursal Destino ]");
                return;
            }
            if (IdDepOrigen=="")
            {
                return;
            }
            if (IdDepDestino== "")
            {
                return;
            }
            if (sucOrigen.autoDepositoPrincipal == "")
            {
                Helpers.Msg.Error("SUCURSAL ORIGEN NO POSEE DEPOSITO PRINCIPAL ASIGNADO");
                return;
            }
            if (sucDestino.autoDepositoPrincipal == "")
            {
                Helpers.Msg.Error("SUCURSAL DESTINO NO POSEE DEPOSITO PRINCIPAL ASIGNADO");
                return;
            }
            if (sucDestino.auto == sucOrigen.auto)
            {
                Helpers.Msg.Error("SUCURSAL DESTINO NO PUEDE SER IGUAL A LA SUCURSAL ORIGEN");
                return;
            }

            //var filtro = new OOB.LibInventario.Movimiento.Traslado.Consultar.Filtro();
            //filtro.autoDeposito = sucDestino.autoDepositoPrincipal;
            //if (_departamento != null)
            //{
            //    filtro.autoDepartamento = _departamento.auto;
            //}
            //var rt3 = Sistema.MyData.Producto_Movimiento_Traslado_Consultar_ProductosPorDebajoNivelMinimo(filtro);
            //if (rt3.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(rt3.Mensaje);
            //    return;
            //}
            //_gestionDetalle.AgregarItem(rt3.Lista, sucOrigen.autoDepositoPrincipal);

            var filtro = new OOB.LibInventario.Movimiento.Traslado.Capturar.ProductoPorDebajoNivelMinimo.Filtro();
            filtro.autoDepositoVerificarNivel= sucDestino.autoDepositoPrincipal;
            filtro.autoDepositoOrigen = sucOrigen.autoDepositoPrincipal;
            if (_departamento != null)
            {
                filtro.autoDepartamento = _departamento.auto;
            }
            var rt3 = Sistema.MyData.Capturar_ProductosPorDebajoNivelMinimo(filtro);
            if (rt3.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt3.Mensaje);
                return;
            }
            _gestionDetalle.AgregarItem(rt3.Lista, sucOrigen.autoDepositoPrincipal);

            CargarDetallesIsOk = true;
        }


        public BindingSource DetalleSouce
        {
            get { return _gestionDetalle.Souce; } 
        }

        public void setFiltros(Buscar.Filtrar.data data)
        {
        }

        public void EliminarItemsNoDisponible()
        {
            _gestionDetalle.EliminarItemsNoDisponible(); 
        }

        public void ActualizarConceptos()
        {
            var rt1 = Sistema.MyData.Concepto_GetLista();
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return;
            }
            lConcepto.Clear();
            lConcepto.AddRange(rt1.Lista);
            bsConcepto.CurrencyManager.Refresh();
        }

        public void setSucursalOrigen(string idSuc)
        {
            sucOrigen = null;
            IdDepOrigen = "";
            if (idSuc != "")
            {
                var r01 = Sistema.MyData.Sucursal_GetFicha(idSuc);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                sucOrigen = r01.Entidad;
                IdDepOrigen = sucOrigen.autoDepositoPrincipal;
            }
        }

        public void setSucursalDestino(string idSuc)
        {
            sucDestino= null;
            IdDepDestino= "";
            if (idSuc != "")
            {
                var r01 = Sistema.MyData.Sucursal_GetFicha(idSuc);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                sucDestino= r01.Entidad;
                IdDepDestino= sucDestino.autoDepositoPrincipal;
            }
        }

        public void setDepartamento(string idDepart)
        {
            _departamento = lDepartamento.FirstOrDefault(s => s.auto == idDepart);
        }


        public void VerExistencia()
        {
            if (_gestionDetalle.ItemActual != null)
            {
                _gestionExistencia.setFicha(_gestionDetalle.ItemActual.FichaPrd.AutoId);
                _gestionExistencia.Inicia();
            }
        }

        public void EliminarItemsExistenciaDepositoCero()
        {
            _gestionDetalle.EliminarItemsExistenciaDepositoCero(); 
        }

        public void AnalisisProductos()
        {
            if (sucDestino == null)
                return;

            _gestionAnalisisGeneral.Inicializar();
            _gestionAnalisisGeneral.setDeposito(sucDestino.autoDepositoPrincipal);
            _gestionAnalisisGeneral.setUltimosXDias(15);
            _gestionAnalisisGeneral.setModulo(Analisis.General.EnumModulo.Ventas);
            _gestionAnalisisGeneral.Inicia();
        }

        public void AnalisisDetallado()
        {
            if (_gestionDetalle.ItemActual == null)
                return;

            _gestionAnalisisDetallado.Inicializar();
            _gestionAnalisisDetallado.setDeposito(sucDestino.autoDepositoPrincipal);
            _gestionAnalisisDetallado.setProducto(_gestionDetalle.ItemActual.FichaPrd.AutoId);
            _gestionAnalisisDetallado.setUltimosXDias(15);
            _gestionAnalisisDetallado.setModulo(Analisis.Detallado.EnumModulo.Ventas);
            _gestionAnalisisDetallado.Inicia();
        }

        public void VerExistenciaDeposito()
        {
            if (sucDestino != null)
            {
                _gestionAnalisisExistencia.Inicializa();
                _gestionAnalisisExistencia.setDeposito(sucDestino.autoDepositoPrincipal);
                _gestionAnalisisExistencia.Inicia();
            }
        }

        public void setHabilitarConcepto(bool p)
        {
        }

        public bool HabilitarConcepto
        {
            get { return false; }
        }

        public void Inicializa()
        {
            _departamento = null;
        }

    }

}