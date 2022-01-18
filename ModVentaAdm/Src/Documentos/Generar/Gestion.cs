using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Documentos.Generar
{

    public class Gestion
    {


        private IDocGestion _docGestion;
        private DatosDocumento.Gestion _datosDocGestion;
        private BuscarProducto.Gestion _busqProducto;
        private Cliente.Visualizar.Gestion _visualCliente;
        private Cliente.Documentos.Gestion _visualClienteDoc;
        private Cliente.Articulos.Gestion _visualClienteArticulos;
        private AgregarEditarItem.Gestion _agregarEditarItem;
        private Pendiente.Gestion _pendienteGestion;
        private Items.Gestion _items;
        private enumerados.BusqPrd _prefBusqPrd;
        private int _idVentaTemporal;
        private bool _abandonarDocIsOk;
        private bool _rupturaPorExistencia;
        private List<tipoDocRemitir> _ltipoDocRemitir;
        private BindingSource _bsTipoDocRemitir;
        private CambioTasa.Gestion _gCambioTasa;
        private bool _documentoProcesadoIsOk;


        public string TipoDocumento { get { return _docGestion.TipoDocumento; } }
        public string CntItem { get { return _items.CntItem.ToString(); } }
        public decimal TasaDivisa { get { return _docGestion.TasaDivisa; } }
        public decimal Monto { get { return _items.MontoTotal; } }
        public decimal MontoDivisa { get { return _items.MontoTotalDivisa; } }
        public decimal MontoNeto { get { return _items.MontoNeto; } }
        public decimal MontoIva { get { return _items.MontoIva; } }
        public string RifCliente { get { return _datosDocGestion.ClienteRif; } }
        public string CodigoCliente { get { return _datosDocGestion.ClienteCodigo; } }
        public string Cliente { get { return _datosDocGestion.ClienteRazonSocialDireccion; } }
        public BindingSource ItemsSource { get { return _items.ItemsSource; } }
        public enumerados.BusqPrd PrefBusqProducto { get { return _prefBusqPrd; } }
        public string DatosDoc_Fecha { get { return _datosDocGestion.DataFecha; } }
        public string DatosDoc_CondPago { get { return _datosDocGestion.DataCondPago; } }
        public string DatosDoc_Deposito { get { return _datosDocGestion.DataDeposito; } }
        public string DatosDoc_FechaVence { get { return _datosDocGestion.DataFechaVence; } }
        public string DatosDoc_OrdenCompra { get { return _datosDocGestion.DataOrdenCompra; } }
        public string DatosDoc_Pedido { get { return _datosDocGestion.DataPedido; } }
        public string DatosDoc_Serie { get { return ""; } }
        public string DatosDoc_Sucursal { get { return _datosDocGestion.DataSucursal; } }
        public string DatosDoc_Notas { get { return _datosDocGestion.DataNotasDoc; } }
        public OOB.Sistema.TipoDocumento.Entidad.Ficha SistTipoDocumento { get { return _docGestion.SistTipoDocumento; } }
        public bool AbandonarDocIsOk { get { return _abandonarDocIsOk; } }
        public int CantDocPend { get { return _docGestion.CantDocPend; } }
        public int CantDocRecuperar { get { return _docGestion.CantDocRecuperar; } }
        public BindingSource RemisionSource { get { return _bsTipoDocRemitir; } }
        //
        public bool DocumentoProcesadoIsOk { get { return _documentoProcesadoIsOk; } }


        public Gestion()
        {
            _ltipoDocRemitir = new List<tipoDocRemitir>();
            _bsTipoDocRemitir = new BindingSource();
            _bsTipoDocRemitir.DataSource = _ltipoDocRemitir;

            _items = new Items.Gestion();
            _prefBusqPrd = enumerados.BusqPrd.SnDefinir;
            _datosDocGestion = new DatosDocumento.Gestion();
            _visualCliente = new Cliente.Visualizar.Gestion();
            _visualClienteDoc = new Cliente.Documentos.Gestion();
            _visualClienteArticulos = new Cliente.Articulos.Gestion();
            _busqProducto = new BuscarProducto.Gestion();
            _agregarEditarItem = new AgregarEditarItem.Gestion();
            _pendienteGestion = new Pendiente.Gestion();
            _idVentaTemporal = -1;
            _abandonarDocIsOk = false;
            _rupturaPorExistencia = false;
            _gCambioTasa = new CambioTasa.Gestion();
        }


        public void Inicializa()
        {
            _prefBusqPrd = enumerados.BusqPrd.SnDefinir;
            _datosDocGestion.Inicializa();
            _docGestion.Inicializa();
            _items.Inicializa();
            _busqProducto.Inicializa();
            _idVentaTemporal = -1;
            _abandonarDocIsOk = false;
            _rupturaPorExistencia = false;
            _documentoProcesadoIsOk = false;
        }

        private DocGenerarFrm _frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (_docGestion.CargarData())
                {
                    _ltipoDocRemitir.Clear();
                    _ltipoDocRemitir = _docGestion.TipoDocRemitir.Select(s =>
                    {
                        var nr2 = new tipoDocRemitir(s.id, s.descripcion);
                        return nr2;
                    }).ToList(); ;
                    _bsTipoDocRemitir.DataSource = _ltipoDocRemitir;
                    _bsTipoDocRemitir.CurrencyManager.Refresh();

                    _items.setDivisa(TasaDivisa);

                    if (_frm == null)
                    {
                        _frm = new DocGenerarFrm();
                        _frm.setControlador(this);
                    }
                    _frm.ShowDialog();
                }
            }
        }

        private bool CargarData()
        {
            var r01 = Sistema.MyData.Configuracion_BusquedaPreferenciaProducto();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var r02 = Sistema.MyData.Configuracion_RupturaPorExistencia();
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _rupturaPorExistencia = r02.Entidad;

            _prefBusqPrd = (enumerados.BusqPrd)r01.Entidad;
            switch (_prefBusqPrd)
            {
                case enumerados.BusqPrd.Codigo:
                    ActivarBusPorCodigo();
                    break;
                case enumerados.BusqPrd.Nombre:
                    ActivarBusPorDescripcion();
                    break;
                case enumerados.BusqPrd.Referencia:
                    ActivarBusPorReferencia();
                    break;
            }

            return true;
        }

        public void setDocGestion(IDocGestion doc)
        {
            _docGestion = doc;
        }

        public void NuevoDocumento()
        {
            if (_datosDocGestion.AceptarDatosIsOK)
            {
                return;
            }
            _documentoProcesadoIsOk = false;
            _datosDocGestion.Inicializa();
            _datosDocGestion.setHabilitarSucursal(!_items.HayItemsEnBandeja);
            _datosDocGestion.setHabilitarDeposito(!_items.HayItemsEnBandeja);
            _datosDocGestion.setHabilitarBusquedaCliente(!_items.HayItemsEnBandeja);
            _datosDocGestion.setHabilitarDatosDoc(_docGestion.HabilitarDatosDoc);
            _datosDocGestion.setTipoDocumento(SistTipoDocumento);
            _datosDocGestion.setIsModoRegistrar(true);
            _datosDocGestion.setFactorDivisa(TasaDivisa);
            _datosDocGestion.setIdEquipo(Sistema.IdEquipo);
            _datosDocGestion.Inicia();
            if (_datosDocGestion.AceptarDatosIsOK)
            {
                _idVentaTemporal = _datosDocGestion.IdRegDocTemporal;
            }
        }

        public void EditarDatosDocumento()
        {
            if (!_datosDocGestion.AceptarDatosIsOK)
            {
                return;
            }
            _datosDocGestion.setHabilitarSucursal(!_items.HayItemsEnBandeja);
            _datosDocGestion.setHabilitarDeposito(!_items.HayItemsEnBandeja);
            _datosDocGestion.setHabilitarBusquedaCliente(!_items.HayItemsEnBandeja);
            _datosDocGestion.setHabilitarDatosDoc(_docGestion.HabilitarDatosDoc);
            _datosDocGestion.setIsModoRegistrar(false);
            _datosDocGestion.Inicia();
        }

        public void LimpiarDatosDocumento()
        {
            if (_items.HayItemsEnBandeja)
            {
                Helpers.Msg.Error("DATOS DEL DOCUMENTO EN CUESTION NO PUEDEN SER LIMPIADOS");
                return;
            }

            var msg = "Estas Seguro De Limpiar Datos de Encabezado Del Documento ?";
            var r = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes)
            {
                var r01 = Sistema.MyData.Venta_Temporal_Encabezado_Eliminar(_idVentaTemporal);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _idVentaTemporal = -1;
                _datosDocGestion.Limpiar();
            }
        }

        public void VisualizarCliente()
        {
            if (_datosDocGestion.AceptarDatosIsOK)
            {
                _visualCliente.Inicializa();
                _visualCliente.setFicha(_datosDocGestion.EntidadCliente.id);
                _visualCliente.Inicia();
            }
        }

        public void VisualizarClenteDoc()
        {
            if (_datosDocGestion.AceptarDatosIsOK)
            {
                var fecha = DateTime.Now.Date;
                var filtroOOB = new OOB.Maestro.Cliente.Documento.Filtro()
                {
                    desde = fecha.AddDays(-120),
                    hasta = fecha,
                    autoCliente = _datosDocGestion.EntidadCliente.id,
                };
                var r01 = Sistema.MyData.Cliente_Documentos_GetLista(filtroOOB);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                _visualClienteDoc.Inicializa();
                _visualClienteDoc.setCliente(_datosDocGestion.EntidadCliente);
                _visualClienteDoc.setLista(r01.ListaD);
                _visualClienteDoc.Inicia();
            }
        }

        public void VisualizarClienteArticulos()
        {
            if (_datosDocGestion.AceptarDatosIsOK)
            {
                var fecha = DateTime.Now.Date;
                var filtroOOB = new OOB.Maestro.Cliente.Articulos.Filtro()
                {
                    desde = fecha.AddDays(-120),
                    hasta = fecha,
                    autoCliente = _datosDocGestion.EntidadCliente.id,
                };
                var r01 = Sistema.MyData.Cliente_ArticulosVenta_GetLista(filtroOOB);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _visualClienteArticulos.Inicializa();
                _visualClienteArticulos.setCliente(_datosDocGestion.EntidadCliente);
                _visualClienteArticulos.setLista(r01.ListaD);
                _visualClienteArticulos.Inicia();
            }
        }

        public void EliminarItem()
        {
            if (_items.ItemActual != null)
            {
                var r00 = Sistema.MyData.Permiso_GenerarDoc_AnularItem(Sistema.Usuario.idGrupo);
                if (r00.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return;
                }

                if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
                {
                    var msg = "Eliminar Item En Cuestión ?";
                    var r = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (r != DialogResult.Yes)
                    {
                        return;
                    }

                    var _itActual = _items.ItemActual;
                    var ficha = new OOB.Venta.Temporal.Item.Eliminar.Ficha()
                    {
                        itemEncabezado = new OOB.Venta.Temporal.Item.Eliminar.ItemEncabezado()
                        {
                            id = _idVentaTemporal,
                            monto = _itActual.mTotal,
                            montoDivisa = _itActual.mTotalDivisa,
                            renglones = 1,
                        },
                        itemDetalle = new OOB.Venta.Temporal.Item.Eliminar.ItemDetalle()
                        {
                            id = _itActual.Id,
                        },
                        itemActDeposito = null,
                    };
                    if (_itActual.MercanciaIsEnReserva)
                    {
                        var xficha = new OOB.Venta.Temporal.Item.Eliminar.ItemActDeposito()
                        {
                            autoDeposito = _datosDocGestion.DataIdDeposito,
                            autoProducto = _itActual.IdProducto,
                            cntActualizar = _itActual.CantUnd,
                            prdDescripcion = _itActual.DescripcionPrd,
                        };
                        ficha.itemActDeposito = xficha;
                    }
                    var r01 = Sistema.MyData.Venta_Temporal_Item_Eliminar(ficha);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _items.EliminarItem(_itActual);
                }
            }
        }

        public void setCadenaBusqProducto(string cad)
        {
            _busqProducto.setCadenaBusq(cad);
        }

        public void BusqProducto()
        {
            if (!_datosDocGestion.AceptarDatosIsOK)
            {
                Helpers.Msg.Alerta("DEBES PRIMERO HACER CLICK EN NUEVO DOCUMENTO");
                return;
            }
            _busqProducto.setDepositoBuscar(_datosDocGestion.DataIdDeposito);
            _busqProducto.setActivarSeleccionItem(true);
            _busqProducto.setFactorCambio(TasaDivisa);
            _busqProducto.Buscar();
            if (_busqProducto.ItemSeleccionadoIsOk)
            {
                CapturarDataProducto(_busqProducto.ItemSeleccionado.Id);
            }
        }

        private void CapturarDataProducto(string id)
        {
            var r01 = Sistema.MyData.Producto_GetFichaById(id);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var tarifaPrecioManejar = _datosDocGestion.EntidadCliente.tarifa;

            _agregarEditarItem.Inicializa();
            _agregarEditarItem.setItemDocGestion(_docGestion.ItemGestion);
            _agregarEditarItem.setTarifaPrecio(tarifaPrecioManejar);
            _agregarEditarItem.setTasaDivisa(TasaDivisa);
            _agregarEditarItem.setIdDeposito(_datosDocGestion.DataIdDeposito);
            _agregarEditarItem.setRupturaPorExistencia(_rupturaPorExistencia);
            _agregarEditarItem.setAgregar(r01.Entidad, _idVentaTemporal);
            _agregarEditarItem.Inicia();
            if (_agregarEditarItem.ProcesarItemIsOk)
            {
                var idItemAgregado = _agregarEditarItem.IdItemAgregado;
                var r02 = Sistema.MyData.Venta_Temporal_Item_GetFichaById(idItemAgregado);
                if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return;
                }
                _items.AgregarItem(r02.Entidad, TasaDivisa);
            }
        }

        public void ActivarBusPorCodigo()
        {
            _busqProducto.ActivarBusPorCodigo();
        }

        public void ActivarBusPorDescripcion()
        {
            _busqProducto.ActivarBusPorDescripcion();
        }

        public void ActivarBusPorReferencia()
        {
            _busqProducto.ActivarBusPorReferencia();
        }

        public void setNotasDoc(string p)
        {
            if (_idVentaTemporal != -1)
            {
                var ficha = new OOB.Venta.Temporal.Cambios.Notas.Ficha()
                {
                    id = _idVentaTemporal,
                    notas = p,
                };
                var r01 = Sistema.MyData.Venta_Temporal_SetNotas(ficha);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _datosDocGestion.setNotasDoc(p);
            }
        }

        public void LimpiarItems()
        {
            if (_items.HayItemsEnBandeja)
            {
                var msg = "Eliminar Items En Cuestión ?";
                var r = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (r != DialogResult.Yes)
                {
                    return;
                }

                var ficha = new OOB.Venta.Temporal.Item.Limpiar.Ficha()
                {
                    itemEncabezado = new OOB.Venta.Temporal.Item.Limpiar.ItemEncabezado()
                    {
                        id = _idVentaTemporal,
                    },
                    itemDetalle = _items.ListaItems.Select(s =>
                    {
                        var rg = new OOB.Venta.Temporal.Item.Limpiar.ItemDetalle()
                        {
                            id = s.Id,
                        };
                        return rg;
                    }).ToList(),
                    itemActDeposito = null,
                };
                ficha.itemActDeposito = _items.ListaItems.Where(w => w.MercanciaIsEnReserva).Select(s =>
                {
                    var rg = new OOB.Venta.Temporal.Item.Limpiar.ItemActDeposito()
                    {
                        autoDeposito = _datosDocGestion.DataIdDeposito,
                        autoProducto = s.IdProducto,
                        cntActualizar = s.CantUnd,
                        prdDescripcion = s.DescripcionPrd,
                    };
                    return rg;
                }).ToList();

                var r01 = Sistema.MyData.Venta_Temporal_Item_Limpiar(ficha);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _items.LimpiarItems();
            }
            else
            {
                Helpers.Msg.Alerta("NOHAY ITEMS REGISTRADOS");
            }
        }

        public void AbandonarDoc()
        {
            if (_idVentaTemporal == -1)
            {
                _abandonarDocIsOk = true;
                return;
            }

            _abandonarDocIsOk = false;
            var msg = "Abandonar Documento En Cuestión ?";
            var r = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes)
            {
                if (_idVentaTemporal != -1)
                {
                    var ficha = new OOB.Venta.Temporal.Anular.Ficha()
                    {
                        IdEncabezado = _idVentaTemporal,
                        Items = _items.ListaItems.Select(s =>
                        {
                            var rg = new OOB.Venta.Temporal.Anular.Item()
                            {
                                idItem = s.Id,
                            };
                            return rg;
                        }).ToList(),
                        ItemsActDeposito = _items.ListaItems.Where(w => w.MercanciaIsEnReserva).Select(s =>
                        {
                            var rg = new OOB.Venta.Temporal.Anular.ItemActDeposito()
                            {
                                autoDeposito = _datosDocGestion.DataIdDeposito,
                                autoProducto = s.IdProducto,
                                cntActualizar = s.CantUnd,
                                prdDescripcion = s.DescripcionPrd,
                            };
                            return rg;
                        }).ToList(),
                    };
                    var r01 = Sistema.MyData.Venta_Temporal_Anular(ficha);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _abandonarDocIsOk = true;
                }
                else
                {
                    _abandonarDocIsOk = true;
                }
            }
        }

        public void EditarItem()
        {
            if (_items.ItemActual != null)
            {
                var _itActual = _items.ItemActual;
                var _idEditar = _itActual.Id;

                var r01 = Sistema.MyData.Producto_GetFichaById(_itActual.IdProducto);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var tarifaPrecioManejar = _datosDocGestion.EntidadCliente.tarifa;

                _agregarEditarItem.Inicializa();
                _agregarEditarItem.setItemDocGestion(_docGestion.ItemGestion);
                _agregarEditarItem.setTarifaPrecio(tarifaPrecioManejar);
                _agregarEditarItem.setTasaDivisa(TasaDivisa);
                _agregarEditarItem.setIdDeposito(_datosDocGestion.DataIdDeposito);
                _agregarEditarItem.setRupturaPorExistencia(_rupturaPorExistencia);
                _agregarEditarItem.setEditar(_itActual, _idVentaTemporal, r01.Entidad);
                _agregarEditarItem.setCargarPrecioNeto(_itActual.PNeto);
                _agregarEditarItem.Inicia();
                if (_agregarEditarItem.ProcesarItemIsOk)
                {
                    var idItemAgregado = _agregarEditarItem.IdItemAgregado;
                    var r02 = Sistema.MyData.Venta_Temporal_Item_GetFichaById(idItemAgregado);
                    if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r02.Mensaje);
                        return;
                    }
                    _items.EliminarLista(_idEditar);
                    _items.AgregarItem(r02.Entidad, TasaDivisa);
                }

            }
        }

        public void DocPendiente()
        {
            if (_idVentaTemporal == -1)
            {
                return;
            }
            if (!_items.HayItemsEnBandeja)
            {
                return;
            }

            var msg = "Pasar Documento En Cuestión A Espera/Pendiente ?";
            var r = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes)
            {
                var fichaOOB = new OOB.Venta.Temporal.Pendiente.Dejar.Ficha()
                {
                    idTemporal = _idVentaTemporal,
                    notas = _datosDocGestion.DataNotasDoc,
                };
                var r01 = Sistema.MyData.VentaAdm_Temporal_Pendiente_Dejar(fichaOOB);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _items.EliminarListaItems();
                _idVentaTemporal = -1;
                _datosDocGestion.Limpiar();
                ActualizarTasaDivisa();
            }
        }

        public void RecuperarDocumento()
        {
            if (_idVentaTemporal != -1)
            {
                Helpers.Msg.Alerta("NO DEBE HABER NINGUN DOCUMENTO EN PROCESO PARA ACTIVAR ESTA OPCION");
                return;
            }
            if (_items.HayItemsEnBandeja)
            {
                Helpers.Msg.Alerta("NO DEBE HABER NINGUN DOCUMENTO EN PROCESO PARA ACTIVAR ESTA OPCION");
                return;
            }

            var msg = "Recuperar Documentos Dejados Por Corte/Fallas Electricas ?";
            var r = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes)
            {
                var fichaOOB = new OOB.Venta.Temporal.Recuperar.Ficha()
                {
                    autoSistDocumento = _docGestion.SistTipoDocumento.id,
                    autoUsuario = Sistema.Usuario.id,
                    idEquipo = Sistema.IdEquipo,
                };
                var r01 = Sistema.MyData.VentaAdm_Temporal_Recuperar(fichaOOB);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                Helpers.Msg.OK("SISTEMA RECUPERO ( " + r01.Entidad.ToString() + " ) DOCUMENTO(S)");
            }
        }

        public void AbrirDocPendiente()
        {
            if (_idVentaTemporal != -1)
            {
                Helpers.Msg.Alerta("NO DEBE HABER NINGUN DOCUMENTO EN PROCESO PARA ACTIVAR ESTA OPCION");
                return;
            }
            if (_items.HayItemsEnBandeja)
            {
                Helpers.Msg.Alerta("NO DEBE HABER NINGUN DOCUMENTO EN PROCESO PARA ACTIVAR ESTA OPCION");
                return;
            }

            var filtroOOB = new OOB.Venta.Temporal.Pendiente.Lista.Filtro()
            {
                autoSistDocumento = SistTipoDocumento.id,
                autoUsuario = Sistema.Usuario.id,
                idEquipo = Sistema.IdEquipo,
            };
            var r01 = Sistema.MyData.VentaAdm_Temporal_Pendiente_GetLista(filtroOOB);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _pendienteGestion.Inicializa();
            _pendienteGestion.setData(r01.ListaD);
            _pendienteGestion.Inicia();
            if (_pendienteGestion.ItemSeleccionadoIsOk)
            {
                var idPendiente = _pendienteGestion.IdItemSeleccionado;
                AbrirPendiente(idPendiente);
            }
        }

        private void AbrirPendiente(int idPendiente)
        {
            var r01 = Sistema.MyData.VentaAdm_Temporal_Pendiente_Abrir(idPendiente);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _datosDocGestion.setIdEquipo(Sistema.IdEquipo);
            _datosDocGestion.setTipoDocumento(SistTipoDocumento);
            _datosDocGestion.setCargarData(r01.Entidad.Encabezado);
            _items.AgregarLista(r01.Entidad.Items, r01.Entidad.Encabezado.factorDivisa);
            _idVentaTemporal = r01.Entidad.Encabezado.id;
            //
            _docGestion.setCambioTasaDivisa(_datosDocGestion.DataFactorDivisa);
            _items.setCambioTasaDivisa(_datosDocGestion.DataFactorDivisa);
        }

        public void RemisionDoc()
        {
            if (!_datosDocGestion.AceptarDatosIsOK)
            {
                return;
            }

            if (_items.HayItemsEnBandeja)
            {
                Helpers.Msg.Alerta("OPCION NO PERMITIDA CUANDO EXISTEN ITEMS EN PROCESO");
                return;
            }

            var filtroOOB = new OOB.Maestro.Cliente.Documento.Filtro()
            {
                desde = null,
                hasta = null,
                autoCliente = _datosDocGestion.EntidadCliente.id,
                tipoDoc = OOB.Maestro.Cliente.Documento.Enumerados.enumTipoDoc.SinDefinir,
            };
            var tipoDoc = (tipoDocRemitir)_bsTipoDocRemitir.Current;
            switch (tipoDoc.id)
            {
                case "01":
                    filtroOOB.tipoDoc = OOB.Maestro.Cliente.Documento.Enumerados.enumTipoDoc.Factura;
                    break;
                case "04":
                    filtroOOB.tipoDoc = OOB.Maestro.Cliente.Documento.Enumerados.enumTipoDoc.NotaEntrega;
                    break;
                case "05":
                    filtroOOB.tipoDoc = OOB.Maestro.Cliente.Documento.Enumerados.enumTipoDoc.Presupuesto;
                    break;
                case "06":
                    filtroOOB.tipoDoc = OOB.Maestro.Cliente.Documento.Enumerados.enumTipoDoc.Pedido;
                    break;
            }
            var r01 = Sistema.MyData.Cliente_Documentos_GetLista(filtroOOB);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            _visualClienteDoc.Inicializa();
            _visualClienteDoc.setHabilitarSeleccionarDocumento(true);
            _visualClienteDoc.setHabilitarVisualizarDocumento(false);
            _visualClienteDoc.setCliente(_datosDocGestion.EntidadCliente);
            _visualClienteDoc.setLista(r01.ListaD);
            _visualClienteDoc.Inicia();
            if (_visualClienteDoc.SeleccionarDocumentoIsOk)
            {
                CargarDocumentoRemision(_visualClienteDoc.IdDocumentoSeleccionado);
            }
        }

        private void CargarDocumentoRemision(string autoDoc)
        {
            var r01 = Sistema.MyData.Documento_GetById(autoDoc);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var ficha = _docGestion.CargaRemision(r01.Entidad, _idVentaTemporal);
            if (ficha != null)
            {
                var r02 = Sistema.MyData.VentaAdm_Temporal_Remision_Registrar(ficha);
                if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return;
                }
            }
        }

        public void CambioTasaDivisa()
        {
            if (_idVentaTemporal != -1)
            {
                var _tasaAnterior = TasaDivisa;

                _gCambioTasa.setTasa(TasaDivisa);
                _gCambioTasa.Inicializa();
                _gCambioTasa.Inicia();
                if (_gCambioTasa.CambioTasaIsOk) 
                {
                    var _tasa = _gCambioTasa.TasaCambiar;
                    _docGestion.setCambioTasaDivisa(_tasa);
                    _items.setCambioTasaDivisa(_tasa);
                    var ficha = new OOB.Venta.Temporal.Cambios.TasaDivisa.Ficha()
                    {
                        id = _idVentaTemporal,
                        tasaDivisa = _tasa,
                        montoDivisa = MontoDivisa,
                        items = _items.ListaItems.Select(s =>
                        {
                            var nr = new OOB.Venta.Temporal.Cambios.TasaDivisa.Item()
                            {
                                id = s.Id,
                                descProducto = s.DescripcionPrd,
                                totalDivisa = s.mTotalDivisa,
                            };
                            return nr;
                        }).ToList(),
                    };
                    var r01 = Sistema.MyData.Venta_Temporal_SetTasaDivisa(ficha);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        _docGestion.setCambioTasaDivisa(_tasaAnterior);
                        _items.setCambioTasaDivisa(_tasaAnterior);

                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                }
            }
        }

        private void ActualizarTasaDivisa()
        {
            _docGestion.ActualizarTasaDivisaSistema();
        }

        public void LimpiezaGeneral()
        {
            var msg = "Limpiar Plantilla General ?";
            var r = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r != DialogResult.Yes)
            {
                return;
            }

            var fichaAnular = new OOB.Venta.Temporal.Anular.Ficha()
            {
                IdEncabezado = _idVentaTemporal,
                Items = _items.ListaItems.Select(s =>
                {
                    var rg = new OOB.Venta.Temporal.Anular.Item()
                    {
                        idItem = s.Id,
                        prdDescripcion = s.DescripcionPrd,
                    };
                    return rg;
                }).ToList(),
                ItemsActDeposito = _items.ListaItems.Where(w => w.MercanciaIsEnReserva).Select(s =>
                {
                    var rg = new OOB.Venta.Temporal.Anular.ItemActDeposito()
                    {
                        autoDeposito = _datosDocGestion.DataIdDeposito,
                        autoProducto = s.IdProducto,
                        cntActualizar = s.CantUnd,
                        prdDescripcion = s.DescripcionPrd,
                        idItem = s.Id,
                    };
                    return rg;
                }).ToList(),
            };
            var r01 = Sistema.MyData.Venta_Temporal_Anular(fichaAnular);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            IniciarDocumentoNuevo();
        }

        public void ProcesarDoc()
        {
            switch(_datosDocGestion.DataSistCodigoTipoDocumento)
            {
                case "05":
                    ProcesarPresupuesto();
                    break;
            }
        }

        private void ProcesarPresupuesto()
        {
            var xmsg = "Procesar/Guardar Presupuesto";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.No) { return; }
                

            var r01 = Sistema.MyData.Sistema_TasaFiscal_GetLista();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return ;
            }
            var _tf1 = r01.ListaD.FirstOrDefault(f => f.codigo == "01");
            var _tf2 = r01.ListaD.FirstOrDefault(f => f.codigo == "02");
            var _tf3 = r01.ListaD.FirstOrDefault(f => f.codigo == "03");


            var _monto = Monto;
            var _montoNeto = MontoNeto;
            var _montoImpuesto = MontoIva;
            var subTotalNeto = _montoNeto;  

            var dsctoFinal = 1m;
            _items.setDsctoFinal(dsctoFinal);
            var montoCambio = 0m;
            var BaseExenta = _items.ListaItems.Sum(s => s.MontoExento);
            var MontoBase = _items.ListaItems.Sum(s => s.MontoBase);
            var MontoImpuesto = _items.ListaItems.Sum(s => s.MontoImpuesto);
            var MontoBase1 = _items.ListaItems.Where(w => w.idTasaIva == _tf1.id).Sum(s => s.MontoBase);
            var MontoBase2 = _items.ListaItems.Where(w => w.idTasaIva == _tf2.id).Sum(s => s.MontoBase);
            var MontoBase3 = _items.ListaItems.Where(w => w.idTasaIva == _tf3.id).Sum(s => s.MontoBase);
            var MontoImpuesto1 = _items.ListaItems.Where(w => w.idTasaIva == _tf1.id).Sum(s => s.MontoImpuesto);
            var MontoImpuesto2 = _items.ListaItems.Where(w => w.idTasaIva == _tf2.id).Sum(s => s.MontoImpuesto);
            var MontoImpuesto3 = _items.ListaItems.Where(w => w.idTasaIva == _tf3.id).Sum(s => s.MontoImpuesto);

            var costoMonto = _items.ListaItems.Sum(s => s.CostoVenta); ;
            var netoMonto = _items.ListaItems.Sum(s => s.NetoVenta); ;
            var utilidadMonto = netoMonto - costoMonto;
            var importeDocumento = (BaseExenta + MontoBase + MontoImpuesto);
            importeDocumento = Math.Round(importeDocumento, 2, MidpointRounding.AwayFromZero);
            var importeDocumentoDivisa = importeDocumento/TasaDivisa;
            importeDocumentoDivisa = Math.Round(importeDocumentoDivisa, 2, MidpointRounding.AwayFromZero);
            var factorCambio = TasaDivisa;

            var subTotal = importeDocumento;
            var dsctoMonto = _monto - importeDocumento;
            var saldoPendiente = 0.0m;


            var fichaOOB = new OOB.Documento.Agregar.Presupuesto.Ficha()
            {
                RazonSocial = _datosDocGestion.EntidadCliente.razonSocial,
                DirFiscal = _datosDocGestion.EntidadCliente.dirFiscal ,
                CiRif = _datosDocGestion.EntidadCliente.ciRif,
                CodigoTipoDoc = _datosDocGestion.EntidadTipoDoc.codigo,
                Exento = BaseExenta,
                Base1 = MontoBase1,
                Base2 = MontoBase2,
                Base3 = MontoBase3,
                Impuesto1 = MontoImpuesto1,
                Impuesto2 = MontoImpuesto2,
                Impuesto3 = MontoImpuesto3,
                MBase = MontoBase,
                Impuesto = MontoImpuesto,
                Total = importeDocumento,
                Tasa1 = _tf1.tasa ,
                Tasa2 = _tf2.tasa ,
                Tasa3 = _tf3.tasa ,
                Nota = _datosDocGestion.DataNotasDoc,
                TasaRetencionIva = 0.0m,
                TasaRetencionIslr = 0.0m,
                RetencionIva = 0.0m,
                RetencionIslr = 0.0m,
                AutoCliente = _datosDocGestion.EntidadCliente.id,
                CodigoCliente = _datosDocGestion.EntidadCliente.codigo,
                Control = "",
                OrdenCompra = "",
                Dias = 0,
                Descuento1 = dsctoMonto,
                Descuento2 = 0.0m,
                Cargos = 0.0m,
                Descuento1p = dsctoFinal,
                Descuento2p = 0.0m,
                Cargosp = 0.0m,
                Columna = "1",
                EstatusAnulado = "0",
                Aplica = "",
                ComprobanteRetencion = "",
                SubTotalNeto = subTotalNeto,
                Telefono = _datosDocGestion.EntidadCliente.telefono1,
                FactorCambio = factorCambio,
                CodigoVendedor = _datosDocGestion.EntidadVendedor.cod ,
                Vendedor = _datosDocGestion.EntidadVendedor.desc ,
                AutoVendedor = _datosDocGestion.EntidadVendedor.id ,
                FechaPedido = DateTime.Now.Date,
                Pedido = "",
                CondicionPago = _datosDocGestion.DataCondPagoIsCredito=="1" ? "CREDITO" : "CONTADO",
                Usuario = Sistema.Usuario.nombre,
                CodigoUsuario = Sistema.Usuario.codigo,
                CodigoSucursal = _datosDocGestion.EntidadSucursal.cod,
                Transporte = _datosDocGestion.EntidadTransporte.desc ,
                CodigoTransporte = _datosDocGestion.EntidadTransporte.cod,
                MontoDivisa = importeDocumentoDivisa,
                Despachado = "",
                DirDespacho = _datosDocGestion.DataDirDespacho,
                Estacion = Sistema.EquipoEstacion,
                Renglones = _items.ListaItems.Count(),
                SaldoPendiente = saldoPendiente,
                ComprobanteRetencionIslr = "",
                DiasValidez = _datosDocGestion.DataDiasValidez,
                AutoUsuario = Sistema.Usuario.id,
                AutoTransporte = _datosDocGestion.EntidadTransporte.id,
                Situacion = "Procesado",
                SignoTipoDoc = _datosDocGestion.EntidadTipoDoc.signo ,
                SiglasTipoDoc = _datosDocGestion.EntidadTipoDoc.siglas,
                Tarifa = _datosDocGestion.EntidadCliente.tarifa,
                TipoRemision = "",
                DocumentoRemision = "",
                AutoRemision = "",
                NombreTipoDoc = _datosDocGestion.EntidadTipoDoc.descripcion,
                SubTotalImpuesto = MontoImpuesto,
                SubTotal = subTotal,
                TipoCliente = "",
                Planilla = "",
                Expendiente = "",
                AnticipoIva = 0.0m,
                TercerosIva = 0.0m,
                Neto = netoMonto,
                Costo = costoMonto,
                Utilidad = utilidadMonto,
                Utilidadp = 100 - (costoMonto / netoMonto * 100),
                TipoTipoDoc=_datosDocGestion.EntidadTipoDoc.tipo,
                CiTitular = "",
                NombreTitular = "",
                CiBeneficiario = "",
                NombreBeneficiario = "",
                Clave = "",
                DenominacionFiscal = "No Contribuyente",
                Cambio = montoCambio,
                EstatusValidado = "0",
                Cierre = "",
                EstatusCierreContable = "0",
                CierreFtp = "",
                Prefijo = _datosDocGestion.EntidadSucursal.cod,
            };

            var detalles = _items.ListaItems.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.Presupuesto.FichaDetalle()
                {
                    AutoProducto = s.DataItem.autoProducto,
                    Codigo = s.DataItem.codigoProducto,
                    Nombre = s.DataItem.nombreProducto,
                    AutoDepartamento = s.DataItem.autoDepartamento,
                    AutoGrupo = s.DataItem.autoGrupo,
                    AutoSubGrupo = s.DataItem.autoSubGrupo,
                    AutoDeposito = s.DataItem.autoDeposito,
                    Cantidad = s.DataItem.cantidad,
                    Empaque = s.DataItem.empaqueDesc,
                    PrecioNeto = s.DataItem.precioNeto,
                    Descuento1p = s.DataItem.dsctoPorct,
                    Descuento2p = 0.0m,
                    Descuento3p = 0.0m,
                    Descuento1 = s.DsctoMonto,
                    Descuento2 = 0.0m,
                    Descuento3 = 0.0m,
                    CostoVenta = s.CostoVenta,
                    TotalNeto = s.Importe ,
                    Tasa = s.DataItem.tasaIva,
                    Impuesto = s.MIva,
                    Total = s.mTotal, 
                    EstatusAnulado = "0",
                    Tipo = _datosDocGestion.EntidadTipoDoc.codigo,
                    Deposito = _datosDocGestion.EntidadDeposito.desc,
                    Signo = _datosDocGestion.EntidadTipoDoc.signo,
                    PrecioFinal = s.PrecioFinal,
                    AutoCliente = _datosDocGestion.EntidadCliente.id,
                    Decimales = s.DataItem.decimalesProducto,
                    ContenidoEmpaque = s.DataItem.empaqueCont,
                    CantidadUnd = s.DataItem.cantidadUnd,
                    PrecioUnd = s.PrecioFinal,
                    CostoUnd = s.DataItem.costoUnd,
                    Utilidad = s.Utilidad, 
                    Utilidadp = s.UtilidadP,
                    PrecioItem = s.PrecioItem,
                    EstatusGarantia = "0",
                    EstatusSerial = "0",
                    CodigoDeposito = _datosDocGestion.EntidadDeposito.cod,
                    DiasGarantia = 0,
                    Detalle = s.Notas,
                    PrecioSugerido = 0.0m,
                    AutoTasa = s.DataItem.autoTasaIva,
                    EstatusCorte = "0",
                    X = 0m,
                    Y = 0m,
                    Z = 0m,
                    Corte = "",
                    Categoria = s.DataItem.categroiaProducto,
                    Cobranzap = 0.0m,
                    Ventasp = 0.0m,
                    CobranzapVendedor = 0.0m,
                    VentaspVendedor = 0.0m,
                    Cobranza = 0.0m,
                    Ventas = 0.0m,
                    CobranzaVendedor = 0.0m,
                    VentasVendedor = 0.0m,
                    CostoPromedioUnd = s.DataItem.costoPromdUnd,
                    CostoCompra = s.DataItem.costoPromd,
                    EstatusChecked = "1",
                    Tarifa = s.DataItem.tarifaPrecio,
                    TotalDescuento = s.DsctoMontoTotal,
                    CodigoVendedor = _datosDocGestion.EntidadVendedor.cod,
                    AutoVendedor = _datosDocGestion.EntidadVendedor.id,
                    CierreFtp = "",
                };
                return nr;
            }).ToList();
            fichaOOB.Detalles = detalles;
            fichaOOB.VentaTemporal = new OOB.Documento.Agregar.Presupuesto.FichaTemporalVenta() { id = _idVentaTemporal };

            var r02 = Sistema.MyData.Documento_Agregar_Presupuesto(fichaOOB);
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }
            _documentoProcesadoIsOk = true;
            IniciarDocumentoNuevo();
        }

        private void IniciarDocumentoNuevo()
        {
            _idVentaTemporal = -1;
            _datosDocGestion.Limpiar();
            _items.LimpiarItems();
            ActualizarTasaDivisa();
        }

    }

}