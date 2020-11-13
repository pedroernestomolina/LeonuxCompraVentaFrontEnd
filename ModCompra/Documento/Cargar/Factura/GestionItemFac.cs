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


        public BindingSource ItemSource { get { return bs; } }
        public int TItems { get { return bs.Count; } }
        public decimal TotalMonto { get { return 0.0m; } }
        public decimal MontoIva { get { return 0.0m; } }
        public decimal MontoDivisa { get { return 0.0m; } }


        public GestionItemFac()
        {
            ldata = new List<dataItem>();
            bl = new BindingList<dataItem>(ldata);
            bs = new BindingSource();
            bs.DataSource = bl;
        }


        public void LimpiarItems()
        {
            Helpers.Msg.Alerta("PRONTO");
        }

        public void EliminarItem()
        {
            Helpers.Msg.Alerta("PRONTO");
        }

        public void EditarItem()
        {
            Helpers.Msg.Alerta("PRONTO");
        }

    }

}