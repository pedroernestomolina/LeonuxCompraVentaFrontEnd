using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{

    public interface IData: IProducto, ICliente, IServidor, IItem, IVentaDocumento, IFiscal, IConfiguracion,
        IPendiente, IPermiso, IDeposito, ICobrador, IVendedor, ITransporte, IMedioCobro, ISerie, IJornada, IOperador,
        IUsuario, IMovConceptoInv
    {

        void setServidorRemoto(string instancia, string basedatos);
        OOB.ResultadoEntidad<DateTime> FechaServidor();
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Sistema.InformacionBD.Ficha> InformacionBD();
        OOB.Resultado Inicializar_BdLocal();
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Empresa.Ficha> Empresa_Datos();
        OOB.ResultadoEntidad<DateTime?> FechaUltimaActualizacionBDServidor();

    }

}