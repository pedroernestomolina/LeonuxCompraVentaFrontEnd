using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Controlador
{

    public interface IGestionTotalizar
    {

        bool IsOk { get; set; }
        decimal Dscto { get; }
        decimal Cargo { get; }


        void Inicializar();
        void Guardar();


    }

}