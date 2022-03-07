using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ModInventario.MaestrosInv
{
    
    public interface IMaestro: IGestion
    {

        string Titulo { get; }
        bool AgregarIsOk { get; }
        bool EditarIsOk { get; }
        bool EliminarIsOk { get; }
        BindingSource Source { get; }
        int CntItems { get; }


        bool CargarData();
        void AgregarItem();
        void EditarItem();
        void EliminarItem();


        void setGestion(IMaestroTipo _gMtDepart);

    }

}