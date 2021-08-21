using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Maestros.Cobrador
{
    
    public interface IAgregarEditar
    {

        string TituloFicha { get; }
        string GetCodigo { get; }
        string GetRazonSocial { get; }
        bool SalirIsOk { get; }
        bool AbandonarIsOk { get; }
        bool ProcesarIsOk { get; }
        string AutoFichaNueva { get; }


        void Inicializa();
        void setCodigo(string p);
        void setRazonSocial(string p);
        void Procesar();
        void Salir();
        bool CargarData();
        void setFichaEditar(string p);

    }

}