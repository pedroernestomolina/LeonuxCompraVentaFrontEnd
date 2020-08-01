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
        //DtoLib.ResultadoLista<DtoLibInventario.Producto.Estatus.Resumen> Producto_Estatus_Lista();
        OOB.ResultadoLista<OOB.LibInventario.Producto.Origen.Ficha> Producto_Origen_Lista();
        OOB.ResultadoLista<OOB.LibInventario.Producto.Categoria.Ficha> Producto_Categoria_Lista();
        //DtoLib.ResultadoLista<DtoLibInventario.Producto.AdmDivisa.Resumen> Producto_AdmDivisa_Lista();
        //DtoLib.ResultadoLista<DtoLibInventario.Producto.Pesado.Resumen> Producto_Pesado_Lista();
        //DtoLib.ResultadoLista<DtoLibInventario.Producto.Oferta.Resumen> Producto_Oferta_Lista();

    }

}