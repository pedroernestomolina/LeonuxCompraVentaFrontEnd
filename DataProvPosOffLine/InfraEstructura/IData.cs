using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{

    public interface IData: IProducto, ICliente, IServidor, IItem, IVentaDocumento, IFiscal, IConfiguracion,
        IPendiente, IPermiso, IDeposito, ICobrador, IVendedor, ITransporte, IMedioCobro, ISerie, IJornada, IOperador
    {

        void setServidorRemoto(string instancia, string basedatos);
        OOB.ResultadoEntidad<DateTime> FechaServidor();

    }

}