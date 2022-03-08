using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MaestrosInv.Departamento
{
    
    public interface IAgregarEditar: IGestion
    {

        bool ProcesarIsOk { get; }
        bool AbandonarIsOk { get; }
        string Codigo { get; }
        string Nombre { get; }


        void Procesar();
        void Abandonar();


        void setCodigo(string p);
        void setNombre(string p);
    }

}