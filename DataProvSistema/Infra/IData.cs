using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    public interface IData: IDeposito, ISucursalGrupo, ISucursal, IUsuario, IPrecio,
        IFuncion, IUsuarioGrupo

    {

        OOB.ResultadoEntidad<DateTime> FechaServidor();

    }

}