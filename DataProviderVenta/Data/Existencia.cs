using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Data
{

    public partial class DataProvider: DataProviderVenta.Infra.IData
    {

        public OOB.ResultadoEntidad<OOB.LibVenta.Inventario.Existencia.Ficha> Existencia(string autoPrd, string autoDep)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibVenta.Inventario.Existencia.Ficha>();

            var r01 = MyData.Existencia(autoPrd, autoDep);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            var s = r01.Entidad;
            var ubicacion=s.Ubicacion_1.Trim()+Environment.NewLine+s.Ubicacion_2.Trim()+
                Environment.NewLine+s.Ubicacion_3.Trim()+Environment.NewLine+s.Ubicacion_4.Trim();
            var ent = new OOB.LibVenta.Inventario.Existencia.Ficha()
            {
                autoDeposito=s.autoDeposito ,
                CodigoDeposito=s.CodigoDeposito ,
                DescripcionDeposito=s.DescripcionDeposito,
                CantUndFisica=s.cntFisica,
                CantUndReservada=s.cntReservada,
                CantUndDisponible=s.cntDisponible,
                Ubicacion=ubicacion,
            };
            result.Entidad = ent;

            return result;
        }

    }

}