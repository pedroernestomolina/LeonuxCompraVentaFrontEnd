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

        public OOB.ResultadoLista<OOB.LibSistema.UsuarioGrupo.Ficha> UsuarioGrupo_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.UsuarioGrupo.Ficha>();

            var r01 = MyData.GrupoUsuario_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibSistema.UsuarioGrupo.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.UsuarioGrupo.Ficha()
                        {
                            auto = s.auto,
                            nombre = s.nombre,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.UsuarioGrupo.Ficha> UsuarioGrupo_GetFicha(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.UsuarioGrupo.Ficha>();

            var r01 = MyData.GrupoUsuario_GetFicha(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.UsuarioGrupo.Ficha()
            {
                auto = s.auto,
                nombre = s.nombre,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoAuto UsuarioGrupo_Agregar(OOB.LibSistema.UsuarioGrupo.Agregar ficha)
        {
            var rt = new OOB.ResultadoAuto();

            var list = ficha.permisos.Select(s =>
            {
                var nr = new DtoLibSistema.GrupoUsuario.Permiso()
                {
                    codigoFuncion = s.codigoFuncion,
                    estatus = s.estatus,
                    seguridad = s.seguridad,
                };
                return nr;
            }).ToList();
            var fichaDTO = new DtoLibSistema.GrupoUsuario.Agregar()
            {
                nombre = ficha.nombre,
                 permisos= list,
            };
            var r01 = MyData.GrupoUsuario_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            rt.Auto = r01.Auto;

            return rt;
        }

        public OOB.Resultado UsuarioGrupo_Editar(OOB.LibSistema.UsuarioGrupo.Editar ficha)
        {
            var rt = new OOB.Resultado();

            var fichaDTO = new DtoLibSistema.GrupoUsuario.Editar()
            {
                auto = ficha.auto,
                nombre = ficha.nombre,
            };
            var r01 = MyData.GrupoUsuario_Editar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.Resultado GrupoUsuario_ELiminar(string auto)
        {
            var rt = new OOB.Resultado();

            var r01 = MyData.GrupoUsuario_ELiminar(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

        public OOB.ResultadoLista<OOB.LibSistema.UsuarioGrupo.Usuario> GrupoUsuario_GetUsuarios(string auto)
        {
            var rt = new OOB.ResultadoLista<OOB.LibSistema.UsuarioGrupo.Usuario>();

            var r01 = MyData.GrupoUsuario_GetUsuarios(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibSistema.UsuarioGrupo.Usuario>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibSistema.UsuarioGrupo.Usuario()
                        {
                            autoId = s.autoId,
                            apellido = s.apellido,
                            codigo = s.codigo,
                            estatus = s.estatus,
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