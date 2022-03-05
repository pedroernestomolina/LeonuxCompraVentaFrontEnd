using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Deposito
{

    public class Gestion
    {

        private GestionLista _gestionLista;


        public BindingSource Source { get { return _gestionLista.Source; } }
        public int Items { get { return _gestionLista.Items; } }
        public OOB.LibSistema.Deposito.Ficha ItemActual { get { return _gestionLista.ItemActual; } }


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

            var r01 = Sistema.MyData.Deposito_GetLista();
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
            var r00 = Sistema.MyData.Permiso_ControlDeposito_Agregar(Sistema.UsuarioP.autoGrupo);
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
            var r00 = Sistema.MyData.Permiso_ControlDeposito_Editar(Sistema.UsuarioP.autoGrupo);
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

        public void ActivarInactivar()
        {
            if (ItemActual != null)
            {
                var r00 = Sistema.MyData.Permiso_ControlDeposito_Agregar(Sistema.UsuarioP.autoGrupo);
                if (r00.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return;
                }

                if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
                {
                    if (ItemActual.isActivo)
                        Inactivar();
                    else
                        Activar();
                }
            }
        }

        private void Activar()
        {
            var xmsg = "Estas Seguro de querer Activar este Depósito ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var r01 = Sistema.MyData.Deposito_Activar(ItemActual.auto);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                ItemActual.setEstatusActivo();
                Helpers.Msg.OK("Proceso Realizado Con Exito !!!");
            }
        }

        private void Inactivar()
        {
            var xmsg = "Estas Seguro de querer Inactivar este Depósito ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                var r01 = Sistema.MyData.Deposito_Inactivar(ItemActual.auto);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                ItemActual.setEstatusInactivo();
                Helpers.Msg.OK("Proceso Realizado Con Exito !!!");
            }
        }

    }

}