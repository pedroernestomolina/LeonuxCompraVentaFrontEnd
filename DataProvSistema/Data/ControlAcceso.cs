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

        public OOB.ResultadoLista<OOB.LibSistema.ControlAcceso.Data.Ficha> ControlAcceso_GetData(string idGrupo)
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.ControlAcceso.Data.Ficha>();

            var r01 = MyData.ControlAcceso_GetData(idGrupo);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var lst = new List<OOB.LibSistema.ControlAcceso.Data.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.ControlAcceso.Data.Ficha()
                        {
                            estatus = s.estatus,
                            fCodigo = s.fCodigo,
                            fNombre = s.fNombre,
                            seguridad = s.seguridad,
                        };
                    }).ToList();
                }
            }
            rt.Lista = lst;

            return rt;
        }

        public OOB.Resultado ControlAcceso_Actualizar(OOB.LibSistema.ControlAcceso.Actualizar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.ControlAcceso.Actualizar.Ficha()
            {
                ItemsAcceso = ficha.ItemsAcceso.Select(s =>
                {
                    var nr = new DtoLibSistema.ControlAcceso.Actualizar.ItemAcceso()
                    {
                        codFuncion = s.codFuncion,
                        codGrupo = s.codGrupo,
                        estatus = s.estatus,
                        seguridad = s.seguridad,
                    };
                    return nr;
                }).ToList(),
            };
            var r01 = MyData.ControlAcceso_Actualizar(fichaDTO);
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