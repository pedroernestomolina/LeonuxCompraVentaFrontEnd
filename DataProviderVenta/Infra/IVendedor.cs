using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Infra
{
    
    public interface IVendedor
    {

        OOB.ResultadoLista <OOB.LibVenta.Vendedor.Ficha> VendedorLista();

    }

}
