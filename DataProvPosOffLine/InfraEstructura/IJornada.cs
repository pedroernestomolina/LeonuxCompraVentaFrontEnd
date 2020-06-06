using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{
    
    public interface IJornada
    {

        OOB.ResultadoId Jornada_Abrir(OOB.LibVenta.PosOffline.Jornada.Abrir.Ficha ficha);
        OOB.Resultado Jornada_Cerrar(OOB.LibVenta.PosOffline.Jornada.Cerrar.Ficha ficha);
        OOB.ResultadoEntidad<int> Jornada_Activa();
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Jornada.Cargar.Ficha> Jornada_Cargar(int idJornada);

    }

}