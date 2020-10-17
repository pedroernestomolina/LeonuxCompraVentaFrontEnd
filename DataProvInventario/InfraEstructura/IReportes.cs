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
        OOB.ResultadoLista<OOB.LibInventario.Reportes.Top20.Ficha> Reportes_Top20(OOB.LibInventario.Reportes.Top20.Filtro filtro);

    }

}