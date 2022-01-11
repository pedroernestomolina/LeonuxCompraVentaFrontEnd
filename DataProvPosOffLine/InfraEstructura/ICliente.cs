using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{

    public interface ICliente
    {

        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Cliente.Ficha> Cliente(int id);
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Cliente.Ficha> Cliente_BuscarPorCiRif(string ciRif);
        OOB.ResultadoId Cliente_Agregar(OOB.LibVenta.PosOffline.Cliente.Agregar ficha);
        OOB.Resultado Cliente_Editar(OOB.LibVenta.PosOffline.Cliente.Editar.Ficha ficha);
        OOB.ResultadoLista<OOB.LibVenta.PosOffline.Cliente.Ficha> Cliente_Lista(string filtro);
        OOB.ResultadoLista<OOB.LibVenta.PosOffline.Cliente.ExportarData.Ficha> Cliente_ExportarData(OOB.LibVenta.PosOffline.Cliente.ExportarData.Filtro filtro);

    }

}