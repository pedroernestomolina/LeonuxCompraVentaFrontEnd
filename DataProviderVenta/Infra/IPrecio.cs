using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Infra
{

    public interface IPrecio
    {

        OOB.ResultadoEntidad<OOB.LibVenta.Inventario.Precio.Ficha> Precio(string autoPrd, string idPrecio);

    }

}