using DataProvSistema.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Data
{
    
    public partial class DataProv: IData
    {

        public OOB.ResultadoLista<OOB.LibSistema.Funcion.Ficha> Funcion_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.Funcion.Ficha>();

            var r01 = MyData.Funcion_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibSistema.Funcion.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.Funcion.Ficha()
                        {
                            codigo = s.codigo,
                            nombre = s.nombre,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

    }

}