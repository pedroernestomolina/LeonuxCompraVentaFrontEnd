using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IConfiguracion
    {

        OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumPreferenciaBusqueda> Configuracion_PreferenciaBusqueda();
        OOB.ResultadoEntidad<OOB.LibInventario.Configuracion.Enumerados.EnumMetodoCalculoUtilidad> Configuracion_MetodoCalculoUtilidad();
        OOB.ResultadoEntidad<decimal> Configuracion_TasaCambioActual();

    }

}