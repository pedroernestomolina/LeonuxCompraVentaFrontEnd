using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Proveedor.Administrador
{
    
    public class Gestion
    {


        private dataFiltro _filtrar;
        private OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor _configuracionMetodoBusqueda;
        private GestionLista _gestionLista;
        private AgregarEditar.Gestion _gestionAgregarEditar;
        private ArticulosCompra.Gestion _gestionCompraArticulos;
        private Documentos.Gestion _gestionDocumentos;


        public int cntItem { get { return _gestionLista.Items; } }
        public Enumerados.enumMetodoBusqueda MetodoBusqueda { get { return _filtrar.MetodoBusqueda; } }
        public BindingSource Source { get { return _gestionLista.Source; } }
        public string Proveedor { get { return _gestionLista.Proveedor; } }
        public OOB.LibCompra.Proveedor.Data.Ficha Item { get { return _gestionLista.Item; } }


        public Gestion()
        {
            _filtrar= new dataFiltro();
            _configuracionMetodoBusqueda = OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor.SinDefinir;
            _gestionLista = new GestionLista();
            _gestionLista.ItemChanged +=_gestionLista_ItemChanged;
            _gestionAgregarEditar= new AgregarEditar.Gestion();
            _gestionCompraArticulos = new ArticulosCompra.Gestion();
            _gestionDocumentos = new Documentos.Gestion();
        }


        private void _gestionLista_ItemChanged(object sender, EventArgs e)
        {
            frm.ActualizarDataProveedor();
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

            var r01 = Sistema.MyData.Configuracion_PreferenciaBusquedaProveedor();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _configuracionMetodoBusqueda = r01.Entidad;
            asignaMetodoBusqueda(r01.Entidad);

            return rt;
        }

        private void asignaMetodoBusqueda(OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor metodo)
        {
            switch (metodo)
            {
                case OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor.PorCodigo:
                    _filtrar.MetodoBusqueda = Enumerados.enumMetodoBusqueda.PorCodigo;
                    break;
                case OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor.PorNombre:
                    _filtrar.MetodoBusqueda = Enumerados.enumMetodoBusqueda.PorNombre;
                    break;
                case OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor.Rif:
                    _filtrar.MetodoBusqueda = Enumerados.enumMetodoBusqueda.PorRif;
                    break;
            }
        }

        public void ActivarBusqueda()
        {
            var filtroOOB = new OOB.LibCompra.Proveedor.Lista.Filtro()
            {
                cadena = _filtrar.cadena,
                MetodoBusqueda = (OOB.LibCompra.Proveedor.Enumerados.EnumMetodoBusqueda) _filtrar.MetodoBusqueda,
            };

            var r01 = Sistema.MyData.Proveedor_GetLista(filtroOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _gestionLista.setLista(r01.Lista);
            _filtrar.Limpiar();

            //_gestionFiltro.Limpiar();
            //frm.ActualizarItem();
            //Cadena = "";
        }

        public void Inicializar()
        {
            _filtrar.Limpiar();
            switch (_configuracionMetodoBusqueda)
            {
                case OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor.PorCodigo :
                    _filtrar.MetodoBusqueda = Enumerados.enumMetodoBusqueda.PorCodigo;
                    break;
                case OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor.PorNombre:
                    _filtrar.MetodoBusqueda = Enumerados.enumMetodoBusqueda.PorNombre;
                    break;
                case OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor.Rif:
                    _filtrar.MetodoBusqueda = Enumerados.enumMetodoBusqueda.PorRif;
                    break;
            }
        }

        public void setCadena(string p)
        {
            _filtrar.cadena = p;
        }

        public void setMetodoPorCodigo()
        {
            _filtrar.MetodoBusqueda= Enumerados.enumMetodoBusqueda.PorCodigo;
        }

        public void setMetodoPorNombre()
        {
            _filtrar.MetodoBusqueda = Enumerados.enumMetodoBusqueda.PorNombre;
        }

        public void setMetodoPorCiRif()
        {
            _filtrar.MetodoBusqueda = Enumerados.enumMetodoBusqueda.PorRif;
        }

        public void LimpiarBusqueda()
        {
            _gestionLista.LimpiarLista();
        }

        public void AgregarFicha()
        {
            _gestionAgregarEditar.setGestion(new AgregarEditar.Agregar.Gestion());
            _gestionAgregarEditar.Inicializar();
            _gestionAgregarEditar.Inicia();
            if (_gestionAgregarEditar.AgregarIsOk) 
            {
                InsertarFichaLista(_gestionAgregarEditar.autoProvRegistrado);
            }
        }

        private void InsertarFichaLista(string autoPrv)
        {
            var r01 = Sistema.MyData.Proveedor_GetFicha (autoPrv);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _gestionLista.AgregarFicha(r01.Entidad);
        }

        public void EditarFicha()
        {
            if (Item != null)
            {
                _gestionAgregarEditar.setGestion(new AgregarEditar.Editar.Gestion());
                _gestionAgregarEditar.Inicializar();
                _gestionAgregarEditar.setFichaEditar(Item);
                _gestionAgregarEditar.Inicia();
                if (_gestionAgregarEditar.EditarIsOk)
                {
                    var auto = Item.autoId;
                    ActualizarFichaLista(auto);
                }

            }
        }

        private void ActualizarFichaLista(string autoId)
        {
            _gestionLista.EliminarItem(autoId);
            InsertarFichaLista(autoId);
        }

        public void CompraArticulos()
        {
            if (Item != null) 
            {
                _gestionCompraArticulos.Inicializa();
                _gestionCompraArticulos.setProveedor(Item);
                _gestionCompraArticulos.Inicia();
            }
        }

        public void Documentos()
        {
            if (Item != null)
            {
                _gestionDocumentos.Inicializa();
                _gestionDocumentos.setProveedor(Item);
                _gestionDocumentos.Inicia();
            }
        }

    }

}