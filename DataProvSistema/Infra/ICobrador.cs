using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{

    public interface ICobrador
    {

        OOB.ResultadoLista<OOB.LibSistema.Cobrador.Entidad.Ficha> Cobrador_GetLista(OOB.LibSistema.Cobrador.Lista.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibSistema.Cobrador.Entidad.Ficha> Cobrador_GetFicha_ById(string id);
        OOB.ResultadoAuto Cobrador_AgregarFicha(OOB.LibSistema.Cobrador.Agregar.Ficha ficha);
        OOB.Resultado Cobrador_EditarFicha(OOB.LibSistema.Cobrador.Editar.Ficha ficha);

    }

}