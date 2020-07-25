using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.SucursalGrupo
{
    
    public class GestionLista
    {

        private GestionAgregarEditar _gestionAgregarEditar;
        private List<OOB.LibSistema.SucursalGrupo.Ficha> lGrupo;
        private BindingList<OOB.LibSistema.SucursalGrupo.Ficha> blGrupo;
        private BindingSource bsGrupo;


        public BindingSource Source { get { return bsGrupo; } }
        public int Items { get { return blGrupo.Count; } }


        public GestionLista()
        {
            _gestionAgregarEditar = new GestionAgregarEditar();
            lGrupo = new List<OOB.LibSistema.SucursalGrupo.Ficha>();
            blGrupo = new BindingList<OOB.LibSistema.SucursalGrupo.Ficha>(lGrupo);
            bsGrupo = new BindingSource();
            bsGrupo.DataSource = blGrupo;
        }


        public void setLista(List<OOB.LibSistema.SucursalGrupo.Ficha> lista) 
        {
            blGrupo.Clear();
            foreach (var it in lista.OrderBy(o=>o.nombre).ToList())
            {
                blGrupo.Add(it);
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
            var r01 = Sistema.MyData.SucursalGrupo_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
            }
            setLista(r01.Lista);
        }

        public void EditarItem()
        {
            var it = (OOB.LibSistema.SucursalGrupo.Ficha) bsGrupo.Current;
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