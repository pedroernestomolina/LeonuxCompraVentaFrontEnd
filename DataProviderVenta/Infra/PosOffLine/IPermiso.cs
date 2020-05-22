using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Infra.PosOffLine
{
    
    public interface IPermiso
    {

        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Permiso.Ficha> PosOffLine_Permiso_ModuloVenta(string autoGrupo);

    }

}