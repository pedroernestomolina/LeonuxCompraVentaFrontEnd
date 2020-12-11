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

        private List<OOB.LibInventario.Sucursal.Ficha> lSucursal;
        private BindingSource bsSucursal;
        private IGestionListaDetalle _gestionListaDetalle;
        private Anular.Gestion _gestionAnular;
        private Filtros.Gestion _gestionFiltros;


        public enumerados.EnumTipoAdministrador TipoAdministrador { get { return enumerados.EnumTipoAdministrador.AdmDocumentos; } }
        public string Titulo { get { return "Administrador De Documentos"; } }
        public BindingSource ItemsSource { get { return _gestionListaDetalle.ItemsSource; } }
        public BindingSource SucursalSource { get { return bsSucursal; } }
        public string ItemsEncontrados { get { return _gestionListaDetalle.ItemsEncontrados; } }


        public Gestion()
        {
            lSucursal = new List<OOB.LibInventario.Sucursal.Ficha>();
            bsSucursal = new BindingSource();
            bsSucursal.DataSource = lSucursal;

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

            if (_gestionFiltros.FechaIsOk)
            {
                filtro.Desde = _gestionFiltros.FechaDesde.Value.Date;
                filtro.Hasta = _gestionFiltros.FechaHasta.Value.Date;
            }
            else
            {
                Helpers.Msg.Error("Fechas Incorrectas, Verifique Por Favor");
                return;
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

            //var rt1 = Sistema.MyData.Sucursal_GetLista();
            //if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(rt1.Mensaje);
            //    return false;
            //}
            //lSucursal.Clear();
            //lSucursal.AddRange(rt1.Lista);
            //bsSucursal.CurrencyManager.Refresh();

            return rt;
        }

        public void LimpiarFiltros()
        {
            _gestionFiltros.InicializarFiltros();
        }

    }

}