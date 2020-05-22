using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{
    
    public interface IFiscal
    {

        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Fiscal.Ficha> Fiscal_Tasas();

    }

}