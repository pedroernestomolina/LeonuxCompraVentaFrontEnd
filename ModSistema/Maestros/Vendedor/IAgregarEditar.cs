using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModSistema.Maestros.Vendedor
{
    
    public interface IAgregarEditar
    {

        string TituloFicha { get; }
        string GetRif { get; }
        string GetCodigo { get; }
        string GetRazonSocial { get; }
        string GetDirFiscal { get; }
        string GetPersona { get; }
        string GetTelefono { get; }
        string GetEmail { get; }
        string GetWebSite { get; }
        string GetAdvertencia { get; }
        string GetMemo { get; }
        bool SalirIsOk { get; }
        bool AbandonarIsOk { get; }
        bool ProcesarIsOk { get; }
        string AutoFichaNueva { get; }


        void Inicializa();
        void setCiRif(string p);
        void setCodigo(string p);
        void setRazonSocial(string p);
        void setDirFiscal(string p);
        void setPersona(string p);
        void setTelefono(string p);
        void setEmail(string p);
        void setWebSite(string p);
        void setAdvertencia(string p);
        void setMemo(string p);
        void Procesar();
        void Salir();
        bool CargarData();
        void setFichaEditar(string p);

    }

}