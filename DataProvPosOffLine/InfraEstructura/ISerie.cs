using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{

    public interface ISerie
    {

        OOB.ResultadoLista<OOB.LibVenta.PosOffline.Serie.Ficha> Serie_Lista();

    }

}