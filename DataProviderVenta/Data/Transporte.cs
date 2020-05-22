using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Data
{

    public partial class DataProvider: DataProviderVenta.Infra.IData
    {

        public OOB.ResultadoLista<OOB.LibVenta.Transporte.Ficha> TransporteLista()
        {
            var result = new OOB.ResultadoLista<OOB.LibVenta.Transporte.Ficha>();

            var r01 = MyData.TransporteLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Lista = new List<OOB.LibVenta.Transporte.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    result.Lista = r01.Lista.Select(s =>
                    {
                        return new OOB.LibVenta.Transporte.Ficha()
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