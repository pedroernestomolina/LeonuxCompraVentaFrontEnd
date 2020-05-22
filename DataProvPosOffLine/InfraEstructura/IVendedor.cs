using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{
    
    public interface IVendedor
    {

        OOB.ResultadoLista<OOB.LibVenta.PosOffline.Vendedor.Ficha> Vendedor_Lista();

    }

}