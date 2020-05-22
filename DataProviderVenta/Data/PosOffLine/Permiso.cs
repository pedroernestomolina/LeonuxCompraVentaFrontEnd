using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Data
{

    public partial class DataProvider : DataProviderVenta.Infra.IData
    {

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Permiso.Ficha> PosOffLine_Permiso_ModuloVenta(string autoGrupo)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Permiso.Ficha>();

            var nr = new OOB.LibVenta.PosOffline.Permiso.Ficha()
            {
                IsHabilitado=true,
                NivelSeguridad= OOB.LibVenta.PosOffline.Permiso.Enumerados.enumNivelSeguridad.Maximo,
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}