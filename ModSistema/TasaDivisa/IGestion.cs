using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.TasaDivisa
{
    
    public interface IGestion
    {

        string TituloFuncion { get; }
        decimal ValorActual { get; set; }
        decimal ValorNuevo { set; }

        bool CargarData();
        bool Procesar();

    }

}