using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Infra
{

    public interface IMovInvConcepto
    {

        OOB.ResultadoEntidad<OOB.LibVenta.MovInventario.Concepto.Ficha> MovInventario_Concepto(string auto);
        
    }

}