using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.SucursalGrupo
{
    
    public class Gestion
    {

        private GestionLista _gestionLista;


        public BindingSource Source { get { return _gestionLista.Source; } }
        public int Items { get { return _gestionLista.Items; } }


        public Gestion()
        {
            _gestionLista = new GestionLista();
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

            var r01 = Sistema.MyData.SucursalGrupo_GetLista();
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
            var r00 = Sistema.MyData.Permiso_ControlSucursalGrupo_Agregar(Sistema.UsuarioP.autoGrupo);
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
            var r00 = Sistema.MyData.Permiso_ControlSucursalGrupo_Editar(Sistema.UsuarioP.autoGrupo);
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

    }

}