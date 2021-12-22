﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Administrador.Documentos
{

    public class Gestion: IGestion
    {


        private Reportes.Filtro.IFiltro _filtrarPor;
        private IGestionListaDetalle _gLista;
        private Reportes.Filtro.Gestion _gFiltro;
        private Reportes.Modo.ListaDocumento.Gestion _gRepDoc;
        private Helpers.Imprimir.IDocumento _gVisualizarDoc;


        public BindingSource ItemsSource { get { return _gLista.ItemsSource; } }
        public string ItemsEncontrados { get { return _gLista.ItemsEncontrados; } }
        public BindingSource SucursalSource { get { return _gFiltro.SourceSucursal ; } }
        public BindingSource TipoDocSource { get { return _gFiltro.SourceTipoDoc; } }
        public data GetItemActual { get { return _gLista.GetItemActual; } }
        public DateTime GetDesde { get { return _gFiltro.GetDesde; } }
        public DateTime GetHasta { get { return _gFiltro.GetHasta; } }
        public string GetIdSucursal { get { return _gFiltro.GetIdSucursal ; } }
        public string GetIdTipoDoc { get { return _gFiltro.GetIdTipoDoc; } }


        public Gestion()
        {
            _filtrarPor = new filtro();
            _gLista = new GestionLista();
            _gFiltro= new Reportes.Filtro.Gestion();
            _gRepDoc = new Reportes.Modo.ListaDocumento.Gestion();
            _gVisualizarDoc = new Helpers.Imprimir.Grafico.Documento();
        }


        public void Inicializa()
        {
            _gFiltro.Inicializa();
            _gLista.Inicializa();
        }

        AdmDocFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                frm = new AdmDocFrm();
                frm.setControlador(this);
                frm.Show();
            }
        }

        public void Buscar()
        {
            GenerarBusqueda();
        }

        private void GenerarBusqueda()
        {
            var filtro = new OOB.Documento.Lista.Filtro()
            {
                codSucursal = _gFiltro.GetCodigoSucursal,
                codTipoDocumento= _gFiltro.GetCodigoTipoDoc,
                desde = _gFiltro.GetDesde,
                hasta = _gFiltro.GetHasta,
                idCliente = _gFiltro.GetIdCliente,
                idProducto = _gFiltro.GetIdProducto,
                estatus = _gFiltro.GetEstatus,
            };
            var rt1 = Sistema.MyData.Documento_Get_Lista(filtro);
            if (rt1.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return;
            }
            _gLista.setLista(rt1.ListaD);
        }

        public void AnularItem()
        {
            var msg = "OPCION NO ACTIVADA";
            MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
        }

        public void LimpiarFiltros()
        {
            _gFiltro.LimpiarFiltros();
        }

        public void LimpiarData()
        {
            _gLista.LimpiarData();
        }

        public void VisualizarDocumento()
        {
            if (GetItemActual != null)
            {
                var r01 = Helpers.Imprimir.Documento.CargarDataDocumento(GetItemActual.idDocumento);
                if (r01 != null)
                {
                    _gVisualizarDoc.setData(r01);
                    _gVisualizarDoc.ImprimirDoc();
                }
            }
        }

        public void Imprimir()
        {
            _gRepDoc.setFiltros(_gFiltro.GetFiltros());
            _gRepDoc.setListaDoc(_gLista.GetListaDoc);
            _gRepDoc.Generar();
        }

        private bool CargarData()
        {
            return _gFiltro.CargarData();
        }

        public void setFechaDesde(DateTime fecha)
        {
            _gFiltro.setFechaDesde(fecha);
        }

        public void setFechaHasta(DateTime fecha)
        {
            _gFiltro.setFechaHasta(fecha);
        }

        public void setSucursal(string autoId)
        {
            _gFiltro.setSucursal(autoId);
        }

        public void setTipoDoc(string id)
        {
            _gFiltro.setTipoDoc(id);
        }

        public void CorrectorDocumento()
        {
            var msg = "OPCION NO ACTIVADA";
            MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
        }

        public void Filtros()
        {
            _gFiltro.setFiltros(_filtrarPor);
            _gFiltro.Inicia();
        }

    }

}