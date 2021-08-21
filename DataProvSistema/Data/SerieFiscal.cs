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

        public OOB.ResultadoLista<OOB.LibSistema.SerieFiscal.Entidad.Ficha> SerieFiscal_GetLista(OOB.LibSistema.SerieFiscal.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.SerieFiscal.Entidad.Ficha>();

            var filtroDto = new DtoLibSistema.SerieFiscal.Lista.Filtro();
            var r01 = MyData.SerieFiscal_GetLista(filtroDto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibSistema.SerieFiscal.Entidad.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.SerieFiscal.Entidad.Ficha()
                        {
                            id = s.id,
                            control = s.control,
                            correlativo = s.correlativo,
                            estatus = s.estatus,
                            serie = s.serie,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.SerieFiscal.Entidad.Ficha> SerieFiscal_GetFicha_ById(string id)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.SerieFiscal.Entidad.Ficha>();

            var r01 = MyData.SerieFiscal_GetFicha_ById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.SerieFiscal.Entidad.Ficha()
            {
                control = s.control,
                correlativo = s.correlativo,
                estatus = s.estatus,
                estatusFactura = s.estatusFactura,
                estatusNtCredito = s.estatusNtCredito,
                estatusNtDebito = s.estatusNtDebito,
                estatusNtEntrega = s.estatusNtEntrega,
                id = s.id,
                serie = s.serie,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoAuto SerieFiscal_AgregarFicha(OOB.LibSistema.SerieFiscal.Agregar.Ficha ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibSistema.SerieFiscal.Agregar.Ficha()
            {
                control = ficha.control,
                correlativo = ficha.correlativo,
                estatusFactura = ficha.estatusFactura,
                estatusNtCredito = ficha.estatusNtCredito,
                estatusNtDebito = ficha.estatusNtDebito,
                estatusNtEntrega = ficha.estatusNtEntrega,
                serie = ficha.serie,
            };
            var r01 = MyData.SerieFiscal_AgregarFicha(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Auto = r01.Auto;

            return rt;
        }

        public OOB.Resultado SerieFiscal_EditarFicha(OOB.LibSistema.SerieFiscal.Editar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.SerieFiscal.Editar.Ficha()
            {
                id = ficha.id,
                control = ficha.control,
                correlativo = ficha.correlativo,
                serie = ficha.serie,
            };
            var r01 = MyData.SerieFiscal_EditarFicha(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado SerieFiscal_ActivarFicha(OOB.LibSistema.SerieFiscal.ActivarInactivar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.SerieFiscal.ActivarInactivar.Ficha()
            {
                id = ficha.id,
            };
            var r01 = MyData.SerieFiscal_Activar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado SerieFiscal_InactivarFicha(OOB.LibSistema.SerieFiscal.ActivarInactivar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.SerieFiscal.ActivarInactivar.Ficha()
            {
                id = ficha.id,
            };
            var r01 = MyData.SerieFiscal_Inactivar(fichaDTO);
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