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
        Enumerados.Maestro GridVisualizarIs { get; }

        bool CargarData();
        void Inicializa();
        void setLista(GestionLista _gestionLista);
        void AgregarFicha();
        void EditarFicha(dataLista ItemActual);
        void CambiarEstatus(Maestros.Estatus.Gestion gestion, string idFicha);

    }

}
