using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Infra
{
    
    public interface IJornada
    {

        OOB.Resultado.FichaEntidad<OOB.Pos.EnUso.Ficha> Jornada_EnUso_GetByIdEquipo(string idEquipo);
        OOB.Resultado.FichaId Jornada_Abrir(OOB.Pos.Abrir.Ficha ficha);
        OOB.Resultado.FichaEntidad<OOB.Pos.EnUso.Ficha> Jornada_EnUso_GetById(int id);

    }

}