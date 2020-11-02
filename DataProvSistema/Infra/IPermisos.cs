using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    public interface IPermisos
    {

        OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMaximo();
        OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMedio();
        OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMinimo();

        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ToolSistema(string autoGrupoUsuario);

    }

}
