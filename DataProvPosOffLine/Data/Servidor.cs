using DataProvPosOffLine.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.Data
{

    public partial class DataProv: IData
    {

        public OOB.Resultado Servidor_Test()
        {
            var result = new OOB.Resultado();

            var r01 = MyData.Servidor_Test();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

        public OOB.Resultado Servidor_ActualizarData()
        {
            var result = new OOB.Resultado();

            var r01 = MyData.Servidor_ActualizarData();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

    }

}