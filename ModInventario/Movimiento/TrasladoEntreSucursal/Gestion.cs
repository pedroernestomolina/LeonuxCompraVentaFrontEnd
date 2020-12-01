﻿using System;
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
        private List<OOB.LibInventario.Concepto.Ficha> lConcepto;
        private List<OOB.LibInventario.Sucursal.Ficha> lSucOrigen;
        private List<OOB.LibInventario.Sucursal.Ficha> lSucDestino;
        private BindingSource bsConcepto;
        private BindingSource bsSucOrigen;
        private BindingSource bsSucDestino;
        private Movimiento.data miData;
        private GestionDetalle _gestionDetalle;
        private decimal tasaCambio;
        private bool isCerrarOk;
        private OOB.LibInventario.Sucursal.Ficha sucOrigen;
        private OOB.LibInventario.Sucursal.Ficha sucDestino;

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
        public string IdSucursal { get { return miData.IdSucursal; } set { miData.IdSucursal = value; } }
        public string IdConcepto { get { return miData.IdConcepto; } set { miData.IdConcepto = value; } }
        public string IdDepOrigen
        { 
            get { return miData.IdDepOrigen; } 
            set 
            {
                if (_gestionDetalle.TotalItems == 0) 
                {
                    if (miData.IdDepDestino != "")
                    {
                        if (miData.IdDepDestino != value)
                            miData.IdDepOrigen = value; 
                    }
                    else
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
                    if (miData.IdDepOrigen != "")
                    {
                        if (miData.IdDepOrigen != value)
                            miData.IdDepDestino = value;
                    }
                    else
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
            lSucOrigen = new List<OOB.LibInventario.Sucursal.Ficha>();
            lSucDestino = new List<OOB.LibInventario.Sucursal.Ficha>();
            bsConcepto = new BindingSource();
            bsSucOrigen = new BindingSource();
            bsSucDestino = new BindingSource();
            bsConcepto.DataSource = lConcepto;
            bsSucOrigen.DataSource = lSucOrigen;
            bsSucDestino.DataSource = lSucDestino;
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
                _gestionDetalle.AgregarItem(_gestionListaPrd.ItemSeleccionado.FichaPrd, miData.IdDepOrigen, miData.IdDepDestino);
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
            tasaCambio = rt4.Entidad;
            _gestionDetalle.setTasaCambio(tasaCambio);

            lConcepto.Clear();
            lConcepto.AddRange(rt2.Lista);
            bsConcepto.CurrencyManager.Refresh();

            lSucOrigen.Clear();
            lSucOrigen.AddRange(rt1.Lista);
            bsSucOrigen.CurrencyManager.Refresh();

            lSucDestino.Clear();
            lSucDestino.AddRange(rt1.Lista);
            bsSucDestino.CurrencyManager.Refresh();

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
            return;
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
            //var rt1 = Sistema.MyData.Deposito_GetFicha(sucOrigen.autoDepositoPrincipal);
            //if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(rt1.Mensaje);
            //    return false;
            //}
            //var depOrigen = rt1.Entidad;
            //var rt2 = Sistema.MyData.Deposito_GetFicha(sucDestino.autoDepositoPrincipal);
            //if (rt2.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(rt2.Mensaje);
            //    return false;
            //}
            //var depDestino= rt1.Entidad;

            var ficha = new OOB.LibInventario.Movimiento.Traslado.Insertar.Ficha()
            {
                autoConcepto = miData.IdConcepto,
                autoDepositoDestino = sucDestino.autoDepositoPrincipal ,
                autoDepositoOrigen = sucOrigen.autoDepositoPrincipal ,
                autoRemision = "",
                autorizado = miData.AutorizadoPor,
                autoUsuario = Sistema.UsuarioP.autoUsu,
                cierreFtp = "",
                codConcepto = concepto.codigo,
                codDepositoDestino = sucDestino.codigoDepositoPrincipal ,
                codDepositoOrigen = sucOrigen.codigoDepositoPrincipal ,
                codigoSucursal = sucOrigen.codigo,
                codUsuario = Sistema.UsuarioP.codigoUsu,
                desConcepto = concepto.nombre,
                desDepositoDestino = sucDestino.nombreDepositoPrincipal ,
                desDepositoOrigen = sucOrigen.nombreDepositoPrincipal ,
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
                    autoDepositoOrigen = sucOrigen.autoDepositoPrincipal ,
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
            if (_gestionDetalle.TotalItems > 0)
                return;

            if (IdDepOrigen=="")
            {
                return;
            }
            if (IdDepDestino== "")
            {
                return;
            }

            var rt1 = Sistema.MyData.Sucursal_GetFicha(IdDepOrigen );
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return;
            }
            sucOrigen = rt1.Entidad;
            var rt2 = Sistema.MyData.Sucursal_GetFicha(IdDepDestino);
            if (rt2.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt2.Mensaje);
                return;
            }
            sucDestino = rt2.Entidad;

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

            var filtro = new OOB.LibInventario.Movimiento.Traslado.Consultar.Filtro();
            filtro.autoDeposito = sucDestino.autoDepositoPrincipal;
            var rt3 = Sistema.MyData.Producto_Movimiento_Traslado_Consultar_ProductosPorDebajoNivelMinimo(filtro);
            if (rt3.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt3.Mensaje);
                return;
            }
            _gestionDetalle.AgregarItem(rt3.Lista, sucOrigen.autoDepositoPrincipal);
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

    }

}