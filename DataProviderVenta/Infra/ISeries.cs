﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Infra
{

    public interface ISeries
    {
        
        OOB.ResultadoLista<OOB.LibVenta.Series.Ficha> SeriesLista();

    }

}