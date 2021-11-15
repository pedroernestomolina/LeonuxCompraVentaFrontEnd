using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Infra
{

    public interface IUsuario
    {

        OOB.ResultadoEntidad<OOB.LibSistema.Usuario.Ficha> Usuario_Principal();
        OOB.ResultadoLista<OOB.LibSistema.Usuario.Ficha> Usuario_GetLista(OOB.LibSistema.Usuario.Lista.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibSistema.Usuario.Ficha> Usuario_GetFicha(string autoUsu);
        OOB.ResultadoAuto Usuario_Agregar(OOB.LibSistema.Usuario.Agregar ficha);
        OOB.Resultado Usuario_Editar(OOB.LibSistema.Usuario.Editar ficha);
        OOB.Resultado Usuario_Inactivar(OOB.LibSistema.Usuario.Inactivar ficha);
        OOB.Resultado Usuario_Activar(OOB.LibSistema.Usuario.Activar ficha);
        OOB.ResultadoEntidad<OOB.LibSistema.Usuario.Ficha> Usuario_Cargar(OOB.LibSistema.Usuario.Buscar.Ficha ficha);
        OOB.Resultado Usuario_ActualizarSesion(OOB.LibSistema.Usuario.ActualizarSesion.Ficha ficha);
        OOB.Resultado Usuario_Eliminar(string id);

    }

}