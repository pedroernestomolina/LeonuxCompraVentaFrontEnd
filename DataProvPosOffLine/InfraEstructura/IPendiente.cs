using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{
    
    public interface IPendiente
    {

        OOB.Resultado Pendiente_DejarCtaEnPendiente(OOB.LibVenta.PosOffline.Pendiente.DejarEnPendiente.Agregar ficha);
        OOB.ResultadoLista<OOB.LibVenta.PosOffline.Pendiente.Ficha> Pendiente_Lista();
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Pendiente.CtaAbrir.Ficha> Pendiente_AbrirCta(int id);
        OOB.Resultado Pendiente_EliminarCta(int id);
        OOB.ResultadoEntidad<bool> Pendiente_HayCuentasporProcesar();

    }

}