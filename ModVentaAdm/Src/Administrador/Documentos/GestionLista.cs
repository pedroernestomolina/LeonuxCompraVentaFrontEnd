using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Administrador.Documentos
{
    
    public class GestionLista: IGestionListaDetalle
    {


        private List<data> _list;
        private BindingList<data> _bl;
        private BindingSource _bs;


        public BindingSource ItemsSource { get { return _bs; } }
        public string ItemsEncontrados { get { return "Items Encontrados: "+_bl.Count.ToString("n0").Trim(); } }


        public GestionLista()
        {
            _list = new List<data>();
            _bl = new BindingList<data>(_list);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void AnularItem()
        {
        }

        public void LimpiarData()
        {
        }

        public void VisualizarDocumento()
        {
        }

        public void Imprimir()
        {
        }

        public void CorrectorDocumento()
        {
        }

    }

}