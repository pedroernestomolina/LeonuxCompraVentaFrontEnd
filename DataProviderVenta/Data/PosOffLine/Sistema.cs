using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Data
{

    public partial class DataProvider : DataProviderVenta.Infra.IData
    {

        public OOB.ResultadoEntidad<string> PosOffLine_ClaveSeguridad()
        {
            var rt = new OOB.ResultadoEntidad<string>();

            var nr = new OOB.ResultadoEntidad<string>()
            {
                Entidad="100",
            };
            rt= nr;

            return rt;
        }

    }

}