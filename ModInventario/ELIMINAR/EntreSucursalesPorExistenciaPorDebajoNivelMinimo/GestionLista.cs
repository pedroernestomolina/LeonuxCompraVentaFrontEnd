using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Movimiento.Traslado.EntreSucursalesPorExistenciaPorDebajoNivelMinimo
{
    
    public class GestionLista
    {

        private BindingList<Item> blItem;
        private BindingSource bs;
        private List<Item> items;


        public BindingSource _bs { get { return bs; } }
        public List<Item> Items { get { return items; } }
        public int Renglones { get { return items.Count(); }}
        public decimal Total { get { return items.Sum(s=>s.Importe); }}


        public GestionLista()
        {
            items = new List<Item>();
            blItem = new BindingList<Item>(items);
            bs = new BindingSource();
            bs.CurrentChanged += bs_CurrentChanged;
            bs.DataSource = blItem;
        }


        private void bs_CurrentChanged(object sender, EventArgs e)
        {
        }

        public void setItems(List<OOB.LibInventario.Movimiento.Traslado.Consultar.ProductoPorDebajoNivelMinimo> list) 
        {
            blItem.Clear();
            foreach (var i in list.OrderBy(o=>o.nombreProducto).ToList()) 
            {
                var nr = new Item()
                {
                    ficha = i,
                };
                blItem.Add(nr);
            }
        }

        public void Inicializar()
        {
            items.Clear();
            blItem.Clear();
        }

    }

}