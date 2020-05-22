using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Data
{

    public partial class DataProvider: DataProviderVenta.Infra.IData
    {

        public OOB.ResultadoLista<OOB.LibVenta.Cobrador.Ficha> CobradorLista()
        {
            var result = new OOB.ResultadoLista<OOB.LibVenta.Cobrador.Ficha>();

            var r01 = MyData.CobradorLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Lista = new List<OOB.LibVenta.Cobrador.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    result.Lista = r01.Lista.Select(s =>
                    {
                        return new OOB.LibVenta.Cobrador.Ficha()
                        {
                            Auto = s.Auto,
                            Codigo = s.Codigo,
                            Nombre = s.Nombre,
                        };
                    }).ToList();
                }
            }

            return result;
        }

    }

}