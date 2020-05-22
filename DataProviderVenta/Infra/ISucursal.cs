using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Infra
{
    
    public interface ISucursal
    {

        OOB.ResultadoLista<OOB.LibVenta.Sucursal.Ficha> SucursalLista();

    }

}