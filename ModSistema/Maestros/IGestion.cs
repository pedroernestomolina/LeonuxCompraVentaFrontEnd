using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Maestros
{
    
    public interface IGestion
    {

        string MaestroTitulo { get; }


        bool CargarData();
        void Inicializa();
        void setLista(GestionLista _gestionLista);

    }

}
