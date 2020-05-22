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

        public OOB.ResultadoLista<OOB.LibVenta.PosOffline.Vendedor.Ficha> Vendedor_Lista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibVenta.PosOffline.Vendedor.Ficha>();

            var r01 = MyData.Vendedor_Lista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibVenta.PosOffline.Vendedor.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibVenta.PosOffline.Vendedor.Ficha()
                        {
                            Auto = s.Auto,
                            Codigo = s.Codigo,
                            Nombre = s.Nombre,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

    }

}