using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Infra
{

    public interface IData: IUsuario, ISucursal
    {

        OOB.Resultado.FichaEntidad<DateTime> FechaServidor();
        OOB.Resultado.Ficha Test();

    }

}