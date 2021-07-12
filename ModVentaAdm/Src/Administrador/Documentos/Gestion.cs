using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Administrador.Documentos
{

    public class Gestion: IGestion
    {


        private IGestionListaDetalle _gestionLista;
        private Filtro.Gestion _gestionFiltro;
        private Reportes.Filtro.Gestion _gestionFiltro2;


        public BindingSource ItemsSource { get { return _gestionLista.ItemsSource; } }
        public string ItemsEncontrados { get { return _gestionLista.ItemsEncontrados; } }
        public BindingSource SucursalSource { get { return _gestionFiltro.SucursalSource; } }
        public BindingSource TipoDocSource { get { return _gestionFiltro.TipoDocSource; } }


        public Gestion()
        {
            _gestionLista = new GestionLista();
            _gestionFiltro = new Filtro.Gestion();
            _gestionFiltro2 = new Reportes.Filtro.Gestion();
        }


        public void Inicializa()
        {
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
            _gestionFiltro2.Inicializa();
            _gestionFiltro2.LimpiarCliente();
        }

        private void GenerarBusqueda()
        {
            var r01= _gestionFiltro.Filtro();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            if (_gestionFiltro2.ClienteSeleccionadoIsOK)
            {
                r01.Entidad.idCliente = _gestionFiltro2.IdCliente;
            }

            var rt1 = Sistema.MyData.Documento_Get_Lista(r01.Entidad);
            if (rt1.Result == OOB.Resultado.Enumerados.EnumResult.isError )
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return;
            }
            _gestionLista.setLista(rt1.ListaD);
        }


        public void AnularItem()
        {
        }

        public void LimpiarFiltros()
        {
            _gestionFiltro.LimpiarFiltros();
            _gestionFiltro2.Inicializa();
            _gestionFiltro2.LimpiarCliente();
        }

        public void LimpiarData()
        {
            _gestionLista.LimpiarData();
        }

        public void VisualizarDocumento()
        {
            _gestionLista.VisualizarDocumento();
        }

        public void Imprimir()
        {
        }

        public void Limpiar()
        {
        }

        private bool CargarData()
        {
            return _gestionFiltro.CargarData();
        }

        private DateTime _fechaDesde=DateTime.Now.Date;
        public void setFechaDesde(DateTime fecha)
        {
            _gestionFiltro.setFechaDesde(fecha);
            _fechaDesde = fecha;
        }

        private DateTime _fechaHasta=DateTime.Now.Date;
        public void setFechaHasta(DateTime fecha)
        {
            _gestionFiltro.setFechaHasta(fecha);
            _fechaHasta = fecha;
        }

        private string _idSucursal;
        public void setSucursal(string autoId)
        {
            _gestionFiltro.setSucursal(autoId);
            _idSucursal = autoId;
        }

        public void setTipoDoc(string id)
        {
            _gestionFiltro.setTipoDoc(id);
        }

        public void CorrectorDocumento()
        {
        }

        public void Filtros()
        {
            var filt = new filtro();
            _gestionFiltro2.Inicializa();
            _gestionFiltro2.setFiltros(filt);
            if (_gestionFiltro2.CargarData()) 
            {
                _gestionFiltro2.setFechaDesde(_fechaDesde);
                _gestionFiltro2.setFechaHasta(_fechaHasta);
                _gestionFiltro2.setSucursal(_idSucursal);
                _gestionFiltro2.Inicia();
            }
        }

    }

}