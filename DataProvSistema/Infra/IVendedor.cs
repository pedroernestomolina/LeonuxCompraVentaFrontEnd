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

    }

}
