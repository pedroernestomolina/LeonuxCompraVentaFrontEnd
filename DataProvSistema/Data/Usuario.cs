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

        public OOB.ResultadoEntidad<OOB.LibSistema.Usuario.Ficha> Usuario_Principal()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Usuario.Ficha>();

            var r01 = MyData.Usuario_Principal();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Usuario.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Usuario.Ficha> Usuario_GetFicha(string autoUsu)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Usuario.Ficha>();

            var r01 = MyData.Usuario_GetFicha(autoUsu);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var fechaNula = new DateTime(2000, 1, 1);
            var _estatus= OOB.LibSistema.Usuario.Enumerados.EnumModo.Activo;
            if (s.estatus.Trim().ToUpper()!="ACTIVO")
                _estatus= OOB.LibSistema.Usuario.Enumerados.EnumModo.Inactivo;
            var nr = new OOB.LibSistema.Usuario.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
                apellido = s.apellido,
                grupo = s.grupo,
                estatus = _estatus,
                fechaAlta = s.fechaAlta.ToShortDateString(),
                fechaBaja = s.fechaBaja == fechaNula ? "" : s.fechaBaja.ToShortDateString(),
                fechaUltSesion = s.fechaUltSesion == fechaNula ? "" : s.fechaUltSesion.ToShortDateString(),
                autoGrupo = s.autoGrupo,
                clave = s.clave,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoAuto Usuario_Agregar(OOB.LibSistema.Usuario.Agregar ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var fichaDTO = new DtoLibSistema.Usuario.Agregar()
            {
                autoGrupo = ficha.autoGrupo,
                nombre = ficha.nombre,
                codigo = ficha.codigo,
                apellido = ficha.apellido,
                clave = ficha.clave,
                estatus = ficha.estatus,
            };
            var r01 = MyData.Usuario_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            rt.Auto = r01.Auto;
            return rt;
        }

        public OOB.Resultado Usuario_Editar(OOB.LibSistema.Usuario.Editar ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Usuario.Editar()
            {
                auto = ficha.auto,
                autoGrupo = ficha.autoGrupo,
                nombre = ficha.nombre,
                codigo = ficha.codigo,
                apellido = ficha.apellido,
                clave = ficha.clave,
            };
            var r01 = MyData.Usuario_Editar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Usuario_Inactivar(OOB.LibSistema.Usuario.Inactivar ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Usuario.Inactivar()
            {
                auto = ficha.auto,
            };
            var r01 = MyData.Usuario_Inactivar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado Usuario_Activar(OOB.LibSistema.Usuario.Activar ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Usuario.Activar()
            {
                auto = ficha.auto,
            };
            var r01 = MyData.Usuario_Activar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Usuario.Ficha> Usuario_Cargar(OOB.LibSistema.Usuario.Buscar.Ficha ficha)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Usuario.Ficha>();

            var fichaBuscar = new DtoLibSistema.Usuario.Buscar.Ficha()
            {
                codigo = ficha.Codigo,
                clave = ficha.Clave,
            };
            var r01 = MyData.Usuario_Buscar(fichaBuscar);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var u = r01.Entidad;
            var nr = new OOB.LibSistema.Usuario.Ficha()
            {
                auto = u.autoUsu,
                codigo = u.codigoUsu,
                nombre = u.nombreUsu,
                apellido = u.apellidoUsu,
                estatus = u.isActivo ? OOB.LibSistema.Usuario.Enumerados.EnumModo.Activo : OOB.LibSistema.Usuario.Enumerados.EnumModo.Inactivo,
                autoGrupo = u.autoGru,
                grupo = u.nombreGru,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.Resultado Usuario_ActualizarSesion(OOB.LibSistema.Usuario.ActualizarSesion.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.Usuario.ActualizarSesion.Ficha()
            {
                autoUsu = ficha.autoUsu
            };
            var r01 = MyData.Usuario_ActualizarSesion(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibSistema.Usuario.Ficha> Usuario_GetLista(OOB.LibSistema.Usuario.Lista.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.Usuario.Ficha>();

            var filtroDTO = new DtoLibSistema.Usuario.Lista.Filtro()
            {
                IdGrupo = filtro.IdGrupo,
            };
            var r01 = MyData.Usuario_GetLista(filtroDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibSistema.Usuario.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        var fechaNula=new DateTime(2000,1,1);
                        var _estatus = OOB.LibSistema.Usuario.Enumerados.EnumModo.Activo;
                        if (s.uEstatus.Trim().ToUpper() != "ACTIVO")
                            _estatus = OOB.LibSistema.Usuario.Enumerados.EnumModo.Inactivo;
                        var _fechaAlta = (s.uFechaAlta!=fechaNula ? s.uFechaAlta.ToShortDateString(): "");
                        var _fechaBaja = (s.uFechaBaja != fechaNula ? s.uFechaBaja.ToShortDateString() : "");
                        var _fechaUltSesion = (s.uFechaUltSesion != fechaNula ? s.uFechaUltSesion.ToShortDateString() : "");
                        return new OOB.LibSistema.Usuario.Ficha()
                        {
                            auto = s.uId,
                            codigo = s.uCodigo,
                            nombre = s.uNombre,
                            apellido = s.uApellido,
                            grupo = s.gNombre,
                            estatus = _estatus,
                            fechaAlta = _fechaAlta,
                            fechaBaja =_fechaBaja,
                            fechaUltSesion = _fechaUltSesion,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.Resultado Usuario_Eliminar(string id)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.Usuario_Eliminar(id);
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