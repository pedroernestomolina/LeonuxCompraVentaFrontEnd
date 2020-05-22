using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{
    
    public interface IDeposito
    {

        OOB.ResultadoLista<OOB.LibVenta.PosOffline.Deposito.Ficha> Deposito_Lista();

    }

}