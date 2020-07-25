using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IConcepto
    {

        OOB.ResultadoEntidad<OOB.LibInventario.Concepto.Ficha> Concepto_PorTraslado();

    }

}