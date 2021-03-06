﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.InfraEstructura
{
    
    public interface IServidor
    {

        OOB.Resultado Servidor_Test();
        OOB.Resultado Servidor_ActualizarData();
        OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Servidor.PrepararData.Ficha> Servidor_PrepararData();
        OOB.Resultado Servidor_EnviarData(OOB.LibVenta.PosOffline.Servidor.EnviarData.Ficha ficha);

    }

}