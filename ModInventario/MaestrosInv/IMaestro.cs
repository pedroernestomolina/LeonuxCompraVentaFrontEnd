using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.MaestrosInv
{

    public interface IMaestro: IGestion
    {

        void setGestion(IMaestroTipo _gMtDepart);

    }

}