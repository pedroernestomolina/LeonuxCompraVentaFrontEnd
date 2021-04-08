﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Maestros.EmpaqueMedida
{

    public class Gestion : IGestion
    {


        private IGestionLista _gestionLista;
        private AgregarEditar _agregarEditar;


        public string Maestro { get { return "Maestro: Empaques y Medidas"; } }
        public int TotalItems { get { return _gestionLista.TotalItems; } }
        public BindingSource Source { get { return _gestionLista.Source; } }
        public bool IsMarca { get { return false; } }
        public bool IsEmpaqueMedida { get { return true; } }


        public Gestion()
        {
            _gestionLista = new GestionLista();
            _agregarEditar = new AgregarEditar();
        }


        public bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.EmpaqueMedida_GetLista ();
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
            var r00 = Sistema.MyData.Permiso_CrearUnidadEmpaque (Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _agregarEditar.Agregar();
                if (_agregarEditar.IsOk)
                {
                    _gestionLista.Agregar(_agregarEditar.Ficha);
                }
            }
        }

        public void EditarItem()
        {
            var r00 = Sistema.MyData.Permiso_ModificarUnidadEmpaque(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var itActual = (data)_gestionLista.ItemActual;
                if (itActual != null)
                {
                    _agregarEditar.Editar(itActual);
                    if (_agregarEditar.IsOk)
                    {
                        _gestionLista.ActualizarItem(_agregarEditar.Ficha);
                    }
                }
            }

        }

        public void EliminarItem()
        {
        }

    }

}