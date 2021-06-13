﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Factura
{
    
    public class GestionFac : Controlador.IGestion
    {

        public event EventHandler ActualizarItemHnd;


        private Controlador.IGestionDocumento gestionDoc;
        private Controlador.IGestionItem gestionItem;
        private Controlador.IGestionProductoBuscar gestionPrdBuscar;
        private Controlador.IGestionTotalizar gestionTotalizar;
        private OOB.LibCompra.Empresa.Fiscal.Ficha tasasFiscal;
        private OOB.LibCompra.Concepto.Ficha conceptoCompra;


        public Controlador.GestionProductoBuscar.metodoBusqueda MetodoBusquedaProducto { get { return gestionPrdBuscar.MetodoBusquedaProducto; } }
        public Controlador.IGestionDocumento GestionDoc { get { return gestionDoc; } }
        public Controlador.IGestionItem GestionItem {get { return gestionItem; }}
        public Controlador.IGestionTotalizar GestionTotalizar {get { return gestionTotalizar; }}
        public bool VisualizarColDevolucion { get { return false; } }


        public string CadenaPrdBuscar { get { return gestionPrdBuscar.CadenaPrdBuscar; } set { gestionPrdBuscar.CadenaPrdBuscar = value; } }
        public bool SalidaOk { get; set; }


        public string TituloDocumento { get { return "Entrada Documento: ( FACTURA )"; } }
        public System.Drawing.Color ColorFondoDocumento { get { return System.Drawing.Color.Green; } }


        public GestionFac()
        {
            SalidaOk = false;
            gestionDoc= new GestionDocumentoFac();
            gestionItem = new GestionItemFac();
            gestionPrdBuscar = new GestionProductoBuscarFac();
            gestionTotalizar = new GestionTotalizarFac();
            gestionItem.ActualizarItemHnd +=gestionItem_ActualizarItemHnd;
        }

        private void gestionItem_ActualizarItemHnd(object sender, EventArgs e)
        {
            EventHandler hnd = ActualizarItemHnd;
            if (hnd != null)
            {
                hnd(this, e);
            }
        }

        public void Inicializar() 
        {
            SalidaOk = false;
        }

        public bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_PreferenciaBusquedaProducto();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var r02 = Sistema.MyData.Empresa_GetTasas();
            if (r02.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }

            var r03 = Sistema.MyData.Concepto_PorMovCompra();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }

            var mt = Controlador.GestionProductoBuscar.metodoBusqueda.SinDefinir;
            switch (r01.Entidad)
            {
                case OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProducto.PorCodigo:
                    mt = Controlador.GestionProductoBuscar.metodoBusqueda.Codigo;
                    break;
                case OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProducto.PorNombre:
                    mt= Controlador.GestionProductoBuscar.metodoBusqueda.Nombre;
                    break;
                case OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProducto.Referencia:
                    mt= Controlador.GestionProductoBuscar.metodoBusqueda.Referencia;
                    break;
            }
            gestionPrdBuscar.setMetodoBusqueda(mt);
            tasasFiscal = r02.Entidad;
            conceptoCompra = r03.Entidad;

            return rt;
        }

        public void Salir()
        {
            SalidaOk = false;
            var ms = MessageBox.Show("Estas Seguro de Abandonar/Perder Datos del Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (ms == DialogResult.Yes)
            {
                SalidaOk = true;
            }
        }

        public void LimpiarDocumento()
        {
            var ms = MessageBox.Show("Estas Seguro Limpiar/Perder Los Datos ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (ms == DialogResult.Yes)
            {
                gestionItem.Limpiar();
                gestionDoc.Limpiar();
            }
        }

        public void BuscarProducto()
        {
            if (!gestionDoc.IsAceptarOk)
            {
                Helpers.Msg.Alerta("Debe Primero Hacer Click En Nuevo Documento");
                return;
            }
            gestionPrdBuscar.BuscarProducto();
            if (gestionPrdBuscar.IsProductoSeleccionadoOk)
            {
                var autoPrd = gestionPrdBuscar.AutoProductoSeleccionado;
                if (verificarDepositoAsignado(autoPrd))
                    gestionItem.AgregarItem(autoPrd, gestionDoc.Proveedor.autoId, gestionDoc.FactorDivisa);
            }
        }

        private bool verificarDepositoAsignado(string prdAuto)
        {
            var rt = true;
            var ficha = new OOB.LibCompra.Producto.VerificarDepositoAsignado.Ficha() { autoPrd = prdAuto, autoDeposito = gestionDoc.IdDeposito };
            var rt1 = Sistema.MyData.Producto_VerificaDepositoAsignado(ficha);
            if (rt1.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return false;
            }
            return rt;
        }

        public void ActivarBusquedaProductoPorCodigo()
        {
            gestionPrdBuscar.setMetodoBusqueda(Controlador.GestionProductoBuscar.metodoBusqueda.Codigo);
        }

        public void ActivarBusquedaProductoPorNombre()
        {
            gestionPrdBuscar.setMetodoBusqueda(Controlador.GestionProductoBuscar.metodoBusqueda.Nombre);
        }

        public void ActivarBusquedaProductoPorReferencia()
        {
            gestionPrdBuscar.setMetodoBusqueda(Controlador.GestionProductoBuscar.metodoBusqueda.Referencia);
        }

        public void Guardar()
        {
            SalidaOk = false;

            if (!gestionDoc.IsAceptarOk)
            {
                Helpers.Msg.Error("Datos Del Documento Incorrectos !!!");
                return;
            }

            if (gestionItem.TItems == 0)
            {
                Helpers.Msg.Error("No Hay Items Que Procesar !!!");
                return;
            }

            if (gestionItem.TotalMonto == 0.0m)
            {
                Helpers.Msg.Error("Monto del Documento Incorrecto !!!");
                return;
            }

            SalidaOk = GuardarDoc();
        }

        private bool GuardarDoc()
        {
            var rt = true;

            var tasaCambioActual = 0.0m;
            var metodoCalculoUtilidad = OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.SinDefinir;
            var forzarRedondeo = OOB.LibCompra.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.SinDefinir;
            var preferenciPrecio = OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.SinDefinir;

            var rt1 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return false;
            }
            tasaCambioActual = rt1.Entidad; 
            var rt2 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad ();
            if (rt2.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt2.Mensaje);
                return false;
            }
            metodoCalculoUtilidad = rt2.Entidad;
            var rt3 = Sistema.MyData.Configuracion_ForzarRedondeoPrecioVenta();
            if (rt3.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt3.Mensaje);
                return false;
            }
            forzarRedondeo = rt3.Entidad;
            var rt4 = Sistema.MyData.Configuracion_PreferenciaRegistroPrecio();
            if (rt4.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt4.Mensaje);
                return false;
            }
            preferenciPrecio = rt4.Entidad;

            var fichaPrdPrecio = new List<OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecio>();
            var fichaPrdPrecioHistorico = new List<OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico>();
            foreach (dataItem it in gestionItem.Lista)
            {

                if (it.Producto.costoUnd >= it.CostoFinal_Und)
                {
                    continue;
                }

                var rt5 = Sistema.MyData.Producto_GetUtilidadPrecio(it.Producto.auto);
                if (rt5.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(rt5.Mensaje);
                    return false;
                }

                var xprecio = new Precio(rt5.Entidad);
                xprecio.setCostoDivisaUnd(it.CostoDivisaFinal_Und);
                xprecio.setRedondeo(forzarRedondeo);
                xprecio.setCalculoUtilidad(metodoCalculoUtilidad);
                xprecio.setTasaCambioActual(tasaCambioActual);
                xprecio.setPreferenciaRegistroPrecio(preferenciPrecio);

                var nr = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecio()
                {
                    autoPrd = xprecio.autoPrd,
                    pDivisaFull_1 = xprecio.pDivisaFull_1,
                    pDivisaFull_2 = xprecio.pDivisaFull_2,
                    pDivisaFull_3 = xprecio.pDivisaFull_3,
                    pDivisaFull_4 = xprecio.pDivisaFull_4,
                    pDivisaFull_5 = xprecio.pDivisaFull_5,
                    precioNeto_1= xprecio.PrecioNeto_1,
                    precioNeto_2 = xprecio.PrecioNeto_2,
                    precioNeto_3 = xprecio.PrecioNeto_3,
                    precioNeto_4 = xprecio.PrecioNeto_4,
                    precioNeto_5 = xprecio.PrecioNeto_5,
                };
                fichaPrdPrecio.Add(nr);

                if (nr.precioNeto_1 > 0) 
                {
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = nr.precioNeto_1,
                        precioId = "1",
                    };
                    fichaPrdPrecioHistorico.Add(ph);
                }
                if (nr.precioNeto_2 > 0)
                {
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = nr.precioNeto_2,
                        precioId = "2",
                    };
                    fichaPrdPrecioHistorico.Add(ph);
                }
                if (nr.precioNeto_3 > 0)
                {
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = nr.precioNeto_3,
                        precioId = "3",
                    };
                    fichaPrdPrecioHistorico.Add(ph);
                }
                if (nr.precioNeto_4 > 0)
                {
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = nr.precioNeto_4,
                        precioId = "4",
                    };
                    fichaPrdPrecioHistorico.Add(ph);
                }
                if (nr.precioNeto_5 > 0)
                {
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = nr.precioNeto_5,
                        precioId = "pto",
                    };
                    fichaPrdPrecioHistorico.Add(ph);
                }
            }

            var saldoPend = 0.0m;
            if (gestionDoc.DiasCredito>0)
                saldoPend=gestionItem.TotalMonto_Final;

            var fichaDoc = new OOB.LibCompra.Documento.Cargar.Factura.FichaDocumento()
            {
                anoRelacion = gestionDoc.AnoRelacion,
                anticipoIva = 0.0m,
                aplicaDocumentoNro = "",
                autoConcepto = "0000000001",
                autoProveedor = gestionDoc.Proveedor.autoId,
                autoRemision = "",
                cierreFtp = "",
                ciRifProveedor = gestionDoc.Proveedor.ciRif,
                cntRenglones = gestionItem.TItems,
                codicionPago = gestionDoc.CondicionPago,
                codigoProveedor = gestionDoc.Proveedor.codigo,
                columna = "1",
                comprobanteRetencionISLR = "",
                comprobanteRetencionNro = "",
                controlNro = gestionDoc.ControlNro,
                denominacionFiscal = "No Contribuyente",
                diasCredito = gestionDoc.DiasCredito,
                diasValidez = 0,
                direccionFiscalProveedor = gestionDoc.Proveedor.direccionFiscal,
                documentoNombre = "COMPRAS",
                documentoNro = gestionDoc.DocumentoNro,
                documentoRemision = "",
                documentoTipo = "Compras",
                esAnulado = "0",
                estacionEquipo = Sistema.EquipoEstacion,
                estatusCierreContable = "0",
                expediente = "",
                factorCambio = gestionDoc.FactorDivisa,
                fechaDocumento = gestionDoc.FechaEmision,
                fechaRetencion = new DateTime(2000, 01, 01).Date,
                fechaVencimiento = gestionDoc.FechaVencimiento,
                mesRelacion = gestionDoc.MesRelacion,
                montoBase = gestionItem.MontoBase_Final,
                montoBase1 = gestionItem.MontoBase1_Final,
                montoBase2 = gestionItem.MontoBase2_Final,
                montoBase3 = gestionItem.MontoBase3_Final,
                montoCargo = gestionItem.MontoCargo_Final,
                montoCosto = 0.0m,
                montoDescuento1 = gestionItem.MontoDescuento_Final,
                montoDescuento2 = 0.0m,
                montoDivisa = gestionItem.MontoDivisa_Final,
                montoExento = gestionItem.MontoExento_Final,
                montoImpuesto = gestionItem.MontoImpuesto_Final,
                montoImpuesto1 = gestionItem.MontoImpuesto1_Final,
                montoImpuesto2 = gestionItem.MontoImpuesto2_Final,
                montoImpuesto3 = gestionItem.MontoImpuesto3_Final,
                montoNeto = gestionItem.TotalMonto_Final - gestionItem.MontoImpuesto_Final,
                montoRetencionISLR = 0.0m,
                montoRetencionIva = 0.0m,
                montoSaldoPendeiente = saldoPend,
                montoTotal = gestionItem.TotalMonto_Final,
                montoUtilidad = 0.0m,
                nombreRazonSocialProveedor = gestionDoc.Proveedor.nombreRazonSocial,
                notaDocumento = gestionDoc.Notas,
                ordenCompraNro = gestionDoc.OrdenCompraNro,
                planilla = "",
                serieDocumento = "FAC",
                signoDocumento = 1,
                situacionDocumento = "Procesado",
                subTotalNeto = gestionItem.TotalMonto_Final - gestionItem.MontoImpuesto_Final,
                subTotal = gestionItem.TotalMonto_Final,
                subTotalImpuesto = gestionItem.MontoImpuesto_Final,
                sucursalCodigo = gestionDoc.Sucursal.codigo,
                tarifa = "0",
                telefonoPropveedor = gestionDoc.Proveedor.identidad.telefono,
                tercerosIva = 0.0m,
                tipoDocumento = "01",
                tipoProveedor = "",
                tipoRemision = "",
                usuarioAuto = Sistema.UsuarioP.autoUsu,
                usuarioCodigo = Sistema.UsuarioP.codigoUsu,
                usuarioNombre = Sistema.UsuarioP.nombreUsu,
                valorPorccargo = gestionTotalizar.Cargo,
                valorPorcDescuento1 = gestionTotalizar.Dscto,
                valorPorcDescuento2 = 0.0m,
                valorPorctUtilidad = 0.0m,
                valorTasaIva1 = tasasFiscal.Tasa1,
                valorTasaIva2 = tasasFiscal.Tasa2,
                valorTasaIva3 = tasasFiscal.Tasa3,
                valorTasaRetencionISLR = 0.0m,
                valorTasaRetencionIva = 0.0m,
            };
            var fichaCxP = new OOB.LibCompra.Documento.Cargar.Factura.FichaCxP()
            {
                acumulado = 0.0m,
                Anexo = "",
                autoAgencia = "0000000001",
                autoProveedor = gestionDoc.Proveedor.autoId,
                ciRifProveedor = gestionDoc.Proveedor.ciRif,
                codigoProveedor = gestionDoc.Proveedor.codigo,
                diasCredito = gestionDoc.DiasCredito,
                documentoNro = gestionDoc.DocumentoNro,
                esAnulado = "0",
                esCancelado = "0",
                estatusCierreContable = "0",
                fechaVencimiento = gestionDoc.FechaVencimiento,
                importe = gestionItem.TotalMonto_Final,
                importeDivisa = gestionItem.MontoDivisa_Final,
                nombreAgencia = "",
                nombreRazonSocialProveedor = gestionDoc.Proveedor.nombreRazonSocial,
                nota = "",
                numero = "",
                resta = gestionItem.TotalMonto_Final,
                signoDocumento = 1,
                tipoDocumento = "FAC",
            };
            var fichaDetalle= new List<OOB.LibCompra.Documento.Cargar.Factura.FichaDetalle>();
            var fichaPrdDeposito = new List<OOB.LibCompra.Documento.Cargar.Factura.FichaPrdDeposito>();
            var fichaPrdKardex = new List<OOB.LibCompra.Documento.Cargar.Factura.FichaPrdKardex>();
            var fichaPrdCosto= new List<OOB.LibCompra.Documento.Cargar.Factura.FichaPrdCosto>();
            var fichaPrdCostoHistorico = new List<OOB.LibCompra.Documento.Cargar.Factura.FichaPrdCostoHistorico>();
            var fichaPrdProveedor  = new List<OOB.LibCompra.Documento.Cargar.Factura.FichaPrdProveedor>();
            foreach (dataItem it in gestionItem.Lista)
            {
                var detalle = new OOB.LibCompra.Documento.Cargar.Factura.FichaDetalle()
                {
                    autoDepartamento = it.Producto.autoDepartamento,
                    autoDeposito = gestionDoc.IdDeposito,
                    autoGrupo = it.Producto.autoGrupo,
                    autoProducto = it.Producto.auto,
                    autoProveedor = gestionDoc.Proveedor.autoId,
                    autoSubGrupo= it.Producto.autoSubGrupo,
                    autoTasaIva = it.Producto.autoTasa,
                    cantidadBonoFac = 0.0m,
                    cantidadFac = it.cantidad,
                    cantidadUnd = it.CantidadUnd,
                    categoriaPrd = it.Producto.categoria,
                    cierreFtp = "",
                    codigoProducto = it.Producto.codigo,
                    codigoProveedor = it.CodRefPrv,
                    contenidoEmpaque = it.Producto.contenidoCompra,
                    costoBruto=it.costoMoneda,
                    costoCompra=it.CostoFinal,
                    costoPromedioUnd=0.0m,
                    costoUnd=it.CostoFinal_Und ,
                    decimalesPrd = it.Producto.decimales,
                    depositoCodigo = gestionDoc.Deposito.codigo,
                    depositoNombre = gestionDoc.Deposito.nombre,
                    detalle = "",
                    empaquePrd = it.ProductoEmpaqueDesc,
                    esAnulado = "0",
                    estatusUnidad = "0",
                    fechaLote = new DateTime(200, 01, 01).Date,
                    montoDescto1 = it.dsct_1_m,
                    montoDescto2 = it.dsct_2_m,
                    montoDescto3 = it.dsct_3_m,
                    montoImpuesto = it.impuesto,
                    montoTotal = it.total,
                    nombreProducto = it.Producto.descripcion,
                    signo = 1,
                    tipoDocumento = "01",
                    totalNeto=it.subTotal_2,
                    valorPorcDescto1 = it.dsct_1_p,
                    valorPorcDescto2 = it.dsct_2_p,
                    valorPorcDescto3 = it.dsct_3_p,
                    valorTasaIva = it.Producto.tasaIva,
                };
                fichaDetalle.Add(detalle);
                var prdDep = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdDeposito()
                {
                    autoDep = gestionDoc.IdDeposito,
                    autoPrd = it.Producto.auto,
                    cantidadUnd = it.CantidadUnd,
                    nombrePrd = it.Producto.descripcion,
                };
                fichaPrdDeposito.Add(prdDep);
                var prdKardex = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdKardex()
                {
                    autoConcepto = conceptoCompra.auto,
                    autoDeposito = gestionDoc.Deposito.auto,
                    autoPrd = it.Producto.auto,
                    cantidadBonoFac = 0.0m,
                    cantidadFac = it.cantidad,
                    cantidadUnd = it.CantidadUnd,
                    cierreFtp = "",
                    codigoConcepto = conceptoCompra.codigo,
                    codigoDeposito = gestionDoc.Deposito.codigo,
                    codigoMovDoc = "01",
                    codigoSucursal = gestionDoc.Sucursal.codigo,
                    costoUnd = it.CostoFinal_Und,
                    documentoNro = gestionDoc.DocumentoNro,
                    entidad = gestionDoc.Proveedor.nombreRazonSocial,
                    esAnulado = "0",
                    modulo = "Compras",
                    montoTotal = it.TotalFinal,
                    nombreConcepto = conceptoCompra.nombre,
                    nombreDeposito = gestionDoc.Deposito.nombre,
                    nota = "",
                    precioUnd = 0.0m,
                    siglasMovDoc = "FAC",
                    signoDocumento = 1,
                    nombrePrd = it.Producto.descripcion,
                };
                fichaPrdKardex.Add(prdKardex);
                var prdCosto = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdCosto()
                {
                    autoPrd = it.Producto.auto,
                    cntUnd = it.CantidadUnd,
                    contenido = it.Producto.contenidoCompra,
                    costo = it.CostoFinal,
                    costoDivisa = it.CostoDivisaFinal,
                    costoUnd = it.CostoFinal_Und,
                    nombrePrd = it.Producto.descripcion,
                };
                fichaPrdCosto.Add(prdCosto);
                var prdCostoHistorico = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdCostoHistorico()
                {
                    autoPrd = it.Producto.auto,
                    costo = it.CostoFinal,
                    costoDivisa = it.CostoDivisaFinal,
                    documento = gestionDoc.DocumentoNro,
                    nota = "",
                    serie = "FAC",
                    tasaDivisa = gestionDoc.FactorDivisa,
                };
                fichaPrdCostoHistorico.Add(prdCostoHistorico);
                if (it.CodRefPrvActual=="")
                {
                    if (it.CodRefPrv != "") 
                    {
                        var prdProveedor = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdProveedor()
                        {
                            autoPrd = it.Producto.auto,
                            autoProveedor = gestionDoc.Proveedor.autoId,
                            codigoRefProveedor = it.CodRefPrv,
                        };
                        fichaPrdProveedor.Add(prdProveedor);
                    }
                }
            }

            var ficha = new OOB.LibCompra.Documento.Cargar.Factura.Ficha()
            {
                documento = fichaDoc,
                cxp = fichaCxP,
                detalles = fichaDetalle,
                prdDeposito = fichaPrdDeposito,
                prdKardex = fichaPrdKardex,
                prdCosto = fichaPrdCosto,
                prdCostosHistorico = fichaPrdCostoHistorico,
                prdProveedor = fichaPrdProveedor,
                prdPrecios= fichaPrdPrecio,
                prdPreciosHistorico=fichaPrdPrecioHistorico,
            };

            var r01 = Sistema.MyData.Compra_DocumentoAgregarFactura(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            Helpers.Msg.AgregarOk();
            Helpers.VisualizarDocumento.Visualizar(r01.Auto);

            return rt;
        }

        public void CargarItems()
        {
        }

        public void Totalizar()
        {
            if (!gestionDoc.IsAceptarOk)
            {
                Helpers.Msg.Error("Datos Del Documento Incorrectos !!!");
                return;
            }

            if (gestionItem.TItems == 0)
            {
                Helpers.Msg.Error("No Hay Items Que Procesar !!!");
                return;
            }

            if (gestionItem.TotalMonto == 0.0m)
            {
                Helpers.Msg.Error("Monto del Documento Incorrecto !!!");
                return;
            }

            gestionTotalizar.SetMonto(gestionItem.TotalMonto);
            gestionTotalizar.SetNotas(gestionDoc.Notas);
            gestionTotalizar.Inicia();
            if (gestionTotalizar.IsOk)
            {
                gestionItem.setDescuentoFinal(gestionTotalizar.Dscto);
                gestionItem.setCargoFinal(gestionTotalizar.Cargo);
                gestionDoc.setNotas(gestionTotalizar.Notas);
                Guardar();
            }
        }

    }

}