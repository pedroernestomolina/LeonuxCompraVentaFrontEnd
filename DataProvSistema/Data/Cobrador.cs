using DataProvSistema.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Data
{

    public partial class DataProv : IData
    {

        public OOB.ResultadoLista<OOB.LibSistema.Cobrador.Entidad.Ficha> Cobrador_GetLista(OOB.LibSistema.Cobrador.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.Cobrador.Entidad.Ficha>();

            var filtroDto = new DtoLibSistema.Cobrador.Lista.Filtro();
            var r01 = MyData.Cobrador_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibSistema.Cobrador.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.Cobrador.Entidad.Ficha()
                        {
                            id = s.id,
                            codigo = s.codigo,
                            nombre = s.nombre,
                            ciRif = s.ciRif,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

    }

}