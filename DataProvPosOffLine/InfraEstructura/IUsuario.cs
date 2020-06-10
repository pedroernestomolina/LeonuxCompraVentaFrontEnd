using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{

    public interface IUsuario
    {

        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Usuario.Ficha> Usuario_Cargar(OOB.LibVenta.PosOffline.Usuario.BuscarCargar ficha);

    }

}