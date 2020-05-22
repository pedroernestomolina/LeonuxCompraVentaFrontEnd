using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion
{

    public class Venta
    {

        public event EventHandler ProcesarOk;


        private OOB.LibVenta.PosOffline.Usuario.Ficha _usuario;
        private OOB.LibVenta.PosOffline.Fiscal.Ficha _fiscal;
        private OOB.LibVenta.PosOffline.Configuracion.Deposito.Ficha _deposito;
        private OOB.LibVenta.PosOffline.Configuracion.Vendedor.Ficha _vendedor;
        private OOB.LibVenta.PosOffline.Configuracion.Cobrador.Ficha _cobrador;
        private OOB.LibVenta.PosOffline.Configuracion.Transporte.Ficha _transporte;
        private OOB.LibVenta.PosOffline.Configuracion.MedioCobro.Ficha _medioCobro;
        private OOB.LibVenta.PosOffline.Permiso.Pos.Ficha _permisos;
        private CtrCliente _ctrCliente;
        private CtrItem _ctrItem;


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
        }


        Pago.PagoFrm procesarFrm; 
        public void Procesar() 
        {
            if (_ctrCliente.Cliente == null) 
            {
                return;
            }
            if (_ctrCliente.Cliente.Id == -1)
            {
                return;
            }
            if (_ctrItem.Items == null)
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

            procesarFrm = new Facturacion.Pago.PagoFrm();
            procesarFrm.Inicializa(_ctrCliente, this);
            procesarFrm.ShowDialog();
            if (procesarFrm.PagoIsOk)
            {
                GuardarFactura(procesarFrm.Pago);
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


            _ctrItem.setDescuentoGlobal(_dsctoGlobalPorct);
            _ctrItem.setCargoGlobal(_cargoGlobalPorct);
            var ficha = new OOB.LibVenta.PosOffline.VentaDocumento.Agregar()
            {
                Aplica = "",
                AutoUsuario = _usuario.Auto,
                ClienteCiRif = _ctrCliente.Cliente.CiRif,
                ClienteDirFiscal = _ctrCliente.Cliente.DirFiscal,
                ClienteNombreRazonSocial = _ctrCliente.Cliente.NombreRazaonSocial,
                ClienteTelefono = _ctrCliente.Cliente.Telefono,
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
                Serie = SerieFactura,
                SignoDocumento = 1,
                TasaIva_1 = _fiscal.Tasa1,
                TasaIva_2 = _fiscal.Tasa2,
                TasaIva_3 = _fiscal.Tasa3,
                TipoDocumento = OOB.LibVenta.PosOffline.VentaDocumento.Enumerados.EnumTipoDocumento.Factura,
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

                var nrEliminar = new OOB.LibVenta.PosOffline.VentaDocumento.AgregarItemEliminar()
                {
                    IdEliminar = rg.Id,
                };
                fichaItemsEliminar.Add(nrEliminar);

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
            Helpers.Msg.AgregarOk();
            Notificar();
        }

        private void Notificar()
        {
            EventHandler handler = ProcesarOk;
            if (handler != null) 
            {
                handler(this, null);
            }
        }

    }

}