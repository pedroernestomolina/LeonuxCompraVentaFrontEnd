using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Infra
{

    public interface IPermiso
    {

        OOB.ResultadoEntidad<OOB.LibVenta.Permiso.Ficha> Permiso_Venta_DarDescuento_Item(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibVenta.Permiso.Ficha> Permiso_Venta_Eliminar_Item(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibVenta.Permiso.Ficha> Permiso_Venta_PrecioLibre_Item(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibVenta.Permiso.Ficha> Permiso_Venta_DescuentoGlobal(string autoGrupoUsuario);

    }

}