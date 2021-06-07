using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Infra
{
    
    public interface IReportes
    {

        OOB.Resultado.Lista<OOB.Reportes.GeneralDocumento.Ficha> Reportes_GeneralDocumento(OOB.Reportes.GeneralDocumento.Filtro filtro);

    }

}