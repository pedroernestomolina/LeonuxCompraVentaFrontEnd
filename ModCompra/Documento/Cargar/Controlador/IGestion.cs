using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public interface IGestion
    {

        string TituloDocumento { get; }
        bool SalidaOk { get; }
        Controlador.GestionProductoBuscar.metodoBusqueda MetodoBusquedaProducto { get; }


        string CadenaPrdBuscar { get; set; }


        IGestionDocumento GestionDoc { get; }
        IGestionItem GestionItem { get; }
        

        void Inicializar();
        bool CargarData();
        void Salir();
        void ProcesarGurdar();
        void LimpiarDocumento();
        void BuscarProducto();
        void ActivarBusquedaProductoPorCodigo();
        void ActivarBusquedaProductoPorNombre();
        void ActivarBusquedaProductoPorReferencia();

    }

}