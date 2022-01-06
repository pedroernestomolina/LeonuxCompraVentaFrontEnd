using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Movimiento.Descargo
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
        public string TipoMovimiento { get {return "DESCARGO";} }
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
        public ficha Sucursal { get { return miData.GetSucursal; } }
        public ficha DepositoOrigen { get { return miData.GetDepositoOrigen; } }
        public ficha Concepto { get { return miData.GetConcepto; } }
        public bool HabilitarCambioSucursal { get { return _gestionDetalle.TotalItems == 0; } }
        public bool HabilitarCambioDepositoOrigen { get { return _gestionDetalle.TotalItems == 0; } }
        public string GetIdSucursal
        {
            get
            {
                var id = "";
                if (Sucursal != null)
                    id = Sucursal.id;
                return id;
            }
        }
        public string GetIdDepositoOrigen
        {
            get
            {
                var id = "";
                if (DepositoOrigen != null)
                    id = DepositoOrigen.id;
                return id;
            }
        }
        

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
                if (DepositoOrigen == null)
                {
                    Helpers.Msg.Error("CAMPO [ DEPOSITO ORIGEN ] NO SELECCIONADO");
                    return;
                }
                _gestionDetalle.AgregarItem(_gestionListaPrd.ItemSeleccionado.FichaPrd, DepositoOrigen.id);
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
            var rt4 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (rt4.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt4.Mensaje);
                return false;
            }
            tasaCambio = rt4.Entidad;
            _gestionDetalle.setTasaCambio(tasaCambio);

            lConcepto.Clear();
            lConcepto.AddRange(rt2.Lista.OrderBy(o => o.nombre).ToList());
            bsConcepto.CurrencyManager.Refresh();

            lSucursal.Clear();
            lSucursal.AddRange(rt1.Lista.OrderBy(o => o.nombre).ToList());
            bsSucursal.CurrencyManager.Refresh();

            return rt;
        }

        public void Limpiar()
        {
            isCerrarOk = false;
            miData.Limpiar();
            lDepOrigen.Clear();
            bsDepOrigen.CurrencyManager.Refresh();
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
            _gestionDetalle.EditarItem(DepositoOrigen.id);
        }

        public void Procesar()
        {
            miData.detalle = _gestionDetalle.Detalle;
            if (miData.Verificar())
            {
                if (Sucursal == null)
                {
                    Helpers.Msg.Error("Campo [ Sucursal ] No Seleccionada");
                    return;
                }
                if (Concepto == null)
                {
                    Helpers.Msg.Error("Campo [ Concepto Movimiento ] No Seleccionada");
                    return;
                }
                if (DepositoOrigen == null)
                {
                    Helpers.Msg.Error("Campo [ Deposito Origen ] No Seleccionada");
                    return;
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
            var ficha = new OOB.LibInventario.Movimiento.DesCargo.Insertar.Ficha()
            {
                autoConcepto = Concepto.id,
                autoDepositoDestino = DepositoOrigen.id,
                autoDepositoOrigen = DepositoOrigen.id,
                autoRemision = "",
                autorizado = miData.AutorizadoPor,
                autoUsuario = Sistema.UsuarioP.autoUsu,
                cierreFtp = "",
                codConcepto = Concepto.codigo,
                codDepositoDestino = DepositoOrigen.codigo,
                codDepositoOrigen = DepositoOrigen.codigo,
                codigoSucursal = Sucursal.codigo,
                codUsuario = Sistema.UsuarioP.codigoUsu,
                desConcepto = Concepto.descripcion,
                desDepositoDestino = DepositoOrigen.descripcion,
                desDepositoOrigen = DepositoOrigen.descripcion,
                documentoNombre = "DESCARGOS",
                estacion = Environment.MachineName,
                estatusAnulado = "0",
                estatusCierreContable = "0",
                nota = miData.Motivo,
                renglones = _gestionDetalle.TotalItems,
                situacion = "Procesado",
                tipo = "02",
                total = MontoMovimiento,
                usuario = Sistema.UsuarioP.nombreUsu,
                factorCambio=tasaCambio,
                montoDivisa=Math.Round(MontoMovimiento/tasaCambio,2, MidpointRounding.AwayFromZero),
            };

            var detalles = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.DesCargo.Insertar.FichaDetalle()
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
                    signo = -1,
                    tipo = "02",
                    total = s.ImporteMonedaLocal,
                };
                return rg;
            }).ToList();
            ficha.detalles = detalles;

            var lDep = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.DesCargo.Insertar.FichaPrdDeposito()
                {
                    autoDeposito = DepositoOrigen.id,
                    autoProducto = s.FichaPrd.AutoId,
                    nombreProducto = s.DescripcionPrd,
                    cantidadUnd = s.CantidadUnd,
                };
                return rg;
            }).ToList();
            ficha.prdDeposito = lDep;

            var lKardex = _gestionDetalle.Detalle.ListaItems.Select(s =>
            {
                var rg = new OOB.LibInventario.Movimiento.DesCargo.Insertar.FichaKardex()
                {
                    autoConcepto = Concepto.id,
                    autoDeposito = DepositoOrigen.id,
                    autoProducto = s.FichaPrd.AutoId,
                    cantidad = s.Cantidad,
                    cantidadBono = 0.0m,
                    cantidadUnd = s.CantidadUnd,
                    codigoMov = "02",
                    codigoConcepto = Concepto.codigo,
                    codigoDeposito = DepositoOrigen.codigo,
                    codigoSucursal = Sucursal.codigo,
                    costoUnd = s.CostoUndMonedaLocal,
                    entidad = "",
                    estatusAnulado = "0",
                    modulo = "Inventario",
                    nombreConcepto = Concepto.descripcion,
                    nombreDeposito = DepositoOrigen.descripcion,
                    nota = "",
                    precioUnd = 0.0m,
                    siglasMov = "DES",
                    signoMov = -1,
                    total = s.ImporteMonedaLocal,
                };
                return rg;
            }).ToList();
            ficha.movKardex = lKardex;

            var r01 = Sistema.MyData.Producto_Movimiento_DesCargo_Insertar(ficha);
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
            get { return  enumerados.enumTipoMovimiento.Descargo; }
        }

        public void setFiltros(Buscar.Filtrar.data data)
        {
            _gestionBusquedaPrd.setFiltros(data);
        }

        public void ActualizarConceptos()
        {
            var rt1 = Sistema.MyData.Concepto_GetLista();
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return ;
            }
            lConcepto.Clear();
            lConcepto.AddRange(rt1.Lista);
            bsConcepto.CurrencyManager.Refresh();
        }

        public void setHabilitarConcepto(bool p)
        {
        }

        public bool HabilitarConcepto
        {
            get { return true; }
        }

        public void Inicializa()
        {
        }

        public void setSucursal(string id)
        {
            var suc = lSucursal.FirstOrDefault(f => f.auto == id);
            if (suc != null)
            {
                var r01 = Sistema.MyData.Sucursal_GetFicha(id);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var r02 = Sistema.MyData.Deposito_GetListaBySucursal(r01.Entidad.codigo);
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return;
                }
                lDepOrigen.Clear();
                lDepOrigen.AddRange(r02.Lista.OrderBy(o => o.nombre).ToList());
                bsDepOrigen.CurrencyManager.Refresh();
                miData.setSucursal(new ficha(suc.auto, suc.nombre, suc.codigo));
                miData.setDepositoOrigen(null);
            }
            else
            {
                miData.setSucursal(null);
                miData.setDepositoOrigen(null);
            }
        }

        public void setDepositoOrigen(string id)
        {
            miData.setDepositoOrigen(null);
            var dep = lDepOrigen.FirstOrDefault(f => f.auto == id);
            if (dep != null)
            {
                miData.setDepositoOrigen(new ficha(dep.auto, dep.nombre, dep.codigo));
            }
        }

        public void setConcepto(string id)
        {
            miData.setConcepto(null);
            var ent = lConcepto.FirstOrDefault(f => f.auto == id);
            if (ent != null)
            {
                miData.setConcepto(new ficha(ent.auto, ent.nombre, ent.codigo));
            }
        }


        //NO IMPLEMENTAR
        public bool HabilitarCambioDepositoDestino { get { return false; } }
        public string GetIdDepositoDestino { get { return ""; } }
        public void setDepositoDestino(string id)
        {
        }


    }

}