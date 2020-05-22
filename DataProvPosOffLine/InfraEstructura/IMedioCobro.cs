using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{

    public interface IMedioCobro
    {

        OOB.ResultadoLista<OOB.LibVenta.PosOffline.MedioCobro.Ficha> MedioCobro_Lista();

    }

}