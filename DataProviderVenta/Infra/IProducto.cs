using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Infra
{
    
    public interface IProducto
    {

        OOB.ResultadoLista<OOB.LibVenta.Inventario.Producto.Ficha> ProductoLista(OOB.LibVenta.Inventario.Producto.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibVenta.Inventario.Producto.Ficha> ProductoDetalle(string auto);
        OOB.ResultadoEntidad<OOB.LibVenta.Inventario.Producto.Ficha> Producto(string auto);

    }

}