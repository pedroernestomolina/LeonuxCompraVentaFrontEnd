﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Usuario
{
    
    public class Gestion
    {

        private GestionLista _gestionLista;


        public BindingSource Source { get { return _gestionLista.Source; } }
        public OOB.LibSistema.Usuario.Ficha ItemActual { get { return _gestionLista.Item; } }
        public int Items { get { return _gestionLista.Items; } }


        public Gestion()
        {
            _gestionLista = new GestionLista();
            _gestionLista.CambioItemActual+=_gestionLista_CambioItemActual;
        }


        private void _gestionLista_CambioItemActual(object sender, EventArgs e)
        {
            if (_gestionLista.Item != null) 
            {
                if (frm != null) 
                {
                    frm.setActualizarItem();
                }
            }
        }

        MaestroFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                frm = new MaestroFrm();
                frm.setControlador(this);
                frm.setActualizarItem();
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Usuario_GetLista();
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
            var r00 = Sistema.MyData.Permiso_ControlUsuario_Agregar(Sistema.UsuarioP.autoGrupo);
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
            var r00 = Sistema.MyData.Permiso_ControlUsuario_Editar(Sistema.UsuarioP.autoGrupo);
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
            var r00 = Sistema.MyData.Permiso_ControlUsuario_ActivarInactivar(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionLista.ActivarInactivar();
            }
        }

    }

}