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

        public OOB.Resultado.FichaEntidad<OOB.Sucursal.Entidad.Ficha> Sucursal_GetFichaById(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Sucursal.Entidad.Ficha>();

            var r01 = MyData.Sucursal_GetFichaById(id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            var nr = new OOB.Sucursal.Entidad.Ficha()
            {
                codigo = ent.codigo,
                id = ent.id,
                nombre = ent.nombre
            };
            result.Entidad = nr;

            return result;
        }

    }

}