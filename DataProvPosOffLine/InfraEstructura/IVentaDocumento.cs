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
        OOB.ResultadoLista<OOB.LibVenta.PosOffline.VentaDocumento.Ficha> VentaDocumento_Lista(OOB.LibVenta.PosOffline.VentaDocumento.Filtro filtro);
        OOB.Resultado VentaDocumento_Anular(int idDocumento);
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.VentaDocumento.Ficha> VentaDocumento_Cargar(int idDocumento);

    }

}