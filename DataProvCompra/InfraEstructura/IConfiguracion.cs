using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface IConfiguracion
    {

        OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor> Configuracion_PreferenciaBusquedaProveedor();
        OOB.ResultadoEntidad<decimal> Configuracion_TasaCambioActual();

    }

}