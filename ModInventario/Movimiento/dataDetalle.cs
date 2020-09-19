using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Movimiento
{
    
    public class dataDetalle
    {

        private List<item> lstItems;


        public List<item> ListaItems { get { return lstItems; } }
        public decimal MontoMovimiento { get { return ListaItems.Sum(s => s.ImporteMonedaLocal); } }



        public dataDetalle()
        {
            lstItems = new List<item>();
        }


        public void Limpiar()
        {
            lstItems.Clear();
        }

        public void Agregar(OOB.LibInventario.Producto.Data.Ficha ficha, decimal cnt, decimal costo, enumerados.enumTipoEmpaque emp,
            decimal tasaCambio, decimal importe, decimal importeMonedaLocal)
        {
            lstItems.Add(new item(ficha,cnt,costo, emp, tasaCambio, importe, importeMonedaLocal));
        }
        public void Remover(item it)
        {
            lstItems.Remove(it);
        }

    }

}