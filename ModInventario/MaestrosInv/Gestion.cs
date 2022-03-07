using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MaestrosInv
{

    public class Gestion: IMaestro
    {

        private IMaestroTipo _gestion;
        private ILista _gLista;


        public string Titulo { get { return _gestion.Titulo; } }
        public int CntItems { get { return _gLista.CntItems; } }
        public BindingSource Source { get { return _gLista.Source; } }
        public data ItemActual { get { return _gLista.ItemActual; } }
        public bool AgregarIsOk { get { return _gestion.AgregarIsOk; } }
        public bool EliminarIsOk { get { return _gestion.EliminarIsOk; } }
        public bool EditarIsOk { get { return _gestion.EditarIsOk; } }


        public Gestion(ILista ctrLista)
        {
            _gLista = ctrLista;
        }


        public void Inicializa()
        {
            _gLista.Inicializa();
        }

        MaestroFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new MaestroFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public bool CargarData()
        {
            if (_gestion.CargarData())
            {
                _gLista.setLista(_gestion.ListData);
            }
            return true;
        }

        public void setGestion(IMaestroTipo ctr)
        {
            _gestion = ctr;
        }

        public void AgregarItem()
        {
            _gestion.AgregarItem();
            if (_gestion.AgregarIsOk)
            {
                _gLista.Agregar(_gestion.ItemAgregarEditar);
            }
        }

        public void EditarItem()
        {
            if (ItemActual != null)
            {
                _gestion.EditarItem(ItemActual);
                if (_gestion.EditarIsOk)
                {
                    _gLista.Actualizar(_gestion.ItemAgregarEditar);
                }
            }
        }

        public void EliminarItem()
        {
            if (ItemActual != null)
            {
                _gestion.EliminarItem(ItemActual);
                if (_gestion.EliminarIsOk)
                {
                    _gLista.EliminarItemActual();
                }
            }
        }

    }

}