using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{

    public interface IUsuarioGrupo
    {

        OOB.ResultadoLista<OOB.LibSistema.UsuarioGrupo.Ficha> UsuarioGrupo_GetLista();
        OOB.ResultadoEntidad<OOB.LibSistema.UsuarioGrupo.Ficha> UsuarioGrupo_GetFicha(string auto);
        OOB.ResultadoAuto UsuarioGrupo_Agregar(OOB.LibSistema.UsuarioGrupo.Agregar ficha);
        OOB.Resultado UsuarioGrupo_Editar(OOB.LibSistema.UsuarioGrupo.Editar ficha);
        OOB.Resultado GrupoUsuario_ELiminar(string auto);
        OOB.ResultadoLista<OOB.LibSistema.UsuarioGrupo.Usuario> GrupoUsuario_GetUsuarios(string auto);

    }

}