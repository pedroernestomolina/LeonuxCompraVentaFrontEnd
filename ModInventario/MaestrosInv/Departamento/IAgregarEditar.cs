using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MaestrosInv.Departamento
{
    
    public interface IAgregarEditar
    {

        bool IsOk { get; }
        string Codigo { get; }
        string Nombre { get; }
        bool ProcesarIsOk { get; }
        bool AbandonarIsOk { get; }
        string ItemAgregarId { get; }
        string Titulo { get; }


        void Inicializa();
        void Inicia();
        void Procesar();
        void Abandonar();


        void setCodigo(string p);
        void setNombre(string p);
        void setItemEditar(string id);

    }

}