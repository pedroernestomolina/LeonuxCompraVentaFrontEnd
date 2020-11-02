using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface IProducto
    {

        OOB.ResultadoLista<OOB.LibCompra.Producto.Data.Ficha> Producto_GetLista(OOB.LibCompra.Producto.Lista.Filtro filtro);

    }

}