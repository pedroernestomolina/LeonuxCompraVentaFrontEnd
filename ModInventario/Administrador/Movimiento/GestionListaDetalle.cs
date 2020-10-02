using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;


namespace ModInventario.Administrador.Movimiento
{
    
    public class GestionListaDetalle: IGestionListaDetalle
    {

        private List<data> list;
        private BindingSource bs;
        private BindingList<data> bl;


        public BindingSource Source { get { return bs; } }
        public string Items { get { return string.Format("Items Encontrados: {0}", bs.Count); } }
        public data Item { get; set; }


        public GestionListaDetalle()
        {
            list = new List<data>();
            bl = new BindingList<data>(list);
            bs = new BindingSource();
            bs.CurrentChanged+=bs_CurrentChanged;
            bs.DataSource = bl;
        }

        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            if (bs.Current != null)
                Item = (data)bs.Current;
        }

        public void setLista(List<OOB.LibInventario.Movimiento.Lista.Ficha> list)
        {
            bl.Clear();
            foreach (var rg in list)
            {
                bl.Add(new data(rg));
            }
        }

        public void LimpiarData()
        {
            var msg = MessageBox.Show("Desechar Vista Actual ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                bl.Clear();
            }
        }

        public void AnularItem()
        {
            if (Item != null)
            {
                if (!Item.IsAnulado)
                {
                    var msg = MessageBox.Show("Anular Movimiento Actual ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msg == DialogResult.Yes)
                    {
                    }
                }
                else
                    Helpers.Msg.Error("Documento Ya Está Anulado, Verifique Por Favor");
            }
        }

    }

}