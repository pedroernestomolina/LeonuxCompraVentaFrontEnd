using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.SucursalDeposito
{
    
    public class GestionLista
    {

        private GestionAjustar _gestionAjustar;
        private List<OOB.LibSistema.Sucursal.Ficha> lLista;
        private BindingList<OOB.LibSistema.Sucursal.Ficha> blLista;
        private BindingSource bsLista;


        public BindingSource Source { get { return bsLista; } }
        public int Items { get { return blLista.Count; } }


        public GestionLista()
        {
            _gestionAjustar = new GestionAjustar();
            lLista = new List<OOB.LibSistema.Sucursal.Ficha>();
            blLista = new BindingList<OOB.LibSistema.Sucursal.Ficha>(lLista);
            bsLista = new BindingSource();
            bsLista.DataSource = blLista;
        }


        public void setLista(List<OOB.LibSistema.Sucursal.Ficha> list)
        {
            blLista.Clear();
            foreach (var it in list.OrderBy(o => o.nombre).ToList())
            {
                blLista.Add(it);
            }
        }

        public void EditarItem()
        {
            var it = (OOB.LibSistema.Sucursal.Ficha)bsLista.Current;
            if (it != null) 
            {
                _gestionAjustar.setFicha(it);
                _gestionAjustar.Inicia();
                if (_gestionAjustar.IsAjusteOk) 
                {
                    CargarData();
                }
            }
        }

        private void CargarData()
        {
            var r01 = Sistema.MyData.Sucursal_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
            }
            setLista(r01.Lista);
        }

        public void EliminarAsignacion()
        {
            var it = (OOB.LibSistema.Sucursal.Ficha)bsLista.Current;
            if (it != null)
            {
                var msg = MessageBox.Show("Estas Seguro De Quitar Esta Asignacion ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    var r01 = Sistema.MyData.Sucursal_QuitarDepositoPrincipal(it.auto);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    CargarData();
                }
            }
        }

    }

}