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

        public OOB.Resultado.FichaEntidad<OOB.Vendedor.Entidad.Ficha> Vendedor_GetFichaById(string id)
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Vendedor.Entidad.Ficha>();

            var r01 = MyData.Vendedor_GetFichaById (id);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            result.Entidad = new OOB.Vendedor.Entidad.Ficha()
            {
                codigo = ent.codigo,
                id = ent.id,
                nombre = ent.nombre,
            };

            return result;
        }

    }

}