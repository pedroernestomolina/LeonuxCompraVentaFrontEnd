using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Infra.PosOffLine
{
    
    public interface IUsuario
    {

        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Usuario.Ficha> PosOffLine_Usuario(string usuCodigo, string usuClave);

    }

}