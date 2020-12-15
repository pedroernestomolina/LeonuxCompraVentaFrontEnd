﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface IReportes
    {

        OOB.ResultadoLista<OOB.LibCompra.Reportes.GeneralDocumentos.Ficha> Reportes_ComprasDocumento(OOB.LibCompra.Reportes.GeneralDocumentos.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCompra.Reportes.CompraporDepartamento.Ficha> Reportes_ComprasPorDepartamento(OOB.LibCompra.Reportes.CompraporDepartamento.Filtro filtro);

    }

}