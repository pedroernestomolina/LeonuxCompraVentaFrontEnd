﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface IPermiso
    {

        OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMaximo();
        OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMedio();
        OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMinimo();
         
        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_ToolCompra(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_Registrar_Factura(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_AdmDoc(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_AdmDoc_Anular(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_AdmDoc_Visualizar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibCompra.Permiso.Ficha> Permiso_AdmDoc_Reporte(string autoGrupoUsuario);

    }

}