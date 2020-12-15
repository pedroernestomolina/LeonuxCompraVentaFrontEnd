using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Filtros
{
    
    public interface IFiltros
    {

        bool ActivarDepOrigen { get; }
        bool ActivarDepDestino { get; }
        bool ActivarEstatus { get; }

    }

}