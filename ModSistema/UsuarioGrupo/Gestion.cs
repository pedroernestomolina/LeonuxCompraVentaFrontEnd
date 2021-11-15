using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.UsuarioGrupo
{

    public class Gestion
    {

        private GestionLista _gestionLista;
        private Usuario.Gestion _gestionUsuario;
        private ControlAcceso.Gestion _gestionControlAcceso;


        public BindingSource Source { get { return _gestionLista.Source; } }
        public int Items { get { return _gestionLista.Items; } }


        public Gestion()
        {
            _gestionLista = new GestionLista();
            _gestionUsuario = new Usuario.Gestion();
            _gestionControlAcceso = new ControlAcceso.Gestion();
        }

        public void Inicia()
        {
            if (CargarData())
            {
                var frm = new MaestroFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.UsuarioGrupo_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _gestionLista.setLista(r01.Lista);

            return rt;
        }

        public void AgregarItem()
        {
            var r00 = Sistema.MyData.Permiso_ControlUsuarioGrupo_Agregar(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionLista.AgregarItem();
            }
        }

        public void EditarItem()
        {
            var r00 = Sistema.MyData.Permiso_ControlUsuarioGrupo_Editar(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionLista.EditarItem();
            }
        }

        public void EliminarItem()
        {
            var r00 = Sistema.MyData.Permiso_ControlUsuarioGrupo_Eliminar(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionLista.EliminarItem();

            }
        }

        public void ListaUsuarios()
        {
            var it = _gestionLista.ItemActual;
            if (it != null)
            {
                var r0 = Sistema.MyData.GrupoUsuario_GetUsuarios(it.auto);
                if (r0.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r0.Mensaje);
                    return;
                }

                _gestionUsuario.Inicializa();
                _gestionUsuario.setFiltroGrupo(it.auto);
                _gestionUsuario.Inicia();
            }
        }

        public void Inicializa()
        {
            _gestionLista.Inicializa();
        }

        public void Permisos()
        {
            var it = _gestionLista.ItemActual;
            if (it != null)
            {
                var r01 = Sistema.MyData.ControlAcceso_GetData(it.auto);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                _gestionControlAcceso.Inicializa();
                _gestionControlAcceso.setGrupo(it.auto, it.nombre);
                _gestionControlAcceso.setLista(r01.Lista);
                _gestionControlAcceso.Inicia();
            }
        }

    }

}