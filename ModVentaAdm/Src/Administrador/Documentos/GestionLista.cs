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
        private Helpers.Imprimir.IDocumento _gestionVisualizarDoc;


        public BindingSource ItemsSource { get { return _bs; } }
        public string ItemsEncontrados { get { return "Items Encontrados: "+_bl.Count.ToString("n0").Trim(); } }


        public GestionLista()
        {
            _list = new List<data>();
            _bl = new BindingList<data>(_list);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
            _gestionVisualizarDoc = new Helpers.Imprimir.Grafico.Documento();
        }


        public void AnularItem()
        {
        }

        public void LimpiarData()
        {
            if (_bl.Count > 0)
            {
                var msg = MessageBox.Show("Desechar Vista Actual ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    _bl.Clear();
                    _bs.CurrencyManager.Refresh();
                }
            }
        }

        public void VisualizarDocumento()
        {
            if (_bs.Current != null)
            {
                var it = (data)_bs.Current;
                var r01 = Helpers.Imprimir.Documento.CargarDataDocumento(it.idDocumento);
                if (r01 != null) 
                {
                    _gestionVisualizarDoc.setData(r01);
                    _gestionVisualizarDoc.ImprimirDoc();
                }
            }
        }

        public void Imprimir()
        {
        }

        public void CorrectorDocumento()
        {
        }

        public void setLista(List<OOB.Documento.Lista.Ficha> list)
        {
            _bl.Clear();
            foreach (var doc in list.OrderByDescending(o=>o.FechaEmision).ThenByDescending(o=>o.DocNombre).ThenByDescending(o=>o.DocNumero).ToList())
            {
                _bl.Add(new data(doc));
            }
        }

    }

}