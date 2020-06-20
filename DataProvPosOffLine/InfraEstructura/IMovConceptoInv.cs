using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{

    public interface IMovConceptoInv
    {

        OOB.ResultadoLista<OOB.LibVenta.PosOffline.MovConceptoInv.Ficha>  MovConceptoInv_Lista();

    }

}