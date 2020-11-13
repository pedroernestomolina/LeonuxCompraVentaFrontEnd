using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Factura
{
    
    public class GestionFac : Controlador.IGestion
    {

        private Controlador.IGestionDocumento gestionDoc;
        private Controlador.IGestionItem gestionItem;
        private Controlador.IGestionProductoBuscar gestionPrdBuscar;


        public Controlador.IGestionDocumento GestionDoc { get { return gestionDoc; } }
        public Controlador.IGestionItem GestionItem {get { return gestionItem; }}
        public Controlador.IGestionProductoBuscar GestionProductoBuscar { get { return gestionPrdBuscar; } }


        public string TituloDocumento
        {
            get { return "Entrada Documento: ( FACTURA )"; }
        }


        public GestionFac()
        {
            gestionDoc= new GestionDocumentoFac();
            gestionItem = new GestionItemFac();
            gestionPrdBuscar = new GestionProductoBuscarFac();
        }


        public bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_PreferenciaBusquedaProducto();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var mt = Controlador.GestionProductoBuscar.metodoBusqueda.SinDefinir;
            switch (r01.Entidad)
            {
                case OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProducto.PorCodigo:
                    mt = Controlador.GestionProductoBuscar.metodoBusqueda.Codigo;
                    break;
                case OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProducto.PorNombre:
                    mt= Controlador.GestionProductoBuscar.metodoBusqueda.Nombre;
                    break;
                case OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProducto.Referencia:
                    mt= Controlador.GestionProductoBuscar.metodoBusqueda.Referencia;
                    break;
            }
            gestionPrdBuscar.setMetodoBusqueda(mt);

            return rt;
        }

    }

}