using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Infra
{
    public interface IPermiso
    {

        OOB.Resultado.FichaEntidad <string> Permiso_PedirClaveAcceso_NivelMaximo();
        OOB.Resultado.FichaEntidad<string> Permiso_PedirClaveAcceso_NivelMedio();
        OOB.Resultado.FichaEntidad<string> Permiso_PedirClaveAcceso_NivelMinimo();

        OOB.Resultado.FichaEntidad<OOB.Permiso.Entidad.Ficha> Permiso_Reportes(string autoGrupoUsuario);

    }

}