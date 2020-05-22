using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Data
{

    public partial class DataProvider: DataProviderVenta.Infra.IData
    {

        public OOB.ResultadoEntidad<OOB.LibVenta.MovInventario.Concepto.Ficha> MovInventario_Concepto(string auto)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibVenta.MovInventario.Concepto.Ficha>();

            var r01 = MyData.MovInventario_Concepto(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            var ent = r01.Entidad;
            result.Entidad = new OOB.LibVenta.MovInventario.Concepto.Ficha()
            {
                Auto = ent.Auto,
                Codigo=ent.Codigo,
                Nombre=ent.Descripcion,
            };

            return result;
        }

    }

}