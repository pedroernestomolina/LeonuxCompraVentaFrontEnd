using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Filtros.Administrador
{

    public class Filtros: IFiltros
    {

        public bool ActivarDepOrigen
        {
            get { return true; }
        }

        public bool ActivarDepDestino
        {
            get { return true; }
        }

        public bool ActivarEstatus
        {
            get { return true; }
        }

    }

}
