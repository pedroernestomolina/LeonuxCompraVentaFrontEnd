using ModVentaAdm.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Prov
{
    
    public partial class DataPrv : IData
    {

        public OOB.Resultado.FichaEntidad<OOB.Configuracion.BusquedaCliente.Entidad.Ficha> Configuracion_BusquedaCliente()
        {
            var rt = new OOB.Resultado.FichaEntidad<OOB.Configuracion.BusquedaCliente.Entidad.Ficha>();

            var r01 = MyData.Configuracion_BusquedaCliente();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return rt;
            }

            var nr = new OOB.Configuracion.BusquedaCliente.Entidad.Ficha()
            {
                Usuario = r01.Entidad.Usuario,
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}