using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface IPermiso
    {

        OOB.Resultado.FichaEntidad<OOB.Permiso.Entidad.Ficha> Permiso_Pos(OOB.Permiso.Buscar.Ficha ficha);

    }

}
