using ServiceVenta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Data
{

    public partial class DataProvider: DataProviderVenta.Infra.IData
    {

        public static IService MyData;

        
        public DataProvider() 
        {
            MyData = new ServiceVenta.MyService.Service();
        }

        public OOB.ResultadoEntidad<DateTime> FechaServidor()
        {
            var result = new OOB.ResultadoEntidad<DateTime>();

            var r01 = MyData.FechaServidor();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = (DateTime)r01.Entidad;
            return result;
        }

    }

}