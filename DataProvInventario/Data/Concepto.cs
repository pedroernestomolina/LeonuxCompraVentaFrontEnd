using DataProvInventario.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.Data
{
    
    public partial class DataProv: IData
    {

        OOB.ResultadoEntidad<OOB.LibInventario.Concepto.Ficha> IConcepto.Concepto_PorTraslado()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibInventario.Concepto.Ficha>();

            var r01 = MyData.Concepto_PorTraslado();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibInventario.Concepto.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}