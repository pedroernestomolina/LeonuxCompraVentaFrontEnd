using DataProvPosOffLine.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.Data
{
    
    public partial class DataProv: IData
    {

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Fiscal.Ficha> Fiscal_Tasas()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Fiscal.Ficha>();

            var r01 = MyData.Fiscal_Tasas();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var c = r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Fiscal.Ficha()
            {
                 Tasa1=c.Tasa1,
                 Tasa2=c.Tasa2,
                 Tasa3=c.Tasa3
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}