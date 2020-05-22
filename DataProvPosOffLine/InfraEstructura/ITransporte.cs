using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{
    
    public interface ITransporte
    {

        OOB.ResultadoLista<OOB.LibVenta.PosOffline.Transporte.Ficha> Transporte_Lista();

    }

}