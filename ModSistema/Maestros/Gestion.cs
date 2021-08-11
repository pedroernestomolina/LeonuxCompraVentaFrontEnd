using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Maestros
{
    
    public class Gestion
    {

        private GestionLista _gestionLista;
        private IGestion _gestion;


        public BindingSource Source { get { return _gestionLista.Source; } }
        public int CntItem { get { return _gestionLista.CntItem; } }
        public string MaestroTitulo { get { return _gestion.MaestroTitulo; } }
        public dataLista ItemActual { get { return _gestionLista.ItemActual; } }


        public Gestion()
        {
            _gestionLista = new GestionLista();
        }


        public void setGestion(IGestion gestion)
        {
            this._gestion =gestion;
            _gestion.setLista(_gestionLista);
        }

        public void Inicializa() 
        {
            _gestion.Inicializa();
            _gestionLista.Inicializa();
        }

        private MaestroFrm frm;
        public void Inicia()
        {
            if (_gestion.CargarData())
            {
                if (frm == null) 
                {
                    frm = new MaestroFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
      
        public void AgregarFicha()
        {
            var r00 = Sistema.MyData.Permiso_ControlVendedor_Agregar(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestion.AgregarFicha();
            }
        }

        public void EditarFicha()
        {
            if (ItemActual != null)
            {
                var r00 = Sistema.MyData.Permiso_ControlVendedor_Editar(Sistema.UsuarioP.autoGrupo);
                if (r00.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return;
                }

                if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
                {
                    _gestion.EditarFicha(ItemActual);
                }
            }
        }

    }

}