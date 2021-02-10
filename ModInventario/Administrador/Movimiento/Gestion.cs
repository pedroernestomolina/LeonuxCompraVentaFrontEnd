using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Administrador.Movimiento
{
    
    public class Gestion: IGestion
    {

        private IGestionListaDetalle _gestionListaDetalle;
        private Anular.Gestion _gestionAnular;
        private Filtros.Gestion _gestionFiltros;
        private List<OOB.LibInventario.Sucursal.Ficha> lSucursal;
        private BindingSource bsSucursal;


        public enumerados.EnumTipoAdministrador TipoAdministrador { get { return enumerados.EnumTipoAdministrador.AdmDocumentos; } }
        public string Titulo { get { return "Administrador De Documentos de Inventario"; } }
        public BindingSource Source { get { return _gestionListaDetalle.Source; } }
        public string Items { get { return _gestionListaDetalle.Items; }}
        public DateTime? Filtro_Desde { get; set; }
        public DateTime? Filtro_Hasta { get; set; }
        public string Filtro_TipoDoc { get; set; }
        public string Filtro_Sucursal { get; set; }
        public BindingSource SucursalSource { get { return bsSucursal; } }


        public Gestion()
        {
            lSucursal = new List<OOB.LibInventario.Sucursal.Ficha>();
            bsSucursal = new BindingSource();
            bsSucursal.DataSource = lSucursal;

            LimpiarFiltros();

            _gestionAnular = new Anular.Gestion();
            _gestionListaDetalle = new GestionListaDetalle();
            _gestionListaDetalle.setGestionAnular(_gestionAnular);
            _gestionFiltros = new Filtros.Gestion();
            _gestionFiltros.setGestion(new Filtros.Administrador.Filtros());
        }


        AdministradorFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                frm = new AdministradorFrm();
                frm.setControlador(this);
                frm.Show();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var rt1 = Sistema.MyData.Sucursal_GetLista();
            if (rt1.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return false;
            }
            lSucursal.Clear();
            lSucursal.AddRange(rt1.Lista.OrderBy(o=>o.nombre).ToList());
            bsSucursal.CurrencyManager.Refresh();

            return rt;
        }

        private void Limpiar()
        {
            Filtro_Desde = DateTime.Now;
            Filtro_Hasta = DateTime.Now;
        }

        public void Buscar()
        {
            GenerarBusqueda();
        }

        private string xfiltros;
        private void GenerarBusqueda()
        {
            xfiltros = "";
            var filtro = new OOB.LibInventario.Movimiento.Lista.Filtro();
            if (Filtro_Desde.HasValue) { filtro.Desde = Filtro_Desde.Value.Date; xfiltros += "Desde: " + Filtro_Desde.Value.ToShortDateString(); }
            if (Filtro_Hasta.HasValue) { filtro.Hasta = Filtro_Hasta.Value.Date; xfiltros += ", Hasta: " + Filtro_Hasta.Value.ToShortDateString(); }

            if (Filtro_Hasta.HasValue) 
                if (Filtro_Desde.HasValue)
                    if (Filtro_Desde.Value > Filtro_Hasta.Value) 
                    {
                        Helpers.Msg.Error("Fechas Incorrectas, Verifique Por Favor");
                        return;
                    }

            if (Filtro_TipoDoc != "") 
            {
                switch (Filtro_TipoDoc) 
                {
                    case "01":
                        filtro.TipoDocumento = OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Cargo;
                        xfiltros += ", Doc/Tipo: CARGO"; 
                        break;
                    case "02":
                        filtro.TipoDocumento = OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Descargo;
                        xfiltros += ", Doc/Tipo: DESCARGO"; 
                        break;
                    case "03":
                        filtro.TipoDocumento = OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Traslado;
                        xfiltros += ", Doc/Tipo: TRASLADO"; 
                        break;
                    case "04":
                        filtro.TipoDocumento = OOB.LibInventario.Movimiento.enumerados.EnumTipoDocumento.Ajuste;
                        xfiltros += ", Doc/Tipo: AJUSTE"; 
                        break;
                }
            }
            filtro.IdSucursal = Filtro_Sucursal;
            if (Filtro_Sucursal!="")
                xfiltros += ", Cod/Suc: "+Filtro_Sucursal; 

            if (_gestionFiltros.FiltrosIsOk)
            {
                if (_gestionFiltros.DataFiltrar.depDestino != null)
                {
                    filtro.IdDepDestino = _gestionFiltros.DataFiltrar.depDestino.auto;
                    xfiltros += ", Dep/Destino: " + _gestionFiltros.DataFiltrar.depDestino.nombre;
                }
                if (_gestionFiltros.DataFiltrar.depOrigen != null) 
                {
                    filtro.IdDepOrigen = _gestionFiltros.DataFiltrar.depOrigen.auto;
                    xfiltros += ", Dep/Origen: " + _gestionFiltros.DataFiltrar.depOrigen.nombre;
                }
                if (_gestionFiltros.DataFiltrar.estatus != null)
                {
                    filtro.Estatus = OOB.LibInventario.Movimiento.enumerados.EnumEstatus.Activo;
                    if (_gestionFiltros.DataFiltrar.estatus.Id != "01")
                        filtro.Estatus = OOB.LibInventario.Movimiento.enumerados.EnumEstatus.Anulado;

                    if (filtro.Estatus==OOB.LibInventario.Movimiento.enumerados.EnumEstatus.Activo)
                        xfiltros += ", Estatus: ACTIVO" ;
                    else
                        xfiltros += ", Estatus: ANULADO";
                }
            }
            var rt1 = Sistema.MyData.Producto_Movimiento_GetLista(filtro);
            if (rt1.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return;
            }

            _gestionFiltros.LimpiarFiltros();
            _gestionListaDetalle.setLista(rt1.Lista);
        }

        public void AnularItem()
        {
            _gestionListaDetalle.AnularItem();
        }

        public void LimpiarFiltros()
        {
            Filtro_Desde = DateTime.Now;
            Filtro_Hasta = DateTime.Now;
            Filtro_TipoDoc = "";
            Filtro_Sucursal = "";
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
            _gestionListaDetalle.Imprimir(xfiltros);
        }

        public void Filtros()
        {
            _gestionFiltros.Inicia();
        }

    }

}