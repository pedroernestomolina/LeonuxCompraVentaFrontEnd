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

    }

}