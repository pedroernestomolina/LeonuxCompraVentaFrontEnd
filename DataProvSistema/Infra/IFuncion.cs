using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    public interface IFuncion
    {

        OOB.ResultadoLista<OOB.LibSistema.Funcion.Ficha> Funcion_GetLista();

    }

}