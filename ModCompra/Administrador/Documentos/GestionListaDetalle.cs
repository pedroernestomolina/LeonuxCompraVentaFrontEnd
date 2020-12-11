﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Administrador.Documentos
{
    
    public class GestionListaDetalle: IGestionListaDetalle
    {

        private List<data> list;
        private BindingSource bs;
        private BindingList<data> bl;
        private Anular.Gestion _anular;


        public BindingSource ItemsSource { get { return bs; } }
        public string ItemsEncontrados { get { return string.Format("Items Encontrados: {0}", bs.Count); } }
        public data Item { get; set; }


        public GestionListaDetalle()
        {
            list = new List<data>();
            bl = new BindingList<data>(list);
            bs = new BindingSource();
            bs.CurrentChanged += bs_CurrentChanged;
            bs.DataSource = bl;
        }

        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            if (bs.Current != null)
                Item = (data)bs.Current;
        }

        public void LimpiarData()
        {
            if (bl.Count > 0) 
            {
                var msg = MessageBox.Show("Desechar Vista Actual ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    bl.Clear();
                    bs.CurrencyManager.Refresh();
                }
            }
        }

        public void AnularItem()
        {
            if (Item != null)
            {
                //if (!Item.IsAnulado)
                //{
                //    var r00 = Sistema.MyData.Permiso_AdmAnularMovimientoInventario(Sistema.UsuarioP.autoGru);
                //    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                //    {
                //        Helpers.Msg.Error(r00.Mensaje);
                //        return;
                //    }
                //    if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
                //    {
                //        _anular.Inicia();
                //        if (_anular.IsAnularOK)
                //        {
                //            var msg = MessageBox.Show("Anular Movimiento Actual ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                //            if (msg == DialogResult.Yes)
                //            {
                //                switch (Item.Ficha.docTipo)
                //                {
                //                    case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Cargo:
                //                        AnularCargo();
                //                        break;
                //                    case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Descargo:
                //                        AnularDescargo();
                //                        break;
                //                    case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Traslado:
                //                        AnularTraslado();
                //                        break;
                //                    case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Ajuste:
                //                        AnularAjuste();
                //                        break;
                //                }
                //            }
                //        }
                //    }
                //}
                //else
                //    Helpers.Msg.Error("Documento Ya Está Anulado, Verifique Por Favor");
            }
        }

        private void AnularAjuste()
        {
            //var ficha = new OOB.LibInventario.Movimiento.Anular.Ajuste.Ficha()
            //{
            //    autoDocumento = Item.Ficha.autoId,
            //    autoSistemaDocumento = "0000000042",
            //    autoUsuario = Sistema.UsuarioP.autoUsu,
            //    codigoUsuario = Sistema.UsuarioP.codigoUsu,
            //    estacion = Environment.MachineName,
            //    motivo = _anular.Motivo,
            //    nombreUsuario = Sistema.UsuarioP.nombreUsu,
            //};
            //var r01 = Sistema.MyData.Producto_Movimiento_Ajuste_Anular(ficha);
            //if (r01.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return;
            //}

            //Item.Ficha.isDocAnulado = true;
            //bs.CurrencyManager.Refresh();
            //Helpers.Msg.EliminarOk();
        }

        private void AnularTraslado()
        {
            //var ficha = new OOB.LibInventario.Movimiento.Anular.Traslado.Ficha()
            //{
            //    autoDocumento = Item.Ficha.autoId,
            //    autoSistemaDocumento = "0000000026",
            //    autoUsuario = Sistema.UsuarioP.autoUsu,
            //    codigoUsuario = Sistema.UsuarioP.codigoUsu,
            //    estacion = Environment.MachineName,
            //    motivo = _anular.Motivo,
            //    nombreUsuario = Sistema.UsuarioP.nombreUsu,
            //};
            //var r01 = Sistema.MyData.Producto_Movimiento_Traslado_Anular(ficha);
            //if (r01.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return;
            //}

            //Item.Ficha.isDocAnulado = true;
            //bs.CurrencyManager.Refresh();
            //Helpers.Msg.EliminarOk();
        }

        private void AnularDescargo()
        {
            //var ficha = new OOB.LibInventario.Movimiento.Anular.Descargo.Ficha()
            //{
            //    autoDocumento = Item.Ficha.autoId,
            //    autoSistemaDocumento = "0000000025",
            //    autoUsuario = Sistema.UsuarioP.autoUsu,
            //    codigoUsuario = Sistema.UsuarioP.codigoUsu,
            //    estacion = Environment.MachineName,
            //    motivo = _anular.Motivo,
            //    nombreUsuario = Sistema.UsuarioP.nombreUsu,
            //};
            //var r01 = Sistema.MyData.Producto_Movimiento_Descargo_Anular(ficha);
            //if (r01.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return;
            //}

            //Item.Ficha.isDocAnulado = true;
            //bs.CurrencyManager.Refresh();
            //Helpers.Msg.EliminarOk();
        }

        private void AnularCargo()
        {
            //var ficha = new OOB.LibInventario.Movimiento.Anular.Cargo.Ficha()
            //{
            //    autoDocumento = Item.Ficha.autoId,
            //    autoSistemaDocumento = "0000000024",
            //    autoUsuario = Sistema.UsuarioP.autoUsu,
            //    codigoUsuario = Sistema.UsuarioP.codigoUsu,
            //    estacion = Environment.MachineName,
            //    motivo = _anular.Motivo,
            //    nombreUsuario = Sistema.UsuarioP.nombreUsu,
            //};
            //var r01 = Sistema.MyData.Producto_Movimiento_Cargo_Anular(ficha);
            //if (r01.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return;
            //}

            //Item.Ficha.isDocAnulado = true;
            //bs.CurrencyManager.Refresh();
            //Helpers.Msg.EliminarOk();
        }

        public void setGestionAnular(Anular.Gestion _gestionAnular)
        {
            _anular = _gestionAnular;
        }

        public void VisualizarDocumento()
        {
            if (Item != null)
            {
                var r00 = Sistema.MyData.Permiso_AdmDoc_Visualizar (Sistema.UsuarioP.autoGru);
                if (r00.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return;
                }
                if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
                {
                    Helpers.VisualizarDocumento.Visualizar(Item.AutoDoc);
                }
            }
        }

        public void CargarVisualizarDocumento(string idMov)
        {
            //var rt1 = Sistema.MyData.Producto_Movimiento_GetFicha(idMov);
            //if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(rt1.Mensaje);
            //    return;
            //}

            //switch (Item.Ficha.docTipo)
            //{
            //    case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Cargo:
            //    case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Descargo:
            //    case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Traslado:
            //        Visualizar(rt1.Entidad);
            //        break;
            //    case OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Ajuste:
            //        VisualizarAjuste(rt1.Entidad);
            //        break;
            //}
        }

        private void Visualizar(OOB.LibInventario.Movimiento.Ver.Ficha xficha)
        {
            //var ficha = new Reportes.Documentos.data();
            //ficha.documentoNro = xficha.documentoNro;
            //ficha.fecha = xficha.fecha;
            //ficha.notas = xficha.notas;
            //ficha.autorizadoPor = xficha.autorizadoPor;
            //ficha.depositoOrigen = xficha.depositoOrigen;
            //ficha.codigoDepositoOrigen = xficha.codigoDepositoOrigen;
            //ficha.depositoDestino = xficha.depositoDestino;
            //ficha.codigoDepositoDestino = xficha.codigoDepositoDestino;
            //ficha.tipoDocumento = xficha.tipoDocumento;
            //ficha.nombreDocumento = xficha.nombreDocumento;
            //ficha.codigoConcepto = xficha.codigoConcepto;
            //ficha.concepto = xficha.concepto;
            //ficha.estacion = xficha.estacion;
            //ficha.usuario = xficha.usuario;
            //ficha.usuarioCodigo = xficha.usuarioCodigo;

            //var det = new List<Reportes.Documentos.dataDetalle>();
            //foreach (var it in xficha.detalles)
            //{
            //    var nr = new Reportes.Documentos.dataDetalle()
            //    {
            //        cantidad = it.cantidad,
            //        codigo = it.codigo,
            //        costoUnd = it.costoUnd,
            //        descripcion = it.descripcion,
            //        importe = it.importe,
            //        signo = 1,
            //        cantidadUnd = it.cantidadUnd,
            //        contenido = it.contenido,
            //        empaque = it.empaque,
            //        esUnidad = it.esUnidad,
            //    };
            //    det.Add(nr);
            //};
            //ficha.detalles = det;

            //var rp1 = new Reportes.Documentos.Movimiento(ficha);
            //rp1.Generar();
        }

        private void VisualizarAjuste(OOB.LibInventario.Movimiento.Ver.Ficha xficha)
        {
            //var ficha = new Reportes.Documentos.data();
            //ficha.documentoNro = xficha.documentoNro;
            //ficha.fecha = xficha.fecha;
            //ficha.notas = xficha.notas;
            //ficha.autorizadoPor = xficha.autorizadoPor;
            //ficha.depositoOrigen = xficha.depositoOrigen;
            //ficha.codigoDepositoOrigen = xficha.codigoDepositoOrigen;
            //ficha.depositoDestino = xficha.depositoDestino;
            //ficha.codigoDepositoDestino = xficha.codigoDepositoDestino;
            //ficha.tipoDocumento = xficha.tipoDocumento;
            //ficha.nombreDocumento = xficha.nombreDocumento;
            //ficha.codigoConcepto = xficha.codigoConcepto;
            //ficha.concepto = xficha.concepto;
            //ficha.estacion = xficha.estacion;
            //ficha.usuario = xficha.usuario;
            //ficha.usuarioCodigo = xficha.usuarioCodigo;

            //var det = new List<Reportes.Documentos.dataDetalle>();
            //foreach (var it in xficha.detalles)
            //{
            //    var nr = new Reportes.Documentos.dataDetalle()
            //    {
            //        cantidad = it.cantidad,
            //        codigo = it.codigo,
            //        costoUnd = it.costoUnd,
            //        descripcion = it.descripcion,
            //        importe = it.importe,
            //        signo = it.signo,
            //        cantidadUnd = it.cantidadUnd,
            //        contenido = it.contenido,
            //        empaque = it.empaque,
            //        esUnidad = it.esUnidad,
            //        decimales = it.decimales,
            //    };
            //    det.Add(nr);
            //};
            //ficha.detalles = det;

            //var rp1 = new Reportes.Documentos.Movimiento(ficha);
            //rp1.Generar();
        }

        public void Imprimir()
        {
            //var r00 = Sistema.MyData.Permiso_AdmReporteMovimientoInventario(Sistema.UsuarioP.autoGru);
            //if (r00.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(r00.Mensaje);
            //    return;
            //}
            //if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            //{
            //    if (bl.Count > 0)
            //    {
            //        var data = new List<Reportes.Movimientos.data>();
            //        foreach (var rg in bl)
            //        {
            //            var nr = new Reportes.Movimientos.data()
            //            {
            //                documentoNro = rg.DocumentoNro,
            //                concepto = rg.Concepto,
            //                fechaHora = rg.FechaHora,
            //                importe = rg.Ficha.docMonto,
            //                isAnulado = rg.IsAnulado,
            //                nombreDocumento = rg.STipoDoc,
            //                renglones = rg.SRenglones,
            //                situacion = rg.Situacion,
            //                sucursal = rg.Sucursal,
            //                usuarioEstacion = rg.UsuarioEstacion,
            //            };
            //            data.Add(nr);
            //        }
            //        var rp = new Reportes.Movimientos.gestionRep(data);
            //        rp.Generar();
            //    }
            //}
        }

        public void setLista(List<OOB.LibCompra.Documento.Lista.Ficha> list)
        {
            bl.Clear();
            foreach (var rg in list.OrderByDescending(o => o.fechaEmision).ToList())
            {
                bl.Add(new data(rg));
            }
            bs.CurrencyManager.Refresh();
        }

    }

}