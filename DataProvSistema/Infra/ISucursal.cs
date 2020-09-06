using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    public interface ISucursal
    {

        OOB.ResultadoLista<OOB.LibSistema.Sucursal.Ficha> Sucursal_GetLista();
        OOB.ResultadoEntidad<OOB.LibSistema.Sucursal.Ficha> Sucursal_GetFicha(string auto);
        OOB.ResultadoAuto Sucursal_Agregar(OOB.LibSistema.Sucursal.Agregar ficha);
        OOB.Resultado Sucursal_Editar(OOB.LibSistema.Sucursal.Editar ficha);
        OOB.Resultado Sucursal_AsignarDepositoPrincipal(OOB.LibSistema.Sucursal.AsignarDepositoPrincipal ficha);
        OOB.Resultado Sucursal_QuitarDepositoPrincipal(string autoSuc);
        OOB.ResultadoEntidad<int> Sucursal_GeneraCodigoAutomatico();

    }

}