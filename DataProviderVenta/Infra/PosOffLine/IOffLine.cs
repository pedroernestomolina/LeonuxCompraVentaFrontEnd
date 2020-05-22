using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Infra.PosOffLine
{

    public interface IOffLine: IUsuario, IPermiso, IProducto
    {

        OOB.ResultadoEntidad<string> PosOffLine_ClaveSeguridad();

    }

}