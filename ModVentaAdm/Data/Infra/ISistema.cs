using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Infra
{
    
    public interface ISistema
    {

        OOB.Resultado.FichaEntidad<OOB.Sistema.Empresa.Entidad.Ficha> Sistema_Empresa_GetFicha();

    }

}