using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{

    public interface IUsuario
    {

        OOB.ResultadoEntidad<OOB.LibSistema.Usuario.Ficha> Usuario_Principal();

    }

}