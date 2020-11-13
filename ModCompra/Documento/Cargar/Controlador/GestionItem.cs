using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public class GestionItem: IGestionItem
    {


        private IGestionItem _gestion;


        public BindingSource ItemSource { get; set; }
        public int TItems { get { return _gestion.TItems; } }
        public decimal TotalMonto { get { return _gestion.TotalMonto; } }
        public decimal MontoIva { get { return _gestion.MontoIva; } }
        public decimal MontoDivisa { get { return _gestion.MontoDivisa; } }


        public void setGestion(IGestionItem gestion)
        {
            _gestion = gestion;
        }

        public void LimpiarItems()
        {
            _gestion.LimpiarItems();
        }

        public void EliminarItem()
        {
            _gestion.EliminarItem();
        }

        public void EditarItem()
        {
            _gestion.EditarItem();
        }

    }

}