﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Maestros.Marcas
{

    public class GestionLista
    {

        private GestionAgregarEditar _gestionAgregarEditar;
        private List<OOB.LibInventario.Marca.Ficha> lLista;
        private BindingList<OOB.LibInventario.Marca.Ficha> blLista;
        private BindingSource bsLista;


        public BindingSource Source { get { return bsLista; } }
        public int Items { get { return blLista.Count; } }


        public GestionLista()
        {
            _gestionAgregarEditar = new GestionAgregarEditar();
            lLista = new List<OOB.LibInventario.Marca.Ficha>();
            blLista = new BindingList<OOB.LibInventario.Marca.Ficha>(lLista);
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
            var r01 = Sistema.MyData.Marca_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
            }
            setLista(r01.Lista);
        }

        public void EditarItem()
        {
            var it = (OOB.LibInventario.Marca.Ficha)bsLista.Current;
            if (it != null)
            {
                _gestionAgregarEditar.Editar(it);
                if (_gestionAgregarEditar.IsAgregarEditarOk)
                {
                    CargarData();
                }
            }
        }

        public void setLista(List<OOB.LibInventario.Marca.Ficha> list)
        {
            blLista.Clear();
            foreach (var it in list.OrderBy(o => o.nombre).ToList())
            {
                blLista.Add(it);
            }
        }

    }

}