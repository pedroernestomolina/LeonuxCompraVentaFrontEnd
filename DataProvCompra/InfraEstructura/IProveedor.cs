using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface IProveedor
    {

        OOB.ResultadoLista<OOB.LibCompra.Proveedor.Data.Ficha> Proveedor_GetLista(OOB.LibCompra.Proveedor.Lista.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibCompra.Proveedor.Data.Ficha> Proveedor_GetFicha(string autoPrv);

    }

}