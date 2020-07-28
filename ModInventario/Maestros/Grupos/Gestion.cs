﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Maestros.Grupos
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

            var r01 = Sistema.MyData.Grupo_GetLista();
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
            _gestionLista.AgregarItem();
        }

        public void EditarItem()
        {
            _gestionLista.EditarItem();
        }

    }

}