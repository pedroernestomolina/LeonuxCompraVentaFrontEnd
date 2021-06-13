using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Infra
{
    
    public interface IConfiguracion
    {

        OOB.Resultado.FichaEntidad<OOB.Configuracion.BusquedaCliente.Entidad.Ficha> Configuracion_BusquedaCliente();

    }

}