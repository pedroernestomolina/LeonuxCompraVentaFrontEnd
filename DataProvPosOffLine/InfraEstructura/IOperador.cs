using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{

    public interface IOperador
    {

        OOB.ResultadoId Operador_Abrir(OOB.LibVenta.PosOffline.Operador.Abrir.Ficha ficha);
        OOB.Resultado Operador_Cerrar(OOB.LibVenta.PosOffline.Operador.Cerrar.Ficha ficha);
        OOB.ResultadoEntidad<int> Operador_Activo();
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Operador.Cargar.Ficha> Operador_Cargar(int idOperador);

    }

}
