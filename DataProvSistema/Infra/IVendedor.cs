using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    public interface IVendedor
    {

        OOB.ResultadoLista<OOB.LibSistema.Vendedor.Entidad.Ficha> Vendedor_GetLista(OOB.LibSistema.Vendedor.Lista.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibSistema.Vendedor.Entidad.Ficha> Vendedor_GetFicha_ById(string id);
        OOB.ResultadoAuto Vendedor_AgregarFicha(OOB.LibSistema.Vendedor.Agregar.Ficha ficha);
        OOB.Resultado Vendedor_EditarFicha(OOB.LibSistema.Vendedor.Editar.Ficha ficha);
        OOB.Resultado Vendedor_Activar(OOB.LibSistema.Vendedor.ActivarInactivar.Ficha ficha);
        OOB.Resultado Vendedor_Inactivar(OOB.LibSistema.Vendedor.ActivarInactivar.Ficha ficha);

    }

}
