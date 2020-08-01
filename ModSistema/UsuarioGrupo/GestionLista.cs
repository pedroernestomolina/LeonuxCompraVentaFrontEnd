using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.UsuarioGrupo
{

    public class GestionLista
    {

        private GestionAgregarEditar _gestionAgregarEditar;
        private List<OOB.LibSistema.UsuarioGrupo.Ficha> lLista;
        private BindingList<OOB.LibSistema.UsuarioGrupo.Ficha> blLista;
        private BindingSource bsLista;


        public BindingSource Source { get { return bsLista; } }
        public int Items { get { return blLista.Count; } }


        public GestionLista()
        {
            _gestionAgregarEditar = new GestionAgregarEditar();
            lLista = new List<OOB.LibSistema.UsuarioGrupo.Ficha>();
            blLista = new BindingList<OOB.LibSistema.UsuarioGrupo.Ficha>(lLista);
            bsLista = new BindingSource();
            bsLista.DataSource = blLista;
        }


        public void setLista(List<OOB.LibSistema.UsuarioGrupo.Ficha> lista)
        {
            blLista.Clear();
            foreach (var it in lista.OrderBy(o => o.nombre).ToList())
            {
                blLista.Add(it);
            }
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
            var r01 = Sistema.MyData.UsuarioGrupo_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
            }
            setLista(r01.Lista);
        }

        public void EditarItem()
        {
            var it = (OOB.LibSistema.UsuarioGrupo.Ficha)bsLista.Current;
            if (it != null)
            {
                _gestionAgregarEditar.Editar(it);
                if (_gestionAgregarEditar.IsAgregarEditarOk)
                {
                    CargarData();
                }
            }
        }

    }

}