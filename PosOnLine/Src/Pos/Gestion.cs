using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Pos
{

    public class Gestion
    {

        public enum EnumModoFuncion { Facturacion = 1, NotaCredito };


        private decimal _tasaCambioActual;
        private OOB.Deposito.Entidad.Ficha _depositoAsignado;
        private OOB.Sucursal.Entidad.Ficha _sucursalAsignada;
        private OOB.Concepto.Entidad.Ficha _conceptoVenta;
        private OOB.Concepto.Entidad.Ficha _conceptoDevVenta;
        private OOB.Sistema.TipoDocumento.Entidad.Ficha _tipoDocumentoVenta;
        private OOB.Sistema.TipoDocumento.Entidad.Ficha _tipoDocumentoDevVenta;
        private OOB.Sistema.TipoDocumento.Entidad.Ficha _tipoDocumentoNotaEntrega;
        private OOB.Vendedor.Entidad.Ficha _vendedorAsignado;
        private OOB.Sistema.SerieFiscal.Entidad.Ficha _serieFactura;
        private OOB.Sistema.SerieFiscal.Entidad.Ficha _serieNotaCredito;
        private OOB.Sistema.SerieFiscal.Entidad.Ficha _serieNotaEntrega;
        private OOB.Sistema.Transporte.Entidad.Ficha _transporteAsignado;
        private OOB.Sistema.TasaFiscal.Entidad.Ficha _tasaFiscal_1;
        private OOB.Sistema.TasaFiscal.Entidad.Ficha _tasaFiscal_2;
        private OOB.Sistema.TasaFiscal.Entidad.Ficha _tasaFiscal_3;
        private OOB.Sistema.Cobrador.Entidad.Ficha _cobradorAsignado;
        private OOB.Sistema.MedioPago.Entidad.Ficha _medioPagoEfectivo;
        private OOB.Sistema.MedioPago.Entidad.Ficha _medioPagoDivisa;
        private OOB.Sistema.MedioPago.Entidad.Ficha _medioPagoElectronico;
        private OOB.Sistema.MedioPago.Entidad.Ficha _medioPagoOtro; 

        private EnumModoFuncion _modoFuncion;
        private bool _permitirBusquedaPorDescripcion;
        private Producto.Lista.Gestion _gestionListar;
        private Producto.Buscar.Gestion _gestionBuscar;
        private Cliente.Gestion _gestionCliente;
        private Consultor.Gestion _gestionConsultor;
        private Item.Gestion _gestionItem;
        private Devolucion.Gestion _gestionDevolucion;
        private Multiplicar.Gestion _gestionMultiplicar;
        private Pago.Procesar.Gestion _gestionProcesarPago;
        private Pendiente.Gestion _gestionPendiente;


        public Decimal TasaCambioActual { get { return _tasaCambioActual; } }
        public string UsuarioActual { get { return Sistema.Usuario.codigo + Environment.NewLine + Sistema.Usuario.nombre; } }
        public string EquipoEstacion { get { return Sistema.EquipoEstacion; } }
        public string ClienteData { get { return _gestionCliente.ClienteData; } }
        public int CantItem { get { return _gestionItem.CantItem; } }
        public decimal TotalPeso { get { return _gestionItem.TotalPeso; } }
        public int CantRenglones { get { return _gestionItem.CantRenglones; } }
        public decimal Importe { get { return _gestionItem.Importe; } }
        public decimal ImporteDivisa { get { return _gestionItem.ImporteDivisa; } }
        public string ProductoNombre { get { return _gestionItem.Producto; } }
        public string ProductoTasaIva { get { return _gestionItem.PrdTasaIva; } }
        public decimal ProductoPrecioNeto { get { return _gestionItem.PrdPrecioNeto; } }
        public decimal ProductoIva { get { return _gestionItem.PrdIva; } }
        public decimal ProductoContenido { get { return _gestionItem.PrdContenido; } }
        public int CntCtasPendientes { get { return _gestionPendiente.CntCtasPendientes; } }
        public BindingSource ItemSource { get { return _gestionItem.ItemSource; } }
        public bool SalirIsOk
        {
            get
            {
                var rt = true;
                if (Importe > 0) { return false; }
                if (CantItem > 0) { return false; }
                return rt;
            }
        }


        public Gestion()
        {
            _modoFuncion = EnumModoFuncion.Facturacion;
            _permitirBusquedaPorDescripcion = true;

            _gestionListar = new Producto.Lista.Gestion();
            _gestionBuscar = new Producto.Buscar.Gestion();
            _gestionBuscar.setGestionLista(_gestionListar);
            _gestionCliente = new Cliente.Gestion();
            _gestionConsultor = new Consultor.Gestion();
            _gestionConsultor.setGestionBuscar(_gestionBuscar);
            _gestionDevolucion = new Devolucion.Gestion();
            _gestionMultiplicar = new Multiplicar.Gestion();
            _gestionPendiente = new Pendiente.Gestion();
            _gestionItem = new Item.Gestion();
            _gestionItem.Hnd_Item_Cambio += _gestionItem_Hnd_Item_Cambio;
            _gestionItem.setGestionMultiplicar(_gestionMultiplicar);
            _gestionItem.setGestionDevolucion(_gestionDevolucion);
            _gestionItem.setGestionPendiente(_gestionPendiente);
            _gestionProcesarPago = new Pago.Procesar.Gestion();
        }


        private void _gestionItem_Hnd_Item_Cambio(object sender, EventArgs e)
        {
            if (frm != null)
            {
                frm.ActualizarItem();
            }
        }

        public void Inicializa()
        {
            _tasaCambioActual = 0.0m;
        }

        PosFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new PosFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_FactorDivisa();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var r02 = Sistema.MyData.Deposito_GetFichaById(Sistema.ConfiguracionActual.idDeposito);
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            var r02_1 = Sistema.MyData.Concepto_GetFichaById (Sistema.ConfiguracionActual.idConceptoVenta);
            if (r02_1.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_1.Mensaje);
                return false;
            }
            var r02_2 = Sistema.MyData.Concepto_GetFichaById(Sistema.ConfiguracionActual.idConceptoDevVenta);
            if (r02_2.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_2.Mensaje);
                return false;
            }
            var r02_3 = Sistema.MyData.Sistema_TipoDocumento_GetFichaById(Sistema.ConfiguracionActual.idTipoDocumentoVenta);
            if (r02_3.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_3.Mensaje);
                return false;
            }
            var r02_4 = Sistema.MyData.Sistema_TipoDocumento_GetFichaById(Sistema.ConfiguracionActual.idTipoDocumentoDevVenta);
            if (r02_4.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_4.Mensaje);
                return false;
            }
            var r02_5 = Sistema.MyData.Sistema_TipoDocumento_GetFichaById(Sistema.ConfiguracionActual.idTipoDocumentoNotaEntrega);
            if (r02_5.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_5.Mensaje);
                return false;
            }
            var r02_6 = Sistema.MyData.Sucursal_GetFichaById (Sistema.ConfiguracionActual.idSucursal);
            if (r02_6.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_6.Mensaje);
                return false;
            }
            var r02_7 = Sistema.MyData.Vendedor_GetFichaById(Sistema.ConfiguracionActual.idVendedor);
            if (r02_7.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_7.Mensaje);
                return false;
            }
            var r02_8 = Sistema.MyData.Sistema_Serie_GetFichaById (Sistema.ConfiguracionActual.idSerieFactura);
            if (r02_8.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_8.Mensaje);
                return false;
            }
            var r02_9 = Sistema.MyData.Sistema_Serie_GetFichaById(Sistema.ConfiguracionActual.idSerieNotaCredito);
            if (r02_9.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_9.Mensaje);
                return false;
            }
            var r02_A = Sistema.MyData.Sistema_Serie_GetFichaById(Sistema.ConfiguracionActual.idSerieNotaEntrega);
            if (r02_A.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_A.Mensaje);
                return false;
            }
            var r02_B = Sistema.MyData.Sistema_Transporte_GetFichaById (Sistema.ConfiguracionActual.idTransporte);
            if (r02_B.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_B.Mensaje);
                return false;
            }
            var r02_C = Sistema.MyData.Sistema_Fiscal_GetTasas(new OOB.Sistema.TasaFiscal.Listar.Filtro());
            if (r02_C.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_C.Mensaje);
                return false;
            }
            var r02_D = Sistema.MyData.Sistema_Cobrador_GetFichaById(Sistema.ConfiguracionActual.idCobrador);
            if (r02_D.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_D.Mensaje);
                return false;
            }
            var r02_E = Sistema.MyData.Sistema_MedioPago_GetFichaById(Sistema.ConfiguracionActual.idMedioPagoEfectivo);
            if (r02_E.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_E.Mensaje);
                return false;
            }
            var r02_F = Sistema.MyData.Sistema_MedioPago_GetFichaById(Sistema.ConfiguracionActual.idMedioPagoDivisa);
            if (r02_F.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_F.Mensaje);
                return false;
            }
            var r02_G = Sistema.MyData.Sistema_MedioPago_GetFichaById(Sistema.ConfiguracionActual.idMedioPagoElectronico);
            if (r02_G.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_G.Mensaje);
                return false;
            }
            var r02_H = Sistema.MyData.Sistema_MedioPago_GetFichaById(Sistema.ConfiguracionActual.idMedioPagoOtros);
            if (r02_H.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02_H.Mensaje);
                return false;
            }

            var filtro = new OOB.Venta.Item.Lista.Filtro()
            {
                idOperador = Sistema.PosEnUso.id,
            };
            var r03 = Sistema.MyData.Venta_Item_GetLista(filtro);
            if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            _tasaCambioActual = r01.Entidad;
            _depositoAsignado = r02.Entidad;
            _conceptoVenta = r02_1.Entidad;
            _conceptoDevVenta = r02_2.Entidad;
            _tipoDocumentoVenta= r02_3.Entidad;
            _tipoDocumentoDevVenta=r02_4.Entidad;
            _tipoDocumentoNotaEntrega = r02_5.Entidad;
            _sucursalAsignada = r02_6.Entidad;
            _vendedorAsignado = r02_7.Entidad;
            _serieFactura = r02_8.Entidad;
            _serieNotaCredito = r02_9.Entidad;
            _serieNotaEntrega= r02_A.Entidad;
            _transporteAsignado = r02_B.Entidad;
            _tasaFiscal_1 = r02_C.ListaD.FirstOrDefault(f => f.codTasa == 1);
            _tasaFiscal_2 = r02_C.ListaD.FirstOrDefault(f => f.codTasa == 2);
            _tasaFiscal_3 = r02_C.ListaD.FirstOrDefault(f => f.codTasa == 3);
            _cobradorAsignado=r02_D.Entidad;
            _medioPagoEfectivo=r02_E.Entidad;
            _medioPagoDivisa=r02_F.Entidad;
            _medioPagoElectronico = r02_G.Entidad;
            _medioPagoOtro = r02_H.Entidad;

            _gestionBuscar.setDepositoAsignado(_depositoAsignado);
            _gestionBuscar.setTarifaPrecio(Sistema.ConfiguracionActual.idPrecioManejar);
            _gestionConsultor.setTarifaPrecio(Sistema.ConfiguracionActual.idPrecioManejar);
            _gestionItem.Inicializar();
            _gestionItem.setDepositoAsignado(_depositoAsignado);
            _gestionItem.setTarifaPrecio(Sistema.ConfiguracionActual.idPrecioManejar);
            _gestionItem.setValidarExistencia(Sistema.ConfiguracionActual.ValidarExistencia_Activa);
            _gestionItem.setData(r03.ListaD, _tasaCambioActual);

            return rt;
        }

        public void ClienteBuscar()
        {
            _gestionCliente.Inicializa();
            _gestionCliente.Inicia();
            _gestionItem.setItemActualInicializar();
        }

        public void Consultor()
        {
            _gestionConsultor.Inicializa();
            _gestionConsultor.setFactorCambio(_tasaCambioActual);
            _gestionConsultor.Inicia();
            _gestionItem.setItemActualInicializar();
        }

        public void BuscarProducto(string cadena)
        {
            if (cadena == "") { return; }

            if (_modoFuncion == EnumModoFuncion.Facturacion)
            {
                _gestionBuscar.GestionListar.setCantidadVisible(true);
                _gestionBuscar.GestionListar.setPrecioVisible(true);
                _gestionBuscar.ActivarBusqueda(cadena, _permitirBusquedaPorDescripcion);
                if (_gestionBuscar.BusquedaIsOk)
                {
                    _gestionItem.Inicializar();
                    _gestionItem.RegistraItem(_gestionBuscar.AutoProducto);
                }
                else
                    _gestionItem.setItemActualInicializar();
            }

        }

        public void AnularVenta()
        {
            _gestionItem.Inicializar();
            _gestionItem.AnularVenta();
            if (_gestionItem.AnularVentaIsOk)
            {
                _gestionCliente.Limpiar();
            }
            _gestionItem.setItemActualInicializar();
        }

        public void DevolucionItem()
        {
            _gestionItem.DevolucionItem();
        }

        public void IncrementarItem()
        {
            _gestionItem.Incrementar();
        }

        public void DecrementarItem()
        {
            _gestionItem.Decrementar();
        }

        public void Multiplicar()
        {
            _gestionItem.Multiplicar();
        }

        public void DejarCtaPendiente()
        {
            if (_gestionCliente.Cliente == null)
            {
                Helpers.Msg.Error("DEBE SELECCIONAR UN CLIENTE ANTES DE DEJAR LA CUENTA PENDIENTE");
            }
            else
            {
                _gestionItem.DejarCtaPendiente(_gestionCliente.Cliente);
                if (_gestionItem.DejarCtaPendienteIsOk)
                {
                    _gestionCliente.Limpiar();
                }
            }
            _gestionItem.setItemActualInicializar();
        }

        public void AbriCtaPendiente()
        {
            if (CntCtasPendientes > 0)
            {
                if (Importe == 0.0m && CantRenglones == 0)
                {
                    _gestionPendiente.Inicializar();
                    _gestionPendiente.Inicia();
                    if (_gestionPendiente.AbrirCtaPendienteIsOk)
                    {
                        ActualizarData();
                        if (_gestionPendiente.CtaPediente.Ficha != null) 
                        {
                            _gestionCliente.CargarCliente(_gestionPendiente.CtaPediente.Ficha.idCliente);
                        }
                    }
                }
                else
                {
                    Helpers.Msg.Error("HAY UNA CUENTA EN PROCESO");
                }
            }
            _gestionItem.setItemActualInicializar();
        }

        private void ActualizarData()
        {
            var filtro = new OOB.Venta.Item.Lista.Filtro()
            {
                idOperador = Sistema.PosEnUso.id,
            };
            var r01 = Sistema.MyData.Venta_Item_GetLista(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _gestionItem.setData(r01.ListaD, _tasaCambioActual);
        }

        public void Totalizar()
        {
            if (Importe > 0)
            {
                if (_gestionCliente.Cliente == null)
                {
                    Helpers.Msg.Error("DEBE SELECCIONAR UN CLIENTE PARA PROCESAR DOCUMENTO");
                    return;
                }
                _gestionProcesarPago.Inicializar();
                _gestionProcesarPago.setCliente(_gestionCliente.ClienteData);
                _gestionProcesarPago.setImporte(_gestionItem.Importe);
                _gestionProcesarPago.setTasaCambio(_tasaCambioActual);
                _gestionProcesarPago.Inicia();
                if (_gestionProcesarPago.PagoIsOk) 
                {
                    ProcesarFactura();
                }
            }
            _gestionItem.setItemActualInicializar();
        }

        private void ProcesarFactura()
        {

            var dsctoFinal= _gestionProcesarPago.DescuentoPorct;
            _gestionItem.setDescuentoFinal(dsctoFinal);

            var isCredito = _gestionProcesarPago.IsCredito;
            var montoRecibido = _gestionProcesarPago.MontoRecibido;
            var montoCambio = _gestionProcesarPago.MontoCambioDar_MonedaNacional;
            var BaseExenta= _gestionItem.Items.Sum(s=>s.BaseExenta);
            var MontoBase = _gestionItem.Items.Sum(s => s.MontoBase);
            var MontoImpuesto = _gestionItem.Items.Sum(s => s.MontoImpuesto);
            var MontoBase1= _gestionItem.Items.Where(w=>w.IdTasaFiscal==_tasaFiscal_1.id).Sum(s => s.MontoBase);
            var MontoBase2= _gestionItem.Items.Where(w=>w.IdTasaFiscal==_tasaFiscal_2.id).Sum(s => s.MontoBase);
            var MontoBase3= _gestionItem.Items.Where(w=>w.IdTasaFiscal==_tasaFiscal_3.id).Sum(s => s.MontoBase);
            var MontoImpuesto1 = _gestionItem.Items.Where(w=>w.IdTasaFiscal==_tasaFiscal_1.id).Sum(s => s.MontoImpuesto);
            var MontoImpuesto2 = _gestionItem.Items.Where(w=>w.IdTasaFiscal==_tasaFiscal_2.id).Sum(s => s.MontoImpuesto);
            var MontoImpuesto3 = _gestionItem.Items.Where(w=>w.IdTasaFiscal==_tasaFiscal_3.id).Sum(s => s.MontoImpuesto);
            var dsctoMonto = _gestionItem.Importe * dsctoFinal/100;
            var utilidadMonto = _gestionItem.Items.Sum(s=>s.Utilidad);
            var costoMonto = _gestionItem.Items.Sum(s=>s.CostoVenta);
            var subTotalNeto= _gestionItem.Items.Sum(s=>s.TotalNeto);
            var subTotal= _gestionItem.Importe- dsctoMonto;
            var netoMonto= _gestionItem.Items.Sum(s=>s.VentaNeta);

            var importeDocumento= _gestionProcesarPago.MontoPagar;
            var importeDocumentoDivisa = _gestionProcesarPago.MontoPagarDivisa;
            var documento="XYZ123";
            var factorCambio = _tasaCambioActual;
            var saldoPendiente=isCredito?importeDocumento:0.0m;

            var fichaOOB = new OOB.Documento.Agregar.Factura.Ficha()
            {
                DocumentoNro = documento,
                RazonSocial = _gestionCliente.Cliente.Nombre,
                DirFiscal = _gestionCliente.Cliente.DireccionFiscal,
                CiRif = _gestionCliente.Cliente.CiRif,
                Tipo = _tipoDocumentoVenta.codigo,
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
                Tasa1 = _tasaFiscal_1.tasa,
                Tasa2 = _tasaFiscal_2.tasa,
                Tasa3 = _tasaFiscal_3.tasa,
                Nota = "",
                TasaRetencionIva = 0.0m,
                TasaRetencionIslr = 0.0m,
                RetencionIva = 0.0m,
                RetencionIslr = 0.0m,
                AutoCliente = _gestionCliente.Cliente.Id,
                CodigoCliente = _gestionCliente.Cliente.Codigo,
                Control = _serieFactura.Control,
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
                Telefono = _gestionCliente.Cliente.Telefono,
                FactorCambio = factorCambio,
                CodigoVendedor = _vendedorAsignado.codigo,
                Vendedor = _vendedorAsignado.nombre,
                AutoVendedor = _vendedorAsignado.id,
                FechaPedido = DateTime.Now.Date,
                Pedido = "",
                CondicionPago = isCredito ? "CREDITO" : "CONTADO",
                Usuario = Sistema.Usuario.nombre,
                CodigoUsuario = Sistema.Usuario.codigo,
                CodigoSucursal = _sucursalAsignada.codigo,
                Transporte = _transporteAsignado.nombre,
                CodigoTransporte = _transporteAsignado.codigo,
                MontoDivisa = importeDocumentoDivisa,
                Despachado = "",
                DirDespacho = "",
                Estacion = Sistema.EquipoEstacion,
                Renglones = _gestionItem.CantRenglones,
                SaldoPendiente = saldoPendiente,
                ComprobanteRetencionIslr = "",
                DiasValidez = 0,
                AutoUsuario = Sistema.Usuario.id,
                AutoTransporte = _transporteAsignado.id,
                Situacion = "Procesado",
                Signo = _tipoDocumentoVenta.signo,
                Serie = _serieFactura.Serie,
                Tarifa = Sistema.ConfiguracionActual.idPrecioManejar,
                TipoRemision = "",
                DocumentoRemision = "",
                AutoRemision = "",
                DocumentoNombre = "VENTA",
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
                DocumentoTipo = _tipoDocumentoVenta.tipo,
                CiTitular = "",
                NombreTitular = "",
                CiBeneficiario = "",
                NombreBeneficiario = "",
                Clave = "",
                DenominacionFiscal = "No Contribuyente",
                Cambio = montoCambio,
                EstatusValidado = "0",
                Cierre = Sistema.PosEnUso.idAutoArqueoCierre,
                EstatusCierreContable = "0",
                CierreFtp = "",
                Prefijo=_sucursalAsignada.codigo+Sistema.IdEquipo,
            };

            var detalles = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.Factura.FichaDetalle()
                {
                    AutoProducto = s.Ficha.autoProducto,
                    Codigo = s.Ficha.codigo,
                    Nombre = s.Ficha.nombre,
                    AutoDepartamento = s.Ficha.autoDepartamento,
                    AutoGrupo = s.Ficha.autoGrupo,
                    AutoSubGrupo = s.Ficha.autoSubGrupo,
                    AutoDeposito = s.Ficha.autoDeposito,
                    Cantidad = s.Ficha.cantidad,
                    Empaque = s.Ficha.empaqueDescripcion,
                    PrecioNeto = s.Ficha.pneto,
                    Descuento1p = 0.0m,
                    Descuento2p = 0.0m,
                    Descuento3p = 0.0m,
                    Descuento1 = 0.0m,
                    Descuento2 = 0.0m,
                    Descuento3 = 0.0m,
                    CostoVenta = s.CostoVenta,
                    TotalNeto = s.TotalNeto,
                    Tasa = s.Ficha.tasaIva,
                    Impuesto = s.Impuesto,
                    Total = s.Total,
                    EstatusAnulado = "0",
                    Tipo = _tipoDocumentoVenta.codigo,
                    Deposito = _depositoAsignado.nombre,
                    Signo = _tipoDocumentoVenta.signo,
                    PrecioFinal = s.PrecioFinal,
                    AutoCliente = _gestionCliente.Cliente.Id,
                    Decimales = s.Ficha.decimales,
                    ContenidoEmpaque = s.Ficha.empaqueContenido,
                    CantidadUnd = s.TotalUnd,
                    PrecioUnd = s.PrecioUnd,
                    CostoUnd = s.Ficha.costoUnd,
                    Utilidad = s.Utilidad,
                    Utilidadp = s.UtilidadP,
                    PrecioItem = s.PrecioItem,
                    EstatusGarantia = "0",
                    EstatusSerial = "0",
                    CodigoDeposito = _depositoAsignado.codigo,
                    DiasGarantia = 0,
                    Detalle = "",
                    PrecioSugerido = 0.0m,
                    AutoTasa = s.Ficha.autoTasa,
                    EstatusCorte = "0",
                    X = 1,
                    Y = 1,
                    Z = 1,
                    Corte = "",
                    Categoria = s.Ficha.categoria,
                    Cobranzap = 0.0m,
                    Ventasp = 0.0m,
                    CobranzapVendedor = 0.0m,
                    VentaspVendedor = 0.0m,
                    Cobranza = 0.0m,
                    Ventas = 0.0m,
                    CobranzaVendedor = 0.0m,
                    VentasVendedor = 0.0m,
                    CostoPromedioUnd = s.Ficha.costoPromedioUnd,
                    CostoCompra = s.Ficha.costoCompra,
                    EstatusChecked = "1",
                    Tarifa = Sistema.ConfiguracionActual.idPrecioManejar,
                    TotalDescuento = 0.0m,
                    CodigoVendedor = _vendedorAsignado.codigo,
                    AutoVendedor = _vendedorAsignado.id,
                    CierreFtp = "",
                };
                return nr;
            }).ToList();
            fichaOOB.Detalles = detalles;

            var actDeposito = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.Factura.FichaDeposito()
                {
                    AutoDeposito = s.Ficha.autoDeposito,
                    AutoProducto = s.Ficha.autoProducto,
                    CantUnd = s.TotalUnd,
                };
                return nr;
            }).ToList();
            fichaOOB.ActDeposito = actDeposito;

            var kardex = _gestionItem.Items.Select(s =>
            {
                var nr = new OOB.Documento.Agregar.Factura.FichaKardex()
                {
                    AutoProducto = s.Ficha.autoProducto,
                    Total = s.TotalUnd * s.Ficha.costoUnd,
                    AutoDeposito = s.Ficha.autoDeposito,
                    AutoConcepto = _conceptoVenta.id,
                    Documento = documento,
                    Modulo = "Ventas",
                    Entidad = _gestionCliente.Cliente.Nombre,
                    Signo = -1,
                    Cantidad = s.Cantidad,
                    CantidadBono = 0.0m,
                    CantidadUnd = s.TotalUnd,
                    CostoUnd = s.Ficha.costoPromedioUnd,
                    EstatusAnulado = "0",
                    Nota = "",
                    PrecioUnd = s.PrecioFinal,
                    Codigo = _tipoDocumentoVenta.codigo,
                    Siglas = _tipoDocumentoVenta.siglas,
                    CierreFtp = "",
                    CodigoSucursal = _sucursalAsignada.codigo,
                    CodigoDeposito = _depositoAsignado.codigo,
                    NombreDeposito = _depositoAsignado.nombre,
                    CodigoConcepto = _conceptoVenta.codigo,
                    NombreConcepto = _conceptoVenta.nombre,
                };
                return nr;
            }).ToList();
            fichaOOB.MovKardex = kardex;

            fichaOOB.DocCxC = new OOB.Documento.Agregar.Factura.FichaCxC()
            {
                CCobranza=0.0m,
                CCobranzap=0.0m,
                TipoDocumento = _tipoDocumentoVenta.siglas,
                Documento = documento,
                Nota="",
                Importe = importeDocumento ,
                Acumulado = isCredito?0.0m:importeDocumento,
                AutoCliente = _gestionCliente.Cliente.Id,
                Cliente = _gestionCliente.Cliente.Nombre,
                CiRif = _gestionCliente.Cliente.CiRif,
                CodigoCliente = _gestionCliente.Cliente.Codigo,
                EstatusCancelado = isCredito?"0":"1",
                Resta=isCredito?importeDocumento:0.0m,
                EstatusAnulado = "0",
                Numero="",
                AutoAgencia = "0000000001",
                Agencia="",
                Signo = _tipoDocumentoVenta.signo,
                AutoVendedor = _vendedorAsignado.id,
                CDepartamento=0.0m,
                CVentas=0.0m,
                CVentasp=0.0m,
                Serie = _serieFactura.Serie ,
                ImporteNeto = netoMonto,
                Dias=0,
                CastigoP=0.0m,
                CierreFtp="", 
            };

            if (isCredito)
            {
                fichaOOB.DocCxCPago = null;
            }
            else 
            {
                fichaOOB.DocCxCPago = new OOB.Documento.Agregar.Factura.FichaCxCPago();
                var p = new OOB.Documento.Agregar.Factura.FichaCxC()
                {
                    CCobranza = 0.0m,
                    CCobranzap = 0.0m,
                    TipoDocumento = "PAG",
                    Nota = "",
                    Importe = importeDocumento,
                    Acumulado = 0.0m,
                    AutoCliente = _gestionCliente.Cliente.Id,
                    Cliente = _gestionCliente.Cliente.Nombre,
                    CiRif = _gestionCliente.Cliente.CiRif,
                    CodigoCliente = _gestionCliente.Cliente.Codigo,
                    EstatusCancelado = "0",
                    Resta = 0.0m,
                    EstatusAnulado = "0",
                    Numero = "",
                    AutoAgencia = "0000000001",
                    Agencia = "",
                    Signo = -1,
                    AutoVendedor = _vendedorAsignado.id,
                    CDepartamento = 0.0m,
                    CVentas = 0.0m,
                    CVentasp = 0.0m,
                    Serie = "",
                    ImporteNeto = 0.0m,
                    Dias = 0,
                    CastigoP = 0.0m,
                    CierreFtp = "",
                };
                var pR = new OOB.Documento.Agregar.Factura.FichaCxCRecibo()
                {
                    AutoUsuario = Sistema.Usuario.id,
                    Importe = importeDocumento,
                    Usuario = Sistema.Usuario.nombre,
                    MontoRecibido = montoRecibido,
                    Cobrador = _cobradorAsignado.nombre,
                    AutoCliente = _gestionCliente.Cliente.Id,
                    Cliente = _gestionCliente.Cliente.Nombre,
                    CiRif = _gestionCliente.Cliente.CiRif,
                    Codigo = _gestionCliente.Cliente.Codigo,
                    EstatusAnulado = "0",
                    Direccion = _gestionCliente.Cliente.DireccionFiscal,
                    Telefono = _gestionCliente.Cliente.Telefono,
                    AutoCobrador = _cobradorAsignado.id,
                    Anticipos = 0.0m,
                    Cambio = montoCambio,
                    Nota = "",
                    CodigoCobrador = _cobradorAsignado.codigo,
                    Retenciones = 0.0m,
                    Descuentos = 0.0m,
                    Cierre = Sistema.PosEnUso.idAutoArqueoCierre,
                    CierreFtp = "",
                };
                var pD = new OOB.Documento.Agregar.Factura.FichaCxCDocumento()
                {
                    Id = 1,
                    Documento = documento,
                    TipoDocumento = "FAC",
                    Operacion = "Pago",
                    Importe = importeDocumento ,
                    Dias = 0,
                    CastigoP = 0.0m,
                    ComisionP = 0.0m,
                    CierreFtp = "",
                };
                var pM = new List<OOB.Documento.Agregar.Factura.FichaCxCMetodoPago>();
                foreach (var it in _gestionProcesarPago.PagoDetalles) 
                {
                    var autoMedioPago = "";
                    var codigoMedioPago = "";
                    var descMedioPago = "";
                    var lote = "";
                    var referencia = "";
                    var montoRecibe = it.MontoRecibido;

                    switch (it.Modo) 
                    {
                        case Pago.Procesar.Enumerados.ModoPago.Efectivo:
                            autoMedioPago = _medioPagoEfectivo.id;
                            codigoMedioPago = _medioPagoEfectivo.codigo;
                            descMedioPago = _medioPagoEfectivo.nombre;
                            break;
                        case Pago.Procesar.Enumerados.ModoPago.Divisa:
                            montoRecibe = it.Monto;
                            autoMedioPago = _medioPagoDivisa.id;
                            codigoMedioPago = _medioPagoDivisa.codigo;
                            descMedioPago = _medioPagoDivisa.nombre;
                            lote = it.Cantidad.ToString("n2");
                            referencia = TasaCambioActual.ToString("n0").Replace(".","");
                            break;
                        case Pago.Procesar.Enumerados.ModoPago.Electronico:
                            autoMedioPago =  _medioPagoElectronico.id;
                            codigoMedioPago = _medioPagoElectronico.codigo;
                            descMedioPago = _medioPagoElectronico.nombre;
                            lote = it.Lote;
                            referencia = it.Referencia;
                            break;
                        case Pago.Procesar.Enumerados.ModoPago.Otro:
                            autoMedioPago = _medioPagoOtro.id;
                            codigoMedioPago = _medioPagoOtro.codigo;
                            descMedioPago = _medioPagoOtro.nombre;
                            lote = it.Lote;
                            referencia = it.Referencia;
                            break;
                    }

                    pM.Add(new OOB.Documento.Agregar.Factura.FichaCxCMetodoPago()
                    {
                        AutoMedioPago = autoMedioPago ,
                        AutoAgencia="",
                        Medio = descMedioPago ,
                        Codigo = codigoMedioPago ,
                        MontoRecibido = montoRecibe,
                        EstatusAnulado = "0",
                        Numero="",
                        Agencia="",
                        AutoUsuario = Sistema.Usuario.id ,
                        Lote=lote,
                        Referencia=referencia,
                        AutoCobrador= _cobradorAsignado.id,
                        Cierre=Sistema.PosEnUso.idAutoArqueoCierre,
                        CierreFtp="",
                    });
                }
                fichaOOB.DocCxCPago.Pago = p;
                fichaOOB.DocCxCPago.Recibo = pR;
                fichaOOB.DocCxCPago.Documento = pD;
                fichaOOB.DocCxCPago.MetodoPago = pM;
            }

            var r01 = Sistema.MyData.Documento_Agregar_Factura(fichaOOB);
            if (r01.Result ==  OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
        }

    }

}