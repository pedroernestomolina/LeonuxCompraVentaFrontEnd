using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Infra
{
    
    public interface IExistencia
    {

        OOB.ResultadoEntidad<OOB.LibVenta.Inventario.Existencia.Ficha> Existencia(string autoPrd, string autoDep);

    }

}