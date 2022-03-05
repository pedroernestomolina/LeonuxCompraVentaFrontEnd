using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{
    
    public interface IPermisos
    {

        OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMaximo();
        OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMedio();
        OOB.ResultadoEntidad<string> Permiso_PedirClaveAcceso_NivelMinimo();

        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ToolSistema(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_InicializarBD(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_InicializarBD_Sucursal(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_AjustarTasaDivisa(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_AjustarTasaDivisaRecepcionPos(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_EtiquetaParaPrecios(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_AsignarDepositoSucursal(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_AsignarDepositoSucursal_EliminarAsignacion(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_AsignarDepositoSucursal_EditarAsignacion(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha>  Permiso_ControlSucursalGrupo(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlSucursalGrupo_Agregar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlSucursalGrupo_Editar(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlSucursal(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlSucursal_Agregar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlSucursal_Editar(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlDeposito(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlDeposito_Agregar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlDeposito_Editar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlDeposito_ActivarInactivar(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlUsuarioGrupo(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlUsuarioGrupo_Agregar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlUsuarioGrupo_Editar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlUsuarioGrupo_Eliminar(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlUsuario(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlUsuario_Agregar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlUsuario_Editar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlUsuario_ActivarInactivar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlUsuario_Eliminar(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlVendedor(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlVendedor_Agregar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlVendedor_Editar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlVendedor_ActivarInactivar(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlCobrador(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlCobrador_Agregar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlCobrador_Editar(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlSerieFiscal(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlSerieFiscal_Agregar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlSerieFiscal_Editar(string autoGrupoUsuario);
        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ControlSerieFiscal_ActivarInactivar(string autoGrupoUsuario);

        OOB.ResultadoEntidad<OOB.LibSistema.Permiso.Ficha> Permiso_ConfiguracionSistema(string autoGrupoUsuario);

    }

}