using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Cliente.Administrador
{
    
    public class Gestion
    {


        private OOB.Configuracion.BusquedaCliente.Entidad.Ficha _metodoBusqPred;
        private dataFiltro _filtrar;
        private GestionLista _gestionLista;
        private AgregarEditar.Gestion _gestionAgregarEditar;
        private Articulos.Gestion _gestionArticulos;
        private Documentos.Gestion _gestionDocumentos;


        public int cntItem { get { return _gestionLista.Items; } }
        public Enumerados.enumMetodoBusqueda MetodoBusqueda { get { return _filtrar.MetodoBusqueda; } }
        public BindingSource Source { get { return _gestionLista.Source; } }
        public string Cliente { get { return _gestionLista.Cliente; } }
        public data Item { get { return _gestionLista.Item; } }


        public Gestion()
        {
            _metodoBusqPred = null;
            _filtrar= new dataFiltro();
            _gestionLista = new GestionLista();
            _gestionLista.ItemChanged +=_gestionLista_ItemChanged;
            _gestionAgregarEditar= new AgregarEditar.Gestion();
            _gestionArticulos = new Articulos.Gestion();
            _gestionDocumentos = new Documentos.Gestion();
        }


        private void _gestionLista_ItemChanged(object sender, EventArgs e)
        {
            frm.ActualizarFicha();
        }

        private AdmFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm==null)
                {
                    frm = new AdmFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_BusquedaCliente();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _metodoBusqPred = r01.Entidad;
            asignaMetodoBusqueda(r01.Entidad);

            return rt;
        }

        private void asignaMetodoBusqueda(OOB.Configuracion.BusquedaCliente.Entidad.Ficha ficha)
        {
            switch (ficha.ModoBusqueda)
            {
                case OOB.Configuracion.BusquedaCliente.Entidad.Enumerado.EnumPreferenciaBusqueda.Codigo:
                    _filtrar.setMetodoPorCodigo();
                    break;
                case OOB.Configuracion.BusquedaCliente.Entidad.Enumerado.EnumPreferenciaBusqueda.Nombre:
                    _filtrar.setMetodoPorNombre();
                    break;
                case OOB.Configuracion.BusquedaCliente.Entidad.Enumerado.EnumPreferenciaBusqueda.CiRif:
                    _filtrar.setMetodoPorCiRif();
                    break;
            }
        }

        public void ActivarBusqueda()
        {
            var filtroOOB = new OOB.Maestro.Cliente.Lista.Filtro()
            {
                cadena = _filtrar.cadena,
                metodoBusqueda = (OOB.Maestro.Cliente.Lista.Enumerados.enumMetodoBusqueda)_filtrar.MetodoBusqueda,
            };
            var r01 = Sistema.MyData.Cliente_GetLista(filtroOOB);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _gestionLista.setLista(r01.ListaD);
            _filtrar.Limpiar();
            asignaMetodoBusqueda(_metodoBusqPred);

            //_gestionFiltro.Limpiar();
            //frm.ActualizarItem();
            //Cadena = "";
        }

        public void Inicializa()
        {
            _filtrar.Limpiar();
        }

        public void setCadena(string p)
        {
            _filtrar.setCadena(p);
        }

        public void setMetodoPorCodigo()
        {
            _filtrar.setMetodoPorCodigo();
        }

        public void setMetodoPorNombre()
        {
            _filtrar.setMetodoPorNombre();
        }

        public void setMetodoPorCiRif()
        {
            _filtrar.setMetodoPorCiRif();
        }

        public void LimpiarBusqueda()
        {
            _gestionLista.LimpiarLista();
        }

        public void AgregarFicha()
        {
            _gestionAgregarEditar.setGestion(new AgregarEditar.Agregar.Gestion());
            _gestionAgregarEditar.Inicializa();
            _gestionAgregarEditar.Inicia();
            //if (_gestionAgregarEditar.AgregarIsOk) 
            //{
            //    InsertarFichaLista(_gestionAgregarEditar.autoProvRegistrado);
            //}
        }

        private void InsertarFichaLista(string autoPrv)
        {
            //var r01 = Sistema.MyData.Proveedor_GetFicha (autoPrv);
            //if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return;
            //}
            //_gestionLista.AgregarFicha(r01.Entidad);
        }

        public void EditarFicha()
        {
            //if (Item != null)
            //{
            //    _gestionAgregarEditar.setGestion(new AgregarEditar.Editar.Gestion());
            //    _gestionAgregarEditar.Inicializar();
            //    _gestionAgregarEditar.setFichaEditar(Item);
            //    _gestionAgregarEditar.Inicia();
            //    if (_gestionAgregarEditar.EditarIsOk)
            //    {
            //        var auto = Item.autoId;
            //        ActualizarFichaLista(auto);
            //    }
            //}
        }

        private void ActualizarFichaLista(string autoId)
        {
            //_gestionLista.EliminarItem(autoId);
            //InsertarFichaLista(autoId);
        }

        public void CompraArticulos()
        {
            if (Item != null) 
            {
                _gestionArticulos.Inicializa();
                _gestionArticulos.setCliente(Item);
                _gestionArticulos.Inicia();
            }
        }

        public void Documentos()
        {
            if (Item != null)
            {
                _gestionDocumentos.Inicializa();
                _gestionDocumentos.setCliente(Item);
                _gestionDocumentos.Inicia();
            }
        }

    }

}