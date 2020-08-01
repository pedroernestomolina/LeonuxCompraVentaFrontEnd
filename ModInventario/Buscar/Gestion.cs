using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Buscar
{

    public class Gestion
    {

        private Filtrar.Gestion _gestionFiltro;
        private GestionLista _gestionLista;
        private OOB.LibInventario.Producto.Filtro _filtros;


        public OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda MetodoBusqueda { get; set; }
        public string Cadena { get; set; }
        public object Source { get { return _gestionLista.Source; } }
        public int Items { get { return _gestionLista.Items; } }
        public OOB.LibInventario.Producto.Data.Ficha Item { get { return _gestionLista.Item; } }
        public bool HayItemSeleccionado { get; set; }


        public Gestion()
        {
            _filtros = new OOB.LibInventario.Producto.Filtro();
            _gestionFiltro = new Filtrar.Gestion();
            _gestionLista = new GestionLista();
            _gestionLista.CambioItemActual+=_gestionLista_CambioItemActual;
            LimpiarEntradas();
        }

        private void _gestionLista_CambioItemActual(object sender, EventArgs e)
        {
            frm.ActualizarItem();
        }

        private void LimpiarEntradas()
        {
            Cadena = "";
            MetodoBusqueda = OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda.Codigo;
        }

        BusquedaFrm frm;
        public void Inicia() 
        {
            HayItemSeleccionado = false;
            _gestionLista.Limpiar();

            frm = new BusquedaFrm();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public void RealizarBusqueda()
        {
            _filtros.cadena = this.Cadena;
            _filtros.MetodoBusqueda = this.MetodoBusqueda;
            var r01 = Sistema.MyData.Producto_GetLista(_filtros);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            _gestionLista.setLista(r01.Lista);
            _filtros.Limpiar();
            frm.ActualizarItem();
            Cadena = "";
        }

        public void FiltrarBusqueda()
        {
            _gestionFiltro.Inicia();
            if (_gestionFiltro.IsFiltrarOk) 
            {
                _filtros.autoDepartamento = _gestionFiltro.AutoDepartamento;
                _filtros.autoGrupo = _gestionFiltro.AutoGrupo;
                _filtros.autoTasa = _gestionFiltro.AutoTasa;
                if (_gestionFiltro.IdOrigen != "") 
                {
                    _filtros.origen = (OOB.LibInventario.Producto.Enumerados.EnumOrigen)int.Parse(_gestionFiltro.IdOrigen);
                }
                if (_gestionFiltro.IdCategoria != "") 
                {
                    _filtros.categoria = (OOB.LibInventario.Producto.Enumerados.EnumCategoria)int.Parse(_gestionFiltro.IdCategoria);
                }
                RealizarBusqueda();
            }
        }

        public void SeleccionarItem()
        {
            HayItemSeleccionado = _gestionLista.SeleccionarItem() != null ? true : false;
        }

    }

}