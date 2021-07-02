using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Infra
{

    public interface IData: IUsuario, ISucursal, IDocumento, ISistema, IPermiso, IReportes,
        IClienteGrupo, IClienteZona, IConfiguracion, ICliente, IReportesCli
    {

        OOB.Resultado.FichaEntidad<DateTime> FechaServidor();
        OOB.Resultado.Ficha Test();

    }

}