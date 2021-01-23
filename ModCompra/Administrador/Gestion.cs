using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Administrador
{
    
    public class Gestion
    {

        private IGestion _miGestion;


        public enumerados.EnumTipoAdministrador TipoAdministrador { get { return _miGestion.TipoAdministrador; } }
        public string Titulo { get { return _miGestion.Titulo; } }
        public string ItemsEncontrados { get { return _miGestion.ItemsEncontrados; } }
        public BindingSource ItemsSource { get { return _miGestion.ItemsSource; } }
        public BindingSource SucursalSource { get { return _miGestion.SucursalSource; } }
        public BindingSource TipoDocSource { get { return _miGestion.TipoDocSource; } }

        
        AdministradorFrm frm;
        public void Inicia()
        {
            _miGestion.Limpiar();
            if (_miGestion.CargarData())
            {
                frm = new AdministradorFrm();
                frm.setControlador(this);
                frm.Show();
            }
        }

        public void setGestion(IGestion gestion)
        {
            _miGestion = gestion;
        }


        public void setFechaDesde(DateTime fecha)
        {
            _miGestion.setFechaDesde(fecha);
        }

        public void setFechaHasta(DateTime fecha)
        {
            _miGestion.setFechaHasta(fecha);
        }

        public void Buscar()
        {
            _miGestion.Buscar();
        }

        public void LimpiarFiltros()
        {
            _miGestion.LimpiarFiltros();
        }

        public void LimpiarData()
        {
            _miGestion.LimpiarData();
        }

        public void VisualizarDocumento()
        {
            _miGestion.VisualizarDocumento();
        }

        public void setSucursal(string autoId)
        {
            _miGestion.setSucursal(autoId);
        }

        public void setTipoDoc(string id)
        {
            _miGestion.setTipoDoc(id);
        }

        public void AnularItem()
        {
            _miGestion.AnularItem();
        }

        public void Imprimir()
        {
            Helpers.Msg.Alerta("IR A REPORTES");
        }

    }

}