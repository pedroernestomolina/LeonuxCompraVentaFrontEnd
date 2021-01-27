using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Administrador.Documentos
{
    
    public class Gestion : IGestion
    {


        private IGestionListaDetalle _gestionListaDetalle;
        private Anular.Gestion _gestionAnular;
        private Filtros.Gestion _gestionFiltros;


        public enumerados.EnumTipoAdministrador TipoAdministrador { get { return enumerados.EnumTipoAdministrador.AdmDocumentos; } }
        public string Titulo { get { return "Administrador De Documentos"; } }
        public BindingSource ItemsSource { get { return _gestionListaDetalle.ItemsSource; } }
        public BindingSource SucursalSource { get { return _gestionFiltros.SucursalSource; } }
        public BindingSource TipoDocSource { get { return _gestionFiltros.TipoDocSource; } }
        public string ItemsEncontrados { get { return _gestionListaDetalle.ItemsEncontrados; } }


        public Gestion()
        {
            _gestionFiltros = new Filtros.Gestion();
            _gestionAnular = new Anular.Gestion();
            _gestionListaDetalle = new GestionListaDetalle();
            _gestionListaDetalle.setGestionAnular(_gestionAnular);
        }

        public void Buscar()
        {
            GenerarBusqueda();
        }

        private void GenerarBusqueda()
        {
            var filtro = new OOB.LibCompra.Documento.Lista.Filtro();

            if (_gestionFiltros.DataFiltrar.FechaIsOk())
            {
                filtro.Desde = _gestionFiltros.DataFiltrar.FechaDesde.Date;
                filtro.Hasta = _gestionFiltros.DataFiltrar.FechaHasta.Date;
            }
            else
            {
                Helpers.Msg.Error("Fechas Incorrectas, Verifique Por Favor");
                return;
            }

            if (_gestionFiltros.DataFiltrar.Sucursal != null) 
            {
                filtro.CodigoSuc = _gestionFiltros.DataFiltrar.Sucursal.codigo;
            }

            if (_gestionFiltros.DataFiltrar.TipoDoc != null)
            {
                switch (_gestionFiltros.DataFiltrar.TipoDoc.id) 
                {
                    case "01":
                        filtro.TipoDocumento = OOB.LibCompra.Documento.Enumerados.enumTipoDocumento.Factura;
                        break;
                    case "02":
                        filtro.TipoDocumento = OOB.LibCompra.Documento.Enumerados.enumTipoDocumento.NotaDebito;
                        break;
                    case "03":
                        filtro.TipoDocumento = OOB.LibCompra.Documento.Enumerados.enumTipoDocumento.NotaCredito;
                        break;
                    case "04":
                        filtro.TipoDocumento = OOB.LibCompra.Documento.Enumerados.enumTipoDocumento.OrdenCompra;
                        break;
                    case "05":
                        filtro.TipoDocumento = OOB.LibCompra.Documento.Enumerados.enumTipoDocumento.Recepcion;
                        break;
                }
            }

            var rt1 = Sistema.MyData.Compra_DocumentoGetLista(filtro);
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return;
            }
            _gestionListaDetalle.setLista(rt1.Lista);
        }

        public void AnularItem()
        {
            _gestionListaDetalle.AnularItem();
        }

        public void LimpiarData()
        {
            _gestionListaDetalle.LimpiarData();
        }

        public void VisualizarDocumento()
        {
            _gestionListaDetalle.VisualizarDocumento();
        }

        public void Imprimir()
        {
            _gestionListaDetalle.Imprimir();
        }

        public void setFechaDesde(DateTime fecha)
        {
            _gestionFiltros.setFechaDesde(fecha);
        }

        public void setFechaHasta(DateTime fecha)
        {
            _gestionFiltros.setFechaHasta(fecha);
        }

        public void Inicia()
        {
        }

        public void Limpiar()
        {
            _gestionFiltros.InicializarFiltros();
        }

        public bool CargarData()
        {
            var rt = true;

            if (!_gestionFiltros.CargarData())
                return false;

            return rt;
        }

        public void LimpiarFiltros()
        {
            _gestionFiltros.InicializarFiltros();
        }

        public void setSucursal(string autoId)
        {
            _gestionFiltros.setSucursal(autoId);
        }

        public void setTipoDoc(string id)
        {
            _gestionFiltros.setTipoDoc(id);
        }

        public void CorrectorDocumento()
        {
            _gestionListaDetalle.CorrectorDocumento();
        }

    }

}