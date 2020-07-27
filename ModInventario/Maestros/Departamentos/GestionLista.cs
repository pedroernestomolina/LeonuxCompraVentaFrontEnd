﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Maestros.Departamentos
{

    public class GestionLista
    {

        private GestionAgregarEditar _gestionAgregarEditar;
        private List<OOB.LibInventario.Departamento.Ficha> lLista;
        private BindingList<OOB.LibInventario.Departamento.Ficha> blLista;
        private BindingSource bsLista;


        public BindingSource Source { get { return bsLista; } }
        public int Items { get { return blLista.Count; } }


        public GestionLista()
        {
            _gestionAgregarEditar = new GestionAgregarEditar();
            lLista = new List<OOB.LibInventario.Departamento.Ficha>();
            blLista = new BindingList<OOB.LibInventario.Departamento.Ficha>(lLista);
            bsLista = new BindingSource();
            bsLista.DataSource = blLista;
        }

        public void AgregarItem()
        {
            _gestionAgregarEditar.Agregar();
            if (_gestionAgregarEditar.IsAgregarEditarOk)
            {
                CargarData();
            }
        }

        private void CargarData()
        {
            var r01 = Sistema.MyData.Departamento_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
            }
            setLista(r01.Lista);
        }

        public void EditarItem()
        {
            var it = (OOB.LibInventario.Departamento.Ficha)bsLista.Current;
            if (it != null)
            {
                _gestionAgregarEditar.Editar(it);
                if (_gestionAgregarEditar.IsAgregarEditarOk)
                {
                    CargarData();
                }
            }
        }

        public void setLista(List<OOB.LibInventario.Departamento.Ficha> list)
        {
            blLista.Clear();
            foreach (var it in list.OrderBy(o => o.codigo).ToList())
            {
                blLista.Add(it);
            }
        }

    }

}