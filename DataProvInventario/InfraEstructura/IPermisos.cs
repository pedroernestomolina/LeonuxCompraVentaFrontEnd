﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvInventario.InfraEstructura
{
    
    public interface IPermisos
    {

        OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMaximo();
        OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMedio();
        OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMinimo();

        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CrearProducto(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ModificarProducto(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CambiarPrecios(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CambiarCostos(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_AsignarDepositos(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CambiarDatosDelDeposito(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ActualizarEstatusDelProducto(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CambiarImagenDelProducto(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ToolInventario(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CrearDepartamento(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ModificarDepartamento(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CrearGrupo(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ModificarGrupo(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CrearMarca(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ModificarMarca(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CrearUnidadEmpaque(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ModificarUnidadEmpaque(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_CrearConceptoInventario(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha> Permiso_ModificarConceptoInventario(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>Permiso_MovimientoCargoInventario(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>Permiso_MovimientoDescargoInventario(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>Permiso_MovimientoTrasladoInventario(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>Permiso_MovimientoAjusteInventario(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>Permiso_AdministradorMovimientoInventario(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>Permiso_AnularMovimientoInventario(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>Permiso_DefinirNivelMinimoMaximoInventario(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>Permiso_MovimientoTrasladoEntreSucursales_PorExistenciaDebajoDelMinimo(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>Permiso_Reportes(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>Permiso_Visor(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibInventario.Permiso.Ficha>Permiso_Estadistica(string autoGrupoUsuario);

    }

}
