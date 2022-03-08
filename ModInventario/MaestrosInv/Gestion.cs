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

        private ILista _gLista;


        public string Titulo { get { return ""; } }
        public int CntItems { get { return _gLista.CntItems; } }
        public BindingSource Source { get { return _gLista.Source; } }


        public Gestion(ILista ctrLista) 
        {
            _gLista = ctrLista;
        }


        public void setGestion(IMaestroTipo _gMtDepart)
        {
        }

        public void Inicializa()
        {
        }

        public void Inicia()
        {
        }


        public bool CargarData()
        {
            return true;
        }

        public void AgregarItem()
        {
        }

        public void EditarItem()
        {
        }

    }

}