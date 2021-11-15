using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    public interface IControlAcceso
    {

        OOB.ResultadoLista<OOB.LibSistema.ControlAcceso.Data.Ficha> ControlAcceso_GetData(string idGrupo);
        OOB.Resultado ControlAcceso_Actualizar(OOB.LibSistema.ControlAcceso.Actualizar.Ficha ficha);

    }

}