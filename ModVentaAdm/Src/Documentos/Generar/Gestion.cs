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
        private Items.Gestion _items;
        private enumerados.BusqPrd _prefBusqPrd;
        private int _idVentaTemporal;
        private bool _abandonarDocIsOk;
        private bool _rupturaPorExistencia;


        public string TipoDocumento { get { return _docGestion.TipoDocumento; } }
        public string CntItem { get { return _items.CntItem.ToString(); } }
        public decimal TasaDivisa { get { return _docGestion.TasaDivisa; } }
        public string Monto { get { return "Bs "+_items.MontoTotal.ToString("n2"); } }
        public string MontoDivisa { get { return "$ " + _items.MontoTotalDivisa.ToString("n2"); } }
        public string MontoNeto { get { return "Bs "+_items.MontoNeto.ToString("n2"); } }
        public string MontoIva { get { return "Bs "+_items.MontoIva.ToString("n2"); } }
        public string RifCliente { get { return _datosDocGestion.ClienteRif; } }
        public string CodigoCliente { get { return _datosDocGestion.ClienteCodigo; } }
        public string Cliente { get { return _datosDocGestion.ClienteRazonSocialDireccion; } }
        public BindingSource ItemsSource { get { return _items.ItemsSource; } }
        public enumerados.BusqPrd PrefBusqProducto { get { return _prefBusqPrd; } }
        public string DatosDoc_Fecha { get { return _datosDocGestion.DataFecha;} }
        public string DatosDoc_CondPago { get { return _datosDocGestion.DataCondPago; } }
        public string DatosDoc_Deposito { get { return _datosDocGestion.DataDeposito ; } }
        public string DatosDoc_FechaVence { get { return _datosDocGestion.DataFechaVence; } }
        public string DatosDoc_OrdenCompra { get { return _datosDocGestion.DataOrdenCompra; } }
        public string DatosDoc_Pedido { get { return _datosDocGestion.DataPedido; } }
        public string DatosDoc_Serie { get { return ""; } }
        public string DatosDoc_Sucursal { get { return _datosDocGestion.DataSucursal; } }
        public string DatosDoc_Notas { get { return _datosDocGestion.DataNotasDoc; } }
        public OOB.Sistema.TipoDocumento.Entidad.Ficha SistTipoDocumento { get { return _docGestion.SistTipoDocumento; } }
        public bool AbandonarDocIsOk { get { return _abandonarDocIsOk; } }
        

        public Gestion() 
        {
            _items = new Items.Gestion();
            _prefBusqPrd = enumerados.BusqPrd.SnDefinir ;
            _datosDocGestion = new DatosDocumento.Gestion();
            _visualCliente = new Cliente.Visualizar.Gestion();
            _visualClienteDoc = new Cliente.Documentos.Gestion();
            _visualClienteArticulos = new Cliente.Articulos.Gestion();
            _busqProducto = new BuscarProducto.Gestion();
            _agregarEditarItem = new AgregarEditarItem.Gestion();
            _idVentaTemporal = -1;
            _abandonarDocIsOk = false;
            _rupturaPorExistencia = false;
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
        }

        private DocGenerarFrm _frm;
        public void Inicia() 
        {
            if (CargarData())
            {
                if (_docGestion.CargarData())
                {
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
            _datosDocGestion.Inicializa();
            _datosDocGestion.setHabilitarSucursal(!_items.HayItemsEnBandeja);
            _datosDocGestion.setHabilitarDeposito(!_items.HayItemsEnBandeja);
            _datosDocGestion.setHabilitarBusquedaCliente(!_items.HayItemsEnBandeja);
            _datosDocGestion.setHabilitarDatosDoc(_docGestion.HabilitarDatosDoc);
            _datosDocGestion.setTipoDocumento(SistTipoDocumento);
            _datosDocGestion.setIsModoRegistrar(true);
            _datosDocGestion.setFactorDivisa(TasaDivisa);
            _datosDocGestion.setIdEquipo("01");
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
            if (r== DialogResult.Yes)
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
                _visualCliente.setFicha(_datosDocGestion.EntidadCliente);
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
            if (_items.ItemActual !=null)
            {
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
                    ficha.itemActDeposito=xficha;
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
            _datosDocGestion.setNotasDoc(p);
        }

        public void LimpiarItems()
        {
            if (_items.HayItemsEnBandeja )
            {
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
                    var rg= new OOB.Venta.Temporal.Item.Limpiar.ItemActDeposito()
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
        }

        public void AbandonarDoc()
        {
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

                _agregarEditarItem.Inicializa();
                _agregarEditarItem.setEditar(_itActual, _idVentaTemporal);
                _agregarEditarItem.Inicia();
                if (_agregarEditarItem.ProcesarItemIsOk)
                {
                    //var idItemAgregado = _agregarEditarItem.IdItemAgregado;
                    //var r02 = Sistema.MyData.Venta_Temporal_Item_GetFichaById(idItemAgregado);
                    //if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    //{
                    //    Helpers.Msg.Error(r02.Mensaje);
                    //    return;
                    //}
                    //_items.AgregarItem(r02.Entidad, TasaDivisa);
                }

            }
        }

    }

}