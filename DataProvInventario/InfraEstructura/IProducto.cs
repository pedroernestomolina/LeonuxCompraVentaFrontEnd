using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IProducto
    {

        OOB.ResultadoLista<OOB.LibInventario.Producto.Data.Ficha> Producto_GetLista(OOB.LibInventario.Producto.Filtro filtro);
        //DtoLib.ResultadoEntidad<DtoLibInventario.Producto.VerData.Ficha> Producto_GetFicha(string autoPrd);
        OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Existencia> Producto_GetExistencia(string autoPrd);
        OOB.ResultadoEntidad<OOB.LibInventario.Producto.Data.Precio> Producto_GetPrecio(string autoPrd);

        OOB.ResultadoLista<OOB.LibInventario.Producto.Origen.Ficha> Producto_Origen_Lista();
        OOB.ResultadoLista<OOB.LibInventario.Producto.Categoria.Ficha> Producto_Categoria_Lista();
        OOB.ResultadoLista<OOB.LibInventario.Producto.Estatus.Ficha> Producto_Estatus_Lista();
        OOB.ResultadoLista<OOB.LibInventario.Producto.AdmDivisa.Ficha> Producto_AdmDivisa_Lista();
        OOB.ResultadoLista<OOB.LibInventario.Producto.Pesado.Ficha> Producto_Pesado_Lista();
        OOB.ResultadoLista<OOB.LibInventario.Producto.Oferta.Ficha> Producto_Oferta_Lista();

    }

}