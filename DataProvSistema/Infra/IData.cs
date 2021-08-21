using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    public interface IData: IDeposito, ISucursalGrupo, ISucursal, IUsuario, IPrecio,
        IFuncion, IUsuarioGrupo, IServConf, IPermisos, IConfiguracion, IVendedor, ICobrador ,
        ISerieFiscal

    {

        OOB.ResultadoEntidad<DateTime> FechaServidor();
        OOB.ResultadoEntidad<OOB.LibSistema.Empresa.Data.Ficha> Empresa_Datos();

    }

}