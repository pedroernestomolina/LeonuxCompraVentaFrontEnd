using PosOnLine.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Data.Prov
{
    
    public partial class DataPrv: IData
    {

        public OOB.Resultado.FichaEntidad<OOB.Permiso.Entidad.Ficha> Permiso_Pos(OOB.Permiso.Buscar.Ficha ficha)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Permiso.Entidad.Ficha>();

            var r01 = MyData.Permiso_Pos(ficha.IdGrupoUsuario, ficha.CodigoFuncion);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            var nr = new OOB.Permiso.Entidad.Ficha()
            {
                permisoHabilitado = ent.permisoHabilitado,
                requiereClave = ent.requiereClave,
            };
            result.Entidad = nr;

            return result;
        }

    }

}