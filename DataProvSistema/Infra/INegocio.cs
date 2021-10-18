using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    public interface INegocio
    {

        OOB.ResultadoEntidad<OOB.LibSistema.Negocio.Entidad.Ficha> Negocio_GetEntidad_ByAuto(string autoEmpresa);
        OOB.Resultado Negocio_EditarFicha(OOB.LibSistema.Negocio.Editar.Ficha ficha);

    }

}