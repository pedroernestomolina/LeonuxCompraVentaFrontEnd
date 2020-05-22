using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MovVenta.Venta.VentaAdministrativa
{
    
    public class Venta
    {

        public event EventHandler AgregarOK;


        public OOB.LibVenta.Usuario.Ficha Usuario { get; set; }
        public OOB.LibVenta.Cliente.Ficha Cliente { get; set; }
        public OOB.LibVenta.MovInventario.Concepto.Ficha ConceptoMovInv { get; set; }
        public bool IsContado { get; set; }
        public int DiasCredito { get; set; }
        public OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio TarifaPrecio { get; set; }
        public string DireccionDespacho { get; set; }
        public DateTime FechaPedido { get; set; }
        public string OrdenCompraNro { get; set; }
        public string PedidoNro { get; set; }
        public string NotasDocumento { get; set; }
        public DateTime FechaEmision { get; set; }

        public OOB.LibVenta.Sucursal.Ficha Sucursal { get { return _sucursal; } }
        public OOB.LibVenta.Vendedor.Ficha Vendedor { get { return _vendedor; } }
        public OOB.LibVenta.Cobrador.Ficha Cobrador { get { return _cobrador; } }
        public OOB.LibVenta.Deposito.Ficha Deposito { get { return _deposito; } }
        public OOB.LibVenta.Transporte.Ficha Transporte { get { return _transporte; } }
        public OOB.LibVenta.Series.Ficha Serie { get { return _serie; } }
        public Enumerados.EnumModoImpresion ModoImpresion { get { return _modoImpresion; } }

        public BindingSource SourceSucursal { get { return bsSucursal; } }
        public BindingSource SourceVendedor { get { return bsVendedor; } }
        public BindingSource SourceCobrador { get { return bsCobrador; } }
        public BindingSource SourceDeposito { get { return bsDeposito; } }
        public BindingSource SourceTransporte { get { return bsTransporte; } }
        public BindingSource SourceSerie { get { return bsSerie; } }
        public BindingSource SourceModoImpresion { get { return bsModoImpresion ; } }

        private BindingSource bsSucursal;
        private BindingList<OOB.LibVenta.Sucursal.Ficha> blSucursal;
        private BindingSource bsDeposito;
        private BindingList<OOB.LibVenta.Deposito.Ficha> blDeposito;
        private BindingSource bsVendedor;
        private BindingList<OOB.LibVenta.Vendedor.Ficha> blVendedor;
        private BindingSource bsCobrador;
        private BindingList<OOB.LibVenta.Cobrador.Ficha> blCobrador;
        private BindingSource bsTransporte;
        private BindingList<OOB.LibVenta.Transporte.Ficha> blTransporte;
        private BindingSource bsSerie;
        private BindingList<OOB.LibVenta.Series.Ficha> blSerie;
        private BindingSource bsModoImpresion;

        private OOB.LibVenta.Vendedor.Ficha _vendedor;
        private OOB.LibVenta.Cobrador.Ficha _cobrador;
        private OOB.LibVenta.Deposito.Ficha _deposito;
        private OOB.LibVenta.Sucursal.Ficha _sucursal;
        private OOB.LibVenta.Transporte.Ficha _transporte;
        private OOB.LibVenta.Series.Ficha _serie;
        private Enumerados.EnumModoImpresion _modoImpresion;
        private decimal _factorCambioParaRecibirDivisa;
        private List<Detalle> Items;
        private OOB.LibVenta.Fiscal.Ficha _tasasFiscales;


        public string MesRelacion 
        {
            get 
            {
                var rt = "";
                rt = FechaEmision.Month.ToString().Trim().PadLeft(2, '0');
                return rt;
            }
        }

        public string AnoRelacion
        {
            get
            {
                var rt = "";
                rt = FechaEmision.Year.ToString().Trim();
                return rt;
            }
        }


        public Venta() 
        {
            IsContado = true;
            DiasCredito = 0;
            TarifaPrecio = OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio.SinDefinir; 
            Cliente = null;
            Usuario = null;
            Items = null;

            //
            blDeposito = new BindingList<OOB.LibVenta.Deposito.Ficha>();
            bsDeposito = new BindingSource();
            bsDeposito.CurrentChanged += bsDeposito_CurrentChanged;
            bsDeposito.DataSource = blDeposito;
            //
            blSucursal = new BindingList<OOB.LibVenta.Sucursal.Ficha>();
            bsSucursal = new BindingSource();
            bsSucursal.CurrentChanged += bsSucursal_CurrentChanged;
            bsSucursal.DataSource = blSucursal;
            //
            blVendedor = new BindingList<OOB.LibVenta.Vendedor.Ficha>();
            bsVendedor = new BindingSource();
            bsVendedor.CurrentChanged += bsVendedor_CurrentChanged;
            bsVendedor.DataSource = blVendedor;
            //
            blCobrador = new BindingList<OOB.LibVenta.Cobrador.Ficha>();
            bsCobrador = new BindingSource();
            bsCobrador.CurrentChanged += bsCobrador_CurrentChanged;
            bsCobrador.DataSource = blCobrador;
            //
            blTransporte = new BindingList<OOB.LibVenta.Transporte.Ficha>();
            bsTransporte = new BindingSource();
            bsTransporte.CurrentChanged += bsTransporte_CurrentChanged;
            bsTransporte.DataSource = blTransporte;
            //
            blSerie = new BindingList<OOB.LibVenta.Series.Ficha>();
            bsSerie = new BindingSource();
            bsSerie.CurrentChanged += bsSerie_CurrentChanged;
            bsSerie.DataSource = blSerie;
            //
            string[] modoImpresion = { "FISCAL" , "TEXTO/FORMA LIBRE", "GRAFICO", "CONTINGENCIA" };
            bsModoImpresion = new BindingSource();
            bsModoImpresion.CurrentChanged+=bsModoImpresion_CurrentChanged; 
            bsModoImpresion.DataSource = modoImpresion;
            //
        }

        private void bsModoImpresion_CurrentChanged(object sender, EventArgs e)
        {
             _modoImpresion = (Enumerados.EnumModoImpresion)bsModoImpresion.Position ;
        }

        private void bsSerie_CurrentChanged(object sender, EventArgs e)
        {
            _serie = (OOB.LibVenta.Series.Ficha ) bsSerie.Current;
        }

        private void bsTransporte_CurrentChanged(object sender, EventArgs e)
        {
            _transporte = (OOB.LibVenta.Transporte.Ficha)bsTransporte.Current;
        }

        private void bsCobrador_CurrentChanged(object sender, EventArgs e)
        {
            _cobrador = (OOB.LibVenta.Cobrador.Ficha)bsCobrador.Current;
        }

        private void bsVendedor_CurrentChanged(object sender, EventArgs e)
        {
            _vendedor = (OOB.LibVenta.Vendedor.Ficha)bsVendedor.Current;
        }

        private void bsSucursal_CurrentChanged(object sender, EventArgs e)
        {
            _sucursal = (OOB.LibVenta.Sucursal.Ficha)bsSucursal.Current;
        }

        private void bsDeposito_CurrentChanged(object sender, EventArgs e)
        {
            _deposito = (OOB.LibVenta.Deposito.Ficha)bsDeposito.Current;
        }

        
        public int Renglones 
        {
            get 
            {
                var rt = 0;
                rt = Items.Count();
                return rt;
            }
        }

        public decimal SubTotal 
        {
            get 
            {
                return Items.Sum(s => s.Total);
            }
        }

        public string TarifaPrecioDescripcion
        {
            get
            {
                var dt = "";
                switch (TarifaPrecio)
                {
                    case OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio.Tarifa_1:
                        dt = "PRECIO #1";
                        break;
                    case OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio.Tarifa_2:
                        dt = "PRECIO #2";
                        break;
                    case OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio.Tarifa_3:
                        dt = "PRECIO #3";
                        break;
                    case OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio.Tarifa_4:
                        dt = "PRECIO #4";
                        break;
                }
                return dt;
            }
        }

        public decimal SubTotalNeto
        {
            get
            {
                var rt = 0.0m;
                rt = Items.Sum(sm => sm.Importe);
                return rt;
            }
        }

        public decimal MontoBase 
        {
            get 
            {
                var rt = 0.0m;
                rt = Items.Sum(sm => sm.ItemMontoBase);
                return rt;
            }
        }

        public decimal MontoBaseX(string tasa)
        {
            var rt = 0.0m;
            rt = Items.Where(w=>w.Producto.TipoIva==tasa).Sum(sm => sm.ItemMontoBase);
            return rt;
        }

        public decimal MontoIvaX(string tasa)
        {
            var rt = 0.0m;
            rt = Items.Where(w=>w.Producto.TipoIva==tasa).Sum(sm => sm.ItemMontoIva);
            return rt;
        }

        public decimal MontoExento
        {
            get
            {
                var rt = 0.0m;
                rt = Items.Sum(sm => sm.ItemMontoExento);
                return rt;
            }
        }

        public decimal MontoIva
        {
            get
            {
                var rt = 0.0m;
                rt = Items.Sum(sm => sm.ItemMontoIva);
                return rt;
            }
        }


        public bool CargarData()
        {
            var rt = true;

            //
            var r01 = Program.MyData.DepositoLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            blDeposito.Clear();
            foreach (var it in r01.Lista)
            {
                blDeposito.Add(it);
            }
            //
            var r02 = Program.MyData.SucursalLista();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            blSucursal.Clear();
            foreach (var it in r02.Lista)
            {
                blSucursal.Add(it);
            }
            //
            var r03 = Program.MyData.VendedorLista();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            blVendedor.Clear();
            foreach (var it in r03.Lista)
            {
                blVendedor.Add(it);
            }
            //
            var r04 = Program.MyData.CobradorLista();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }
            blCobrador.Clear();
            foreach (var it in r04.Lista)
            {
                blCobrador.Add(it);
            }
            //
            var r05 = Program.MyData.TransporteLista();
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }
            blTransporte.Clear();
            foreach (var it in r05.Lista)
            {
                blTransporte.Add(it);
            }

            //
            var r06 = Program.MyData.SeriesLista();
            if (r06.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return false;
            }
            blSerie.Clear();
            foreach (var it in r06.Lista)
            {
                blSerie.Add(it);
            }

            //
            var r07 = Program.MyData.TasasFiscales();
            if (r07.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r07.Mensaje);
                return false;
            }
            _tasasFiscales = r07.Entidad;

            return rt;
        }

        public void setDescuentoGlobal(decimal porct) 
        {
            foreach (Detalle it in Items) 
            {
                it.setDescuentoGlobal(porct);
            }
        }

        public void setConceptoMovInv(OOB.LibVenta.MovInventario.Concepto.Ficha ficha) 
        {
            ConceptoMovInv = ficha;
        }

        public void setItems(List<Detalle> _items) 
        {
            Items = _items;
        }

        public void setFactorCambioParaRecibirDivisa(decimal factor) 
        {
            _factorCambioParaRecibirDivisa=factor;
        }

        public void Procesar(Totalizar totalizar) 
        {
            var tarifa = "";
            switch (Cliente.TarifaPrecio)
            {
                case OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio.Tarifa_1:
                    tarifa = "1";
                    break;
                case OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio.Tarifa_2:
                    tarifa = "2";
                    break;
                case OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio.Tarifa_3:
                    tarifa = "3";
                    break;
                case OOB.LibVenta.Cliente.Enumerados.enumTarifaPrecio.Tarifa_4:
                    tarifa = "4";
                    break;
            }

            var ficha = new OOB.LibVenta.Venta.Generar.Agregar()
            {
                AutoCliente = Cliente.Auto,
                AutoCobrador = Cobrador.Auto,
                AutoUsuario = Usuario.Auto,
                AutoVendedor = Vendedor.Auto,
                AutoTransporte = Transporte.Auto,
                ClienteCiRif = Cliente.CiRif,
                ClienteCodigo = Cliente.Codigo,
                ClienteDenominacionFiscal = Cliente.DenominacionFiscalDescripcion,
                ClienteDirFiscal = Cliente.DireccionFiscal,
                ClienteNombre = Cliente.Nombre,
                ClienteTarifa = tarifa,
                ClienteTelefono = Cliente.Telefono_1,
                CobradorCodigo = Cobrador.Codigo,
                CobradorNombre = Cobrador.Nombre,
                CodigoSucursal = Sucursal.Codigo,
                Estacion = Environment.MachineName.ToString(),
                FactorCambio = _factorCambioParaRecibirDivisa,
                MontoRecibido = 0.0m,
                Renglones = Renglones,
                UsuarioCodigo = Usuario.Codigo,
                UsuarioNombre = Usuario.Descripcion,
                VendedorCodigo = Vendedor.Codigo,
                VendedorNombre = Vendedor.Nombre,
                TransporteCodigo = Transporte.Codigo,
                TransporteNombre = Transporte.Nombre,
                CondicionPago = IsContado ? OOB.LibVenta.Venta.Enumerados.enumCondicionPago.Contado : OOB.LibVenta.Venta.Enumerados.enumCondicionPago.Credito,
                DiasCredito = DiasCredito,
                Notas = NotasDocumento,
                SerialFiscal = "",
                CondicionPagoDescripcion=IsContado ? "CONTADO":"CREDITO",
                DocumentoCodigo="01",
                DocumentoSituacion="Procesado",
                DocumentoTipo="Ventas",
                DocumentoNombre="VENTA",
                DocumentoSigno=1,
                MesRelacion=MesRelacion,
                AnoRelacion=AnoRelacion,
                CambioDar=0,
            };

            var encabezado = new OOB.LibVenta.Venta.Generar.AgregarEncabezado()
            {
                AutoRemision = "",
                DepachadoPor = "",
                DireccionDespacho = DireccionDespacho,
                DocumentoRemision = "",
                FechaPedido = FechaPedido,
                OrdenCompra = OrdenCompraNro,
                Pedido = PedidoNro,
                Serie = "",
                TipoRemision = "", 
            };
            ficha.AgregarEncabezado = encabezado;

            foreach (Detalle dt in Items) 
            {
                dt.setDescuentoGlobal(totalizar.DsctGlobal);
                dt.setCargoGlobal(totalizar.CargoGlobal);
            }
            
            var _montoDivisa=0.0m;
            if (_factorCambioParaRecibirDivisa>0)
            {
                _montoDivisa=totalizar.Total/_factorCambioParaRecibirDivisa;
            }
            var _saldoPendiente=totalizar.Total;
            if (IsContado)
            {
                _saldoPendiente=0.0m;
            }
            var _ventaNeta=Items.Sum(sm=>sm.VentaNeta);
            var _costoVenta=Items.Sum(sm=>sm.CostoVenta );
            var _utilidad=Items.Sum(sm=>sm.UtilidadMonto);
            var _utilidadMargen=Items.Average(sm=>sm.UtilidadMargen);
            
            var totales = new OOB.LibVenta.Venta.Generar.AgregarTotal()
            {
                VentaNeta=_ventaNeta,
                CostoVenta=_costoVenta,
                Utilidad=_utilidad,
                UtilidadPorc=_utilidadMargen,

                SubTotalNeto = SubTotalNeto,
                DescuentoMonto_1 = totalizar.MontoDsctGlobal,
                DescuentoMonto_2 = 0.0m,
                DescuentoPorct_1 = totalizar.DsctGlobal,
                DescuentoPorct_2 = 0.0m,
                CargoMonto = totalizar.MontoCargoGlobal,
                CargoPorct = totalizar.CargoGlobal,

                SubTotal = (totalizar.Total - MontoIva),
                SubTotalImpuesto=MontoIva,

                MontoTotal = totalizar.Total,
                MontoBase = MontoBase,
                MontoImpuesto = MontoIva,
                MontoExento = MontoExento,
                MontoBase1 = MontoBaseX("1"),
                MontoBase2 = MontoBaseX("2"),
                MontoBase3 = MontoBaseX("3"),
                MontoImp1 = MontoIvaX("1"),
                MontoImp2 = MontoIvaX("2"),
                MontoImp3 = MontoIvaX("3"),
                Tasa1 = _tasasFiscales.Tasa1 ,
                Tasa2 = _tasasFiscales.Tasa2,
                Tasa3 = _tasasFiscales.Tasa3,

                MontoDivisa= _montoDivisa,
                SaldoPendiente=_saldoPendiente,
            };
            ficha.AgregarTotales = totales;


            var cxc = new OOB.LibVenta.Venta.Generar.AgregarCxc()
            {
                AutoCliente=Cliente.Auto ,
                AutoVendedor=Vendedor.Auto ,
                ClienteCiRif=Cliente.CiRif,
                ClienteCodigo=Cliente.Codigo,
                ClienteNombre=Cliente.Nombre,
                DocumentoVentaSerie="",
                DocumentoVentaTipo="FAC",
                IsCancelado=IsContado?true:false,
                MontoAcumulado=IsContado?totalizar.Total:0.00m,
                MontoImporteNeto=(totalizar.Total - MontoIva),
                MontoImporteTotal=totalizar.Total,
                MontoResta=IsContado?0.00m:totalizar.Total,
                Notas="",
                Signo=1,
            };
            ficha.AgregarCxc = cxc;

           
            var lmv= new List<OOB.LibVenta.Venta.Generar.AgregarKardex>();
            var lapd= new List<OOB.LibVenta.Venta.Generar.AgregarActProductoDeposito>();
            var lc = new List<OOB.LibVenta.Venta.Generar.AgregarCuerpo>();
            foreach (Detalle dt in Items) 
            {
                var mv=new OOB.LibVenta.Venta.Generar.AgregarKardex()
                {
                    AutoProducto= dt.Producto.Auto,
                    AutoConcepto=ConceptoMovInv.Auto,
                    AutoDeposito=Deposito.Auto,
                    Cantidad=dt.Cantidad,
                    CantidadUnd=dt.Cantidad,
                    CostoUndPromedio=dt.Producto.CostoPromedioUnidad,
                    Entidad=ficha.ClienteNombre,
                    PrecioUnd=dt.Precio.PrecioFinal,
                    TotalCostoVenta=dt.CostoVenta,
                    Codigo="01",
                    Siglas="FAC",
                    Signo =-1,
                    Notas="",
                    Modulo="Ventas",
                };
                lmv.Add(mv);

                var apd=new OOB.LibVenta.Venta.Generar.AgregarActProductoDeposito()
                {
                     AutoProducto=dt.Producto.Auto,
                     AutoDeposito=Deposito.Auto,
                     TotalUnd=dt.Cantidad,
                };
                lapd.Add(apd);

                var reg = new OOB.LibVenta.Venta.Generar.AgregarCuerpo()
                {
                    AutoDeposito=Deposito.Auto,
                    AutoDepartamento=dt.Producto.AutoDepartamento,
                    AutoGrupo=dt.Producto.AutoGrupo,
                    AutoProducto=dt.Producto.Auto,
                    AutoSubGrupo=dt.Producto.AutoSubGrupo,
                    AutoTasaImpuesto=dt.Producto.AutoTasa,
                    AutoCliente=Cliente.Auto,
                    AutoVendedor=Vendedor.Auto,
                    Cantidad=dt.Cantidad,
                    CantidadUnd=dt.Cantidad,
                    Categoria=dt.Producto.Categoria,
                    CodigoPrd=dt.Producto.CodigoPrd,
                    CostoCompraPromedio=dt.Producto.CostoPromedioUnidad, 
                    CostoPromedioUnd=dt.Producto.CostoPromedioUnidad,
                    CostoUnd=dt.Producto.CostoUnidad,
                    CostoVenta=dt.CostoVenta,
                    Decimales=dt.Precio.Decimales,
                    DescuentoMonto_1=dt.Precio.DescuentoItemMonto,
                    DescuentoMonto_2=0.0m,
                    DescuentoMonto_3=0.0m,
                    DescuentoPorc_1=dt.Precio.DescuentoItemPorcentaje,
                    DescuentoPorc_2=0.0m,
                    DescuentoPorc_3=0.0m,
                    DiasGarantia=dt.Producto.DiasGarantia,
                    DepositoCodigo= Deposito.Codigo,
                    DepositoDescripcion=Deposito.Nombre,
                    Empaque=dt.Precio.DescEmpVenta ,
                    EmpaqueContenido=dt.Precio.ContEmpVenta ,
                    IsGarantia=dt.Producto.IsGarantia,
                    IsSerial=dt.Producto.IsSerial,
                    MontoDescuento=dt.DescuentoMontoTotal ,
                    MontoImpuesto=dt.ItemMontoIva,
                    MontoTotal=dt.Total,
                    NombrePrd=dt.Producto.NombrePrd,
                    Notas=dt.Notas,
                    PrecioFinal=dt.Precio.PrecioFinal,
                    PrecioItem=dt.Precio.PrecioItem,
                    PrecioNeto=dt.Precio.PrecioNeto,
                    PrecioUnd=dt.Precio.PrecioFinal,
                    TarifaPrecio=tarifa,
                    TasaIva=dt.Producto.TasaImpuesto ,
                    TotalNeto=dt.Importe,
                    TotalItem=dt.Total,
                    UtilidadMonto=dt.UtilidadMonto ,
                    UtilidadPorc=dt.UtilidadMargen ,
                    VendedorCodigo=Vendedor.Codigo,
                    Tipo="01",
                    Signo=1,
                };
                lc.Add(reg);
            }
            ficha.AgregarMovKardex=lmv;
            ficha.AgregarActProductoDeposito=lapd;
            ficha.AgregarCuerpo = lc;

            var r01 = Program.MyData.Venta_AgregarDocumento(ficha);
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
            EventHandler handler = AgregarOK;
            if (handler != null) 
            {
                handler(this, null);
            }
        }

    }

}