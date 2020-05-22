using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Infra
{
    
    public interface IData: ICliente, IDeposito, ISucursal, IVendedor, ICobrador, ITransporte, 
        IProducto, IConfiguracion, IExistencia, IPrecio, IPermiso, IVenta, IMovInvConcepto,
        ISeries, IFiscal, IPos
    {

        OOB.ResultadoEntidad <DateTime> FechaServidor();

    }

}