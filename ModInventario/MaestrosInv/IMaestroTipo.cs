using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MaestrosInv
{
    
    public interface IMaestroTipo
    {

        string Titulo { get; }
        bool AgregarIsOk { get; }
        bool EditarIsOk { get; }
        bool EliminarIsOk { get; }
        data ItemAgregarEditar { get; }
        List<data> ListData { get; }


        void Inicializa();
        bool CargarData();
        void AgregarItem();
        void EditarItem(data ItemActual);
        void EliminarItem(data ItemActual);

    }

}