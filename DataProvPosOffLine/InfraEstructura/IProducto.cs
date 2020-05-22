using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{

    public interface IProducto
    {

        OOB.ResultadoLista<OOB.LibVenta.PosOffline.Producto.Ficha> Producto_Lista(string aBuscar);
        OOB.ResultadoEntidad<string> Producto_BuscarPorCodigoBarraPlu(string aBuscar);
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Producto.Ficha> Producto(string aBuscar);
        OOB.ResultadoLista<OOB.LibVenta.PosOffline.Producto.Ficha> ProductoListaPlu();
        OOB.ResultadoLista<OOB.LibVenta.PosOffline.Producto.Ficha> ProductoListaOferta();

    }

}