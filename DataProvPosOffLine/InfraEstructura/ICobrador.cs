using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{
    
    public interface ICobrador
    {

        OOB.ResultadoLista<OOB.LibVenta.PosOffline.Cobrador.Ficha> Cobrador_Lista();

    }

}