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
        IGestionDocumento GestionDoc { get; }
        IGestionItem GestionItem { get; }
        IGestionProductoBuscar GestionProductoBuscar { get; }


        bool CargarData();

    }

}