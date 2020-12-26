using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.SucursalDeposito
{
    
    public class Gestion
    {


        private GestionLista _gestionLista;


        public int Items { get { return _gestionLista.Items; } }
        public BindingSource Source { get { return _gestionLista.Source; } }


        public Gestion()
        {
            _gestionLista = new GestionLista();
        }


        SucDepFrm frm;
        public void Inicia() 
        {
            if (CargarData())
            {
                frm = new SucDepFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Sucursal_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _gestionLista.setLista(r01.Lista);

            return rt;
        }

        public void EditarItem()
        {
            var r00 = Sistema.MyData.Permiso_AsignarDepositoSucursal_EditarAsignacion(Sistema.UsuarioP.autoGrupo);
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

        public void EliminarAsignacion()
        {
            var r00 = Sistema.MyData.Permiso_AsignarDepositoSucursal_EliminarAsignacion(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionLista.EliminarAsignacion();
            }
        }

    }

}