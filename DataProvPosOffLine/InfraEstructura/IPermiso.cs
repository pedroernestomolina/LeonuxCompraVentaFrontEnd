using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{
    
    public interface IPermiso
    {

        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Permiso.Pos.Ficha> Permiso_ManejoPos();
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Permiso.AdmDocumento.Ficha> Permiso_AdmDocumento();

    }

}