using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{

    public interface IReconversionMonetaria
    {

        OOB.ResultadoEntidad<int> ReconversionMonetaria_GetCount();
        OOB.ResultadoEntidad<OOB.LibSistema.ReconversionMonetaria.Data.Ficha> ReconversionMonetaria_GetData();
        OOB.Resultado ReconversionMonetaria_Actualizar(OOB.LibSistema.ReconversionMonetaria.Actualizar.Ficha ficha);

    }

}