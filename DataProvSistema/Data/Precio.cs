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

        public OOB.ResultadoLista<OOB.LibSistema.Precio.Ficha> Precio_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.Precio.Ficha>();

            var r01 = MyData.Precio_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibSistema.Precio.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.Precio.Ficha()
                        {
                             id=s.id,
                             descripcion=s.descripcion,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Precio.Etiquetar.Ficha> Precio_Etiquetar_GetFicha()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Precio.Etiquetar.Ficha>();

            var r01 = MyData.Precio_Etiquetar_GetFicha();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var p1 = new OOB.LibSistema.Precio.Ficha()
            {
                id = s.Precio1.id,
                descripcion = s.Precio1.descripcion,
            };
            var p2 = new OOB.LibSistema.Precio.Ficha()
            {
                id = s.Precio2.id,
                descripcion = s.Precio2.descripcion,
            };
            var p3 = new OOB.LibSistema.Precio.Ficha()
            {
                id = s.Precio3.id,
                descripcion = s.Precio3.descripcion,
            };
            var p4 = new OOB.LibSistema.Precio.Ficha()
            {
                id = s.Precio4.id,
                descripcion = s.Precio4.descripcion,
            };
            var p5 = new OOB.LibSistema.Precio.Ficha()
            {
                id = s.Precio5.id,
                descripcion = s.Precio5.descripcion,
            };
            var nr = new OOB.LibSistema.Precio.Etiquetar.Ficha()
            {
                Precio1 = p1,
                Precio2 = p2,
                Precio3 = p3,
                Precio4 = p4,
                Precio5 = p5,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.Resultado Precio_Etiquetar_Actualizar(OOB.LibSistema.Precio.Etiquetar.Actualizar ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Precio.Etiquetar.Actualizar()
            {
                descripcion_1 = ficha.descripcion_1,
                descripcion_2 = ficha.descripcion_2,
                descripcion_3 = ficha.descripcion_3,
                descripcion_4 = ficha.descripcion_4,
                descripcion_5 = ficha.descripcion_5,
            };
            var r01 = MyData.Precio_Etiquetar_Actualizar (fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

    }

}