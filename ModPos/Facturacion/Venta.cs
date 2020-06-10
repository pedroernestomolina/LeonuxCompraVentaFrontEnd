using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion
{

    public class Venta
    {

        private Enumerados.EnumModoOperacionPos _modoOperacionPos;
        private Enumerados.EnumModoFuncion _modoFuncion;
        private bool _permitirBusquedaPorDescripcion;
        private bool _activarRepesaje;
        private decimal _limiteRepesajeInf;
        private decimal _limiteRepesajeSup;
        private decimal _montoDivisa;
        private int _idDocumento;

        private OOB.LibVenta.PosOffline.Usuario.Ficha _usuario;
        private OOB.LibVenta.PosOffline.Fiscal.Ficha _fiscal;
        private OOB.LibVenta.PosOffline.Configuracion.Deposito.Ficha _deposito;
        private OOB.LibVenta.PosOffline.Configuracion.Vendedor.Ficha _vendedor;
        private OOB.LibVenta.PosOffline.Configuracion.Cobrador.Ficha _cobrador;
        private OOB.LibVenta.PosOffline.Configuracion.Transporte.Ficha _transporte;
        private OOB.LibVenta.PosOffline.Configuracion.MedioCobro.Ficha _medioCobro;
        private OOB.LibVenta.PosOffline.Permiso.Pos.Ficha _permisos;
        private OOB.LibVenta.PosOffline.VentaDocumento.Ficha _documentoVenta;

        private ClaveSeguridad.Seguridad _seguridad;
        private AbrirPendiente.Pendiente _pendiente;
        private CtrCliente _ctrCliente;
        private CtrItem _ctrItem;
        private CtrlLista _ctrLista;
        private CtrlBuscar _ctrBuscar;
        private CtrConsulta _ctrConsultar;
        private CtrListaItem _ctrListaItem;
        private CtrPago _ctrPago;

        public string SerieFactura { get; set; }
        public string SerieNotaCredito { get; set; }
        public string SerieNotaDebito { get; set; }
        public string CodigoSucursal { get; set; }

        public decimal MontoNacional 
        {
            get 
            {
                var rt = 0.0m;
                rt = _ctrItem.MontoTotal;
                return rt;
            }
        }
        
        public decimal MontoDivisa 
        {
            get 
            {
                var rt = 0.0m;
                rt = _ctrItem.MontoDivisa;
                return rt;
            }
        }

        public decimal TasaCambio
        {
            get 
            {
                var rt = 0.0m;
                rt = _ctrItem.FactorCambio;
                return rt;
            }
        }

        public decimal Descuento
        {
            get
            {
                return 0.0m;
            }
        }

        public CtrCliente Cliente 
        {
            get 
            {
                return _ctrCliente;
            }
        }

        public CtrItem Items 
        {
            get 
            {
                return _ctrItem;
            }
        }

        public CtrlBuscar BuscarItem
        {
            get
            {
                return _ctrBuscar;
            }
        }

        public Enumerados.EnumModoFuncion ModoFuncion 
        {
            get
            {
                return _modoFuncion;
            }
        }


        public Venta(ClaveSeguridad.Seguridad seguridad)
        {
            _seguridad = seguridad;
            _ctrCliente = new CtrCliente();
            _pendiente = new AbrirPendiente.Pendiente(_seguridad);
            _ctrItem = new CtrItem();
            _ctrLista = new CtrlLista();
            _ctrBuscar = new CtrlBuscar(_ctrLista);
            _ctrConsultar = new CtrConsulta(_ctrBuscar);
            _ctrListaItem = new CtrListaItem(_ctrItem);
            _ctrPago = new CtrPago(_seguridad, _ctrCliente);

            _permitirBusquedaPorDescripcion = false;
            _modoOperacionPos = Enumerados.EnumModoOperacionPos.Detal;
            _modoFuncion = Enumerados.EnumModoFuncion.Facturacion;
            _montoDivisa = 0.0m;
            _activarRepesaje = false;
            _limiteRepesajeInf = 0.0m;
            _limiteRepesajeSup = 0.0m;
        }


        public void setFiscal (OOB.LibVenta.PosOffline.Fiscal.Ficha ficha)
        {
            _fiscal= ficha;
        }

        public void setUsuario(OOB.LibVenta.PosOffline.Usuario.Ficha ficha )
        {
            _usuario= ficha;
        }
        
        public void setCliente(CtrCliente cliente )
        {
            _ctrCliente = cliente;
        }

        public void setItem (CtrItem item)
        {
            _ctrItem=item ;
        }

        public void setVendedor(OOB.LibVenta.PosOffline.Configuracion.Vendedor.Ficha ficha)
        {
            _vendedor = ficha;
        }

        public void setCobrador(OOB.LibVenta.PosOffline.Configuracion.Cobrador.Ficha ficha)
        {
            _cobrador = ficha;
        }

        public void setTransporte(OOB.LibVenta.PosOffline.Configuracion.Transporte.Ficha ficha)
        {
            _transporte = ficha;
        }

        public void setDeposito (OOB.LibVenta.PosOffline.Configuracion.Deposito.Ficha ficha)
        {
            _deposito = ficha;
        }

        public void setMedioCobro(OOB.LibVenta.PosOffline.Configuracion.MedioCobro.Ficha ficha)
        {
            _medioCobro = ficha;
        }

        public void setPermiso(OOB.LibVenta.PosOffline.Permiso.Pos.Ficha ficha)
        {
            _permisos = ficha;
            _pendiente.setPermisos(ficha);
        }

        public void setSeguridad (ClaveSeguridad.Seguridad seguridad)
        {
            _seguridad = seguridad;
        }


        public void Procesar() 
        {
            if (_ctrCliente.Ficha.Id == -1)
            {
                return;
            }
            if (_ctrItem.Items.Count<= 0)
            {
                return;
            }
            if (_ctrItem.SubTotal == 0.0m)
            {
                return;
            }

            if (_modoFuncion == Enumerados.EnumModoFuncion.Facturacion) 
            {
                _ctrPago.Pagar(_permisos, MontoNacional, TasaCambio);
            }
            if (_modoFuncion == Enumerados.EnumModoFuncion.NotaCredito)
            {
                _ctrPago.PagarNotaCredito(_permisos, MontoNacional, TasaCambio,  _documentoVenta.DesctoPorc_1);
            }

            if (_ctrPago.PagoIsOk) 
            {
                GuardarFactura(_ctrPago.Pago);
            }
        }

        private void GuardarFactura(Pago.Pago pago)
        {
            var _dsctoGlobalPorct = pago.DescuentoPorct;
            var _dsctoGlobalMonto = pago.Descuento;
            var _cargoGlobalMonto = 0.0m;
            var _cargoGlobalPorct = 0.0m;
            var _montoDivisa=pago.MontoPagarDivisa;
            var _montoTotal = pago.MontoPagar;
            var _cambioDar = pago.MontoCambioDar_MonedaNacional;
            var _montoRecibido = pago.MontoRecibido;
            var _isCredito = pago.IsCredito ? "S" : "N";
            var _tipoDocumento = OOB.LibVenta.PosOffline.VentaDocumento.Enumerados.EnumTipoDocumento.Factura;
            var _signo=1;
            var _aplica="";
            var _serie=SerieFactura;


            if (_modoFuncion == Enumerados.EnumModoFuncion.NotaCredito) 
            {
                _cambioDar = 0.0m;
                _montoRecibido = 0.0m;
                _aplica=_documentoVenta.Documento;
                _tipoDocumento=OOB.LibVenta.PosOffline.VentaDocumento.Enumerados.EnumTipoDocumento.NotaCredito;
                _signo=-1;
                _serie=SerieNotaCredito;
            }

            _ctrItem.setDescuentoGlobal(_dsctoGlobalPorct);
            _ctrItem.setCargoGlobal(_cargoGlobalPorct);
            var ficha = new OOB.LibVenta.PosOffline.VentaDocumento.Agregar()
            {
                IdJornada =Sistema.MyJornada.Id,
                IdOperador=Sistema.MyOperador.Id,

                Aplica = _aplica,
                AutoUsuario = _usuario.Auto,
                ClienteId = _ctrCliente.Ficha.Id,
                ClienteCiRif = _ctrCliente.Ficha.CiRif,
                ClienteDirFiscal = _ctrCliente.Ficha.DirFiscal,
                ClienteNombreRazonSocial = _ctrCliente.Ficha.NombreRazaonSocial,
                ClienteTelefono = _ctrCliente.Ficha.Telefono,
                Control = "",
                Documento = "",
                Estacion = Environment.MachineName,
                FactorCambio = TasaCambio,
                IsDocumentoActivo = true,
                MontoBase = _ctrItem.MontoBase,
                MontoBase_1 = _ctrItem.MontoBaseX("1"),
                MontoBase_2 = _ctrItem.MontoBaseX("2"),
                MontoBase_3 = _ctrItem.MontoBaseX("3"),
                MontoCargo_1 = _cargoGlobalMonto,
                MontoCostoVenta = _ctrItem.MontoCostoVenta,
                MontoDescuento_1 = _dsctoGlobalMonto,
                MontoDescuento_2 = 0.0m,
                MontoDivisa = _montoDivisa,
                MontoExento = _ctrItem.MontoExento,
                MontoImpuesto = _ctrItem.MontoImpuesto,
                MontoIva_1 = _ctrItem.MontoIvaX("1"),
                MontoIva_2 = _ctrItem.MontoIvaX("2"),
                MontoIva_3 = _ctrItem.MontoIvaX("3"),
                MontoSubTotal = _ctrItem.MontoTotal,
                MontoSubTotalImpuesto = _ctrItem.MontoImpuesto,
                MontoSubTotalNeto = _ctrItem.SubTotalNeto,
                MontoTotal = _montoTotal ,
                MontoUtilidad = _ctrItem.UtilidadNetaMonto,
                MontoVentaNeta = _ctrItem.MontoVentaNeto,
                PorcCargo_1 = _cargoGlobalPorct ,
                PorcDescuento_1 = _dsctoGlobalPorct ,
                PorcDescuento_2 = 0.0m,
                PorcUtilidad = _ctrItem.UtilidadNetaPorct,
                Renglones = _ctrItem.Renglones,
                Serie = _serie,
                SignoDocumento = _signo,
                TasaIva_1 = _fiscal.Tasa1,
                TasaIva_2 = _fiscal.Tasa2,
                TasaIva_3 = _fiscal.Tasa3,
                TipoDocumento = _tipoDocumento,
                UsuarioCodigo = _usuario.Codigo,
                UsuarioDescripcion = _usuario.Descripcion,
                CodioSucursal = CodigoSucursal,
                AutoDeposito = _deposito.Auto,
                CodigoDeposito = _deposito.Codigo,
                DescripcionDeposito = _deposito.Descripcion,
                AutoVendedor = _vendedor.Auto,
                CodigoVendedor = _vendedor.Codigo,
                NombreVendedor = _vendedor.Nombre,
                AutoCobrador=_cobrador.Auto,
                CodigoCobrador=_cobrador.Codigo,
                NombreCobrador=_cobrador.Nombre,
                AutoTransporte=_transporte.Auto,
                CodigoTransporte=_transporte.Codigo,
                NombreTransporte=_transporte.Nombre,
                MontoRecibido=_montoRecibido,
                CambioDar=_cambioDar,
                IsCredito=_isCredito,
            };

            var fichaItemsEliminar = new List<OOB.LibVenta.PosOffline.VentaDocumento.AgregarItemEliminar>();
            var fichaItems = new List<OOB.LibVenta.PosOffline.VentaDocumento.AgregarItem>();
            foreach (var rg in _ctrItem.Items)
            {

                if (_modoFuncion == Enumerados.EnumModoFuncion.Facturacion)
                {
                    var nrEliminar = new OOB.LibVenta.PosOffline.VentaDocumento.AgregarItemEliminar()
                    {
                        IdEliminar = rg.Id,
                    };
                    fichaItemsEliminar.Add(nrEliminar);
                }

                var nr = new OOB.LibVenta.PosOffline.VentaDocumento.AgregarItem()
                {
                    AutoDepartamento = rg.AutoDepartamento,
                    AutoGrupo = rg.AutoGrupo,
                    AutoProducto = rg.AutoId,
                    AutoSubGrupo = rg.AutoSubGrupo,
                    AutoTasa = rg.AutoTasa,
                    Cantidad = rg.Cantidad,
                    CantidadUnd = rg.Cantidad,
                    Categoria = rg.Categoria,
                    CodigoPrd = rg.CodigoPrd,
                    CostoCompraUnd = rg.CostoUnd,
                    CostoPromedioUnd = rg.CostoPromUnd,
                    CostoVenta = rg.CostoVenta,
                    Decimales = rg.Decimales,
                    DiasEmpaqueGarantia = rg.DiasEmpaqueGarantia,
                    EmpaqueCodigo = rg.EmpaqueCodigo,
                    EmpaqueContenido = rg.EmpaqueContenido,
                    EmpaqueDescripcion = rg.EmpaqueDescripcion,
                    MontoDscto_1 = 0.0m,
                    MontoDscto_2 = 0.0m,
                    MontoDscto_3 = 0.0m,
                    MontoIva = rg.Iva,
                    MontoUtilidad = rg.UtilidadNetaMonto,
                    NombrePrd = rg.NombrePrd,
                    Notas = "",
                    PorcDscto_1 = 0.0m,
                    PorcDscto_2 = 0.0m,
                    PorcDscto_3 = 0.0m,
                    PorctUtilidad = rg.UtilidadNetaPorct,
                    PrecioSugerido = rg.PrecioSugerido,
                    PrecioNeto = rg.PrecioNeto,
                    PrecioItem = rg.PrecioItem,
                    PrecioFinal = rg.PrecioFinalNeto,
                    PrecioUnd = rg.PrecioFinalNeto,
                    TarifaPrecio = rg.TarifaPrecio,
                    TasaIva = rg.TasaIva,
                    Total = rg.Total,
                    TotalNeto = rg.TotalNeto,
                    TotalDescuento = rg.TotalDescuentoItem,
                    EsPesado=rg.EsPesado,
                    TipoIva=rg.TipoIva,
                };
                fichaItems.Add(nr);
            }
            ficha.Items = fichaItems;
            ficha.ItemsEliminar = fichaItemsEliminar;

            var metodosPago = pago._detalle.Select(s =>
            {
                OOB.LibVenta.PosOffline.Configuracion.MedioCobro.Medio medio=null;
                switch (s.Modo) 
                {
                    case  Pago.Enumerados.ModoPago.Efectivo:
                        medio = _medioCobro.Efectivo;
                        break;
                    case Pago.Enumerados.ModoPago.Divisa:
                        medio = _medioCobro.Divisa;
                        break;
                    case Pago.Enumerados.ModoPago.Electronico:
                        medio = _medioCobro.Electronico;
                        break;
                    case Pago.Enumerados.ModoPago.Otro:
                        medio = _medioCobro.Otro;
                        break;
                }
                var nr = new OOB.LibVenta.PosOffline.VentaDocumento.AgregarMetodoPago()
                {
                    autoMedioPago = medio.Auto,
                    codigoMedioPago = medio.Codigo,
                    descripcionMedioPago = medio.Descripcion,
                    Importe = s.Importe,
                    MontoRecibido = s.MontoRecibido,
                    Tasa = s.Tasa,
                    Lote = s.Lote,
                    Referencia = s.Referencia,
                };
                return nr;
            }).ToList();
            ficha.MetodosPago=metodosPago;

            var r01 = Sistema.MyData2.VentaDocumento_Agregar(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _modoFuncion = Enumerados.EnumModoFuncion.Facturacion;
            _ctrItem.Limpiar();
            _ctrCliente.Limpiar();
            Helpers.Msg.AgregarOk();
        }

        public void CtaPendiente() 
        {
            if (_modoFuncion == Enumerados.EnumModoFuncion.Facturacion)
            {
                _pendiente.Listar();
                if (_pendiente.CtaAbrirIsOk)
                {
                    _ctrCliente.BuscarId(_pendiente.IdClienteAbrir);
                    _ctrItem.CargarLista(_pendiente.ListaItemAbrir);
                }
            }
        }

        public bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData2.Item_Cargar();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _ctrItem.CargarLista(r01.Lista);

            var r02 = Sistema.MyData2.Fiscal_Tasas();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            setFiscal(r02.Entidad);

            var r03 = Sistema.MyData2.Configuracion_FactorCambio();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            _montoDivisa = r03.Entidad;
            _ctrItem.setMontoDivisa(_montoDivisa);

            var r04 = Sistema.MyData2.Configuracion_Repesaje();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }
            _activarRepesaje = r04.Entidad.IsActivo;
            _limiteRepesajeInf = r04.Entidad.LimiteValidoInferior;
            _limiteRepesajeSup = r04.Entidad.LimiteValidoSuperior;
            _ctrItem.setRepesaje(_activarRepesaje, _limiteRepesajeInf, _limiteRepesajeSup);

            var r05 = Sistema.MyData2.Configuracion_Serie();
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }
            SerieFactura = r05.Entidad.ParaFactura;
            SerieNotaCredito = r05.Entidad.ParaNotaCredito;
            SerieNotaDebito = r05.Entidad.ParaNotaDebito;

            var r06 = Sistema.MyData2.Configuracion_Sucursal();
            if (r06.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return false;
            }
            CodigoSucursal = r06.Entidad.Codigo;

            var r07 = Sistema.MyData2.Configuracion_ModoPos();
            if (r07.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r07.Mensaje);
                return false;
            }
            switch (r07.Entidad.Modo)
            {
                case OOB.LibVenta.PosOffline.Configuracion.Enumerados.EnumModoPos.Detal:
                    _modoOperacionPos = Enumerados.EnumModoOperacionPos.Detal;
                    break;
                case OOB.LibVenta.PosOffline.Configuracion.Enumerados.EnumModoPos.Mayor:
                    _modoOperacionPos = Enumerados.EnumModoOperacionPos.Mayor;
                    break;
            }

            var r08 = Sistema.MyData2.Configuracion_Deposito();
            if (r08.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r08.Mensaje);
                return false;
            }
            setDeposito(r08.Entidad);

            var r09 = Sistema.MyData2.Configuracion_Vendedor();
            if (r09.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r09.Mensaje);
                return false;
            }
            setVendedor(r09.Entidad);

            var r0a = Sistema.MyData2.Configuracion_ActivarBusquedaPorDescripcion();
            if (r0a.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0a.Mensaje);
                return false;
            }
            _permitirBusquedaPorDescripcion = r0a.Entidad;

            var r0b = Sistema.MyData2.Configuracion_Cobrador();
            if (r0b.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0b.Mensaje);
                return false;
            }
            setCobrador(r0b.Entidad);

            var r0c = Sistema.MyData2.Configuracion_Transporte();
            if (r0c.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0c.Mensaje);
                return false;
            }
            setTransporte(r0c.Entidad);

            var r0d = Sistema.MyData2.Configuracion_MedioCobro();
            if (r0d.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0d.Mensaje);
                return false;
            }
            setMedioCobro(r0d.Entidad);

            var r0e = Sistema.MyData2.Permiso_ManejoPos();
            if (r0e.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r0e.Mensaje);
                return false;
            }
            setPermiso(r0e.Entidad);
            setUsuario(Sistema.Usuario);

            _documentoVenta = null;
            if (_modoFuncion == Enumerados.EnumModoFuncion.NotaCredito) 
            {
                var r0f = Sistema.MyData2.VentaDocumento_Cargar(_idDocumento);
                if (r0f.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r0f.Mensaje);
                    return false;
                }
                var ent=r0f.Entidad;
                _documentoVenta = ent;
                _ctrCliente.setCliente(ent.ClienteId, ent.ClienteCiRif, ent.ClienteNombre, ent.ClienteDirFiscal, ent.ClienteTelefono);
                _ctrItem.CargarLista(ent.Detalles);
            }

            return rt;
        }

        public void ActivarPos() 
        {
            if (CargarData()) 
            {
                if (_modoFuncion == Enumerados.EnumModoFuncion.Facturacion) 
                {
                    Cliente.Limpiar();
                }

                var frm = new Facturacion.PosVenta();
                frm.setVenta(this);
                frm.ShowDialog();
            }
        }

        public void DejarCtaPendiente() 
        {
            if (_modoFuncion == Enumerados.EnumModoFuncion.Facturacion)
            {
                if (Cliente.Ficha.Id == -1)
                {
                    Helpers.Msg.Error("CLIENTE NO DEFINIDO");
                    return;
                }
                if (_ctrItem.Items.Count == 0)
                {
                    Helpers.Msg.Error("ITEMS NO DEFINIDO");
                    return;
                }

                var seguir = true;
                if (_permisos.DejarCtaPendiente.RequiereClave)
                {
                    seguir = _seguridad.SolicitarClave();
                }
                if (seguir)
                {
                    if (_ctrItem.DejarCtaEnPendiente(Cliente.Ficha))
                    {
                        _ctrCliente.Limpiar();
                        _ctrItem.Limpiar();
                    }
                }
            }
        }

        public void AnularVenta() 
        {
            var seguir = true;
            if (_permisos.AnularVenta.RequiereClave)
            {
                seguir = _seguridad.SolicitarClave();
            }
            if (seguir)
            {
                if (_ctrItem.AnularVenta()) 
                {
                    _modoFuncion = Enumerados.EnumModoFuncion.Facturacion;
                    _ctrCliente.Limpiar();
                }
            }
        }

        public void ActivarCalculador() 
        {
            Helpers.Utilitis.Calculadora();
        }

        public void ListaPlu() 
        {
            if (_modoFuncion == Enumerados.EnumModoFuncion.Facturacion)
            {
                _ctrLista.ListaPlu();
                if (_ctrLista.IsProductoSelected)
                {
                    Items.RegistraItem(_ctrLista.ProductoSelected, 0);
                }
            }
        }

        public void ListaOferta() 
        {
            if (_modoFuncion == Enumerados.EnumModoFuncion.Facturacion)
            {
                _ctrLista.ListaOferta();
            }
        }

        public void Devolucion() 
        {
            if (_ctrItem.Items.Count == 0)
            {
                Helpers.Msg.Error("NO HAY ITEMS EN LA BANDEJA");
                return ;
            }

            if (_modoFuncion == Enumerados.EnumModoFuncion.Facturacion)
            {
                var seguir = true;
                if (_permisos.Devolucion.RequiereClave)
                {
                    seguir = _seguridad.SolicitarClave();
                }
                if (seguir)
                {
                    _ctrListaItem.ActivarDevolucion();
                }
            }
            else 
            {
                _ctrListaItem.ActivarDevolucion(_modoFuncion);
            }
        }

        public void IncrementarItem()
        {
            if (_modoFuncion == Enumerados.EnumModoFuncion.Facturacion)
            {
                if (_ctrItem.Source.CurrencyManager.Position == 0)
                {
                    var it = (Item)_ctrItem.Source.Current;
                    if (it != null)
                    {
                        if (!it.EsPesado)
                        {
                            var seguir = true;
                            if (_permisos.Sumar.RequiereClave)
                            {
                                seguir = _seguridad.SolicitarClave();
                            }
                            if (seguir)
                            {
                                _ctrItem.IncrementarItem(it, 1);
                            }
                        }
                    }
                }
            }
        }

        public void Multiplicar() 
        {
            if (_modoFuncion == Enumerados.EnumModoFuncion.Facturacion)
            {
                if (_ctrItem.Source.CurrencyManager.Position == 0)
                {
                    var it = (Item)_ctrItem.Source.Current;
                    if (it != null)
                    {
                        if (!it.EsPesado)
                        {
                            var seguir = true;
                            if (_permisos.Multiplicar.RequiereClave)
                            {
                                seguir = _seguridad.SolicitarClave();
                            }
                            if (seguir)
                            {
                                _ctrItem.Multiplicar(it);
                            }
                        }
                    }
                }
            }
        }

        public void Restar()
        {
            if (_modoFuncion == Enumerados.EnumModoFuncion.Facturacion)
            {
                if (_ctrItem.Source.CurrencyManager.Position == 0)
                {
                    var it = (Item)_ctrItem.Source.Current;
                    if (it != null)
                    {
                        var seguir = true;
                        if (_permisos.Multiplicar.RequiereClave)
                        {
                            seguir = _seguridad.SolicitarClave();
                        }
                        if (seguir)
                        {
                            _ctrItem.Restar(it);
                        }
                    }
                }
            }
        }

        public void BuscarProducto(string buscar) 
        {
            if (_modoFuncion == Enumerados.EnumModoFuncion.Facturacion)
            {
                var rt = BuscarItem.ActivarBusqueda(buscar, _permitirBusquedaPorDescripcion);
                if (rt)
                {
                    Items.RegistraItem(_ctrBuscar.Producto, _ctrBuscar.Peso);
                }
            }
        }

        public void Consultor() 
        {
            _ctrConsultar.Consultor();
        }

        public void setModoNotaCredito (int idDocumento)
        {
            _modoFuncion= Enumerados.EnumModoFuncion.NotaCredito;
            _idDocumento = idDocumento;
        }

        public void ClienteBuscar() 
        {
            if (_modoFuncion == Enumerados.EnumModoFuncion.Facturacion) 
            {
                Cliente.Buscar();
            }
        }

    }

}