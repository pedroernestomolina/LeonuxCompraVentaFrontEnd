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

        public event EventHandler ActualizarItemHnd;


        private IGestionItem _gestion;


        public BindingSource ItemSource { get { return _gestion.ItemSource; } }
        public int TItems { get { return _gestion.TItems; } }
        public decimal TotalMonto { get { return _gestion.TotalMonto; } }
        public decimal MontoIva { get { return _gestion.MontoIva; } }
        public decimal MontoDivisa { get { return _gestion.MontoDivisa; } }
        public string Item_Producto { get { return _gestion.Item_Producto; } }
        public decimal Item_Importe { get { return _gestion.Item_Importe; } }
        public decimal Item_Impuesto { get { return _gestion.Item_Impuesto; } }
        public decimal Item_Total { get { return _gestion.Item_Total; } }
        public decimal Item_Cantidad { get { return _gestion.Item_Cantidad; } }
        public decimal Item_CantidadUnd { get { return _gestion.Item_CantidadUnd; } }
        public decimal Item_CostoMoneda { get { return _gestion.Item_CostoMoneda; } }
        public decimal Item_CostoMonedaUnd { get { return _gestion.Item_CostoMonedaUnd; } }
        public decimal Item_CostoDivisa { get { return _gestion.Item_CostoDivisa; } }
        public decimal Item_CostoDivisaUnd { get { return _gestion.Item_CostoDivisaUnd; } }
        public string Item_EmpaqueCont { get { return _gestion.Item_EmpaqueCont; } }
        public string Item_CodRefPrv { get { return _gestion.Item_CodRefPrv; } }
        public decimal Item_Dscto { get { return _gestion.Item_Dscto; } }


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

        public void AgregarItem(string autoPrd, string autoPrv, decimal factorDivisa)
        {
            _gestion.AgregarItem(autoPrd, autoPrv, factorDivisa);
        }

        public void Limpiar()
        {
            _gestion.Limpiar();
        }

    }

}