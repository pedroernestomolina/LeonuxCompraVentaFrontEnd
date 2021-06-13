﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Infra
{
    
    public interface IReportes
    {

        OOB.Resultado.Lista<OOB.Reportes.GeneralDocumento.Ficha> Reportes_GeneralDocumento(OOB.Reportes.GeneralDocumento.Filtro filtro);
        OOB.Resultado.Lista<OOB.Reportes.GeneralPorDepartamento.Ficha> Reportes_GeneralPorDepartamento(OOB.Reportes.GeneralPorDepartamento.Filtro filtro);
        OOB.Resultado.Lista<OOB.Reportes.GeneralPorGrupo.Ficha> Reportes_GeneralPorGrupo(OOB.Reportes.GeneralPorGrupo.Filtro filtro);
        OOB.Resultado.Lista<OOB.Reportes.Resumen.Ficha> Reportes_Resumen(OOB.Reportes.Resumen.Filtro filtro);
        OOB.Resultado.Lista<OOB.Reportes.VentaPorProducto.Ficha> Reportes_VentaPorProducto(OOB.Reportes.VentaPorProducto.Filtro filtro);
        OOB.Resultado.Lista<OOB.Reportes.GeneralDocumentoDetalle.Ficha> Reportes_GeneralDocumentoDetalle(OOB.Reportes.GeneralDocumentoDetalle.Filtro filtro);

    }

}