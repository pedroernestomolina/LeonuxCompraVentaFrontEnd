using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Data
{

    public partial class DataProvider : DataProviderVenta.Infra.IData
    {

        public OOB.ResultadoEntidad<string> PosOffLine_Producto_BuscarPorCodigoBarraPlu(string aBuscar)
        {
            var rt = new OOB.ResultadoEntidad<string>();
            return rt;
        }

        public OOB.ResultadoLista<OOB.LibVenta.PosOffline.Producto.Ficha> PosOffLine_Producto_BuscarPorDescripcion(string aBuscar)
        {
            var rt = new OOB.ResultadoLista<OOB.LibVenta.PosOffline.Producto.Ficha>();
            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Producto.Ficha> PosOffLine_Producto(string autoPrd)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Producto.Ficha>();
            return rt;
        }

    }

}