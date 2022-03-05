using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    public interface IDeposito
    {

        OOB.ResultadoLista<OOB.LibSistema.Deposito.Ficha> Deposito_GetLista();
        OOB.ResultadoEntidad<OOB.LibSistema.Deposito.Ficha> Deposito_GetFicha(string auto);
        OOB.ResultadoAuto Deposito_Agregar(OOB.LibSistema.Deposito.Agregar ficha);
        OOB.Resultado Deposito_Editar(OOB.LibSistema.Deposito.Editar ficha);
        OOB.ResultadoEntidad<int> Deposito_GeneraCodigoAutomatico();
        OOB.Resultado Deposito_Activar(string idDep);
        OOB.Resultado Deposito_Inactivar(string idDep);

    }

}