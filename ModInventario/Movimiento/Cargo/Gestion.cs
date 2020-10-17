using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Movimiento.Cargo
{
    
    public class Gestion: IGestion
    {

        private Producto.Busqueda.Gestion _gestionBusquedaPrd;
        private Producto.Lista.Gestion _gestionListaPrd; 
        private List<OOB.LibInventario.Concepto.Ficha> lConcepto;
        private List<OOB.LibInventario.Sucursal.Ficha> lSucursal;
        private List<OOB.LibInventario.Deposito.Ficha> lDepOrigen;
        private List<OOB.LibInventario.Deposito.Ficha> lDepDestino;
        private BindingSource bsSucursal;
        private BindingSource bsConcepto;
        private BindingSource bsDepOrigen;
        private BindingSource bsDepDestino;
        private Movimiento.data miData;
        private GestionDetalle _gestionDetalle;
        private decimal tasaCambio;
        private bool isCerrarOk;


        public bool IsCerrarOk { get { return isCerrarOk; } }
        public string TipoMovimiento { get {return "CARGO";} }
        public decimal MontoMovimiento { get { return _gestionDetalle.MontoMovimiento; } }
        public string ItemsMovimiento  { get { return _gestionDetalle.ItemsMovimiento; } }
        public bool Habilitar_DepDestino { get { return false; } }
        public bool VisualizarColumnaTipoMovimiento { get { return false; } }
        public BindingSource ConceptoSource { get { return bsConcepto; } }
        public BindingSource SucursalSource { get { return bsSucursal; } }
        public BindingSource DepOrigenSource { get { return bsDepOrigen; } }
        public BindingSource DepDestinoSource { get { return bsDepDestino; } }
        public BindingSource DetalleSouce { get { return _gestionDetalle.Souce; } }
        public string IdSucursal { get { return miData.IdSucursal; } set { miData.IdSucursal = value; } }
        public string IdConcepto { get { return miData.IdConcepto; } set { miData.IdConcepto = value; } }
        public string IdDepOrigen
        { 
            get { return miData.IdDepOrigen; } 
            set 
            {
                if (_gestionDetalle.TotalItems == 0) 
                {
                    miData.IdDepOrigen = value; 
                }
            }
        } 
        public string IdDepDestino 
        { 
            get { return miData.IdDepDestino; } 
            set 
            {
                if (_gestionDetalle.TotalItems == 0) 
                {
                    miData.IdDepDestino = value;
                }
            }
        }
        public string AutorizadoPor { get { return miData.AutorizadoPor; } set { miData.AutorizadoPor = value; } }
        public string Motivo { get { return miData.Motivo; } set { miData.Motivo = value; } }
        public DateTime FechaMov { get { return miData.Fecha; } set { miData.Fecha = value; } }
        public OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda MetodoBusqueda { get { return _gestionBusquedaPrd.Metodo; } set { _gestionBusquedaPrd.Metodo = value; } }
        public string CadenaBusqueda { get { return _gestionBusquedaPrd.CadenaBusqueda; } set { _gestionBusquedaPrd.CadenaBusqueda = value; } }
        

        public Gestion()
        {
            _gestionDetalle = new GestionDetalle();
            _gestionBusquedaPrd = new Producto.Busqueda.Gestion();
            _gestionListaPrd = new Producto.Lista.Gestion();
            _gestionListaPrd.ItemSeleccionadoOk+=_gestionListaPrd_ItemSeleccionadoOk;
            miData = new Movimiento.data();

            lConcepto = new List<OOB.LibInventario.Concepto.Ficha>();
            lSucursal = new List<OOB.LibInventario.Sucursal.Ficha>();
            lDepOrigen = new List<OOB.LibInventario.Deposito.Ficha>();
            lDepDestino = new List<OOB.LibInventario.Deposito.Ficha>();
            bsConcepto = new BindingSource();
            bsSucursal = new BindingSource();
            bsDepOrigen = new BindingSource();
            bsDepDestino = new BindingSource();
            bsConcepto.DataSource = lConcepto;
            bsSucursal.DataSource = lSucursal;
            bsDepOrigen.DataSource = lDepOrigen;
            bsDepDestino.DataSource = lDepDestino;
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
                _gestionDetalle.AgregarItem(_gestionListaPrd.ItemSeleccionado.FichaPrd, miData.IdDepOrigen);
            }

        }

        public void Inicia()
        {
            _gestionBusquedaPrd.Inicia();
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
            var rt3 = Sistema.MyData.Deposito_GetLista ();
            if (rt3.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt3.Mensaje);
                return false;
            }

            var rt4 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (rt4.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt4.Mensaje);
                return false;
            }
            tasaCambio = rt4.Entidad;
            _gestionDetalle.setTasaCambio(tasaCambio);

            lConcepto.Clear();
            lConcepto.AddRange(rt2.Lista);
            bsConcepto.CurrencyManager.Refresh();

            lSucursal.Clear();
            lSucursal.AddRange(rt1.Lista);
            bsSucursal.CurrencyManager.Refresh();

            lDepOrigen.Clear();
            lDepOrigen.AddRange(rt3.Lista);
            bsDepOrigen.CurrencyManager.Refresh();

            lDepDestino.Clear();
            lDepDestino.AddRange(rt3.Lista);
            bsDepDestino.CurrencyManager.Refresh();

            return rt;
        }

        public void Limpiar()
        {
            isCerrarOk = false;
            miData.Limpiar();
            _gestionDetalle.Limpiar();
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
            _gestionDetalle.EditarItem();
        }

        public void Procesar()
        {
            miData.detalle = _gestionDetalle.Detalle;
            if (miData.Verificar())
            {
                if (IdDepOrigen == "")
                {
                    Helpers.Msg.Error("[ Depósito Origen ] No Seleccionada");
                    return ;
                }
                var msg = MessageBox.Show("Procesar Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.No) 
                {
                    return;
                }

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
            var concepto= lConcepto.FirstOrDefault(m=>m.auto==miData.IdConcepto);
            var depOrigen = lDepOrigen.FirstOrDefault(m=>m.auto==miData.IdDepOrigen);
            var sucursal = lSucursal.FirstOrDefault(m=>m.auto==miData.IdSucursal);

            var ficha = new OOB.LibInventario.Movimiento.Cargo.Insertar.Ficha()
            {
                autoConcepto = miData.IdConcepto,
                autoDepositoDestino = miData.IdDepOrigen,
                autoDepositoOrigen = miData.IdDepOrigen,
                autoRemision = "",
                autorizado = miData.AutorizadoPor,
                autoUsuario = Sistema.UsuarioP.autoUsu,
                cierreFtp = "",
                codConcepto = concepto.codigo,
                codDepositoDestino = depOrigen.codigo,
                codDepositoOrigen = depOrigen.codigo,
                codigoSucursal = sucursal.codigo,
                codUsuario = Sistema.UsuarioP.codigoUsu,
                desConcepto = concepto.nombre,
                desDepositoDestino = depOrigen.nombre,
                desDepositoOrigen = depOrigen.nombre,
                documentoNombre = "CARGOS",
                estacion = Environment.MachineName,
                estatusAnulado = "0",
                estatusCierreContable = "0",
                nota = miData.Motivo,
                renglones = _gestionDetalle.TotalItems,
                situacion = "Procesado",
                tipo = "01",
                total = MontoMovimiento,
                usuario = Sistema.UsuarioP.nombreUsu,
            };

            var detalles = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaDetalle()
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
                    tipo = "01",
                    total = s.ImporteMonedaLocal,
                };
                return rg;
            }).ToList();
            ficha.detalles = detalles;

            var lDep = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdDeposito()
                {
                    autoDeposito = miData.IdDepOrigen,
                    autoProducto = s.FichaPrd.AutoId,
                    cantidadUnd = s.CantidadUnd,
                };
                return rg;
            }).ToList();
            ficha.prdDeposito = lDep;

            var lCosto = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdCosto()
                {
                    autoProducto = s.FichaPrd.AutoId,
                    cantidadEntranteUnd = s.CantidadUnd,
                    costoDivisa = s.CostoDivisa,
                    costoFinal = s.CostoMonedaLocal,
                    costoFinalUnd = s.CostoUndMonedaLocal,
                };
                return rg;
            }).ToList();
            ficha.prdCosto = lCosto;

            var lCostoHistorico = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdCostoHistorico()
                {
                    autoProducto = s.FichaPrd.AutoId,
                    costo = s.CostoMonedaLocal,
                    divisa = s.CostoDivisa,
                    nota = "",
                    tasaCambio = s.TasaCambio,
                    serie="DOC",
                };
                return rg;
            }).ToList();
            ficha.prdCostoHistorico = lCostoHistorico;

            var lKardex = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaKardex()
                {
                    autoConcepto = concepto.auto,
                    autoDeposito = depOrigen.auto,
                    autoProducto = s.FichaPrd.AutoId,
                    cantidad = s.Cantidad,
                    cantidadBono = 0.0m,
                    cantidadUnd = s.CantidadUnd,
                    codigoMov = "01",
                    codigoConcepto = concepto.codigo,
                    codigoDeposito = depOrigen.codigo,
                    codigoSucursal = sucursal.codigo,
                    costoUnd = s.CostoUndMonedaLocal,
                    entidad = "",
                    estatusAnulado = "0",
                    modulo = "Inventario",
                    nombreConcepto = concepto.nombre,
                    nombreDeposito = depOrigen.nombre,
                    nota = "",
                    precioUnd = 0.0m,
                    siglasMov = "CAR",
                    signoMov = 1,
                    total = s.ImporteMonedaLocal,
                };
                return rg;
            }).ToList();
            ficha.movKardex = lKardex;

            var rt1 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad();
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return false;
            }
            var rt3 = Sistema.MyData.Configuracion_PreferenciaRegistroPrecio();
            if (rt3.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt3.Mensaje);
                return false;
            }
            var rt4 = Sistema.MyData.Configuracion_ForzarRedondeoPrecioVenta();
            if (rt4.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt4.Mensaje);
                return false;
            }

            var lMargen = new List<OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioMargen>();
            var LPrecio = new List<OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecio>();
            var lPrecioHistorico = new List<OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioHistorico>();
            foreach (var it in _gestionDetalle.Detalle.ListaItems)
            { 
                if (it.EsAdmDivisa)
                {
                    var rt2 = Sistema.MyData.Producto_GetPrecio(it.FichaPrd.AutoId);
                    if (rt2.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(rt2.Mensaje);
                        return false;
                    }
                    var rg = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecio();
                    rg.autoProducto = it.FichaPrd.AutoId;
                    rg.precio_1 = null;
                    rg.precio_2 = null;
                    rg.precio_3 = null;
                    rg.precio_4 = null;
                    rg.precio_5 = null;
                    if (rt2.Entidad.precioNeto1 > 0)
                    {
                        var p = Helpers.Utilitis.RecalcularPrecio(it.CostoUndMonedaLocal , rt2.Entidad.utilidad1, rt2.Entidad.tasaIva, rt3.Entidad, rt4.Entidad, rt1.Entidad, tasaCambio);
                        rg.precio_1 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = p.neto, precio_divisa_full = p.fullDivisa };
                        var ph = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioHistorico()
                        {
                            autoProducto = it.FichaPrd.AutoId,
                            nota = "",
                            precio = p.neto,
                            precio_id = "1",
                        };
                        lPrecioHistorico.Add(ph);
                    }
                    if (rt2.Entidad.precioNeto2 > 0)
                    {
                        var p = Helpers.Utilitis.RecalcularPrecio(it.CostoUndMonedaLocal, rt2.Entidad.utilidad2, rt2.Entidad.tasaIva, rt3.Entidad, rt4.Entidad, rt1.Entidad, tasaCambio);
                        rg.precio_2 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = p.neto, precio_divisa_full = p.fullDivisa };
                        var ph = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioHistorico()
                        {
                            autoProducto = it.FichaPrd.AutoId,
                            nota = "",
                            precio = p.neto,
                            precio_id = "2",
                        };
                        lPrecioHistorico.Add(ph);
                    }
                    if (rt2.Entidad.precioNeto3 > 0)
                    {
                        var p = Helpers.Utilitis.RecalcularPrecio(it.CostoUndMonedaLocal, rt2.Entidad.utilidad3, rt2.Entidad.tasaIva, rt3.Entidad, rt4.Entidad, rt1.Entidad, tasaCambio);
                        rg.precio_3 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = p.neto, precio_divisa_full = p.fullDivisa };
                        var ph = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioHistorico()
                        {
                            autoProducto = it.FichaPrd.AutoId,
                            nota = "",
                            precio = p.neto,
                            precio_id = "3",
                        };
                        lPrecioHistorico.Add(ph);
                    }
                    if (rt2.Entidad.precioNeto4 > 0)
                    {
                        var p = Helpers.Utilitis.RecalcularPrecio(it.CostoUndMonedaLocal, rt2.Entidad.utilidad4, rt2.Entidad.tasaIva, rt3.Entidad, rt4.Entidad, rt1.Entidad, tasaCambio);
                        rg.precio_4 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = p.neto, precio_divisa_full = p.fullDivisa };
                        var ph = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioHistorico()
                        {
                            autoProducto = it.FichaPrd.AutoId,
                            nota = "",
                            precio = p.neto,
                            precio_id = "4",
                        };
                        lPrecioHistorico.Add(ph);
                    }
                    if (rt2.Entidad.precioNeto5 > 0)
                    {
                        var p = Helpers.Utilitis.RecalcularPrecio(it.CostoUndMonedaLocal, rt2.Entidad.utilidad5, rt2.Entidad.tasaIva, rt3.Entidad, rt4.Entidad, rt1.Entidad, tasaCambio);
                        rg.precio_5 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecio() { precioNeto = p.neto, precio_divisa_full = p.fullDivisa };
                        var ph = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioHistorico()
                        {
                            autoProducto = it.FichaPrd.AutoId,
                            nota = "",
                            precio = p.neto,
                            precio_id = "PTO",
                        };
                        lPrecioHistorico.Add(ph);
                    }
                    LPrecio.Add(rg);
                }
                else
                {
                    var rt2 = Sistema.MyData.Producto_GetPrecio(it.FichaPrd.AutoId);
                    if (rt2.Result == OOB.Enumerados.EnumResult.isError) 
                    {
                        Helpers.Msg.Error(rt2.Mensaje);
                        return false;
                    }
                    var rg = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrdPrecioMargen();
                    rg.autoProducto = it.FichaPrd.AutoId;
                    rg.precio_1=null;
                    rg.precio_2=null;
                    rg.precio_3=null;
                    rg.precio_4=null;
                    rg.precio_5=null;
                    if (rt2.Entidad.precioNeto1>0)
                    {
                        rg.precio_1 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = ReCalcularMargen(rt2.Entidad.precioNeto1, it.CostoUndMonedaLocal, rt1.Entidad), };
                    }
                    if (rt2.Entidad.precioNeto2 > 0)
                    {
                        rg.precio_2 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = ReCalcularMargen(rt2.Entidad.precioNeto2, it.CostoUndMonedaLocal, rt1.Entidad), };
                    }
                    if (rt2.Entidad.precioNeto3 > 0)
                    {
                        rg.precio_3 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = ReCalcularMargen(rt2.Entidad.precioNeto3, it.CostoUndMonedaLocal, rt1.Entidad), };
                    }
                    if (rt2.Entidad.precioNeto4 > 0)
                    {
                        rg.precio_4 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = ReCalcularMargen(rt2.Entidad.precioNeto4, it.CostoUndMonedaLocal, rt1.Entidad), };
                    }
                    if (rt2.Entidad.precioNeto5 > 0)
                    {
                        rg.precio_5 = new OOB.LibInventario.Movimiento.Cargo.Insertar.FichaPrecioMargen() { utilidad = ReCalcularMargen(rt2.Entidad.precioNeto5, it.CostoUndMonedaLocal, rt1.Entidad), };
                    }
                    lMargen.Add(rg);
                }
            }
            ficha.prdPrecioMargen = lMargen;
            ficha.prdPrecio = LPrecio;
            ficha.prdPrecioHistorico = lPrecioHistorico; 

            var r01 = Sistema.MyData.Producto_Movimiento_Cargo_Insertar(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            return true;
        }

        private decimal ReCalcularMargen(decimal pn, decimal costo, OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad metodo)
        {
            var rt = 0.0m;

            if (metodo == OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Financiero)
            {
                rt = (1 - (costo / pn)) * 100;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }
            else 
            {
                rt = ((pn / costo) - 1) * 100;
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
            }

            return rt;
        }

        public bool AbandonarDocumento()
        {
            var msg = MessageBox.Show("Abandonar Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            return (msg == DialogResult.Yes);
        }

        public enumerados.enumTipoMovimiento EnumTipoMovimiento
        {
            get { return  enumerados.enumTipoMovimiento.Cargo; }
        }

        public void setFiltros(Buscar.Filtrar.data data)
        {
            _gestionBusquedaPrd.setFiltros(data);
        }

    }

}