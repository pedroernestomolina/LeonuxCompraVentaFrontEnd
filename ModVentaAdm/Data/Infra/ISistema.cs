using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Infra
{
    
    public interface ISistema
    {

        OOB.Resultado.FichaEntidad<OOB.Sistema.Empresa.Entidad.Ficha> Sistema_Empresa_GetFicha();

        OOB.Resultado.Lista<OOB.Sistema.Vendedor.Entidad.Ficha> Sistema_Vendedor_GetLista();
        OOB.Resultado.Lista<OOB.Sistema.Cobrador.Entidad.Ficha> Sistema_Cobrador_GetLista();
        OOB.Resultado.Lista<OOB.Sistema.Estado.Entidad.Ficha> Sistema_Estado_GetLista();

    }

}