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

    }

}