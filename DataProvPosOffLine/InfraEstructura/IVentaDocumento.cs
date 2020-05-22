using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{
    
    public interface IVentaDocumento
    {

        OOB.ResultadoId VentaDocumento_Agregar(OOB.LibVenta.PosOffline.VentaDocumento.Agregar ficha);

    }

}