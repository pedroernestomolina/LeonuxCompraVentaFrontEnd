﻿using DataProvSistema.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Data
{

    public partial class DataProv: IData
    {

        public OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMaximo()
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.Permiso_PedirClaveAcceso_NivelMaximo();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }

        public OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMedio()
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.Permiso_PedirClaveAcceso_NivelMedio();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }

        public OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMinimo()
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var r01 = MyData.Permiso_PedirClaveAcceso_NivelMinimo();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ToolSistema(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_ToolSistema(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_InicializarBD(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_InicializarBD(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_InicializarBD_Sucursal(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_InicializarBD_Sucursal(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_AjustarTasaDivisa(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_AjustarTasaDivisa(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_AjustarTasaDivisaRecepcionPos(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_AjustarTasaDivisaRecepcionPos(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_EtiquetaParaPrecios(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_EtiquetaParaPrecios(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_AsignarDepositoSucursal(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_AsignarDepositoSucursal(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_AsignarDepositoSucursal_EliminarAsignacion(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_AsignarDepositoSucursal_EliminarAsignacion(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_AsignarDepositoSucursal_EditarAsignacion(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_AsignarDepositoSucursal_EditarAsignacion(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlSucursalGrupo(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_ControlSucursalGrupo(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlSucursalGrupo_Agregar(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_ControlSucursalGrupo_Agregar(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlSucursalGrupo_Editar(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_ControlSucursalGrupo_Editar(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlSucursal(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_ControlSucursal(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlSucursal_Agregar(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_ControlSucursal_Agregar(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlSucursal_Editar(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_ControlSucursal_Editar(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlDeposito(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_ControlDeposito(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlDeposito_Agregar(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_ControlDeposito_Agregar(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlDeposito_Editar(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_ControlDeposito_Editar(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlUsuarioGrupo(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_ControlUsuarioGrupo(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlUsuarioGrupo_Agregar(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_ControlUsuarioGrupo_Agregar(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlUsuarioGrupo_Editar(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_ControlUsuarioGrupo_Editar(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlUsuario(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_ControlUsuario(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlUsuario_Agregar(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_ControlUsuario_Agregar(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlUsuario_Editar(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_ControlUsuario_Editar(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlUsuario_ActivarInactivar(string autoGrupoUsuario)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>();

            var r01 = MyData.Permiso_ControlUsuario_ActivarInactivar(autoGrupoUsuario);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Permiso.Ficha()
            {
                IsHabilitado = s.IsHabilitado,
                NivelSeguridad = (OOB.LibSistema.Permiso.Enumerados.EnumNivelSeguridad)s.NivelSeguridad,
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}