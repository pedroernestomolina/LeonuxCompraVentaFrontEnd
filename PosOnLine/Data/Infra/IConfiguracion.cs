using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface IConfiguracion
    {

        OOB.Resultado.FichaEntidad<decimal> Configuracion_FactorDivisa();

        OOB.Resultado.FichaEntidad<OOB.Configuracion.Entidad.Ficha> Configuracion_Pos_GetFicha();

    }

}