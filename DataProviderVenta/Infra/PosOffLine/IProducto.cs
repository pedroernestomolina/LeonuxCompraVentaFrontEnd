using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Infra.PosOffLine
{

    public interface IProducto
    {

        OOB.ResultadoEntidad<string> PosOffLine_Producto_BuscarPorCodigoBarraPlu(string aBuscar);
        OOB.ResultadoLista<OOB.LibVenta.PosOffline.Producto.Ficha> PosOffLine_Producto_BuscarPorDescripcion(string aBuscar);
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Producto.Ficha> PosOffLine_Producto(string autoPrd);

    }

}