using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Factura
{
    
    public class GestionItemFac:Controlador.IGestionItem
    {


        private List<dataItem> ldata;
        private BindingList<dataItem> bl;
        private BindingSource bs;
        private GestionAgregarItem gestionAgregarItem;


        public BindingSource ItemSource { get { return bs; } }
        public int TItems { get { return bs.Count; } }
        public decimal TotalMonto { get { return bl.Sum(m => m.total); } }
        public decimal MontoIva { get { return bl.Sum(m => m.impuesto); } }
        public decimal MontoDivisa { get { return bl.Sum(m => m.totalDivisa); } }


        public GestionItemFac()
        {
            ldata = new List<dataItem>();
            bl = new BindingList<dataItem>(ldata);
            bs = new BindingSource();
            bs.DataSource = bl;
            gestionAgregarItem = new GestionAgregarItem();
        }


        public void LimpiarItems()
        {
            if (bl.Count > 0)
            {
                var ms = MessageBox.Show("Estas Seguro De Querer Limpiar Los Items Registrados ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (ms == DialogResult.Yes)
                {
                    bl.Clear();
                    bs.CurrencyManager.Refresh();
                }
            }
        }

        public void EliminarItem()
        {
            if (bs.Current != null) 
            {
                var it = (dataItem)bs.Current;
                var ms = MessageBox.Show("Estas Seguro De Querer Eliminar Este Item ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (ms == DialogResult.Yes)
                {
                    bl.Remove(it);
                    bs.CurrencyManager.Refresh();
                }
            }
        }

        public void EditarItem()
        {
            if (bs.Current != null)
            {
                var it = (dataItem) bs.Current;
                gestionAgregarItem.Editar(it);
            }
        }

        public void AgregarItem(string autoPrd, string autoPrv, decimal factorDivisa)
        {
            gestionAgregarItem.NuevoItem();
            gestionAgregarItem.setAutoProveedor(autoPrv);
            gestionAgregarItem.setFactorDivisa(factorDivisa);
            gestionAgregarItem.setAutoPrd(autoPrd);
            gestionAgregarItem.Inicia();
            if (gestionAgregarItem.RegistroOk)
            {
                InsertarItem(gestionAgregarItem.Item);
            }
        }

        private void InsertarItem(dataItem item)
        {
            bl.Add(item);
            bs.CurrencyManager.Refresh();
        }

    }

}