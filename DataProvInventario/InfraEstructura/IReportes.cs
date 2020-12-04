using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IReportes
    {

        OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroProducto.Ficha> Reportes_MaestroProducto(OOB.LibInventario.Reportes.MaestroProducto.Filtro filtro);
        OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroInventario.Ficha> Reportes_MaestroInventario(OOB.LibInventario.Reportes.MaestroInventario.Filtro filtro);
        OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroExistencia.Ficha> Reportes_MaestroExistencia(OOB.LibInventario.Reportes.MaestroExistencia.Filtro filtro);
        OOB.ResultadoLista<OOB.LibInventario.Reportes.MaestroPrecio.Ficha> Reportes_MaestroPrecio(OOB.LibInventario.Reportes.MaestroPrecio.Filtro filtro);
        OOB.ResultadoLista<OOB.LibInventario.Reportes.Kardex.Ficha> Reportes_Kardex(OOB.LibInventario.Reportes.Kardex.Filtro filtro);

        OOB.ResultadoLista<OOB.LibInventario.Reportes.Top20.Ficha> Reportes_Top20(OOB.LibInventario.Reportes.Top20.Filtro filtro);

        OOB.ResultadoEntidad<OOB.LibInventario.Reportes.CompraVentaAlmacen.Ficha> Reportes_CompraVentaAlmacen(OOB.LibInventario.Reportes.CompraVentaAlmacen.Filtro filtro);

    }

}