using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Movimiento.Traslado.EntreSucursalesPorExistenciaPorDebajoNivelMinimo
{

    public class Gestion
    {

        private GestionLista gestionLista;
        private BindingSource bs_SucOrigen;
        private BindingSource bs_SucDestino ;
        private List<OOB.LibInventario.Sucursal.Ficha > lSucOrigen;
        private List<OOB.LibInventario.Sucursal.Ficha > lSucDestino;
        private OOB.LibInventario.Sucursal.Ficha sucOrigen;
        private OOB.LibInventario.Sucursal.Ficha sucDestino;
        private OOB.LibInventario.Concepto.Ficha conceptoPorTraslado;
        private bool isMovimientoOk;


        public string _autoSucOrigen { get; set; }
        public string _autoSucDestino { get; set; }
        public string _descripcionMov { get; set; }
        public string _autorizadoPor { get; set; }
        public DateTime _fechaMov { get; set; }


        public BindingSource _bsSucOrigen { get { return bs_SucOrigen ; } }
        public BindingSource _bsSucDestino { get { return bs_SucDestino ; } }
        public BindingSource ItemSource { get { return gestionLista._bs; } }
        public int Items { get { return gestionLista.Renglones; } }
        public decimal Total { get { return gestionLista.Total; } }
        public bool IsMovimientoOk { get { return isMovimientoOk;} }


        public Gestion()
        {
            _autoSucOrigen = "";
            _autoSucDestino = "";
            _descripcionMov = "";
            _autorizadoPor = "";
            _fechaMov = DateTime.Now.Date;
            
            isMovimientoOk = false;
            gestionLista = new GestionLista();
            lSucOrigen = new List<OOB.LibInventario.Sucursal.Ficha>();
            lSucDestino = new List<OOB.LibInventario.Sucursal.Ficha>();
            bs_SucOrigen = new BindingSource();
            bs_SucDestino = new BindingSource();
            bs_SucOrigen.DataSource = lSucOrigen;
            bs_SucDestino.DataSource = lSucDestino;
            sucDestino = null;
            sucOrigen = null;
        }


        public void TrasladoEntreSucursal_PorNivelMinimo()
        {
            if (CargarDataTrasladoSucursal())
            {
                var frm = new MovimientoFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarDataTrasladoSucursal()
        {
            var rt = true;

            var rt1 = Sistema.MyData.Sucursal_GetLista();
            if (rt1.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return false;
            }
            lSucOrigen.Clear();
            lSucOrigen.AddRange(rt1.Lista);
            lSucDestino.Clear();
            lSucDestino.AddRange(rt1.Lista);

            var rt2 = Sistema.MyData.Concepto_PorTraslado();
            if (rt2.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt2.Mensaje);
                return false;
            }
            conceptoPorTraslado = rt2.Entidad;

            return rt;
        }

        public void BuscarProductosPorDebajoNivel()
        {
            if (_autoSucOrigen == "") 
            {
                return;
            }
            if (_autoSucDestino == "")
            {
                return;
            }

            var rt1 = Sistema.MyData.Sucursal_GetFicha(_autoSucDestino );
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return;
            }
            sucDestino = rt1.Entidad;

            var rt2 = Sistema.MyData.Sucursal_GetFicha(_autoSucOrigen);
            if (rt2.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt2.Mensaje);
                return;
            }
            sucOrigen = rt2.Entidad;

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
            gestionLista.setItems(rt3.Lista);
        }

        public bool Salida()
        {
            var rt = true;

            if (gestionLista.Renglones > 0) 
            {
                var msg= MessageBox.Show("Salir Y Perder Los Datos Del Movimiento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.No)
                {
                    rt = false;
                }
            }

            return rt;
        }

        public void Inicializar()
        {
            _autoSucOrigen = "";
            _autoSucDestino = "";
            _descripcionMov = "";
            _autorizadoPor = "";
            _fechaMov = DateTime.Now.Date;

            isMovimientoOk = false;
            gestionLista.Inicializar();
            sucDestino = null;
            sucOrigen = null;
        }

        public void ProcesarMovimiento()
        {
            isMovimientoOk = false;

            if (_descripcionMov.Trim() == "") 
            {
                Helpers.Msg.Error("Falta Campo: Descripción Del Movimiento");
                return;
            }
            if (_autorizadoPor.Trim() == "")
            {
                Helpers.Msg.Error("Falta Campo: Autorizado Por");
                return;
            }
            if (_autoSucOrigen.Trim() == "")
            {
                Helpers.Msg.Error("Falta Campo: Sucural Origen");
                return;
            }
            if (_autoSucDestino.Trim() == "")
            {
                Helpers.Msg.Error("Falta Campo: Sucural Destino");
                return;
            }
            if (_autoSucOrigen == _autoSucDestino) 
            {
                Helpers.Msg.Error("Sucural Destino No Puede Ser Igual A Sucursal Origen");
                return;
            }
            if (gestionLista.Renglones == 0)
            {
                Helpers.Msg.Error("No Hay Renglones Que Procesar");
                return;
            }

            var msg = MessageBox.Show("Estas Seguro De Realizar Movimiento De Traslado ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.No) 
            {
                return;
            }
            
            var ficha = new OOB.LibInventario.Movimiento.Traslado.Insertar.Ficha()
            {
                autoConcepto = conceptoPorTraslado.auto,
                autoDepositoDestino = sucDestino.autoDepositoPrincipal,
                autoDepositoOrigen = sucOrigen.autoDepositoPrincipal,
                autorizado = _autorizadoPor,
                autoRemision = "",
                autoUsuario = Sistema.UsuarioP.auto,
                cierreFtp = "",
                codConcepto = conceptoPorTraslado.codigo,
                codDepositoDestino = sucDestino.codigoDepositoPrincipal,
                codDepositoOrigen = sucOrigen.codigoDepositoPrincipal,
                codigoSucursal = sucOrigen.codigo,
                codUsuario = Sistema.UsuarioP.codigo,
                desConcepto = conceptoPorTraslado.nombre,
                desDepositoDestino = sucDestino.nombre,
                desDepositoOrigen = sucOrigen.nombre,
                documentoNombre = "TRANSFERENCIA",
                estacion = Environment.MachineName,
                estatusAnulado = "0",
                estatusCierreContable = "0",
                nota = _descripcionMov,
                renglones = gestionLista.Renglones,
                situacion = "Procesado",
                tipo = "03",
                total = gestionLista.Total,
                usuario = Sistema.UsuarioP.nombre,
            };

            var listDet = new List<OOB.LibInventario.Movimiento.Traslado.Insertar.FichaDetalle>();
            var listKardex = new List<OOB.LibInventario.Movimiento.Traslado.Insertar.FichaKardex>();
            foreach (var it in gestionLista.Items)
            {
                var det = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaDetalle()
                {
                    autoDepartamento = it.ficha.autoDepartamento,
                    autoGrupo = it.ficha.autoGrupo,
                    autoProducto = it.ficha.autoProducto,
                    cantidad = it.Cantidad,
                    cantidadBono = 0,
                    cantidadUnd = it.Cantidad,
                    categoria = it.ficha.categoria,
                    codigoProducto = it.ficha.codigoProducto,
                    contEmpaque = it.ficha.contenidEmpCompra,
                    costoCompra = it.Costo,
                    costoUnd = it.Costo,
                    decimales = it.ficha.decimales,
                    empaque = it.ficha.empaqueCompra,
                    estatusAnulado = "0",
                    estatusUnidad = "1",
                    nombreProducto = it.ficha.nombreProducto,
                    signo = 1,
                    tipo = "03",
                    total = it.Importe,
                };
                listDet.Add(det);
                
                //MOV SALIDA
                var kardexS = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaKardex()
                {
                    autoConcepto = conceptoPorTraslado.auto,
                    autoDeposito = sucOrigen.autoDepositoPrincipal,
                    autoProducto = it.ficha.autoProducto,
                    cantidad = it.Cantidad,
                    cantidadBono = 0,
                    cantidadUnd = it.Cantidad,
                    codigo = "03",
                    codigoSucursal = sucOrigen.codigo,
                    costoUnd = it.Costo,
                    entidad = "",
                    estatusAnulado = "0",
                    modulo = "Inventario",
                    nota = "",
                    precioUnd = 0.0m,
                    siglas = "TRA",
                    signo = -1,
                    total = it.Importe,
                };
                listKardex.Add(kardexS);

                //MOV ENTRADA
                var kardexE = new OOB.LibInventario.Movimiento.Traslado.Insertar.FichaKardex()
                {
                    autoConcepto = conceptoPorTraslado.auto,
                    autoDeposito = sucDestino.autoDepositoPrincipal,
                    autoProducto = it.ficha.autoProducto,
                    cantidad = it.Cantidad,
                    cantidadBono = 0,
                    cantidadUnd = it.Cantidad,
                    codigo = "03",
                    codigoSucursal = sucOrigen.codigo,
                    costoUnd = it.Costo,
                    entidad = "",
                    estatusAnulado = "0",
                    modulo = "Inventario",
                    nota = "",
                    precioUnd = 0.0m,
                    siglas = "TRA",
                    signo = 1,
                    total = it.Importe,
                };
                listKardex.Add(kardexE);
            }
            ficha.detalles = listDet;
            ficha.movKardex = listKardex;

            var rt1 = Sistema.MyData.Producto_Movimiento_Traslado_Insertar(ficha);
            if (rt1.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return;
            }
            isMovimientoOk = true;

            var rt2 = Sistema.MyData.Producto_Movimiento_GetFicha(rt1.Auto);
            if (rt2.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(rt2.Mensaje);
            }

            Imprimir(rt2.Entidad);
            Helpers.Msg.OK("Movimiento Procesado Exitosamente");
        }

        public void Imprimir(OOB.LibInventario.Movimiento.Ver.Ficha xficha)
        {
            //var ficha = new Reportes.Documentos.MovimientoTraslado.Movimiento();
            //ficha.documentoNro = "0000000003";
            //ficha.fecha = _fechaMov;
            //ficha.notas = _descripcionMov;
            //ficha.autorizadoPor = _autorizadoPor;
            //ficha.depositoOrigen = sucOrigen.nombreDepositoPrincipal;
            //ficha.codigoDepositoOrigen = sucOrigen.codigoDepositoPrincipal;
            //ficha.depositoDestino = sucDestino.nombreDepositoPrincipal;
            //ficha.codigoDepositoDestino = sucDestino.codigoDepositoPrincipal;
            //ficha.tipoDocumento = "TRASLADO/TRANSFERENCIA";
            //ficha.codigoConcepto = conceptoPorTraslado.codigo;
            //ficha.concepto = conceptoPorTraslado.nombre;
            //ficha.estacion = Environment.MachineName;
            //ficha.usuario = Sistema.UsuarioP.nombre;
            //ficha.usuarioCodigo = Sistema.UsuarioP.codigo;

            //ficha.detalles = new List<Reportes.Documentos.MovimientoTraslado.Detalle>();
            //foreach (var it in gestionLista.Items)
            //{
            //    var det = new Reportes.Documentos.MovimientoTraslado.Detalle()
            //    {
            //        cantidad = it.Cantidad,
            //        codigo = it.CodigoPrd,
            //        costoUnd = it.Costo,
            //        descripcion = it.NombrePrd,
            //        importe = it.Importe,
            //        signo = 1,
            //    };
            //    ficha.detalles.Add(det);
            //};


            var ficha = new Reportes.Documentos.MovimientoTraslado.Movimiento();
            ficha.documentoNro = xficha.documentoNro ;
            ficha.fecha = xficha.fecha;
            ficha.notas = xficha.notas ;
            ficha.autorizadoPor = xficha.autorizadoPor;
            ficha.depositoOrigen = xficha.depositoOrigen ;
            ficha.codigoDepositoOrigen = xficha.codigoDepositoOrigen ;
            ficha.depositoDestino = xficha.depositoDestino ;
            ficha.codigoDepositoDestino = xficha.codigoDepositoDestino ;
            ficha.tipoDocumento = "TRASLADO/TRANSFERENCIA";
            ficha.codigoConcepto = xficha.codigoConcepto;
            ficha.concepto = xficha.concepto ;
            ficha.estacion = xficha.estacion;
            ficha.usuario = xficha.usuario ;
            ficha.usuarioCodigo = xficha.usuarioCodigo ;

            ficha.detalles = new List<Reportes.Documentos.MovimientoTraslado.Detalle>();
            foreach (var it in xficha.detalles)
            {
                var det = new Reportes.Documentos.MovimientoTraslado.Detalle()
                {
                    cantidad = it.cantidad,
                    codigo = it.codigo,
                    costoUnd = it.costoUnd,
                    descripcion = it.descripcion,
                    importe = it.importe,
                    signo = it.signo,
                };
                ficha.detalles.Add(det);
            };

            var rp1 = new Reportes.Documentos.MovimientoTraslado(ficha);
            rp1.Generar();
        }

    }

}