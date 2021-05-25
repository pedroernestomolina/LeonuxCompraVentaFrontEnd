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


        public BindingSource ItemsSource { get { return _gestionLista.ItemsSource; } }
        public string ItemsEncontrados { get { return _gestionLista.ItemsEncontrados; } }
        public BindingSource SucursalSource { get { return _gestionFiltro.SucursalSource; } }
        public BindingSource TipoDocSource { get { return _gestionFiltro.TipoDocSource; } }


        public Gestion()
        {
            _gestionLista = new GestionLista();
            _gestionFiltro = new Filtro.Gestion();
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
        }

        private void GenerarBusqueda()
        {
            var r01= _gestionFiltro.Filtro();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
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

        public void setFechaDesde(DateTime fecha)
        {
            _gestionFiltro.setFechaDesde(fecha);
        }

        public void setFechaHasta(DateTime fecha)
        {
            _gestionFiltro.setFechaHasta(fecha);
        }

        public void setSucursal(string autoId)
        {
            _gestionFiltro.setSucursal(autoId);
        }

        public void setTipoDoc(string id)
        {
            _gestionFiltro.setTipoDoc(id);
        }

        public void CorrectorDocumento()
        {
        }

    }

}