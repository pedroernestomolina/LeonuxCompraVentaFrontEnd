using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Data
{
    
    public partial class DataProvider: DataProviderVenta.Infra.IData
    {

        public OOB.ResultadoEntidad<OOB.LibVenta.Fiscal.Ficha> TasasFiscales()
        {
            var result = new OOB.ResultadoEntidad<OOB.LibVenta.Fiscal.Ficha>();

            var r01 = MyData.TasasFiscales();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = new OOB.LibVenta.Fiscal.Ficha()
            {
                Tasa1 = r01.Entidad.Tasa1,
                Tasa2 = r01.Entidad.Tasa2,
                Tasa3 = r01.Entidad.Tasa3,
            };
            return result;
        }

    }

}
