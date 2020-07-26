using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    public interface IPrecio
    {

        OOB.ResultadoLista<OOB.LibSistema.Precio.Ficha> Precio_GetLista();
        OOB.ResultadoEntidad<OOB.LibSistema.Precio.Etiquetar.Ficha> Precio_Etiquetar_GetFicha();
        OOB.Resultado Precio_Etiquetar_Actualizar(OOB.LibSistema.Precio.Etiquetar.Actualizar ficha);

    }

}