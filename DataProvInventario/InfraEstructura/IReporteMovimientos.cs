using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{

    public interface IReporteMovimientos
    {

        OOB.ResultadoLista<OOB.LibInventario.Reportes.Movimientos.ArqueoCajaPos.Ficha> 
            CajaBanco_ArqueoVentaPos(OOB.LibInventario.Reportes.Movimientos.Filtro filtro);

    }

}
