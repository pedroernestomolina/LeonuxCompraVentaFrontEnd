using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Data
{

    public partial class DataProvider: DataProviderVenta.Infra.IData
    {

        public OOB.ResultadoEntidad<OOB.LibVenta.Inventario.Precio.Ficha> Precio(string autoPrd, string idPrecio)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibVenta.Inventario.Precio.Ficha>();

            var r01 = MyData.Precio(autoPrd, idPrecio);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            var s = r01.Entidad;
            var ent = new OOB.LibVenta.Inventario.Precio.Ficha()
            {
                Id=s.Id,
                ContEmpVenta=s.ContEmpVenta,
                DescEmpVenta=s.DescEmpVenta,
                PrecioNeto=s.PrecioNeto,
                UtilidadMargen=s.UtilidadMargen,
                Decimales= s.Decimales,
            };
            result.Entidad = ent;

            return result;
        }

    }

}