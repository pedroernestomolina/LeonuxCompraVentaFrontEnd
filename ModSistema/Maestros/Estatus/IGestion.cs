using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Maestros.Estatus
{
    
    public interface IGestion
    {

        string Ficha { get; }
        Enumerados.EnumEstatus Estatus { get; }
        bool ProcesarIsOk { get; }
        bool AbandonarIsOk { get; }
        bool CambioEstatusIsOk { get; }


        bool CargarData();
        void setFicha(string autoId);
        void setEstatusActivo();
        void setEstatusInactivo();
        void Procesar();
        void Inicializa();
        void Salir();
        void Limpiar();

    }

}